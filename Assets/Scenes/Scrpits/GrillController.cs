using UnityEngine;
using UnityEngine.UI;

public class GrillController : MonoBehaviour
{
    public Sprite grillOffSprite;  // Bild n�r grillen �r av
    public Sprite grillOnSprite;   // Bild n�r grillen �r p�
    public AudioSource grillSound; // Ljudk�lla f�r grill-ljudet
    private bool isGrillOn = false; // H�ller koll p� om grillen �r p� eller av
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Button>().onClick.AddListener(ToggleGrill);
    }

    void ToggleGrill()
    {
        isGrillOn = !isGrillOn; // V�xlar mellan av och p�

        if (isGrillOn)
        {
            spriteRenderer.sprite = grillOnSprite; // Byter till "p�" sprite
            grillSound.Play();  // Startar grill-ljudet
        }
        else
        {
            spriteRenderer.sprite = grillOffSprite; // Byter till "av" sprite
            grillSound.Stop();  // Stoppar grill-ljudet
        }
    }
}

