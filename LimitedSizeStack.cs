using System;
using System.Collections.Generic;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        LinkedList<T> list = new LinkedList<T>();
        public int Limit;
        public LimitedSizeStack(int limit)
        {
            Limit = limit;
        }

        public void Push(T item)
        {
            if (Limit == 0)
                return;
            if(list.Count >= Limit)
            {
                list.Remove(list.First.Value);
            }
            list.AddLast(item);
            
        }

        public T Pop()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list.Last.Value;
            list.Remove(list.Last.Value);
            return result;
        }

        public int Count
        {
            get
            {
                return list.Count; 
            }
        }
    }
}
