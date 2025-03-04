using UnityEngine;

public class MenuFunctions : MonoBehaviour
{
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
