using System;
using System.Collections;


namespace TKDynamicArray
{
    public class TKDynamicArray<T> : IEnumerable<T> where T : IComparable<T>
    {
        protected T[] datas;

        public int Count 
        {
            get;
            private set;
        }

        public TKDynamicArray()
        {
            datas = new T[10];
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                return datas[index];
            }
            set
            {
                if(index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                datas[index] = value;
            }
        }

        #region Enumerator
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++) 
            {
                yield return datas[i];
            }
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {

            //for (int i = 0; i < Count; i++)
            //{
            //    yield return datas[i];
            //}
        
            return new TKDynamicArrayEnumerator<T>(datas, Count);
        }

        public class TKDynamicArrayEnumerator<T> : IEnumerator<T>
        {
            T[] Datas;
            int Offset;
            int Count;
            //int Length;

            public T Current
            {
                get 
                { 
                    return Datas[Offset]; 
                }
            }

            object IEnumerator.Current 
            {
                get 
                {
                    return Datas[Offset];
                }   
            }

            public TKDynamicArrayEnumerator(T[] datas, int Count)
            {
                this.Datas = datas;
                this.Offset = -1;
                this.Count = Count;
                //this.Length = datas.Length;
            }


            public bool MoveNext()
            {
                if(Offset >= Count - 1)
                {
                    return false;
                }

                Offset++;
                return true;
            }

            public void Reset()
            {
                Offset = -1;
            }

            public void Dispose()
            {
                
            }
        }
        #endregion

        public void Add(T item) 
        {
            if(Count >= datas.Length)
            {
                //TODO Resize Array
                ResizeArray();
            }

            datas[Count] = item;
            Count++;
        }

        protected void ResizeArray()
        {
            T[] tempArr = new T[Count * 2];

            for (int i = 0; i < Count; i++) 
            {
                tempArr[i] = datas[i];
            }

            datas = tempArr;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if(index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < Count - 1; i++)
            {
                datas[i] = datas[i + 1];
            }

            Count--;
            datas[Count] = default(T);
        }

        public int IndexOf(T item)
        {
            int result = -1;

            if(false == datas.Contains(item))
            {
                return result;
            }

            for (int i = 0; i < Count; i++) 
            {
                if (datas[i] != null && datas[i].Equals(item))
                {
                    result = i;
                }
            }

            return result;
        }

        public void SortBubble()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1; j++)
                {
                    var data1 = datas[j] as IComparable;
                    var data2 = datas[j + 1] as IComparable;
                
                    if(data1 == null || data2 == null)
                    {
                        throw new Exception("Elements isn't IComparable");
                    }
                    
                    if(data1.CompareTo(data2) >= 0)
                    {
                        T temp = datas[j];
                        datas[j] = datas[j + 1];
                        datas[j + 1] = temp;
                    }
                }
            }
        }

    }
}
