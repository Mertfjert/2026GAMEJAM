using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    // Lämnar programmet
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    // Hoppar till nästa scen från den nuvarande scenen
    public void NextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
