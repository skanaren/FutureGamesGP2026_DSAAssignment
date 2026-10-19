using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "PrintEmployeeOne", menuName = "PrintEmployeeOne")]
    public class PrintEmployeeOne : Task {
        [SerializeField] TextAsset jsonFile;
        public override void Execute() {

            if(jsonFile == null) return;

            Employees[] employees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;

            if(employees == null || employees.Length <= 0) return;

            Debug.Log("Name: " + employees[0].name);
            Debug.Log("ID: " + employees[0].employeeId);
            Debug.Log("Has Clearance: " + employees[0].hasEngineRoomClearance);
            Debug.Log("Entered At: " + employees[0].lastEntranceInEngineRoom);
            Debug.Log("Exited At: " + employees[0].lastExitFromEngineRoom);
        }
    }
}
