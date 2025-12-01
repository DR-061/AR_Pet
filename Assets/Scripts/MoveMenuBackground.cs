using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMenuBackground : MonoBehaviour
{
    [SerializeField] RawImage background;
    [SerializeField] float x;
    [SerializeField] float y;

    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x,y) * Time.deltaTime, background.uvRect.size);
    }
}
