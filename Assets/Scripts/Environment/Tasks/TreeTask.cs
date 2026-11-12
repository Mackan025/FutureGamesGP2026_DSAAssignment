using Environment.Tasks;
using System;
using UnityEngine;
using Employees;
using System.Collections.Generic;

namespace tree {
    [CreateAssetMenu(fileName = "TreeTask", menuName = "Scriptable Objects/TreeTask")]

    
    public class TreeTask : Task {

        [SerializeField] Workers array;

        Tree.Tree tree = new Tree.Tree();

        [SerializeField] string lowString = "1970-01-01T00:00:00";
        [SerializeField] string highString = "1970-01-01T00:00:00";

        [SerializeField] bool RangeSearch;


        [SerializeField] List<Workers.Employees> employees;

        float startTime;


        public override void Execute() {

            startTime = Time.realtimeSinceStartup;
            
            AddEmployees();

            DateTime low = DateTime.Parse(lowString);
            DateTime high = DateTime.Parse(highString);

            employees = new List<Workers.Employees>();

            employees.Clear();

            if (RangeSearch) {
                employees = tree.SearchRange(low, high);
            }
            else {
                employees.Add(tree.Search(low).data);
            }

            Debug.Log(BenchMark(startTime) + " seconds to Execute");
        }


        void AddEmployees() {
            for(int i = 0; i < array.employeesSaveArray.Length; i++) {
                tree.Insert(array.employeesSaveArray[i]);
            }
        }

        float BenchMark(float start) {

            float stop = Time.realtimeSinceStartup;

            float time = stop - start;

            return time;
        }
    }

}
