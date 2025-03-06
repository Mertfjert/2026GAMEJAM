using UnityEngine;
using UnityEngine.UI;
using TMPro; // F�r TextMeshPro Dropdown

public class MusicBox : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] tracks;
    public TMP_Dropdown trackDropdown; // Dropdown f�r att v�lja l�t
    private int currentTrackIndex = 0;
    private bool isPlaying = false;

    void Start()
    {
        // Ladda sparad volym och sp�r
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        currentTrackIndex = PlayerPrefs.GetInt("CurrentTrack", 0);

        if (tracks.Length > 0)
        {
            audioSource.clip = tracks[currentTrackIndex];
        }

        // Uppdatera dropdown-menyn med l�tnamn
        UpdateDropdown();
        trackDropdown.value = currentTrackIndex; // S�tt r�tt l�t i dropdown
        trackDropdown.onValueChanged.AddListener(SetTrack); // Koppla dropdown till l�tbyte
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
        SetTrack(currentTrackIndex);
    }

    public void SetTrack(int index)
    {
        if (index >= 0 && index < tracks.Length)
        {
            currentTrackIndex = index;
            audioSource.clip = tracks[currentTrackIndex];
            audioSource.Play();
            isPlaying = true;

            // Spara l�tval
            PlayerPrefs.SetInt("CurrentTrack", currentTrackIndex);
            trackDropdown.value = currentTrackIndex; // Uppdatera dropdown
        }
    }

    public void IncreaseVolume()
    {
        audioSource.volume = Mathf.Clamp(audioSource.volume + 0.1f, 0f, 1f);
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
    }

    public void DecreaseVolume()
    {
        audioSource.volume = Mathf.Clamp(audioSource.volume - 0.1f, 0f, 1f);
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
    }

    private void UpdateDropdown()
    {
        if (trackDropdown == null) return;

        trackDropdown.ClearOptions();
        foreach (var track in tracks)
        {
            trackDropdown.options.Add(new TMP_Dropdown.OptionData(track.name));
        }
    }
}
