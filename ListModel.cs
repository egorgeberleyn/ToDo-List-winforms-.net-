using System.Collections.Generic;

namespace TodoApplication
{    
    public class ListModel<TItem>
    {
        private struct HistoryItem
        {
            public string Action;
            public TItem Item;
            public int Index;
        }

        public List<TItem> Items { get; }
        public int Limit;
        private LimitedSizeStack<HistoryItem> history;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            history = new LimitedSizeStack<HistoryItem>(limit);
        }

        public void AddItem(TItem item)
        {            
            history.Push(new HistoryItem { Action = "push", Index = Items.Count });
            Items.Add(item);
        }

        public void RemoveItem(int index)
        {
            history.Push(new HistoryItem { Action = "pop", Item = Items[index], Index = index});
            Items.RemoveAt(index);
        }

        public bool CanUndo()
        {
            return history.Count != 0;               
        }

        public void Undo()
        {           
            if (CanUndo())
            {
                var action = history.Pop();
                if (action.Action == "pop")
                    Items.Insert(action.Index, action.Item);
                else if(action.Action == "push")
                    Items.RemoveAt(action.Index);
            }
        }
    }
}
