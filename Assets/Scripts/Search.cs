using Employees;
using Environment.Tasks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

namespace search {
    [CreateAssetMenu(fileName = "Search", menuName = "Search")]

    public class Search : Task {

        [SerializeField] string lowString;

        [SerializeField] string highString;

        [SerializeField] Workers array;

        [SerializeField] Workers.Employees[] resultArray;

        float startTime;

        public override void Execute() {

            startTime = Time.realtimeSinceStartup;

            DateTime low = DateTime.Parse(lowString);
            DateTime high = DateTime.Parse(highString);

            if(low > high) {
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

            Debug.Log(BenchMark(startTime) + " seconds to Execute");
        }

        void StartBinarySearch(Workers workers, DateTime num, out int result) {

            result = -1;
            int low = 0;
            int high = workers.employeesSaveArray.Length - 1;

            while (low <= high) {
                int mid = low + (high - low) / 2;

                if (DateTime.Parse(workers.employeesSaveArray[mid].lastEntranceInEngineRoom) == num) {
                    result = mid;


                    //if(mid > 0 && DateTime.Parse(workers.employeesSaveArray[mid - 1].lastEntranceInEngineRoom) == num) {
                    //    while(mid > 0 && DateTime.Parse(workers.employeesSaveArray[mid - 1].lastEntranceInEngineRoom) == num) {
                    //        result = mid - 1;
                    //        mid--;
                    //    }
                    //    return;
                    //}
                    //else if (mid > 0 && DateTime.Parse(workers.employeesSaveArray[mid + 1].lastEntranceInEngineRoom) == num) {
                    //    while(mid < workers.employeesSaveArray.Length - 1 && DateTime.Parse(workers.employeesSaveArray[mid + 1].lastEntranceInEngineRoom) == num) {
                    //        result = mid + 1;
                    //        mid++;
                    //    }
                    //    return;
                    //}
                    
                    

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
            if (low > high || high - low + 1 <= 0) return;

            resultArray = new Workers.Employees[high - low + 1];
            int j = 0; 
            for (int i = low; i < high+1; i++) {
                
                resultArray[j] = workers.employeesSaveArray[i];
                j++;
            }
        }

        float BenchMark(float start) {

            float stop = Time.realtimeSinceStartup;

            float time = stop - start;

            return time;
        }
    }
}
