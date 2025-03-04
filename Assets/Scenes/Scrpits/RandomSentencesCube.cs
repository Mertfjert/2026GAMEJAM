using System.Collections.Generic;
using UnityEngine;
using TMPro; // För TextMeshPro
using UnityEngine.UI; // För UI-knappen

public class RandomSentencesCube : MonoBehaviour
{
    public TextMeshPro textMesh; // Text på kuben
    public Button changeTextButton; // Knapp för att byta mening

    private List<string> sentences = new List<string>
    {
        "Det här är den första meningen.",
        "Unity är ett kraftfullt verktyg!",
        "Kodning är kul och lärorikt.",
        "Hur många meningar kan du läsa?",
        "Slumpmässiga meningar dyker upp här.",
        "Utveckling av spel är spännande!"
    };

    void Start()
    {
        if (textMesh != null)
        {
            UpdateText(); // Visa första slumpmässiga meningen vid start
        }
        else
        {
            Debug.LogError("Ingen TextMeshPro kopplad till skriptet!");
        }

        // Koppla knappen till funktionen som byter mening
        if (changeTextButton != null)
        {
            changeTextButton.onClick.AddListener(UpdateText);
        }
        else
        {
            Debug.LogError("Ingen knapp kopplad till skriptet!");
        }
    }

    // Slumpar fram en ny mening och uppdaterar texten på kuben
    public void UpdateText()
    {
        string randomSentence = sentences[Random.Range(0, sentences.Count)];
        textMesh.text = randomSentence;
    }
}

