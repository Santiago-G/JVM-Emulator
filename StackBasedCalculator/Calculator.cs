using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public class Calculator
    {
        public Stack<int> stacky = new Stack<int>();
        public void Push(int num)
        {
            stacky.Push(num);
        }
        public void Add()
        {
            int a = stacky.Pop();
            int b = stacky.Pop();
            stacky.Push(a + b);
        }

        public void Pop()
        {
            stacky.Pop();
        }
        public void Subtract()
        {
            int a = stacky.Pop();
            int b = stacky.Pop();
            stacky.Push(a - b);
        }

        public void Multiple()
        {
            int a = stacky.Pop();
            int b = stacky.Pop();
            stacky.Push(a * b);
        }

        public void Divide()
        {
            int a = stacky.Pop();
            int b = stacky.Pop();
            stacky.Push(a / b);
        }
    }
}
