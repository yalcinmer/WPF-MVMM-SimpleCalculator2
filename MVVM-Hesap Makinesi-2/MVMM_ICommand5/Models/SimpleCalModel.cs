using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVMM_ICommand5.Models
{
    public class SimpleCalModel
    {
        private string result;
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Operation { get; set; }
        public string Result { get { return result; } }

        public SimpleCalModel()
        {
            FirstNumber ="";
            SecondNumber = "";
            Operation = "";
            result = "";
        }

        public SimpleCalModel(string firstNumber, string secondNumber, string operation)
        {
            ValidData(firstNumber);
            ValidData(secondNumber);
            ValidOperation(operation);

            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            Operation = operation;
            result = "";
        }

        public void ValidOperation(string operation)
        {
            switch (operation)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    break;
                default:
                    MessageBox.Show("Invalid operation");
                    break;
            }
        }

        public void ValidData(string data)
        {
            try
            {
                Convert.ToDouble(data);
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Calculate()
        {
            try
            {
                switch (Operation)
                {
                    case "+":
                        result = (Convert.ToDouble(FirstNumber) + Convert.ToDouble(SecondNumber)).ToString();
                        break;
                    case "-":
                        result = (Convert.ToDouble(FirstNumber) - Convert.ToDouble(SecondNumber)).ToString();
                        break;
                    case "*":
                        result = (Convert.ToDouble(FirstNumber) * Convert.ToDouble(SecondNumber)).ToString();
                        break;
                    case "/":
                        result = (Convert.ToDouble(FirstNumber) / Convert.ToDouble(SecondNumber)).ToString();
                        break;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
