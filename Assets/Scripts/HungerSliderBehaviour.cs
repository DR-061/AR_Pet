using UnityEngine;
using UnityEngine.UI;


public class HungerSlider : MonoBehaviour
{
    private Slider hungerSlider;
    [SerializeField] float hungerincrease;

    [SerializeField] PetBehaviour pet;

    private bool isStarving;

    private void Awake()
    {
        hungerSlider = GetComponent<Slider>();
        hungerSlider.onValueChanged.AddListener((value) =>
        {
            if (!isStarving && value >= hungerSlider.maxValue)
            {
                isStarving = true;
                pet.PlayCrySound();
            }
            else if (value < hungerSlider.maxValue)
            {
                isStarving = false;
            }
        });
    }

    private void Update()
    {
        hungerSlider.value += hungerincrease * Time.deltaTime;
    }

    public void AddHunger(float food)
    {
        hungerSlider.value = Mathf.Clamp(hungerSlider.value - food, 0, hungerSlider.maxValue);
    }

}
