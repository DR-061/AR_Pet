using UnityEngine;
using UnityEngine.InputSystem;

public class SandwichBehaviour : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private bool isActive = false;

    private void Update()
    {
        if (isActive) MoveToMousePos();
    }

    public void ToggleSandwich(bool isActive)
    {
        this.isActive = isActive;

        if (isActive)
        {
            MoveToMousePos();
        }

        gameObject.SetActive(isActive);
    }

    private void MoveToMousePos()
    {
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
        mouseScreenPos.z = 1;
        Vector3 worldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
        transform.position = worldPos;
    }
}
