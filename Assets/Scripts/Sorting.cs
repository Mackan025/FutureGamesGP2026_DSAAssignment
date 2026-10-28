using Employees;
using System;


public class QuickSort {
    public static void StartSort(Workers.Employees[] array) {
        Workers.Employees[] arr = array;
        int n = arr.Length;

        QuickSort ob = new QuickSort();
        ob.Sort(arr, 0, n - 1);
    }

    int Partition(Workers.Employees[] arr, int low, int high) {

        int pivotIndex = UnityEngine.Random.Range(low, high + 1);

        Swap(arr, pivotIndex, high);


        DateTime pivot = DateTime.Parse(arr[high].lastEntranceInEngineRoom);

        int i = low - 1;

        for(int j = low; j < high; j++) {
            DateTime current = DateTime.Parse(arr[j].lastEntranceInEngineRoom);

            if(current <= pivot) {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);

        return i + 1;
    }

    void Sort(Workers.Employees[] arr, int low, int high) {

        if(low < high) {

            int idx = Partition(arr, low, high);

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
