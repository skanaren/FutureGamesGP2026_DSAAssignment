using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "PrintEmployeeTwo", menuName = "PrintEmployeeTwo")]
    public class PrintEmployeeTwo : Task {
        [SerializeField] TextAsset jsonFile;
        public override void Execute() {

            if(jsonFile == null) return;

            Employees[] employees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;

            if(employees == null || employees.Length <= 0) return;

            Debug.Log("Name: " + employees[1].name);
            Debug.Log("ID: " + employees[1].employeeId);
            Debug.Log("Has Clearance: " + employees[1].hasEngineRoomClearance);
            Debug.Log("Entered At: " + employees[1].lastEntranceInEngineRoom);
            Debug.Log("Exited At: " + employees[1].lastExitFromEngineRoom);
        }
    }
}
