/*
          _______ _____  _______ _______ _______ 
         |    ___|     \|    ___|   |   |   |   |
         |    ___|  --  |    ___|       |   |   |
         |_______|_____/|_______|__|_|__|_______| 
     Copyright (C) 2013 EmuDevs <http://www.emudevs.com/>
 
  This program is free software; you can redistribute it and/or modify it
  under the terms of the GNU General Public License as published by the
  Free Software Foundation; either version 2 of the License, or (at your
  option) any later version.
 
  This program is distributed in the hope that it will be useful, but WITHOUT
  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
  more details.
 
  You should have received a copy of the GNU General Public License along
  with this program. If not, see <http://www.gnu.org/licenses/>.
 
    FURTHER CREDITS:
      TrinityCore
      MangosClient
*/

using System;
using System.Numerics;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;

using Essentials;

namespace GMHelper
{
    public delegate void PacketHandler(PacketReader packet);

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public sealed class PacketHandlerAttribute : Attribute
    {
        public Opcodes Opcode { get; private set; }

        public PacketHandlerAttribute(Opcodes _opcode)
        {
            Opcode = _opcode;
        }
    }

    public partial class WorldServer
    {
        #region Client
        /// <summary>
        /// Handles the Client connection, data, etc
        /// </summary>
        TcpClient tcpClient;
        /// <summary>
        /// Player accesses the Character class
        /// </summary>
        public Character Player;

        public BigInteger SessionKey { get; private set; }
        public string username { get; private set; }
        #endregion

        #region Server
        /// <summary>
        /// Player Chat Name List
        /// Handled in QueryHandler and ChatHandler
        /// </summary>
        public List<PlayerName> PlayerNameList = new List<PlayerName>();
        public string InfoMessage;
        public string WarningMessage;
        public string ErrorMessage;
        #endregion

        #region RealmList
        RealmList realm;
        #endregion

        #region Data
        byte[] Buffer;
        int index = 0;
        int remaining = 0;

        private long transferred;
        private long sent;
        private long received;

        public long Transferred
        {
            get { return transferred; }
        }

        public long Sent
        {
            get { return sent; }
        }

        public long Received
        {
            get { return received; }
        }
        #endregion

        /// <summary>
        /// Handles incoming Opcodes
        /// </summary>
        Dictionary<Opcodes, PacketHandler> PacketHandlers = new Dictionary<Opcodes, PacketHandler>();

        public WorldServer(string _username)
        {
            username = _username;
        }
        /// <summary>
        /// Registers SMSG Opcodes
        /// </summary>
        /// <param name="obj"></param>
        void RegisterHandler(object obj)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            IEnumerable<PacketHandlerAttribute> attributes;
            foreach (var method in obj.GetType().GetMethods(flags))
            {
                if (!method.TryGetAttributes(false, out attributes))
                    continue;

                PacketHandler handler = (PacketHandler)PacketHandler.CreateDelegate(typeof(PacketHandler), obj, method);

                foreach (var attribute in attributes)
                    PacketHandlers[attribute.Opcode] = handler;
            }
        }
        /// <summary>
        /// Connects to the specified Realmlist
        /// </summary>
        /// <param name="_realm"></param>
        public void ConnectToRealm(RealmList _realm)
        {
            SessionKey = Logon.SessionKey;
            realm = _realm;

            RegisterHandler(this);

            if (Connect())
            {
                InfoMessage = "Successfully connected to the WorldServer";
                Start();
            }
        }
        /// <summary>
        /// Tries to connect to the WorldServer
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                tcpClient = new TcpClient(ConfigOptions.Host, ConfigOptions.WorldPort);

                if (DatabaseGlobals.CharacterDB.Initialize(ConfigOptions.CharDBHost, ConfigOptions.CharDBUser, ConfigOptions.CharDBPass, ConfigOptions.CharDBName, ConfigOptions.MySQLPort, true, 5, 150))
                    InfoMessage = "Successfully connected to the database...";
                else
                    ErrorMessage = "Could not connect to the database. Retrying in 5 seconds..";

