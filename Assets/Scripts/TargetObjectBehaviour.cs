using UnityEngine;

public class TargetObjectBehaviour : MonoBehaviour
{
    public void ActivateGameObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DeactivateGameObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
