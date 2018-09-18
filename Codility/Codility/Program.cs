using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountDiv(0, 0, 0));
            Console.ReadLine();
        }

        public static int CountDiv(int A, int B, int K)
        {
            //A = 11; B = 345; K = 17;

            if (A > B) return 0;

            if (A <= 0 && B <= 0) return 1;

            if (K <= 0) return 0;

            int m1 = 0, m2 = 0;

            if (A > 0)
                m1 = A >= K ? A % K : K - A;
            if (B > 0)
                m2 = B >= K ? B % K : K - B;

            return ((B - m2) - (A + m1)) / K + 1;
        }

        public static int MissingInteger()
        {
            int[] A = new int[] { -1, -3, 2 };

            int[] A1 = A.Select(x => 0).ToArray();

            if (A.Count(x => x <= 0) == A.Length)
                return 1;

            if (!A.Contains(1))
                return 1;

            for (int i = 1; i <= A.Length; i++)
                if (!A.Contains(i))
                    return i;

            return 0;
        }

        public static int[] MaxCounters()
        {
            int N = 5;
            int max = 0, lastmax = 0;

            int[] Counters = new int[N];

            int[] A = new int[] { 3, 4, 4, 6, 1, 4, 4 };

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= N)
                {
                    Counters[A[i] - 1] = Math.Max(lastmax, Counters[A[i] - 1]);
                    ++Counters[A[i] - 1];
                    max = Math.Max(max, Counters[A[i] - 1]);
                }
                else
                    lastmax = max;
            }

            for (int i = 0; i < Counters.Length; i++)
                Counters[i] = Math.Max(lastmax, Counters[i]);

            return Counters;
        }

        public static int PermCheck(int[] A)
        {
            if (A.Length == 1)
                return 0;

            if (A.Distinct().Count() == 1)
                return 0;

            if (A.Distinct().Count() != A.Max())
                return 0;

            return 1;
        }

        public static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        public static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }


        /*
        public static int FrogRiverOne(int X, int[] A)
        {
            HashSet<Int32> leaf = new HashSet<Int32>();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] <= X)
                    leaf.Add(A[i]);

                if (leaf.Count() == X)//position 1...X
                    return i;
            }

            return -1;            
        }
        */
    }
}
