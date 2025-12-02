using UnityEngine;

public class PetBehaviour : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip crySound;
    [SerializeField] private AudioClip eatSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCrySound()
    {
        audioSource.PlayOneShot(crySound);
    }

    public void PlayEatSound()
    {
        audioSource.PlayOneShot(eatSound);
    }
}
