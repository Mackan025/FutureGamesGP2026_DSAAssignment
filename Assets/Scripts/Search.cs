using Employees;
using Environment.Tasks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace search {
    [CreateAssetMenu(fileName = "Search", menuName = "Search")]

    public class Search : Task {

        [SerializeField] string lowString;

        [SerializeField] string highString;

        [SerializeField] Workers array;

        [SerializeField] Workers.Employees[] resultArray;

        public override void Execute() {

            DateTime low = DateTime.Parse(lowString);
            DateTime high = DateTime.Parse(highString);

            if (low > high) {
                DateTime temp = low;
                low = high;
                high = temp;
            }

            StartBinarySearch(array, low, out int lowResult);
            StartBinarySearch(array, high, out int highResult);

            if(lowResult != -1 && highResult != -1) {
                FindRange(array, lowResult, highResult);
            }
            else {
                Debug.LogError("No results found");
            }
        }

        void StartBinarySearch(Workers workers, DateTime num, out int result) {

            result = -1;
            int low = 0;
            int high = workers.employeesSaveArray.Length - 1;

            while (low <= high) {
                int mid = low + (high - low) / 2;

                if (DateTime.Parse(workers.employeesSaveArray[mid].lastEntranceInEngineRoom) == num) {
                    result = mid;

                    while (mid > 0 && DateTime.Parse(workers.employeesSaveArray[mid - 1].lastEntranceInEngineRoom) == num) {
                        result = mid - 1;
                        mid--;
                    }

                    Debug.Log("Found at index: " + result);
                    return;
                }

                if (DateTime.Parse(workers.employeesSaveArray[mid].lastEntranceInEngineRoom) < num) {
                    low = mid + 1;
                }
                else {
                    high = mid - 1;                    
                }
            }
        }

        void FindRange(Workers workers, int low, int high) {
            if(low > high || high - low + 1 <= 0) {

                Debug.Log(low);
                Debug.Log(high);
                Debug.Log(high - low + 1);
                Debug.LogError("Outside range");
                return;
            }

            resultArray = new Workers.Employees[high - low + 1];
            int j = 0; 
            for(int i = low; i <= high; i++) {
                
                resultArray[j] = workers.employeesSaveArray[i];
                j++;
            }
        }


    }
}
