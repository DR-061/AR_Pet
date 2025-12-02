using UnityEngine;

public class PersonajilloBackgroundBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float InitialXposition;
    [SerializeField] float FinalXposition;


    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        
        if (transform.localPosition.x >= FinalXposition)
        {
            transform.localPosition = new Vector3(InitialXposition, transform.localPosition.y, transform.localPosition.z);
        }
  
    }
}
