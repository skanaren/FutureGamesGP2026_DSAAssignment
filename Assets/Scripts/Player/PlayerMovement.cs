using Environment;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerMovement : MonoBehaviour {
        // this is a test change for the git lecture
        [SerializeField]
        private Animator animator = null;

        [Header("Input")]
        [SerializeField]
        private InputActionReference moveAction;
        [SerializeField]
        private InputActionReference interactAction;
        [SerializeField]
        private InputActionReference attackAction;

        [Header("Movement")]
        [SerializeField]
        private float movementSpeed = 10f;
        [Header("Interaction")]
        [SerializeField]
        private float interactionRange = 5f;

        private Vector2 movementInput = Vector2.zero;

        private void Awake() {
            if(!animator) {
                Debug.LogError("Animator not set");
                return;
            }

            if(!moveAction || !interactAction || !attackAction) {
                Debug.LogError("Input actions not set");
                return;
            }

            moveAction.action.performed += OnMove;
            moveAction.action.canceled += OnMove;

            interactAction.action.performed += OnInteract;
            attackAction.action.performed += OnAttack;
        }

        private void OnMove(InputAction.CallbackContext context) {
            movementInput = context.ReadValue<Vector2>();
            animator.SetBool("bIsMoving", movementInput != Vector2.zero);
        }

        private void OnInteract(InputAction.CallbackContext context) {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionRange);
            IInteractable interactable = hit.collider?.gameObject.GetComponentInParent<IInteractable>();
            if(interactable != null) {
                interactable.OnInteract();
            }
        }
        private void OnAttack(InputAction.CallbackContext context) {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionRange);
            IDamageable damageable = hit.collider?.gameObject.GetComponent<IDamageable>();
            if(damageable != null) {
                damageable.OnAttack();
            }
            
        }

        private void Update() {
            transform.position += (new Vector3(movementInput.x, 0f, movementInput.y)) * (movementSpeed * Time.deltaTime);
        }


        private void OnEnable() {
            moveAction.action.Enable();
            interactAction.action.Enable();
            attackAction.action.Enable();
        }

        private void OnDisable() {
            moveAction.action.performed -= OnMove;
            moveAction.action.canceled -= OnMove;

            interactAction.action.performed -= OnInteract;
            attackAction.action.performed -= OnAttack;

            moveAction.action.Disable();
            interactAction.action.Disable();
            attackAction.action.Disable();

        }
    }
}
