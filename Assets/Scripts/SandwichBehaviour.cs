using System.Collections;
using TMPro;
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

    [SerializeField] private int sandwichesAmount = 4;
    [SerializeField] private TextMeshProUGUI sandwichesAmountText;
    [SerializeField] private Button watchAddButton;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isActive = true;
    }

    private void Start()
    {
        UpdateSandiwches(0);
        watchAddButton.onClick.AddListener(() => AdManager.instance.ShowAd());
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
            UpdateSandiwches(-1);

            if (mouth)
            {
                hungerBar = mouth.transform.parent.GetComponentInChildren<Slider>();
                hungerBar.value = hungerBar.value - 4f;
            }

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (gameObject.activeSelf)
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

    public void UpdateSandiwches(int amountChange)
    {
        sandwichesAmount += amountChange;

        sandwichesAmountText.text = $"x {sandwichesAmount}";

        if (sandwichesAmount <= 0)
        {
            watchAddButton.gameObject.SetActive(true);
        }
        else
        {
            watchAddButton.gameObject.SetActive(false);
        }
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

    private int marks = 0;

    public void mark()
    {
        ++marks;
        if (marks == 2)
        {
            gameObject.SetActive(false);
        }
    }
}