                return true;
            }
            catch (SocketException ex)
            {
                ErrorMessage = "Could not connect to the WorldServer: " + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Disconnects and disposes of the client
        /// </summary>
        public void Disconnect()
        {
            if (IsClientConnected())
            {
                tcpClient.Client.Close();
                tcpClient.Client.Dispose();
                tcpClient = null;
                Manager.m_WorldServer = null;
            }
        }
        /// <summary>
        /// Checks if the Client is connected
        /// </summary>
        /// <returns></returns>
        public bool IsClientConnected()
        {
            if (tcpClient != null && tcpClient.Client != null && tcpClient.Client.Connected)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Start receiving incoming bytes
        /// </summary>
        private void Start()
        {
            Buffer = new byte[4];
            index = 0;
            remaining = 1;
            tcpClient.Client.BeginReceive(Buffer, index, remaining, SocketFlags.None, new AsyncCallback(Receive), null);
        }
        /// <summary>
        /// Handles incoming Opcodes
        /// </summary>
        /// <param name="packet"></param>
        private void HandleIncoming(PacketReader packet)
        {
            PacketHandler handler;
            if (PacketHandlers.TryGetValue((Opcodes)packet.Header.Opcode, out handler))
            {
                if (AuthenticationCrypto.Status == AuthStatus.Ready)
                    handler.BeginInvoke(packet, r => handler.EndInvoke(r), null);
                else
                    handler(packet);
            }
        }

        private void Receive(IAsyncResult ar)
        {
            if (IsClientConnected())
            {
                int bytesReceived = tcpClient.Client.EndReceive(ar);
                if (bytesReceived != 0)
                {
                    Interlocked.Increment(ref transferred);
                    Interlocked.Increment(ref received);

                    AuthenticationCrypto.Decrypt(Buffer, 0, 1);
                    if ((Buffer[0] & 0x80) != 0)
                    {
                        byte temp = Buffer[0];
                        Buffer = new byte[5];
                        Buffer[0] = (byte)((0x7f & temp));

                        remaining = 4;
                    }
                    else
                        remaining = 3;

                    index = 1;
                    tcpClient.Client.BeginReceive(Buffer, index, remaining, SocketFlags.None, new AsyncCallback(ReceiveHeader), null);
                }
            }
        }

        private void ReceiveHeader(IAsyncResult ar)
        {
            if (IsClientConnected())
            {
                int bytesReceived = tcpClient.Client.EndReceive(ar);
                if (bytesReceived != 0)
                {
                    Interlocked.Add(ref transferred, bytesReceived);
                    Interlocked.Add(ref received, bytesReceived);

                    if (bytesReceived == remaining)
                    {
                        AuthenticationCrypto.Decrypt(Buffer, 1, Buffer.Length - 1);
                        ServerHeader header = new ServerHeader(Buffer);

                        if (header.Size > 0)
                        {
                            index = 0;
                            remaining = header.Size;
                            Buffer = new byte[header.Size];
                            tcpClient.Client.BeginReceive(Buffer, index, remaining, SocketFlags.None, new AsyncCallback(ReceivePayload), header);
                        }
                        else
                        {
                            HandleIncoming(new PacketReader(header));
                            Start();
                        }
                    }
                    else
                    {
                        index += bytesReceived;
                        remaining -= bytesReceived;
                        tcpClient.Client.BeginReceive(Buffer, index, remaining, SocketFlags.None, new AsyncCallback(ReceiveHeader), null);
                    }
                }
            }
        }

        private void ReceivePayload(IAsyncResult ar)
        {
            if (IsClientConnected())
            {
                int bytesReceived = tcpClient.Client.EndReceive(ar);
                if (bytesReceived != 0)
                {
                    Interlocked.Add(ref transferred, bytesReceived);
                    Interlocked.Add(ref received, bytesReceived);

                    if (bytesReceived == remaining)
                    {
                        ServerHeader header = (ServerHeader)ar.AsyncState;
                        PacketReader packet = new PacketReader(header, Buffer);
                        HandleIncoming(packet);

                        Start();
                    }
                    else
                    {
                        index += bytesReceived;
                        remaining -= bytesReceived;
                        tcpClient.Client.BeginReceive(Buffer, index, remaining, SocketFlags.None, new AsyncCallback(ReceivePayload), ar.AsyncState);
                    }
                }
            }
        }

        private object SendLock = new object();
        /// <summary>
        /// Sends Opcode & data to the server
        /// </summary>
        /// <param name="writer"></param>
        public void Send(PacketWriter writer)
        {
            byte[] data = writer.FinalizePacket();
            lock (SendLock)
                tcpClient.Client.Send(data);

            Interlocked.Add(ref transferred, data.Length);
            Interlocked.Add(ref sent, data.Length);
        }
    }
}
