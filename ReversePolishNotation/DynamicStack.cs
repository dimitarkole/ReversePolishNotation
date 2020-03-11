using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotation
{
    public class DynamicStack <T>
    {
        public class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                this.Item = item;
                this.Next = null;
            }

            public Node(T item, Node next)
            {
                this.Item = item;
                this.Next = next;
            }
        }

        private Node top;
        private int count;
        public Node Top
        {
            get { return this.top; }
            set { this.top = value; }
        }
        public int Count
        {
            get => count;
        }
        public DynamicStack()
        {
            this.top = null;
            this.count = 0;
        }
        public void Push(T item)
        {
            Node current = new Node(item, this.top);
            this.top = current;
            this.count++;
        }
        public T Pop()
        {
            var el = this.top.Item;
            this.top = this.top.Next;
            this.count--;
            return el;
        }
        public T Peek()
        {
            var el = this.top.Item;
            return el;
        }
        public void Clear()
        {
            this.top = null;
            this.count = 0;
        }
        public T[] ToAray()
        {
            T[] arr = new T[this.Count];
            Node currentNode = this.top;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                arr[i] = currentNode.Item;
                currentNode = currentNode.Next;
            }
            return arr;
        }
    }
}
