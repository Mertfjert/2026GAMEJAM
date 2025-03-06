using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject mainCanvas;  // Huvudk�ket
    public GameObject sauceCanvas; // S�sstationen

    // �ppna s�sstationen
    public void OpenSauceCanvas()
    {
        mainCanvas.SetActive(false); // D�lj k�ket
        sauceCanvas.SetActive(true); // Visa s�sstationen
    }

    // St�ng s�sstationen
    public void CloseSauceCanvas()
    {
        sauceCanvas.SetActive(false); // D�lj s�sstationen
        mainCanvas.SetActive(true); // Visa k�ket igen
    }
}

