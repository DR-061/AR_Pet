using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class HungerSlider : MonoBehaviour
{
    private Slider hungerSlider;
    [SerializeField] float hungerincrease;

    [SerializeField] PetBehaviour pet;

    private void Awake()
    {
        hungerSlider = GetComponent<Slider>();
        hungerSlider.value = hungerSlider.minValue;

    }

    void Update()
    {
        hungerSlider.value += hungerincrease * Time.deltaTime;

        if (hungerSlider.value >= hungerSlider.maxValue)
        {
            pet.PlayCrySound();
        }
    }

    public void AddHunger(float food)
    {
        hungerSlider.value = Mathf.Clamp(hungerSlider.value - food, 0, hungerSlider.maxValue);
    }

}
