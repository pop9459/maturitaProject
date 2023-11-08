using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    static AudioClip staticClickSound;
    private void Awake()
    {
        staticClickSound = clickSound;
    }
    public static void PlayClickSound()
    {
        MainAudioSource.audioSource.PlayOneShot(staticClickSound);
    }
    private void OnMouseDown()
    {
        PlayClickSound();
    }
}
