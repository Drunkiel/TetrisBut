using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public static bool playFallClip;
    public static bool playDeathClip;
    public AudioClip[] fallClips;
    public AudioClip deathClip;
    public Slider effectsSlider;
    public static float effectsVolume;

    public AudioSource audioSource;

    void Update()
    {
        if (playFallClip) PickClip();
        if (playDeathClip) PlayDeathClip();
    }

    public void UpdateVolume()
    {
        effectsVolume = effectsSlider.value;
    }

    void PlayDeathClip ()
    {
        audioSource.volume = effectsVolume;
        audioSource.clip = deathClip;
        audioSource.Play();

        playDeathClip = false;
    }

    public void PickClip()
    {
        int random = Random.Range(0, fallClips.Length);

        audioSource.volume = effectsVolume;
        audioSource.clip = fallClips[random];
        audioSource.Play();

        playFallClip = false;
    }
}
