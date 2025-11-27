using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SandwichBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Slider hungerBar;
    private GameObject mouth;

    private bool isActive;
    [SerializeField] private float sandiwchOffset = 0.5f;
    [SerializeField] private float disappearTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isActive = true;
    }

    private void Update()
    {
        if (isActive) MoveToMousePos();
    }

    public void ToggleSandwich(bool isActive)
    {
        this.isActive = isActive;

        if (isActive)
        {
            StopAllCoroutines();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            MoveToMousePos();
            gameObject.SetActive(isActive);
        }
        else
        {
            if (mouth)
            {
                hungerBar = mouth.transform.parent.GetComponentInChildren<Slider>();
                hungerBar.value = hungerBar.value - 4f;
                AdManager.instance.ShowAd();
            }

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            StartCoroutine(DisappearSandwich(mouth));
        }     
    }

    private void MoveToMousePos()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 1f;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
        worldPos.z = hungerBar.transform.position.z + sandiwchOffset;
        transform.position = worldPos;
    }

    private IEnumerator DisappearSandwich(bool inmediate)
    {
        float delay = inmediate ? 0f : disappearTime;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mouth"))
        {
            mouth = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mouth") && other.gameObject == mouth)
        {
            mouth = null;
        }
    }
}
