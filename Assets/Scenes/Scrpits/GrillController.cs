using UnityEngine;
using UnityEngine.UI;

public class GrillController : MonoBehaviour
{
    public Sprite grillOffSprite;  // Bild när grillen är av
    public Sprite grillOnSprite;   // Bild när grillen är på
    public AudioSource grillSound; // Ljudkälla för grill-ljudet
    private bool isGrillOn = false; // Håller koll på om grillen är på eller av
    private Image spriteRenderer;
    public GameObject grillAnim;

    void Start()
    {
        spriteRenderer = GetComponent<Image>();
    }

    // 🔥 Gör metoden PUBLIC så den syns i Unitys OnClick-lista
    public void ToggleGrill()
    {
        isGrillOn = !isGrillOn; // Växlar mellan av och på

        if (isGrillOn)
        {
            //spriteRenderer.sprite = grillOnSprite; // Byter till "på" sprite
            grillSound.Play();  // Startar grill-ljudet
            grillAnim.SetActive(true);
        }
        else
        {
            //spriteRenderer.sprite = grillOffSprite; // Byter till "av" sprite
            grillSound.Stop();  // Stoppar grill-ljudet
            grillAnim.SetActive(false);
        }
    }
}


