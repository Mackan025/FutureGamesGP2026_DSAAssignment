using Employees;
using System;
using UnityEngine;
using static UnityEditor.Progress;


public class Sorting {
    public static void QuickSort(Workers array) {

        Quicksort.StartSort(array.employeesSaveArray);
    }

    public class Quicksort {
        public static void StartSort(Workers.Employees[] array) {
            Workers.Employees[] arr = array;
            int n = arr.Length;

            Quicksort ob = new Quicksort();
            ob.Sort(arr, 0, n - 1);
        }

        int partition(Workers.Employees[] arr, int low, int high) {
            // First element as pivot

            //int pivot = UnityEngine.Random.Range(low, high + 1);

            int st = low; // st points to the starting of array
            int end = high; // end points to the ending of the array
            int k = high;

            

            for(int i = high; i > low; i--) {

                //DateTime dt = DateTime.Parse(arr[UnityEngine.Random.Range(low, high)].lastEntranceInEngineRoom);
                DateTime dt = DateTime.Parse(arr[high].lastEntranceInEngineRoom);

                DateTimeOffset pivot = new(dt);


                DateTime d = DateTime.Parse(arr[i].lastEntranceInEngineRoom);

                DateTimeOffset dateTimeOffset = new(d);

                if(dateTimeOffset.ToUnixTimeSeconds() > pivot.ToUnixTimeSeconds()) {
                    Swap(arr, i, k--);
                }
            }
            Swap(arr, low, k);
            // As we got pivot element index is end
            // now pivot element is at its sorted position
            // return pivot element index (end)
            return k;
        }

        void Sort(Workers.Employees[] arr, int low, int high) {
            // If low is lesser than high
            if(low < high) {
                // idx is index of pivot element which is at its
                // sorted position
                int idx = partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                Sort(arr, low, idx - 1);
                Sort(arr, idx + 1, high);
            }
        }

        public static void Swap(Workers.Employees[] arr, int i, int j) {
            Workers.Employees temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
