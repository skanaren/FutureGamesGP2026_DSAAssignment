using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "DebugPrint Task", menuName = "DebugPrint Task")]
    public class DebugPrintTask : Task {
        [SerializeField]
        private string textToPrint;

        private void Awake() {
            textToPrint = "ewfffffffffffffff";
        }

        public override void Execute() {
            Debug.Log(textToPrint);
        }
    }
}
