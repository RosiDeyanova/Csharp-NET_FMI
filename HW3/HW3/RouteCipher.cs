using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class RouteCipher : CipherHelper
    {
        private int key;

        public RouteCipher(int key)
        {
            Key = key;
            Row = 1;
            Grid = 
        }

        public int Key { get; set; }

        public string Encrypt(string plainText) { }

        public string Decrypt(string cipherText) { }

        public override string ToString()
        {
            return ;
        }
    }
}
