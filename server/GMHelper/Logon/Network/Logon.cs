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

  FURTHER CREDITS
   MangosClient
*/
using System;
using System.Net;
using System.Text;
using System.Numerics;
using System.Net.Sockets;

using Essentials;

namespace GMHelper
{
    public class Logon
    {
        TcpClient tcpClient;
        private PacketReader packetReader;
        private PacketWriter packetWriter;
        public static RealmList selectedRealm = null;

        public static BigInteger SessionKey { get; private set; }

        private byte[] passwordHash;
        private byte[] M2;
        private byte[] Buffer;
        private string username;

        /// <summary>
        /// Tries to connect to the LogonServer
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="_username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Start(string host, int port, string _username, string password)
        {
            try
            {
                tcpClient = new TcpClient(host, port);

                packetReader = new PacketReader(tcpClient.GetStream());
                packetWriter = new PacketWriter(tcpClient.GetStream());

                username = _username;

                string hashStr = string.Format("{0}:{1}", username, password);

                passwordHash = HashAlgorithm.SHA1.Hash(Encoding.ASCII.GetBytes(hashStr.ToUpper()));

                Buffer = new byte[1];

                HandleSendChallenge();
                Manager.Initialize(_username);

                return true;
            }
            catch (SocketException ex)
            {
                Log.Error("[Error]:", "SocketException: {0}", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Disconnects the client and disposes of it
        /// </summary>
        public void Disconnect()
        {
            if (tcpClient != null && tcpClient.Client.Connected)
            {
                tcpClient.Client.Close();
                tcpClient.Client.Dispose();
                tcpClient = null;
            }
        }

        private void BeginReceive()
        {
            try
            {
                tcpClient.Client.BeginReceive(Buffer, 0, 1, SocketFlags.None, Receive, null);
            }
            catch (Exception ex)
            {
                Log.Error("[Error]:", "Could not Receive: {0}", ex.Message);
            }
        }

        protected void Receive(IAsyncResult ar)
        {
            int receivedBytes = tcpClient.Client.EndReceive(ar);

            if (receivedBytes != 0)
            {
                AuthLogonCodes cmd = (AuthLogonCodes)Buffer[0];
                switch (cmd)
                {
                    case AuthLogonCodes.AUTH_LOGON_CHALLENGE:
                        HandleSendServerChallenge(new PacketReader(tcpClient.GetStream()));
                        break;
                    case AuthLogonCodes.AUTH_LOGON_PROOF:
                        HandleReceiveServerProof(new PacketReader(tcpClient.GetStream()));
                        break;
                    case AuthLogonCodes.REALM_LIST:
                        HandleReceiveServerRealmlist(new PacketReader(tcpClient.GetStream()));
                        break;
                    default:
                        Log.Error("[Error:]", "Unknown Auth Opcode {0}", Buffer[0]);
                        break;
                }
            }
        }

        private void HandleSendChallenge()
        {
            packetWriter.Write((byte)AuthLogonCodes.AUTH_LOGON_CHALLENGE);
            packetWriter.Write((byte)6);
            packetWriter.Write((byte)(username.Length + 30));
            packetWriter.Write((byte)0);
            packetWriter.Write("WoW".ToCString());
            packetWriter.Write(new byte[] { 3, 3, 5 });
            packetWriter.Write((ushort)12340);
            packetWriter.Write("68x".ToCString());
            packetWriter.Write("niW".ToCString());
            packetWriter.Write(Encoding.ASCII.GetBytes("SUne"));
            packetWriter.Write((uint)0x3c);
            packetWriter.Write((uint)BitConverter.ToUInt32((tcpClient.Client.LocalEndPoint as IPEndPoint).Address.GetAddressBytes(), 0));
            packetWriter.Write((byte)username.Length);
            packetWriter.Write(Encoding.ASCII.GetBytes(username));
            BeginReceive();
        }

        #region HandleSendServerChallenge
        private void HandleSendServerChallenge(PacketReader reader)
        {
            Log.Notify("[Logon]:", "HandleSendServerChallenge", true);
            byte unk2 = reader.ReadByte();
            AuthResult errorResult = (AuthResult)reader.ReadByte();
            if (errorResult != AuthResult.WOW_SUCCESS)
            {
                Log.Error("[Error]:", "Failed: {0}", errorResult);
                return;
            }

            byte[] B = reader.ReadBytes(32);
            byte gLength = reader.ReadByte();
            byte[] g = reader.ReadBytes(1);
            byte nLength = reader.ReadByte();
            byte[] N = reader.ReadBytes(32);
            byte[] salt = reader.ReadBytes(32);
            byte[] unk3 = reader.ReadBytes(16);
            byte securityFlags = reader.ReadByte();

            switch (errorResult)
            {
                case AuthResult.WOW_SUCCESS:
                    Log.Notify("[Logon]:", "Successfully received challenge..", true);

                    BigInteger _N, A, _B, a, u, x, S, _salt, unk1, _g, k;

                    _B = B.ToBigInteger();
                    _g = g.ToBigInteger();
                    _N = N.ToBigInteger();
                    _salt = salt.ToBigInteger();
                    unk1 = unk3.ToBigInteger();

                    x = HashAlgorithm.SHA1.Hash(salt, passwordHash).ToBigInteger();

                    var rand = System.Security.Cryptography.RandomNumberGenerator.Create();

                    do
                    {
                        byte[] randBytes = new byte[19];
                        rand.GetBytes(randBytes);
                        a = randBytes.ToBigInteger();

                        A = _g.ModPow(a, _N);
                    } while (A.ModPow(1, _N) == 0);

                    u = HashAlgorithm.SHA1.Hash(A.ToCleanByteArray(), _B.ToCleanByteArray()).ToBigInteger();

                    k = new BigInteger(3);
                    S = (_B - k * _g.ModPow(x, _N)).ModPow(a + u * x, _N);

                    byte[] keyHash;
                    byte[] sData = S.ToCleanByteArray();
                    byte[] keyData = new byte[40];
                    byte[] temp = new byte[16];

                    // take every even indices byte, hash, store in even indices
                    for (int i = 0; i < 16; ++i)
                        temp[i] = sData[i * 2];
                    keyHash = HashAlgorithm.SHA1.Hash(temp);
                    for (int i = 0; i < 20; ++i)
                        keyData[i * 2] = keyHash[i];

                    // do the same for odd indices
                    for (int i = 0; i < 16; ++i)
                        temp[i] = sData[i * 2 + 1];
                    keyHash = HashAlgorithm.SHA1.Hash(temp);
                    for (int i = 0; i < 20; ++i)
                        keyData[i * 2 + 1] = keyHash[i];

                    SessionKey = keyData.ToBigInteger();

                    // XOR the hashes of N and g together
                    byte[] gNHash = new byte[20];

                    byte[] nHash = HashAlgorithm.SHA1.Hash(_N.ToCleanByteArray());
                    for (int i = 0; i < 20; ++i)
                        gNHash[i] = nHash[i];

                    byte[] gHash = HashAlgorithm.SHA1.Hash(_g.ToCleanByteArray());
                    for (int i = 0; i < 20; ++i)
                        gNHash[i] ^= gHash[i];

                    // hash username
                    byte[] userHash = HashAlgorithm.SHA1.Hash(Encoding.ASCII.GetBytes(username));

                    // our proof
                    byte[] m1Hash = HashAlgorithm.SHA1.Hash
                    (
                        gNHash,
                        userHash,
                        salt,
                        A.ToCleanByteArray(),
                        _B.ToCleanByteArray(),
                        SessionKey.ToCleanByteArray()
                    );

                    M2 = HashAlgorithm.SHA1.Hash(A.ToCleanByteArray(), m1Hash, keyData);

                    Log.Notify("[Logon]:", "Sending Auth Logon Proof", true);
                    packetWriter.Write((byte)AuthLogonCodes.AUTH_LOGON_PROOF);
                    packetWriter.Write(A.ToCleanByteArray());
                    packetWriter.Write(m1Hash);
                    packetWriter.Write(new byte[20]);
                    packetWriter.Write((byte)0);
                    packetWriter.Write((byte)0);

                    BeginReceive();
                    break;
            }
        }
        #endregion

        #region HandleReceiveServerProof
        private void HandleReceiveServerProof(PacketReader reader)
        {
            Log.Notify("[Logon]:", "HandleReceiveServerProof", true);

            AuthResult errorResult = (AuthResult)reader.ReadByte();
            if (errorResult != AuthResult.WOW_SUCCESS)
            {
                reader.ReadUInt16();
                Log.Error("[Error]:", "Could not Receive Server Proof: ", errorResult);
                HandleSendChallenge();
                return;
            }

            byte[] _M2 = reader.ReadBytes(20);
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt16();

            bool isSame = true;
            isSame = _M2 != null && _M2.Length == 20;
            for (int i = 0; i < _M2.Length && isSame; ++i)
                if (!(isSame = _M2[i] == M2[i]))
                    break;

            if (isSame)
            {
                packetWriter.Write((byte)AuthLogonCodes.REALM_LIST);
                packetWriter.Write((uint)0);
                Log.Notify("[Logon]:", "Sending Realmlist", true);
            }
            else
                Log.Error("[Error]:", "Proof did not match...");
            BeginReceive();
        }
        #endregion

        #region HandleReceiveServerRealmlist
        private void HandleReceiveServerRealmlist(PacketReader reader)
        {
            Log.Notify("[Logon]:", "HandleReceiveServerRealmlist", true);
            uint size = reader.ReadUInt16();
            reader.ReadUInt32();
            int count = reader.ReadUInt16();
            RealmList[] RealmLists = new RealmList[count];
            for (int i = 0; i < count; ++i)
                RealmLists[i] = new RealmList(reader);

            if (count == 1)
            {
                Log.Notify("[Logon]:", "Realm selected: {0}", true, RealmLists[0].Name);
                selectedRealm = RealmLists[0];
            }

            Manager.m_WorldServer.ConnectToRealm(selectedRealm);
        }
        #endregion
    }
}
