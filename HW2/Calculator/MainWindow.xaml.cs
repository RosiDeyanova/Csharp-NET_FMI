using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<double> nums = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TypeDigit(string digit) 
        {
            if (textBox.Text == "0" || textBox.Text == "00")
            {
                textBox.Text = digit;
            }
            else if ((textBox.Text == "0" && digit == "00") || (string.IsNullOrEmpty(textBox.Text) && digit == "00"))
            {
                textBox.Text = "0";
            }
            else
            {
                textBox.Text += digit;
            }
        }


        private void MainOperations(Operations operations)
        {
            int operationInt = (int)operations;

            if (nums.Count == 0)
            {
                nums.Add(double.Parse(textBox.Text));
            }
            nums.Add(operationInt);
            textBox.Text = string.Empty;
        }

        private void Btn_Number_Click(object sender, RoutedEventArgs e)
        {
            TypeDigit((string)((Button)sender).Content);
        }

        private void Btn_Symbol_Plus_Click(object sender, RoutedEventArgs e)
        {
            MainOperations(Operations.PLUS);
        }

        private void Btn_Symbol_Multiply_Click(object sender, RoutedEventArgs e)
        {
            MainOperations(Operations.MULTIPLY);
        }

        private void Btn_Symbol_Minus_Click(object sender, RoutedEventArgs e)
        {
            MainOperations(Operations.MINUS);
        }

        private void Btn_Symbol_Dot_Click(object sender, RoutedEventArgs e)
        {
            while (!textBox.Text.Contains("."))
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text += ".";
                }
            }
        }

        private void Btn_Symbol_Deriv_Click(object sender, RoutedEventArgs e)
        {
            MainOperations(Operations.DIV);
        }

        private void Btn_Symbol_Equal_Click(object sender, RoutedEventArgs e)
        {
            if (nums.Count == 2)
            {
                nums.Add(double.Parse(textBox.Text));
            }
            switch (nums[1])
            {
                case 1: textBox.Text = (nums[0] + nums[2]).ToString(); break;
                case 2: textBox.Text = (nums[0] - nums[2]).ToString(); break;
                case 3: textBox.Text = (nums[0] * nums[2]).ToString(); break;
                case 4:
                    textBox.Text = nums[2] != 0 ? (nums[0] / nums[2]).ToString() : "Error! Can't devide by zero!";
                    break;
                case 5: textBox.Text = nums[0].ToString(); break;
            }
            nums.Clear();
            nums.Add(double.Parse(textBox.Text));
        }

        private void Btn_Symbol_Exp_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Math.Exp(double.Parse(textBox.Text)).ToString();
        }

        private void Btn_Symbol_Sin_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Math.Sin(double.Parse(textBox.Text)).ToString();
        }

        private void Btn_Symbol_Cos_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Math.Cos(double.Parse(textBox.Text)).ToString();
        }

        private void Btn_Symbol_1_Over_x_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Equals("0"))
            {
                textBox.Text = "Error: Can't devide by zero";
            }
            else
            {
                double result = 1 / double.Parse(textBox.Text);
                textBox.Text = result.ToString();
            }
        }

        private void Btn_Symbol_Log_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Math.Log(double.Parse(textBox.Text)).ToString();
        }

        private void Btn_Symbol_Sqrt_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = Math.Sqrt(double.Parse(textBox.Text)).ToString();
        }

        private void Btn_Symbol_C_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
        }

        private void Btn_Symbol_CA_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = string.Empty;
            nums.Clear();
        }

        private void Btn_Symbol_Off_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
