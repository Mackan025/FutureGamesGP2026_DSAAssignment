using UnityEngine;
using Employees;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SortArray", menuName = "Sort Array Task")]
    public class SortTask : Task {
        [SerializeField] Workers array;

        public override void Execute() {
            Sorting.QuickSort(array);
        }
    }
}

