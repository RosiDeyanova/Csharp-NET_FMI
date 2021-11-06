using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class RouteCipher
    {
        #region Constructors
        public RouteCipher(int key)
        {
            this.key = key;
        }
        #endregion

        #region Variables
        private int key;
        private char[,] grid;
        private int rows;
        #endregion

        #region Properties
        public int Key
        {
            get { return key; }
            set { key = value == 0 ? 1 : value; }
        }
        #endregion

        #region Methods
        private void fillGridForEncryption(String str)
        {
            var cols = Math.Abs(this.Key);
            rows = ((int)Math.Ceiling((double)str.Length / cols));
            int pos = 0;
            char[] cipherTextChars = str.ToCharArray();
            this.grid = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (pos < str.Length)
                    {
                        grid[i, j] = cipherTextChars[pos];
                        pos++;
                    }
                    else
                    {
                        grid[i, j] = 'X';
                    }
                }
            }
        }

        private void positiveKeyLeftPartHandler(char[] message, int messageIterator, int x1, int y1, int x2, int y2, char mode)
        {
            for (int i = x1; i <= x2; i++)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[i, y1]; //Fill the char array with the chars from the left columns
                }
                else
                {
                    grid[i, y1] = message[messageIterator++]; //Fill the left columns of the grid with the chars from the array
                }
            }
            for (int i = y1 + 1; i < y2; i++)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[x2, i];//Fill the char array with the chars from the bottom rows
                }
                else
                {
                    grid[x2, i] = message[messageIterator++];//Fill the bottom rows of the grid with the chars from the array
                }
            }
            if (y1 != y2)
            {
                positiveKeyRightPartHandler(message, messageIterator, x1, y1, x2, y2, mode); // Call the recursive function dealing with the right part of the grid
            }
        }


        private void positiveKeyRightPartHandler(char[] message, int messageIterator, int x1, int y1, int x2, int y2, char mode)
        {
            for (int i = x2; i > x1; i--)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[i, y2]; //Fill the char array with the chars from the right columns
                }
                else
                {
                    grid[i, y2] = message[messageIterator++];//Fill the grid with the chars from the char array
                }
            }
            for (int i = y2; i > y1; i--)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[x1, i];//Fill the char array with the chars from the top rows
                }
                else
                {
                    grid[x1, i] = message[messageIterator++];//Fill the top rows with the chars from the char array
                }
            }
            if (y1 != y2)
            {
                positiveKeyLeftPartHandler(message, messageIterator, ++x1, ++y1, --x2, --y2, mode);//Call the function that deals with the left part of the grid but move one layer inwards
            }
        }


        private void negativeKeyRightPartHandler(char[] message, int messageIterator, int x1, int y1, int x2, int y2, char mode)
        {
            for (int i = x2; i >= x1; i--)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[i, y2];//Fill the char array with the right columns
                }
                else
                {
                    grid[i, y2] = message[messageIterator++];//Fill the right columns with the chars from the char array
                }
            }
            for (int i = y2 - 1; i > y1; i--)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[x1, i];//Fill the char array with the chars from the top rows
                }
                else
                {
                    grid[x1, i] = message[messageIterator++];//Fill the top rows with the chars from the char array
                }
            }
            if (y1 != y2)
            {
                negativeKeyLeftPartHandler(message, messageIterator, x1, y1, x2, y2, mode);//Call the recursive function that deals with the left part of the grid
            }
        }

        private void negativeKeyLeftPartHandler(char[] message, int messageIterator, int x1, int y1, int x2, int y2, char mode)
        {
            for (int i = x1; i < x2; i++)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[i, y1];//Fill the char array with the chars from the left columns
                }
                else
                {
                    grid[i, y1] = message[messageIterator++];//Fill the left columns with the chars from the char array
                }
            }
            for (int i = y1; i < y2; i++)
            {
                // e means encryption, the else statement is for the decryption operations
                if (mode == 'e')
                {
                    message[messageIterator++] = grid[x2, i];//Fill the char array with the chars from the bottom rows
                }
                else
                {
                    grid[x2, i] = message[messageIterator++];//Fill the bottom rows with the chars from the char array
                }
            }
            if (y1 != y2)
            {
                negativeKeyRightPartHandler(message, messageIterator, ++x1, ++y1, --x2, --y2, mode);//Call the recursive function that deals with the right part of the grid but one layer inwards
            }
        }

        public String encrypt(String message)
        {
            this.fillGridForEncryption(message); //Fill the grid with the original message
            char[] messageArray = new char[this.rows * Math.Abs(this.key)];  // Create a char array to deal with the encoded message
                                                                             //If the key is negative call start encrypting from the bottom right corner
            if (this.key < 0)
            {
                this.negativeKeyRightPartHandler(messageArray, 0, 0, 0, this.rows - 1, Math.Abs(this.key) - 1, 'e');
                //Start encrypting from the top right corner
            }
            else
            {
                this.positiveKeyLeftPartHandler(messageArray, 0, 0, 0, this.rows - 1, Math.Abs(this.key) - 1, 'e');
            }
            return new String(messageArray);//Return the encrypted message as a string
        }

        public String toString()
        {
            char[] decodedMessage = new char[this.rows * Math.Abs(this.key)];//Create a char array with the size of the grid
            int iterator = 0;
            //Traverse the grid from right to left and get the chars into a char array
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < Math.Abs(this.key); j++)
                {
                    decodedMessage[iterator++] = grid[i, j];
                }
            }
            return new String(decodedMessage);//Return the char array as a string
        }

        public String decrypt(String message)
        {
            var cols = Math.Abs(this.key);//Set the rows
            var rows = ((int)Math.Ceiling((double)message.Length / cols)); //Calculate the needed rows and set them
            this.grid = new char[rows, cols]; //Set the grid
                                              //If the key is negative,decryption starts from the bottom right corner
            if (this.key < 0)
            {
                this.negativeKeyRightPartHandler(message.ToCharArray(), 0, 0, 0, this.rows - 1, Math.Abs(this.key) - 1, 'd');
            }
            //Else the decryption starts from the top left corner
            else
            {
                this.positiveKeyLeftPartHandler(message.ToCharArray(), 0, 0, 0, this.rows - 1, Math.Abs(this.key) - 1, 'd');
            }
            return toString();//Traverse the grid and return it as a string
        }
    }
    #endregion
}
