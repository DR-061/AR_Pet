using UnityEngine;

public class PersonajilloBackgroundBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float initialXOffset;
    [SerializeField] float finalXOffset;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x;
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x;

        if (transform.position.x >= rightEdge + finalXOffset)
        {
            transform.position = new Vector3(leftEdge - initialXOffset, transform.position.y, transform.position.z);
        }
    }
}
