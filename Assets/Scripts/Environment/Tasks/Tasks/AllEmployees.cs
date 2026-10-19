using System.Threading.Tasks;
using UnityEngine;

namespace Enviornment.Tasks {
    [CreateAssetMenu(fileName = "AllEmployees", menuName = "Scriptable Objects/AllEmployees")]
    public class AllEmployees : Task {
        public override void Execute() {
            Debug.Log("Test");
        }
    }
}

