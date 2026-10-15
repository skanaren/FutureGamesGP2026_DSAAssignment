using Environment;
using Environment.Tasks;
using UnityEngine;

public class Lightcontroller : MonoBehaviour {

    [SerializeField] LightSwitch lightSwitch;
    [SerializeField] GameObject lights;

    private void Start() {
        lightSwitch.isLightOn = false;
    }

    private void Update() {
        lights.SetActive(lightSwitch.isLightOn);
    }
}

