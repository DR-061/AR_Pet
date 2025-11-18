using UnityEngine;
using UnityEngine.EventSystems;

public class SandwichButtonBehaviour : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private SandwichBehaviour sandwich;
    private bool isDragging;
    private GameObject pressedObject;

    private void Start()
    {
        GameObject sandwichObject = GameObject.FindWithTag("Sandwich");
        sandwichObject.SetActive(false);
        sandwich = sandwichObject.GetComponent<SandwichBehaviour>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressedObject = eventData.pointerCurrentRaycast.gameObject;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject releasedObject = eventData.pointerCurrentRaycast.gameObject;

        if (releasedObject && releasedObject.CompareTag("Pet"))
        {
            releasedObject.GetComponent<PetBehaviour>().FeedSandwich();
        }

        sandwich.ToggleSandwich(false);
        pressedObject = null;
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (!isDragging && pressedObject && pressedObject.CompareTag("SandwichButton"))
        {
            isDragging = true;
            sandwich.ToggleSandwich(true);
        }
    }
}
