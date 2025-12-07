using UnityEngine;

public class PetBehaviour : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip crySound;
    [SerializeField] private AudioClip eatSound;
    [SerializeField] GameObject characterModel;
    private Vector3 initRotation;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        initRotation = characterModel.transform.eulerAngles;
    }

    public void PlayCrySound()
    {
        audioSource.PlayOneShot(crySound);
        characterModel.transform.eulerAngles = new Vector3(characterModel.transform.eulerAngles.x, characterModel.transform.eulerAngles.y, -90);
    }

    public void PlayEatSound()
    {
        audioSource.PlayOneShot(eatSound);
        characterModel.transform.eulerAngles = initRotation;
    }
}
