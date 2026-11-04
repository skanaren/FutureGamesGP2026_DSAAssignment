using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "PrintEmployees", menuName = "Scriptable Objects/PrintEmployees")]
    public class PrintEmployees : Task {
        public override void Execute() {

            foreach(Employees employees in EmployeeManager.instance.allEmployees) {

                
                Debug.Log(employees.name + "\n" + employees.lastEntranceInEngineRoom);

            }
        }
    }
}
