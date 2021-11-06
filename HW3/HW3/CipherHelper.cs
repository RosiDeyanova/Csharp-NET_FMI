using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class CipherHelper
    {
        private int rows;
        private char[,] grid;

        public int Row { get; set; }
        public char[,] Grid 
        {
            get { return grid; }
            set {  }
        }

        public char[,] CreateGrid(int rows, int cols) 
        {
            var num = Math.Abs(cols);
            var grid = new char[rows][num];
        }

    }
}
