using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class HungerSlider : MonoBehaviour
{
    private Slider hungerSlider;
    [SerializeField] float hungerincrease;

    private void Awake()
    {
        hungerSlider = GetComponent<Slider>();
        hungerSlider.value = hungerSlider.minValue;

    }

    void Update()
    {
        hungerSlider.value += hungerincrease * Time.deltaTime;
        //if (Keyboard.current.escapeKey.wasPressedThisFrame)
        //{
        //    AddHunger(1);
        //}
    }

    public void AddHunger(float food)
    {
        hungerSlider.value = Mathf.Clamp(hungerSlider.value - food, 0, hungerSlider.maxValue);
    }
    
}
