using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicFunctionalityConsoleApp
{
    public class BasicOperations
    {
        static void Main(string[] args) { }

        /// <summary>
        /// Async method for subtract two element
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        public async Task<int> Addition(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// While loop method
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int Add(int num)
        {
            int c = 0;
            while (c < 10)
            {
               c++;
            }
            return c;
        }

        /// <summary>
        /// For loop method
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int IncreamentNumberBy5(int number)
        {
            for (int i = 5; i > 0; i--)
            {
                number += 5;
            }
            return number;
        }

        /// <summary>
        /// For each method
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FindEvenNumbers(List<int> num)
        {
            int a = 0;
            foreach (var number in num)
            {
                if (number % 2 == 0)
                {
                    a++;
                }
            }
            return a;
        }

        /// <summary>
        /// Switch case method 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="opr"></param>
        /// <returns></returns>
        public string CheckString(string str, int opr)
        {
            switch (opr)
            {
                case 1:
                    return str.ToUpper();
                case 2:
                    return str.ToLower();
                default:
                    return "Invalid operation.";
            }
        }

        /// <summary>
        /// Divide any number by zero throw DivideByZeroException Exception
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public float DivideNumber(int num1, int num2)
        {
            try
            {
                int result = num1 / num2;
                return result;
            }
            catch (Exception)
            {
                throw new DivideByZeroException();
            }
        }

        /// <summary>
        /// Login method with If-Else conditions
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public string Login(string UserName, string Password)
        {
           
                if (UserName == "Dhruvi" && Password == "Dhruvi@0102")
                {
                    return "Success";
                }
                else
                {
                    throw new ArgumentNullException();
                }
        }

    }
}
