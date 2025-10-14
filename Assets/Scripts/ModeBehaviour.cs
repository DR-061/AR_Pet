using UnityEngine;

public class ModeBehaviour : MonoBehaviour
{
    public void ActivateGameObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DesactivateGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void SetRandomColor(GameObject obj)
    {
        obj.GetComponent<MeshRenderer>().material.color =
            new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
    public void SetRotation(GameObject obj)
    {
        obj.transform.Rotate(Vector3.up, 5);
    }
}
