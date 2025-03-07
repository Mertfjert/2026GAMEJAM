using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvasToDisable; // Canvas som ska avaktiveras
    public GameObject canvas3; // Canvas som ska aktiveras

    public void SwitchToCanvas3()
    {
        canvasToDisable.SetActive(false); // St�nger av f�rsta canvas
        canvas3.SetActive(true); // Aktiverar Canvas3
    }
}

