using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    // L�mnar programmet
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    // Hoppar till n�sta scen fr�n den nuvarande scenen
    public void NextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
