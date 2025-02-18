using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureTK
{
    //C#의 ArrayList
    public class TKArrayList<T> where T : IComparable<T>
    {
        protected T[] objectArr = new T[10];

        public int Count
        {
            get;
            private set;
        }

        public T this[int index]
        {
            get
            {
                return objectArr[index];
            }
            set
            {
                if (index < objectArr.Length)
                {
                    objectArr[index] = value;
                }
            }
        }

        public TKArrayList()
        {
            Count = 0;
        }

        public void Add(T obj)
        {
            if (Count >= objectArr.Length)
            {
                ResizeArray();
            }

            objectArr[Count] = obj;
            Count++;
        }

        //값이 중복된다면, 첫번째 값이 Remove
        public void Remove(T obj)
        {
            int index = IndexOf(obj);
            if(index == -1)
            {
                throw new NullReferenceException(nameof(obj));
            }
            if(index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            RemoveAt(index);
        }

        //index부터 앞으로 한 칸 땡기고 끝에 있는거 null로
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = index; i < Count - 1; i++)
            {
                objectArr[i] = objectArr[i + 1];
            }

            Count--;
            objectArr[Count] = default(T);
        }

        public void Clear()
        {
            objectArr = new T[10];
            Count = 0;
        }

        public void Insert(int index, T obj)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if(Count >= objectArr.Length)
            {
                ResizeArray();
            }

            for(int i = Count; i > index; i--)
            {
                objectArr[i] = objectArr[i - 1];
            }
            objectArr[index] = obj;
            Count++;
        }


        /// <summary>
        /// 리스트의 값들 reverse 시키기
        /// </summary>
        public void Reverse()
        {
            if(Count % 2 == 0)
            {
                for (int i = Count - 1; i >= Count / 2; i--)
                {
                    T tempObj = objectArr[i];
                    objectArr[i] = objectArr[(Count - 1) - i];
                    objectArr[(Count - 1) - i] = tempObj;
                }
            }
            else
            {
                for (int i = Count - 1; i >= (Count / 2) + 1; i--)
                {
                    T tempObj = objectArr[i];
                    objectArr[i] = objectArr[(Count - 1) - i];
                    objectArr[(Count - 1) - i] = tempObj;
                }
            }

        }

        /// <summary>
        /// 리스트 값들 비교해서 순서대로 정렬하기
        /// </summary>
        public void Sort() //버블 정렬
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    IComparable obj1 = objectArr[j] as IComparable;
                    IComparable obj2 = objectArr[j + 1] as IComparable; 

                    if(obj1 != null && obj2 != null && obj1.CompareTo(obj2) > 0)
                    {
                        T temp = objectArr[j];
                        objectArr[j] = objectArr[j + 1];
                        objectArr[j + 1] = temp;
                    }
                }
            }
        }

        public bool IsContain(T searchObj)
        {
            foreach (T obj in objectArr)
            {
                if (obj != null && obj.Equals(searchObj))
                {
                    return true;
                }
            }

            return false;
        }
        public int IndexOf(T searchObj)
        {
            for (int i = 0; i < objectArr.Length; i++)
            {
                if (objectArr[i] != null && objectArr[i].Equals(searchObj))
                {
                    return i;
                }
            }
            return -1;
        }

        public void WriteArrayList()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{objectArr[i].ToString()},\t");
            }
        }

        protected void ResizeArray()
        {
            T[] tempArr = new T[objectArr.Length * 2];
            for (int i = 0; i < objectArr.Length; i++)
            {
                tempArr[i] = objectArr[i];
            }
            objectArr = tempArr;
        }


    }
}
