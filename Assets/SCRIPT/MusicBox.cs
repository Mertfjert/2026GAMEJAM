using UnityEngine;
using UnityEngine.UI;
using TMPro; // För TextMeshPro Dropdown

public class MusicBox : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] tracks;
    public TMP_Dropdown trackDropdown; // Dropdown för att välja låt
    private int currentTrackIndex = 0;
    private bool isPlaying = false;

    void Start()
    {
        // Ladda sparad volym och spår
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        currentTrackIndex = PlayerPrefs.GetInt("CurrentTrack", 0);

        if (tracks.Length > 0)
        {
            audioSource.clip = tracks[currentTrackIndex];
        }

        // Uppdatera dropdown-menyn med låtnamn
        UpdateDropdown();
        trackDropdown.value = currentTrackIndex; // Sätt rätt låt i dropdown
        trackDropdown.onValueChanged.AddListener(SetTrack); // Koppla dropdown till låtbyte
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

            // Spara låtval
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
