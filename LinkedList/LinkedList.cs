﻿using System;

namespace LinkedList
{
    public class LinkedLists
    {
        private Node _root;

        #region constructors

        /// <summary>
        /// 23. empty constructor
        /// </summary>
        public LinkedLists()
        {
            _root = null;
        }

        /// <summary>
        /// 23. single element constructor
        /// </summary>
        /// <param name="value"></param>
        public LinkedLists(int value)
        {
            _root = new Node(value);
        }

        /// <summary>
        /// 23. arrayList-based constructor
        /// </summary>
        /// <param name="array"></param>
        public LinkedLists(int[] array)
        {
            if (array.Length == 0)
            {
                _root = null;
                return;
            }
            Node tmp = new Node(array[0]);
            _root = tmp;
            for (int i = 1; i < array.Length; i++)
            {
                tmp.Next = new Node(array[i]);
                tmp = tmp.Next;
            }

        }

        #endregion

        #region actions for specific elements

        /// <summary>
        /// 11. Accessing an array element by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= GetLength())
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        /// <summary>
        ///  1. adding to the end
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node(value);
            }
            else
            {
                _root = new Node(value);
            }

        }

        /// <summary>
        /// 2. adding to the beginning
        /// </summary>       
        public void AddFirst(int value)
        {

            if (_root != null)
            {
                Node tmp = new Node(value);
                tmp.Next = _root;
                _root = tmp;
            }
            else
            {
                _root = new Node(value);
            }

        }

        /// <summary>
        /// 3. adding by index
        /// </summary>
        public void Insert(int index, int value)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > GetLength())
            {
                throw new NullReferenceException();
            }
            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                if (_root != null)
                {
                    Node tmp = _root;

                    for (int i = 1; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }

                    Node tmp2 = new Node(value);
                    tmp2.Next = tmp.Next;
                    tmp.Next = tmp2;
                }
            }
        }

        /// <summary>
        /// 4. removing one element from the end
        /// </summary>
        public void RemoveLast()
        {
            if (_root.Next == null) // как делать без этого?
            {
                _root = null;
                return;
            }
            if (_root != null)
            {
                Node tmp = _root;

                while (tmp.Next.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = tmp.Next.Next; // = null;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// 5. removing one from the beginning
        /// </summary>
        public void RemoveFirst()
        {
            if (_root != null)
            {
                _root = _root.Next;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// 6. removing one by index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveOneByIndex(int index)
        {
            if (_root.Next == null && index == 0)
            {
                _root = null;
                return;
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root != null)
            {
                Node tmp = _root;

                if (index == 0)
                {
                    RemoveFirst();
                }

                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = tmp.Next.Next;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// 7. removing from the end of N elements
        /// </summary>
        /// <param name="num"></param>     
        public void RemoveTheLastFew(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException();
            }
            if (_root == null || (num > GetLength()))
            {
                throw new NullReferenceException();
            }
            else
            {
                Node tmp = _root;
                for (int i = 1; i < (GetLength() - num); i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
            }
        }

        /// <summary>
        /// 8. removing from the beginning of N elements
        /// </summary>
        /// <param name="num"></param>
        public void RemoveFirstFew(int num)
        {
            if (_root == null || num > GetLength())
            {
                throw new NullReferenceException();
            }
            if (_root.Next == null && num == 1)
            {
                _root = null;
                return;
            }
            if (num < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Node tmp = _root;
                for (int i = 1; i <= num; i++)
                {
                    tmp = tmp.Next;
                }
                _root = tmp;
            }
        }

        /// <summary>
        /// 9. removing by index N elements
        /// </summary>
        /// <param name="index"></param>
        /// <param name="num"></param>
        public void RemoveSeveralByIndex(int index, int num)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root == null || num + index > GetLength())
            {
                throw new NullReferenceException();
            }
            if (num < 0)
            {
                throw new ArgumentException();
            }
            Node tmp = _root;
            if (index != 0)
            {
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                Node tmp2 = tmp;
                for (int i = 0; i < num; i++)
                {
                    tmp2 = tmp2.Next;
                }
                tmp.Next = tmp2.Next;
            }
            else
            {
                if (_root.Next == null && num == 1)
                {
                    _root = null;
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        tmp = tmp.Next;
                    }
                    _root = tmp;
                }
            }

        }

        /// <summary>
        /// 10. get the length of the list
        /// </summary>
        public int GetLength()
        {
            int s = 0;
            if (_root != null)
            {
                Node tmp = _root;
                s++;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                    s++;
                }
            }
            return s;
        }

        /// <summary>
        /// 12. first index by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>     
        public int GetFirstIndexByValue(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;
                int s = 0;
                while (tmp != null)
                {
                    if (tmp.Value == value)
                    {
                        return s;
                    }

                    tmp = tmp.Next;
                    s++;
                }
                return -1;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        #endregion

        #region actions for all elements

        /// <summary>
        /// 14. change the order of elements from end to beginning
        /// </summary>
        public void Reverse()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Node oldRoot = _root;
            Node crnt;
            while (oldRoot.Next != null)
            {
                crnt = oldRoot.Next;
                oldRoot.Next = crnt.Next;
                crnt.Next = _root;
                _root = crnt;
            }
        }

        /// <summary>
        /// 15. finding the maximum element
        /// </summary>
        /// <returns></returns>
        public int GetMaxElement()
        {
            if (_root != null)
            {
                Node tmp = _root;
                int max = _root.Value;
                while (tmp != null)
                {
                    if (max < tmp.Value)
                    {
                        max = tmp.Value;
                    }
                    tmp = tmp.Next;
                }
                return max;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// 16. finding the minimum element
        /// </summary>
        /// <returns></returns>       
        public int GetMinElement()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Node tmp = _root;
            int min = _root.Value;
            while (tmp != null)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return min;
        }

        /// <summary>
        /// 17. maximum element index
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMax()
        {
            //return GetFirstIndexByValue(GetMaxElement()); не оптимально, но работает
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Node tmp = _root;
            int max = _root.Value;
            int i = 0;
            int index = 0;

            while (tmp.Next != null)
            {
                i++;
                if (max < tmp.Next.Value)
                {
                    max = tmp.Next.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        /// <summary>
        /// 18. minimum element index
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMin()
        {
            //return GetFirstIndexByValue(GetMinElement()); не оптимальное решение, но оно работает

            if (_root == null)
            {
                throw new NullReferenceException();
            }

            Node tmp = _root;
            int min = _root.Value;
            int i = 0;
            int index = 0;

            while (tmp.Next != null)
            {
                i++;
                if (min > tmp.Next.Value)
                {
                    min = tmp.Next.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        /// <summary>
        /// 19. sort Ascending
        /// </summary>
        public void SortAscending()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Node nodeRoot = new Node(GetMinElement());
            Node nodeNext = nodeRoot;
            int min = nodeRoot.Value;
            while (_root.Next != null)
            {
                RemoveFirstByValue(min);
                nodeNext.Next = new(GetMinElement());
                nodeNext = nodeNext.Next;
                min = nodeNext.Value;
            }
            _root = nodeRoot;
        }

        /// <summary>
        /// 20. descending sort
        /// </summary>
        public void SortDescending()
        {
            if (_root == null)
            {
                throw new NullReferenceException();
            }
            Node nodeRoot = new Node(GetMaxElement());
            Node nodeNext = nodeRoot;
            int max = nodeRoot.Value;
            while (_root.Next != null)
            {
                RemoveFirstByValue(max);
                nodeNext.Next = new(GetMaxElement());
                nodeNext = nodeNext.Next;
                max = nodeNext.Value;
            }
            _root = nodeRoot;
        }

        /// <summary>
        /// 21. removing the first element by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveFirstByValue(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;

                if (_root.Value != value)
                {
                    while (tmp.Next != null)
                    {
                        if (tmp.Next.Value == value)
                        {
                            tmp.Next = tmp.Next.Next;
                            return;
                        }
                        tmp = tmp.Next;
                    }
                }
                else
                {
                    _root = tmp.Next;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// 22. removing all elements by value, returning count
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveAllByValue(int value)
        {
            int s = 0;
            if (_root != null)
            {
                if (_root.Value == value)
                {
                    while (_root != null && _root.Value == value)
                    {
                        _root = _root.Next;
                        s++;
                    }
                }
                Node tmp = _root;
                if (_root != null)
                {
                    while (tmp.Next != null)
                    {
                        if (tmp.Next.Value == value)
                        {
                            tmp.Next = tmp.Next.Next;
                            s++;
                        }
                        else
                        {
                            tmp = tmp.Next;
                        }
                    }
                }
            }

            else
            {
                throw new NullReferenceException();
            }
            return s;
        }

        #endregion

        #region list actions

        /// <summary>
        /// 24. adding a List to the End
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddLinkedListToEnd(LinkedLists LinkedList)
        {
            Node node = LinkedList._root;
            while (node != null)
            {
                Add(node.Value);
                node = node.Next;
            }
        }

        /// <summary>
        /// 25. adding a List to the Top
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddLinkedListToBeginning(LinkedLists LinkedList)
        {

            int i = 0;
            Node node = LinkedList._root;
            while (node != null)
            {
                Insert(i, node.Value);
                node = node.Next;
                i++;
            }
        }

        /// <summary>
        /// 26. adding a list by index
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="index"></param>
        public void AddLinkedListByIndex(int index, LinkedLists LinkedList)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index > GetLength())
            {
                throw new NullReferenceException();
            }
            Node node = LinkedList._root;
            int i = index;
            while (node != null)
            {
                Insert(i, node.Value);
                i++;
                node = node.Next;

            }
        }

        #endregion  

        #region override
        public void WriteToConsole()
        {
            if (_root == null)
            {
                Console.WriteLine();
            }
            Node node = _root;
            string result = "";
            while (node != null)
            {
                result += node.Value + " ";
                node = node.Next;
            }
            Console.WriteLine($"{result}");
        }

        public override string ToString()
        {
            string result = "";
            if (_root == null)
            {
                return result;
            }
            Node newNode = _root;
            while (newNode != null)
            {
                result += newNode.Value + " ";
                newNode = newNode.Next;
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            LinkedLists newNode = (LinkedLists)obj;
            Node tmp1 = _root;
            Node tmp2 = newNode._root;
            if (tmp1 == null && tmp2 == null)
            {
                return true;
            }
            while (tmp1 != null && tmp2 != null)
            {

                if ((tmp1.Next == null && tmp2.Next != null)
                || (tmp1.Next != null && tmp2.Next == null))
                {
                    return false;
                }
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
            //return base.GetHashCode();
        }

        #endregion
    }
}
