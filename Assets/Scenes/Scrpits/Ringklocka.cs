using UnityEngine;
using UnityEngine.UI;

public class Ringklocka : MonoBehaviour
{
    public AudioSource dingSound;  // Ljudk�llan

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayDing);
    }

    void PlayDing()
    {
        if (dingSound != null)
        {
            dingSound.Play();  // Spela upp ljudet
        }
    }
}

