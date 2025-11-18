using System.Collections;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateGameObject(GameObject obj)
    {
        obj.SetActive(true);
       


    }

    public void DeactivateObject(GameObject obj)
    {

        obj.SetActive(false);


    }

    public void SetRandomColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

  
}
