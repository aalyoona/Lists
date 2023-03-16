using System;

namespace ArrayLists
{
    public class ArrayList
    {
        public int Lenght { get; private set; }
        private const int _minArrayLenght = 10;
        private int[] _array;

        /// <summary>
        /// 11. Accessing an array element by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Lenght)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        #region constructors

        /// <summary>
        /// 23. Empty constructor
        /// </summary>
        public ArrayList()
        {
            Lenght = 0;
            _array = new int[_minArrayLenght];
        }

        /// <summary>
        /// 23. Single element constructor
        /// </summary>
        /// <param name="element"></param>
        public ArrayList(int element)
        {
            Lenght = 1;
            _array = new int[_minArrayLenght];
            _array[0] = element;
        }

        /// <summary>
        /// 23. ArrayList-based constructor
        /// </summary>
        /// <param name="arrayList"></param>
        public ArrayList(ArrayList arrayList)
        {
            Lenght = arrayList.Lenght;
            if (arrayList.Lenght > _minArrayLenght)
            {
                _array = new int[(int)(arrayList.Lenght * 1.5)];
            }
            else
            {
                _array = new int[_minArrayLenght];
            }

            for (int i = 0; i < arrayList.Lenght; i++)
            {
                _array[i] = arrayList[i];
            }
        }

        /// <summary>
        /// 23. Array based constructor
        /// </summary>
        /// <param name="arr"></param>
        public ArrayList(int[] arr)
        {
            Lenght = arr.Length;
            if (arr.Length > _minArrayLenght)
            {
                _array = new int[(int)(arr.Length * 1.5)];
            }
            else
            {
                _array = new int[_minArrayLenght];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }
        }

        #endregion

        #region actions for specific elements

