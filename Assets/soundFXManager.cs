using UnityEngine;

public class soundFXManager : MonoBehaviour
{
    public static soundFXManager instance;

    [SerializeField] private AudioSource soundFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the static instance to this object
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }



    public void playSoundFXClip(AudioClip clip, Transform spawnTransForm)
    {
        AudioSource audioSource = Instantiate(soundFX, spawnTransForm.position, Quaternion.identity);

        audioSource.clip = clip;

        audioSource.Play();

        // Get len
        float clipLen = audioSource.clip.length;

        Destroy(audioSource, clipLen);
    }
}
