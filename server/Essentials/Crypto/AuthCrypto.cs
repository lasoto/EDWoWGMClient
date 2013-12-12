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
using HMACSHA1 = System.Security.Cryptography.HMACSHA1;

namespace Essentials
{
    public enum AuthStatus
    {
        Uninitialized,
        Pending,
        Ready
    }

    public class AuthenticationCrypto
    {
        private static readonly byte[] encryptionKey = new byte[]
        {
            0xC2, 0xB3, 0x72, 0x3C, 0xC6, 0xAE, 0xD9, 0xB5,
            0x34, 0x3C, 0x53, 0xEE, 0x2F, 0x43, 0x67, 0xCE
        };
        private static readonly byte[] decryptionKey = new byte[]
        {
            0xCC, 0x98, 0xAE, 0x04, 0xE8, 0x97, 0xEA, 0xCA,
            0x12, 0xDD, 0xC0, 0x93, 0x42, 0x91, 0x53, 0x57
        };

        static readonly HMACSHA1 outputHMAC = new HMACSHA1(encryptionKey);
        static readonly HMACSHA1 inputHMAC = new HMACSHA1(decryptionKey);

        static ARC4 encryptionStream;
        static ARC4 decryptionStream;

        public static AuthStatus Status
        {
            get;
            private set;
        }

        public AuthenticationCrypto()
        {
            Status = AuthStatus.Uninitialized;
        }

        [Obsolete("NYI", true)]
        public static void Pending()
        {
            Status = AuthStatus.Pending;
        }

        public static void Initialize(byte[] sessionKey)
        {
            // create RC4-drop[1024] stream
            encryptionStream = new ARC4(outputHMAC.ComputeHash(sessionKey));
            encryptionStream.Process(new byte[1024], 0, 1024);

            // create RC4-drop[1024] stream
            decryptionStream = new ARC4(inputHMAC.ComputeHash(sessionKey));
            decryptionStream.Process(new byte[1024], 0, 1024);

            Status = AuthStatus.Ready;
        }

        public static void Decrypt(byte[] data, int start, int count)
        {
            if (Status == AuthStatus.Ready)
                decryptionStream.Process(data, start, count);
        }

        public static void Encrypt(byte[] data, int start, int count)
        {
            if (Status == AuthStatus.Ready)
                encryptionStream.Process(data, start, count);
        }
    }
}