        /// <summary>
        ///  1. adding to the end
        /// </summary>
        public void Add(int value)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }
            _array[Lenght] = value;
            Lenght++;
        }

        /// <summary>
        /// 2. adding to the beginning
        /// </summary>
        public void AddToBegin(int value)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }
            ShiftRight(Lenght - 1, 0);
            Lenght++;
            _array[0] = value;
        }

        /// <summary>
        /// 3. adding by index
        /// </summary>
        public void Insert(int index, int value)
        {
            if (index > Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }

            ShiftRight(Lenght - 1, index);
            _array[index] = value;
            Lenght++;
        }

        /// <summary>
        /// 4. removing one element from the end
        /// </summary>
        public void RemoveLast()
        {
            if (Lenght == 0)
            {
                throw new Exception();
            }
            else
            {
                Lenght -= 1;
            }
        }

        /// <summary>
        /// 5. removing one from the beginning
        /// </summary>
        public void RemoveFirst()
        {
            ShiftLeft(1, Lenght);
            --Lenght;
        }

        /// <summary>
        /// 6. removing one by index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveOneByIndex(int index)
        {
            if (index >= Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            ShiftLeft(++index, Lenght);
            Lenght -= 1;
        }

        /// <summary>
        /// 7. removing from the end of N elements
        /// </summary>
        /// <param name="num"></param>
        ///       
        public void RemoveSeveralLast(int num)
        {
            if (num >= Lenght)
            {
                throw new IndexOutOfRangeException();

            }
            Lenght -= num;
        }

        /// <summary>
        /// 8. removing from the beginning of N elements
        /// </summary>
        /// <param name="num"></param>
        public void RemoveSeveralBegin(int num)
        {
            if (num >= Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = num; i > 0; i--)
            {
                ShiftLeft(i, Lenght);
                Lenght--;
            }
        }

        /// <summary>
        /// 9. removing by index N elements
        /// </summary>
        /// <param name="index"></param>
        /// <param name="num"></param>
        public void RemoveSeveralByIndex(int index, int num)
        {
            if (index + num - 1 == index || (index + num >= Lenght))
            {
                throw new Exception();
            }
            for (int i = num + index - 1; i >= index; i--)
            {
                ShiftLeft(i, Lenght);
                Lenght--;
            }
        }

        /// <summary>
        /// 12. first index by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>     
        public int GetFirstIndexByValue(int value)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region actions for all elements

        /// <summary>
        /// 14. change the order of elements from end to beginning
        /// </summary>
        public void Reverse()
        {
            for (int i = 0; i < Lenght / 2; i++)
            {
                int tmp = _array[i];
                _array[i] = _array[Lenght - i - 1];
                _array[Lenght - i - 1] = tmp;
            }
        }

        /// <summary>
        /// 15. finding the maximum element
        /// </summary>
        /// <returns></returns>
        public int GetMaxElement()
        {
            int max = _array[0];

            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        /// <summary>
        /// 16. finding the minimum element
        /// </summary>
        /// <returns></returns>       
        public int GetMinElement()
        {
            int min = _array[0];

            for (int i = 1; i < Lenght - 1; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        /// <summary>
        /// 17. maximum element index
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMax()
        {
            int max = _array[0];
            int maxIndex = 0;

            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        /// <summary>
        /// 18. minimum element index
        /// </summary>
        /// <returns></returns>
        public int GetIndexOfMin()
        {
            int min = _array[0];
            int minIndex = 0;

            for (int i = 1; i < Lenght; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        /// <summary>
        /// 19. sort Ascending
        /// </summary>
        public void SortAscending()
        {
            for (int i = 0; i < Lenght; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < Lenght; j++)
                {
                    if (_array[j] < _array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[minIndex];
                _array[minIndex] = tmp;
            }
        }

        /// <summary>
        /// 20. descending sort
        /// </summary>
        public void SortDescending()
        {
            for (int i = 0; i < Lenght; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < Lenght; j++)
                {
                    if (_array[j] > _array[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[maxIndex];
                _array[maxIndex] = tmp;
            }
        }

        /// <summary>
        /// 21. removing the first element by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveFirstByValue(int value)
        {
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    int traffic = i + 1;
                    ShiftLeft(traffic, Lenght);
                    Lenght--;
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 22. removing all elements by value, returning count
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveAllByValue(int value)
        {
            int num = 0;
            for (int i = 0; i < Lenght; i++)
            {
                if (_array[i] == value)
                {
                    int traffic = i + 1;
                    ShiftLeft(traffic, Lenght);
                    i--;
                    Lenght--;
                    num++;
                }

            }
            return num;
        }

        #endregion

        #region list actions

        /// <summary>
        /// 24. adding a List to the End
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddArrayListToEnd(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Lenght; i++)
            {
                Add(arrayList[i]);
            }
        }

        /// <summary>
        /// 25. adding a List to the Top
        /// </summary>
        /// <param name="arrayList"></param>
        public void AddArrayListToBeginning(ArrayList arrayList)
        {
            int i = 0;
            while (arrayList.Lenght > i)
            {
                Insert(i, arrayList[i]);
                i++;
            }

            //for (int i = 0; i < arrayList.Lenght; i++)
            //{
            //    Lenght++;
            //    ShiftRight(i, Lenght);
            //    _array[i] = arrayList[i];
            //}
        }

        /// <summary>
        /// 26. adding a list by index
        /// </summary>
        /// <param name="arrayList"></param>
        /// <param name="index"></param>
        public void AddArrayListByIndex(int index, ArrayList arrayList)
        {
            for (int i = index; i < arrayList.Lenght + index; i++)
            {
                ShiftRight(Lenght - 1, i + 1);
                _array[i + 1] = arrayList[i - index];
                Lenght++;
            }
        }

        #endregion

        #region private service operations

        /// <summary>
        /// Offset right
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        private void ShiftRight(int end, int start)
        {
            if (Lenght == _array.Length)
            {
                UpArraySize();
            }
            for (int i = end; i >= start; i--)
            {
                _array[i + 1] = _array[i];

            }
        }

        /// <summary>
        /// Offset to the left
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        private void ShiftLeft(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                _array[i - 1] = _array[i];
            }
        }

        /// <summary>
        /// Outputting an array to the console
        /// </summary>
        public void WriteToConsole()
        {
            for (int i = 0; i < Lenght; i++)
            {
                Console.Write($"{_array[i]} ");
            }
        }

        /// <summary>
        /// Increasing the array length by 1.5 times
        /// </summary>
        private void UpArraySize()
        {
            int[] tmpArray = new int[(int)(Lenght * 1.5)];
            for (int i = 0; i < Lenght; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        #endregion

        #region override
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Lenght != arrayList.Lenght)
            {
                return false;
            }

            for (int i = 0; i < Lenght; i++)
            {
                if (arrayList._array[i] != _array[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Lenght; i++)
            {
                s += $"{_array[i]} ";
            }
            return s;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
            //return base.GetHashCode();
        }

        #endregion
    }
}

