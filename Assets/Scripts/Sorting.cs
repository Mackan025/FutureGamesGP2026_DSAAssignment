using Employees;
using System;


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

        int Partition(Workers.Employees[] arr, int low, int high) {
            // Choose a random pivot index
            int pivotIndex = UnityEngine.Random.Range(low, high + 1);

            // Move the pivot to the end
            Swap(arr, pivotIndex, high);

            // Use the last element as the pivot
            DateTime pivot = DateTime.Parse(arr[high].lastEntranceInEngineRoom);

            int i = low - 1;

            for(int j = low; j < high; j++) {
                DateTime current = DateTime.Parse(arr[j].lastEntranceInEngineRoom);

                if(current <= pivot) {
                    i++;
                    Swap(arr, i, j);
                }
            }

            // Place pivot in its correct position
            Swap(arr, i + 1, high);

            return i + 1;
        }

        void Sort(Workers.Employees[] arr, int low, int high) {
            // If low is lesser than high
            if(low < high) {
                // idx is index of pivot element which is at its
                // sorted position
                int idx = Partition(arr, low, high);

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
