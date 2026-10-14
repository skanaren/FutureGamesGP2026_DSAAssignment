using UnityEngine;

namespace Environment
{
    public class Box : MonoBehaviour, IDamageable
    {
        public void OnAttack()
        {
            Debug.Log("I was hit");
        }
    }
}
