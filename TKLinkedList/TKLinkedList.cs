using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKLinkedList
{
    /*
    Add
    Insert
    Remove
    GetNode
    Count
     */

    public class TKLinkedList<T>
    {
        public T Data { get; set; }

        public TKLinkedList<T> Head { get; set; }
        public TKLinkedList<T> Next { get; set; }

        public TKLinkedList(T Data)
        {
            this.Data = Data;
            this.Next = null;
        }



    }
}
