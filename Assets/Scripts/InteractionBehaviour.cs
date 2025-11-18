using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class InteractionBehaviour : MonoBehaviour
{
    private Animator animator;
    private string isInteractingParam = "isInteracting";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<InteractionBehaviour>() != null)
        {
            animator.SetBool(isInteractingParam, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<InteractionBehaviour>() != null)
        {
            animator.SetBool(isInteractingParam, false);
        }
    }
}
