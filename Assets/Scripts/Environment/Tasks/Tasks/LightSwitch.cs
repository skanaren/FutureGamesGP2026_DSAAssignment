using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Lightswitch", menuName = "Lightswitch")]
    public class LightSwitch : Task {

        [SerializeField] public bool isLightOn = false;

        public override void Execute() {
            isLightOn = !isLightOn;
        }
    }
}
