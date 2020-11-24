using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Forms
{
    class Calculator
    {
        static private bool IsOperator(char ch)
        {
            return "+-*".IndexOf(ch) != -1;
        }

        static private byte Priority(char ch)
        {
            switch (ch)
            {
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                default: return 6;
            }
        }

        static private bool IsDelimeter(char ch)
        {
            return " =".IndexOf(ch) != -1;
        }

        static private string GetExpresseion(string expression)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsDelimeter(expression[i])) continue;
                if (Char.IsDigit(expression[i]))
                {
                    while (!IsDelimeter(expression[i]) && !IsOperator(expression[i]))
                    {
                        output += expression[i];
                        i++;

                        if (i == expression.Length) break;
                    }

                    output += " ";
                    i--;
                }
                else if (IsOperator(expression[i]))
                {
                    if (operStack.Count > 0)
                        if (Priority(expression[i]) <= Priority(operStack.Peek()))
                            output += operStack.Pop().ToString() + " ";

                    operStack.Push(char.Parse(expression[i].ToString()));
                }
            }
            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }
            return output;
        }

        static private int Counting(string expression)
        {
            int result = 0;
            Stack<int> tempStack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]))
                {
                    string temp = string.Empty;

                    while (!IsDelimeter(expression[i]) && !IsOperator(expression[i]))
                    {
                        temp += expression[i];
                        i++;
                        if (i == expression.Length) break;
                    }
                    tempStack.Push(int.Parse(temp));
                    i--;
                }
                else if (IsOperator(expression[i]))
                {
                    int a = tempStack.Pop();
                    int b = tempStack.Pop();

                    switch (expression[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                    }
                    tempStack.Push(result);
                }
            }
            return tempStack.Peek();
        }

        static public int Result(string expression)
        {
            string tempExpression = GetExpresseion(expression);
            int result = Counting(tempExpression);
            return result;
        }
    }
}
