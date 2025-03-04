using System.Collections.Generic;
using UnityEngine;
using TMPro; // F�r TextMeshPro
using UnityEngine.UI; // F�r UI-knappen

public class RandomSentencesCube : MonoBehaviour
{
    public TextMeshPro textMesh; // Text p� kuben
    public Button changeTextButton; // Knapp f�r att byta mening

    private List<string> sentences = new List<string>
    {
        "Det h�r �r den f�rsta meningen.",
        "Unity �r ett kraftfullt verktyg!",
        "Kodning �r kul och l�rorikt.",
        "Hur m�nga meningar kan du l�sa?",
        "Slumpm�ssiga meningar dyker upp h�r.",
        "Utveckling av spel �r sp�nnande!"
    };

    void Start()
    {
        if (textMesh != null)
        {
            UpdateText(); // Visa f�rsta slumpm�ssiga meningen vid start
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

    // Slumpar fram en ny mening och uppdaterar texten p� kuben
    public void UpdateText()
    {
        string randomSentence = sentences[Random.Range(0, sentences.Count)];
        textMesh.text = randomSentence;
    }
}

