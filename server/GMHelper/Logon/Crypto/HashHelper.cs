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
using System.IO;
using System.Collections.Generic;

namespace GMHelper
{
    using CryptoNS = System.Security.Cryptography;
    using HashAlgo = System.Security.Cryptography.HashAlgorithm;

    enum HashAlgorithm
    {
        SHA1,
    }

    static class HashHelper
    {
        private delegate byte[] HashFunction(params byte[][] data);

        static Dictionary<HashAlgorithm, HashFunction> HashFunctions;
        static Dictionary<HashAlgorithm, HashAlgo> HashAlgorithms;

        static HashHelper()
        {
            HashFunctions = new Dictionary<HashAlgorithm, HashFunction>();
            HashAlgorithms = new Dictionary<HashAlgorithm, HashAlgo>();

            HashFunctions[HashAlgorithm.SHA1] = SHA1;
            HashAlgorithms[HashAlgorithm.SHA1] = CryptoNS.SHA1.Create();
        }

        private static byte[] Combine(byte[][] buffers)
        {
            MemoryStream stream = new MemoryStream();

            foreach (byte[] buffer in buffers)
                stream.Write(buffer, 0, buffer.Length);

            return stream.ToArray();
        }

        public static byte[] Hash(this HashAlgorithm algorithm, params byte[][] data)
        {
            return HashFunctions[algorithm](data);
        }

        private static byte[] SHA1(params byte[][] data)
        {
            return HashAlgorithms[HashAlgorithm.SHA1].ComputeHash(Combine(data));
        }
    }
}
