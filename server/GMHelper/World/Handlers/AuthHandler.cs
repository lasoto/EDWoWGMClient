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

*/
using System;
using System.Numerics;
using System.Text;

using Essentials;

namespace GMHelper
{
    public partial class WorldServer
    {
        [PacketHandler(Opcodes.ServerAuthChallenge)]
        void HandleServerAuthChallenge(PacketReader reader)
        {
            uint one = reader.ReadUInt32();
            uint seed = reader.ReadUInt32();

            BigInteger seed1 = reader.ReadBytes(16).ToBigInteger();
            BigInteger seed2 = reader.ReadBytes(16).ToBigInteger();

            var rand = System.Security.Cryptography.RandomNumberGenerator.Create();
            byte[] bytes = new byte[4];
            rand.GetBytes(bytes);

            BigInteger _seed = bytes.ToBigInteger();

            uint zero = 0;

            byte[] response = HashAlgorithm.SHA1.Hash(Encoding.ASCII.GetBytes(Manager.m_WorldServer.username.ToUpper()),
                BitConverter.GetBytes(zero),
                BitConverter.GetBytes((uint)_seed),
                BitConverter.GetBytes(seed),
                Manager.m_WorldServer.SessionKey.ToCleanByteArray());

            PacketWriter writer = new PacketWriter(Opcodes.ClientAuthSession);
            writer.Write((uint)12340);
            writer.Write(zero);
            writer.Write(Manager.m_WorldServer.username.ToUpper().ToCString());
            writer.Write(zero);
            writer.Write((uint)_seed);
            writer.Write(zero);
            writer.Write(zero);
            writer.Write(zero);
            writer.Write((ulong)zero);
            writer.Write(response);
            writer.Write(zero);

            Send(writer);

            AuthenticationCrypto.Initialize(Manager.m_WorldServer.SessionKey.ToCleanByteArray());
        }

        [PacketHandler(Opcodes.ServerAuthResponse)]
        void HandleServerAuthResponse(PacketReader reader)
        {
            byte detail = reader.ReadByte();
            uint billingTimeRemaining = reader.ReadUInt32();
            byte billingFlags = reader.ReadByte();
            uint billingTimeRested = reader.ReadByte();
            byte expansion = reader.ReadByte();

            if (detail == 0x0C)
            {
                PacketWriter writer = new PacketWriter(Opcodes.ClientEnumerateCharacters);
                Send(writer);
            }
            else
                ErrorMessage = "Could not respond to ServerAuthResponse";
        }
    }
}
