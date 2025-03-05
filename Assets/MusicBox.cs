using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] tracks; // Lista med MP3-filer
    private int currentTrackIndex = 0;
    private bool isPlaying = false;

    void Start()
    {
        if (tracks.Length > 0)
        {
            audioSource.clip = tracks[currentTrackIndex];
        }
    }

    public void ToggleMusic()
    {
        if (isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
        isPlaying = !isPlaying;
    }

    public void NextTrack()
    {
        if (tracks.Length == 0) return;

        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;
        audioSource.clip = tracks[currentTrackIndex];
        audioSource.Play();
        isPlaying = true;
    }

    public void IncreaseVolume()
    {
        audioSource.volume = Mathf.Clamp(audioSource.volume + 0.1f, 0f, 1f);
    }

    public void DecreaseVolume()
    {
        audioSource.volume = Mathf.Clamp(audioSource.volume - 0.1f, 0f, 1f);
    }
}

