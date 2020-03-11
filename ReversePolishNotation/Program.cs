using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        { 
            string izraz = Console.ReadLine();
            DynamicStack<char> stack = new DynamicStack<char>();
            string obratenpolskizapis = "";
            foreach (var znak in izraz)
            {
                if (znak == '(') stack.Push(znak);
                else if (znak == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                        obratenpolskizapis += (stack.Pop());
                    stack.Pop();
                }
                else if ((znak >= '0' && znak <= '9' || znak == '.')||(znak>= 'a' && (znak <= 'z')))
                {
                   obratenpolskizapis+=znak;
                }
                else if (znak == '-' || znak== '+' || znak == '*' || znak == '/')
                {
                    while (stack.Count > 0 && stack.Peek() != '(' && Prior(znak) <= Prior(stack.Peek()))
                    {
                        obratenpolskizapis += (stack.Pop());
                    }
                    stack.Push(znak);
                }
                else
                {
                    char y = stack.Pop();
                    if (y != '(') obratenpolskizapis += y;
                }

            }
            while (stack.Count > 0)
            {
                obratenpolskizapis+=stack.Pop();
            }
            Console.WriteLine(obratenpolskizapis);


            string expr = "(" + izraz + ")";
            DynamicStack<char> znaci = new DynamicStack<char>();
            DynamicStack<double> stojnosti = new DynamicStack<double>();
            foreach (var znak in expr)
            {
                if (znak== '(') { }
                else if (znak=='+') znaci.Push(znak);
                else if (znak=='-') znaci.Push(znak);
                else if (znak=='*') znaci.Push(znak);
                else if (znak=='/') znaci.Push(znak);
                else if (znak==')')
                {
                    int count = znaci.Count;
                    while (count > 0)
                    {
                        char op = znaci.Pop();
                        double v = stojnosti.Pop();
                        if (op=='+') v = stojnosti.Pop() + v;
                        else if (op=='-') v = stojnosti.Pop() - v;
                        else if (op == '*') v = stojnosti.Pop() * v;
                        else if (op == '/') v = stojnosti.Pop() / v;
                        stojnosti.Push(v);

                        count--;
                    }
                }
                else
                {
                    Console.WriteLine($"znak={znak}");
                    stojnosti.Push(double.Parse(znak.ToString()));
                }
            }
            Console.WriteLine(stojnosti.Pop());
        }
        static int Prior(char c)
        {
            switch (c)
            {
                case '=':
                    return 1;
                case '+':
                    return 2;
                case '-':
                    return 2;
                case '*':
                    return 3;
                case '/':
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
