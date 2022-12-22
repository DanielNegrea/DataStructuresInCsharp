namespace DataStructuresInCsharp.Arrays
{
    internal class Arrays
    {
        /* Remove even integers from an array -> Time complexity O(n) */
        internal static int[] RemoveEven(int[] myArr, int size)
        {
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                if (myArr[i] % 2 != 0) // if odd number found
                {
                    myArr[count] = myArr[i]; // inserting odd values in array starting from first index
                    count++;
                }
            }

            int[] temp = new int[count]; // creating new array with length based on count of uneven numbers

            for (int i = 0; i < count; i++)
            {
                temp[i] = myArr[i];
            }

            myArr = temp;
            return myArr; // returning array after removing odd numbers
        }

        /* Merge two sorted arrays -> Time complexity O(n + m) */
        internal static int[] MergeArrays()
        {
            int[] arr1 = { 1, 3, 4, 5 };
            int[] arr2 = { 2, 6, 7, 8 };
            int[] arr3 = new int[arr1.Length + arr2.Length];

            int i = 0, j = 0, k = 0;

            // Traverse both arrays
            while (i < arr1.Length && j < arr2.Length)
            {
                // if first array element is less than second array element
                if (arr1[i] < arr2[j])
                    arr3[k++] = arr1[i++]; // copy 1st array element to the new array
                else
                    arr3[k++] = arr2[j++]; // copy 2nd array element to the new array
            }

            // Store remaining elements of the first array
            while (i < arr1.Length)
            {
                arr3[k++] = arr1[i++];
            }

            // Store remaining elements of the second array
            while (j < arr2.Length)
            {
                arr3[k++] = arr2[j++];
            }

            return arr3;
        }

        /* Find Two Numbers that Add Up to Given Value -> Time complexity O(nlogn) */
        internal static int[] FindSum()
        {
            int value = 81;
            int[] myArr = new int[] { 1, 21, 3, 14, 5, 60, 7, 6 };
            HelperMethods.QuickSort(myArr, 0, myArr.Length - 1); // Sort the array in Ascending Order

            int pointer1 = 0;    // pointer 1 -> At Start
            int pointer2 = myArr.Length - 1;   // pointer 2 -> At End

            int[] result = new int[2];
            int sum = 0;

            while (pointer1 != pointer2)
            {
                sum = myArr[pointer1] + myArr[pointer2]; // Calulate Sum of pointer 1 and 2

                if (sum < value) // if sum is less than given value => Move pointer 1 to right
                    pointer1++;
                else if (sum > value) // if sum is greater than given value => Move pointer 2 to left
                    pointer2--;
                else
                {
                    result[0] = myArr[pointer1];
                    result[1] = myArr[pointer2];
                    return result;
                }
            }

            return myArr;
        }

        /* Return an array where each index stores the product of all numbers in the array except the number at the index itself -> Time complexity O(n) */
        internal static int[] FindProduct()
        {
            int[] myArr = new int[] { 4, 2, 1, 5, 0 };
            int[] product = new int[myArr.Length];  // Allocate memory for the product array
            int temp = 1;

            // temp contains product of elements on left side excluding arr[i]
            for (int i = 0; i < myArr.Length; i++)
            {
                product[i] = temp;
                temp *= myArr[i];
            }
            temp = 1;  // Initialize temp to 1 for product on right side

            // temp contains product of elements on right side excluding arr[i]
            for (int i = myArr.Length - 1; i >= 0; i--)
            {
                product[i] *= temp;
                temp *= myArr[i];
            }
            return product;
        }

        /* Finding minimum value in an array -> Time complexity O(n) */
        internal static int FindMinimum()
        {
            int[] myArr = new int[] { 12, -8, -26, 17, -25, -1, 6 };
            int min = myArr[0];

            for (int i = 1; i < myArr.Length; i++)
            {
                if (myArr[i] < min)
                    min = myArr[i];
            }

            return min;
        }

        /* Finding the first unique integer in an array -> Time complexity O(n2) */
        internal static int FindFirstUnique()
        {
            int[] myArr = new int[] { 2, 54, 7, 2, 6, 54 };

            for (int i = 0; i < myArr.Length; i++)
                for (int j = i + 1; j < myArr.Length; j++)
                {
                    if (myArr[i] == myArr[j])
                    {
                        i++;
                        j = i;
                    }
                    else if (j == myArr.Length - 1)
                    {
                        return myArr[i];
                    }
                }

            return -1;
        }

        /* Find the second maximum element in the array -> Time complexity O(n) */
        internal static int FindSecondMax()
        {
            int[] myArr = new int[] { 9, 2, 3, 6 };
            int max = int.MinValue;
            int secondMax = int.MinValue;

            for (int i = 0; i < myArr.Length; i++)
            {
                /* If ith element is greater than max then update both max and secondmax */
                if (myArr[i] > max)
                {
                    secondMax = max;
                    max = myArr[i];
                }
                /* If the ith element is in between max and secondmax then update secondmax */
                else if (myArr[i] > secondMax && myArr[i] != max)
                {
                    secondMax = myArr[i];
                }
            }

            return secondMax;
        }

        /* With the given array, rotate its elements by one index from right to left -> Time complexity O(n) */
        internal static int[] RightRotateArray()
        {
            int[] myArr = new int[] { -23, 1, -2, 5, 44, -9, 8 };
            int lastElement = myArr[myArr.Length - 1];

            // Store the last element of the array.
            // Start from the last index and right shift the array by one.
            for (int i = myArr.Length - 1; i > 0; i--)
            {
                myArr[i] = myArr[i - 1];
            }
            // Make the last element stored to be the first element of the array.
            myArr[0] = lastElement;

            return myArr;
        }

        /* Rearrange array elements in such a way that the negative elements appear at one side and positive elements appear in the other. -> Time complexity O(n) */
        internal static int[] RearrangeNegativePositive()
        {
            int[] myArr = new int[] { 10, -1, 20, 4, 5, -9, -6 };
            int j = 0;

            for (int i = 0; i < myArr.Length; i++)
            {
                if (myArr[i] < 0) // If negative number found
                {
                    if (i != j)
                    {
                        // Swapping with leftmost positive
                        int temp = myArr[j];
                        myArr[j] = myArr[i];
                        myArr[i] = temp;
                    }
                    j++;
                }
            }
            return myArr;
        }

        /* Arrange elements in such a way that the maximum element appears first, then the minimum second, then second maximum at the third position,
           the second minimum at fourth, and so on. -> Time complexity O(n) */
        internal static int[] RearrangeSortedMaxMin()
        {
            int[] myArr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int[] newArr = new int[myArr.Length]; // Create a new array to hold re-arranged version of given myArr
            int pointer1 = 0;
            int pointer2 = myArr.Length - 1;

            for (int i = 0; i < myArr.Length; i++)
            {
                if (i % 2 == 0) // Copy large values
                {
                    newArr[i] = myArr[pointer2];
                    pointer2--;
                }
                else // Copy Small values
                {
                    newArr[i] = myArr[pointer1];
                    pointer1++;
                }
            }
            // Copying to original array
            for (int j = 0; j < newArr.Length; j++)
            {
                myArr[j] = newArr[j];
            }
            return myArr;
        }

        /* This approach only works for non-negative numbers! -> Time complexity O(n) -> Space complexity O(1) */
        internal static int[] RearrangeSortedMaxMinInPlace()
        {
            int[] myArr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int maxIndex = myArr.Length - 1;
            int minIndex = 0;
            int maxElem = myArr[maxIndex] + 1; // Store any element that is greater than the maximum element in the array 
            for (int i = 0; i < myArr.Length; i++)
            {
                // At even indices we will store maximum elements
                if (i % 2 == 0)
                {
                    myArr[i] += (myArr[maxIndex] % maxElem) * maxElem;
                    maxIndex -= 1;
                }
                // At odd indices we will store minimum elements
                else
                {
                    myArr[i] += (myArr[minIndex] % maxElem) * maxElem;
                    minIndex += 1;
                }
            }
            // Dividing with maxElem to get original values.
            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = myArr[i] / maxElem;
            }
            return myArr;
        }

        /* With the given an array, find the contiguous subarray with the largest sum. */
        /* Using Kadane's algorithm -> Time complexity O(n) */
        internal static int MaxSumSubarray()
        {
            int[] myArr = new int[] { 1, 10, -1, 11, 5, -30, -7, 20, 25, -35 };

            if (myArr.Length < 1)
                return 0;

            int maxSum = myArr[0];
            int currentMaxSum = myArr[0];

            for (int i = 1; i < myArr.Length; i++)
            {
                if (currentMaxSum < 0)
                    currentMaxSum = myArr[i];
                else
                    currentMaxSum += myArr[i];

                if (maxSum < currentMaxSum)
                    maxSum = currentMaxSum;
            }

            return maxSum;
        }
    }
}