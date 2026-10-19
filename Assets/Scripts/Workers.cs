using System;
using UnityEditor.Timeline;
using UnityEngine;



namespace Employees {
    [CreateAssetMenu(fileName = "Employees", menuName = "Scriptable Objects/New Employees Json")]
    
    public class Workers : ScriptableObject {
        [Serializable]
        public class Employees {

            public string name;
            public int employeeId;
            public bool hasEngineRoomClearance;
            public string lastEntranceInEngineRoom;
            public string lastExitFromEngineRoom;


        }

        public class EmployeesArray {
            public Employees[] employees;
        }

        public Employees[] employeesSaveArray;

    }
    
}
