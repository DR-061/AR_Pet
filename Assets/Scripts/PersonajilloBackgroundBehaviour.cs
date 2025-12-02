using UnityEngine;

public class PersonajilloBackgroundBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 100f;

    private RectTransform rectTransform;
    private float imageWidth;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        imageWidth = rectTransform.sizeDelta.x * rectTransform.localScale.x;
    }

    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        if (rectTransform.anchoredPosition.x >= imageWidth)
        {
            float offset = -2f * imageWidth;
            rectTransform.anchoredPosition += new Vector2(offset, 0);
        }
    }
}