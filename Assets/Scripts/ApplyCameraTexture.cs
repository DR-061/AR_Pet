using System.Collections;
using UnityEngine;

public class ApplyCameraTexture : MonoBehaviour
{
    private Renderer modelRenderer;

    private void Start()
    {
        modelRenderer = GetComponent<Renderer>();
        if (modelRenderer == null) modelRenderer = GetComponentInChildren<Renderer>();

        StartCoroutine(ApplyTextureContinuous());
    }

    private IEnumerator ApplyTextureContinuous()
    {
        while (true)
        {
            int x = 640;
            int y = 480;

            Texture2D currentTexture = new Texture2D(x, y);

            yield return new WaitForEndOfFrame();

            currentTexture.ReadPixels(new Rect(0, 0, x, y), 0, 0);
            currentTexture.Apply();
            modelRenderer.material.mainTexture = currentTexture;
        }
    }
}