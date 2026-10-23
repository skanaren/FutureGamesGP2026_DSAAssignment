using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "PrintEmployeeOne", menuName = "PrintEmployeeOne")]
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
