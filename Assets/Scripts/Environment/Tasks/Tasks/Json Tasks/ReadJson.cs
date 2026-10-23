using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Read Json", menuName = "Read Json")]
    public class ReadJson : Task {
        [SerializeField] TextAsset jsonFile;
        public override void Execute() {

            if(jsonFile == null) return;

            Employees[] employees = JsonUtility.FromJson<EmployeeArray>(jsonFile.text)?.employees;
            EmployeeManager.instance.allEmployees = employees;

            if(employees == null || employees.Length <= 0) return;
        }
    }
}
