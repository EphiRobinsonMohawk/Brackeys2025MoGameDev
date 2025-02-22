using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource fireSource;

    public AudioClip wind;
    public AudioClip fire;
    public AudioClip generator;
    public AudioClip scream1;
    public AudioClip scream2;
    public AudioClip scream3;
    public AudioClip scream4;
    public AudioClip chop;

    public void Start()
    {
        musicSource.clip = wind;
        musicSource.Play();
        fireSource.clip = fire;
        fireSource.Play();
        
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
