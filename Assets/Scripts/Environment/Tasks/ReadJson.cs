using System.Threading.Tasks;
using UnityEngine;
using System.Linq;
using Employees;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "ReadJson Task", menuName = "ReadJson Task")]
    public class ReadJson : Task {

        [SerializeField] TextAsset employeesJson;

        [SerializeField] Workers saveFile;
        
        public override void Execute() {
            if (employeesJson == null) return;

            

            Workers.Employees[] employees = JsonUtility.FromJson<Workers.EmployeesArray>(employeesJson.text).employees;

            if (employees == null || employees.Length <= 0) {
                Debug.LogWarning("Empty Employees");
                return;
            }

            saveFile.employeesSaveArray = employees;
        }
    }
}
