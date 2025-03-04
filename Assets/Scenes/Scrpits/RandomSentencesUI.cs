using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importera TextMeshPro f�r UI

public class RandomSentencesUI : MonoBehaviour
{
    public TextMeshProUGUI sentenceText; // Referens till UI-texten

    private List<string> sentences = new List<string>
    {
        "Tomat.",
        "Kebab",
        "Sallad",
        "S�s",
        "Gurka",
        "Paprika" 
        
    };

    void Start()
    {
        if (sentenceText != null)
        {
            sentenceText.text = GetRandomSentences(); // Uppdatera UI-texten
        }
        else
        {
            Debug.LogError("Ingen TextMeshProUGUI kopplad till scriptet!");
        }
    }

    // Funktion som h�mtar mellan 2 och 6 slumpm�ssiga meningar
    private string GetRandomSentences()
    {
        int numberOfSentences = Random.Range(2, 7); // Slumpar antal meningar (2 till 6)
        List<string> selectedSentences = new List<string>(); // Lista f�r valda meningar
        List<string> tempSentences = new List<string>(sentences); // Kopia av listan

        for (int i = 0; i < numberOfSentences; i++)
        {
            if (tempSentences.Count == 0) break; // Skydda mot tom lista

            int randomIndex = Random.Range(0, tempSentences.Count);
            selectedSentences.Add(tempSentences[randomIndex]);
            tempSentences.RemoveAt(randomIndex); // Undvika dubbletter
        }

        return string.Join("\n", selectedSentences); // Sl� ihop meningar med radbrytning
    }
}

