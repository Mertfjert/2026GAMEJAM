using UnityEngine;
using UnityEngine.UI;

public class TomatClickUI : MonoBehaviour
{
    public GameObject tomat2Prefab;       // Dra in Tomat 2-prefaben här
    public Canvas canvas;                 // Dra in din Canvas här om behövs
    private bool tomatSpawnad = false;    // För att hindra fler spawn

    public void OnClick()
    {
        Debug.Log("Tomat 1 klickad!");  // 🟢 Kolla om klicket funkar

            if (tomat2Prefab != null)
            {
                // 🟢 Skapar Tomat 2 på Canvas
                GameObject nyTomat = Instantiate(tomat2Prefab, transform.position, Quaternion.identity);

                // 🟢 Se till att Tomat 2 hamnar på Canvasen
                nyTomat.transform.SetParent(transform.parent, false);

                // 🟢 Flytta till rätt position
                RectTransform rectTransform = nyTomat.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                }

                Debug.Log("Tomat 2 spawnad!");
            }
            else
            {
                Debug.LogError("tomat2Prefab är INTE tilldelad i Inspector!");
            }
        
    }
}
