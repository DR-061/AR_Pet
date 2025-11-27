using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SandwichBehaviour : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private bool isActive = true;
    [SerializeField] private float disappearTime;
    private Rigidbody rb;
    private bool isInMouth;
    [SerializeField] Slider hungerBar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            if (isInMouth)
            {
                hungerBar.value = hungerBar.value - 4f;
                AdManager.instance.ShowAd();
            }
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            StartCoroutine(DisappearSandwich());
        }     
    }

    private void MoveToMousePos()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 1;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
        transform.position = worldPos;
    }

    private IEnumerator DisappearSandwich()
    {
        yield return new WaitForSeconds(disappearTime);
        gameObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mouth"))
        {
            isInMouth = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mouth"))
        {
            isInMouth = false;
        }
    }
}
