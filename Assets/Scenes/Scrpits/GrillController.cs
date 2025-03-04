using UnityEngine;
using UnityEngine.UI;

public class GrillController : MonoBehaviour
{
    public Sprite grillOffSprite;  // Bild när grillen är av
    public Sprite grillOnSprite;   // Bild när grillen är på
    public AudioSource grillSound; // Ljudkälla för grill-ljudet
    private bool isGrillOn = false; // Håller koll på om grillen är på eller av
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Button>().onClick.AddListener(ToggleGrill);
    }

    void ToggleGrill()
    {
        isGrillOn = !isGrillOn; // Växlar mellan av och på

        if (isGrillOn)
        {
            spriteRenderer.sprite = grillOnSprite; // Byter till "på" sprite
            grillSound.Play();  // Startar grill-ljudet
        }
        else
        {
            spriteRenderer.sprite = grillOffSprite; // Byter till "av" sprite
            grillSound.Stop();  // Stoppar grill-ljudet
        }
    }
}

