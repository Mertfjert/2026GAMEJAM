using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject mainCanvas;  // Huvudköket
    public GameObject sauceCanvas; // Såsstationen

    // Öppna såsstationen
    public void OpenSauceCanvas()
    {
        mainCanvas.SetActive(false); // Dölj köket
        sauceCanvas.SetActive(true); // Visa såsstationen
    }

    // Stäng såsstationen
    public void CloseSauceCanvas()
    {
        sauceCanvas.SetActive(false); // Dölj såsstationen
        mainCanvas.SetActive(true); // Visa köket igen
    }
}

