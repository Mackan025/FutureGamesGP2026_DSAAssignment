using Employees;
using System;
using System.Diagnostics;


public class QuickSort {

    public static void StartSort(Workers.Employees[] array) {

        Workers.Employees[] arr = array;
        int low = 0;
        int high = arr.Length;
        


        QuickSort qs = new();
        qs.Sort(arr, low, high-1);
    }


    void Sort(Workers.Employees[] arr, int low, int high) {

        if(low < high) {
            int partitionIndex = Partition(arr, low, high);
            
            Sort(arr, low, partitionIndex - 1);
            Sort(arr, partitionIndex + 1, high);
        }
    }

    int Partition(Workers.Employees[] arr, int low, int high) {

        int pivot = UnityEngine.Random.Range(low, high+1);

        Swap(arr, pivot, high);

        DateTime num = DateTime.Parse(arr[high].lastEntranceInEngineRoom);

        int i = low - 1;

        for(int j = low; j < high; j++) {

            DateTime current = DateTime.Parse(arr[j].lastEntranceInEngineRoom);

            if(current <= num) {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);

        return i + 1;
    }

    public static void Swap(Workers.Employees[] arr, int i, int j) {

        Workers.Employees temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
