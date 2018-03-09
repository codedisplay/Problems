namespace Problems.Array
{
    // all the arrays if sorted are in increasing order
    // arrays contains no duplicates
    public class ArrayHelper
    {
        #region Array Arrangement Rearrangement 

        #endregion

        #region Array Rotation 

        public static int SortedRotatedArrayMin(int[] arr, int size)
        {
            for (int i = 0; i < size; i++)
            {
                //if(arr[i])
            }

            return 0;
        }

        // Returns max possible value of i*arr[i]
        //var arr = new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //var arr = new int[] { 1, 20, 2, 10 };
        //var sum = ArrayMaxSum(arr, 4);
        public static int ArrayMaxSum(int[] arr, int size)
        {
            if (arr.Length < 0 || size < 1)
                return 0;

            int maxValue = arr[0];
            int maxindex = 0;

            for (int i = 0; i < size; i++)
            {
                if (maxValue < arr[i])
                {
                    maxValue = arr[i];
                    maxindex = i;
                }
            }

            int maxSum = 0;

            int headIndex = maxindex + 1 == size - 1 // Sorted Array but not rotated
                ? 0
                : maxindex + 1;
            int tailIndex = maxindex;

            int currentIndexNumber = 0;

            while (/*headIndex != tailIndex && */currentIndexNumber < size)
            {
                maxSum = maxSum + currentIndexNumber * arr[headIndex];
                headIndex = headIndex + 1 == size
                    ? 0
                    : headIndex + 1;
                currentIndexNumber++;
            }

            return maxSum;

        }

        // array is not sorted
        //Find maximum value of Sum(i* arr[i]) with only rotations on given array allowed
        // Returns max possible value of i*arr[i]
        //var arr = new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //var sum = SortedRotatedArrayMaxSum(arr, 10);
        public static int SortedRotatedArrayMaxSum(int[] arr, int size)
        {
            int pivotIndex = size - 1;

            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    pivotIndex = i;
                    break;
                }
            }

            int maxSum = 0;

            int headIndex = pivotIndex == size - 1 // Sorted Array but not rotated
                ? 0
                : pivotIndex + 1;
            int tailIndex = pivotIndex;

            int currentIndexNumber = 0;

            while (/*headIndex != tailIndex && */currentIndexNumber < size)
            {
                maxSum = maxSum + currentIndexNumber * arr[headIndex];
                headIndex = headIndex + 1 == size
                    ? 0
                    : headIndex + 1;
                currentIndexNumber++;
            }

            return maxSum;
        }

        //var arr = new int[] { 5, 6, 7, 8, 9, 10 };
        //    PairInSorted(arr, 6, 13);
        public static bool PairInSorted(int[] arr, int size, int sum)
        {
            int headIndex = 0;
            int tailIndex = size - 1;

            while (headIndex != tailIndex)
            {
                if (arr[headIndex] + arr[tailIndex] < sum)
                {
                    headIndex++;
                }
                else if (arr[headIndex] + arr[tailIndex] > sum)
                {
                    tailIndex--;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        //Given a sorted and rotated array, find if there is a pair with a given sum
        //var arr = new int[] { 5, 6, 7, 8, 9, 10, 1, 2 };
        //var result = PairInSortedRotated(arr, 8, 50);
        public static bool PairInSortedRotated(int[] arr, int size, int sum)
        {
            int pivotIndex = size - 1;// default assuming that array is sorted but not rotated

            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    pivotIndex = i;
                    break;
                }
            }

            int headIndex = pivotIndex == size - 1 // Sorted Array but not rotated
                ? 0
                : pivotIndex + 1;
            int tailIndex = pivotIndex;

            while (headIndex != tailIndex)
            {
                if (arr[headIndex] + arr[tailIndex] == sum)
                {
                    return true;
                }

                if (arr[headIndex] + arr[tailIndex] < sum)
                {
                    headIndex = headIndex + 1 == size
                        ? 0
                        : headIndex + 1;
                }
                else
                {
                    tailIndex = tailIndex - 1 < 0
                        ? size
                        : tailIndex - 1;
                }
            }

            return false;
        }

        //Search an element in a sorted and rotated array
        //assume that all elements in array are distinct
        // Input arr[] = { 3, 4, 5, 1, 2 }
        // Element to Search = 1
        //   1) Find out pivot point and divide the array in two
        //       sub-arrays. (pivot = 2) /*Index of 5*/
        //   2) Now call binary search for one of the two sub-arrays.
        //       (a) If element is greater than 0th element then
        //              search in left array
        //       (b) Else Search in right array
        //           (1 will go in else as 1 < 0th element(3))
        //   3) If element is found in selected sub-array then return index
        //      Else return -1.  
        //var arr = new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
        //int index = PivotedBinarySearch(arr, 9, 2);
        //arr = new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 };
        //    index = PivotedBinarySearch(arr,9, 28);
        public static int PivotedBinarySearch(int[] arr, int size, int item)
        //where T:IComparable<T>
        {
            int pivotIndex = size - 1;// default assuming that array is sorted but not rotated

            for (int i = 0; i < size - 1; i++)
            {
                if (arr[i] > (arr[i + 1]))
                {
                    pivotIndex = i;
                    break;
                }
            }

            if (arr[pivotIndex] == item)
                return pivotIndex;

            if (arr[pivotIndex] < item)
            {
                return BinarySearch(arr, 0, pivotIndex - 1, item);
            }

            return BinarySearch(arr, pivotIndex + 1, size - 1, item);
        }

        /* Standard Binary Search function */
        static int BinarySearch(int[] arr, int low, int high, int key)
        {
            if (high < low)
                return -1;

            int mid = (low + high) / 2;

            if (key == arr[mid])
                return mid;

            if (key > arr[mid])
                return BinarySearch(arr, (mid + 1), high, key);

            // key > arr[mid]
            return BinarySearch(arr, low, (mid - 1), key);
        }

        //Write a function rotate(ar[], d, n) that rotates arr[] of size n by d elements.
        //1,2,3,4,5,6,7 -> 3,4,5,6,7,1,2
        //int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
        //ArrayRotate(arr, 2, 6);
        //int[] arr = new int[] { 1, 2, 3, 4, 5, 6,7 };
        //ArrayRotate(arr, 3, 7);
        public static void ArrayRotate<T>(T[] arr, int rotateByElements, int size)
        {
            int modifiedItemsCount = 0;

            for (int i = 0; i < rotateByElements && modifiedItemsCount < size; i++)
            {
                //int currentIndex = (size - 1) - rotateByElements;
                int previousIndex = (i + size - rotateByElements) + rotateByElements;
                T previousValue = default(T);

                while (previousIndex != i)
                {
                    int currentIndex =
                        previousIndex - rotateByElements;

                    if (currentIndex < 0)
                        currentIndex = currentIndex + size;

                    T temp = arr[currentIndex];
                    arr[currentIndex] = previousValue.Equals(default(T))
                        ? arr[i]
                        : previousValue;
                    modifiedItemsCount++;

                    previousIndex = currentIndex;
                    previousValue = temp;
                }
            }
        }

        #endregion


        /*UTILITY FUNCTIONS*/
        /* function to print an array */
        public static void printArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                System.Console.WriteLine(arr[i] + " ");
        }
    }
}
