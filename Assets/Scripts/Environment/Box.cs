using UnityEngine;

namespace Environment
{
    public class Box : MonoBehaviour, IDamageable, IInteractable
    {
        public void OnAttack()
        {
            Debug.Log("I was hit");
        }

        public void OnInteract() {
            Debug.Log("This works!");
        }
    }
}
