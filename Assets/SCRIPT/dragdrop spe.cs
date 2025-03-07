using UnityEngine;
using UnityEngine.EventSystems;

public class SpettDragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   /* [Tooltip("Här sätter du alla ingredienser. Drag och släpp dina ingrediensobjekt här.")]
   */ public GameObject[] ingredients;  // Lägg till dina ingrediensobjekt här via Inspector

   [SerializeField] private int minIngredients = 10;  // Minst 10 ingredienser krävs för att dra
   [SerializeField] private int maxIngredients = 14;  // Max 14 ingredienser

    private bool canDrag = false;     // Kontroll om spättet kan dras
    bool isDragging = false;
    private Vector3 startPosition;    // Ursprungsposition för spättet
    private CanvasGroup canvasGroup;  // Hantera transparens och raycasts
    ItemSlot slot;
    bool isLocked;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        slot = GetComponent<ItemSlot>();
        startPosition = transform.position;  // Spara startposition
    }

    void Update()
    {
        if (isDragging)
        {
            slot.ResetIngredientsPos();
        }
        // Kolla hur många ingredienser som är på spättet
        canDrag = CheckIngredientsOnSpett() >= minIngredients;  // Tillåt drag om minst 10 är på plats
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        if (canDrag)
        {
            Debug.Log("Spättet börjar dras!");  // 🛠 TEST: Se om detta dyker upp i Console
            canvasGroup.alpha = 0.8f;            // Gör spättet lite genomskinligt vid drag
            canvasGroup.blocksRaycasts = false;   // Tillåt drag genom andra objekt
        }
    }

    public void SetLock(bool lockStatus)
    {
        isLocked = lockStatus;
        Debug.Log("Lock status ändrad till: " + lockStatus);
    }

    // 🛠 FIX: Använder eventData.position för Canvas med Screen Space - Overlay
    public void OnDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        if (canDrag)
        {
            // Flytta spättet till musens position med eventData.position
            transform.position = eventData.position;
            isDragging = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;                 // Återställ opaciteten
        canvasGroup.blocksRaycasts = true;      // Återställ raycasts
        isDragging = false;

        if (!canDrag)
        {
            transform.position = startPosition;  // Återställ till startposition om drag ej är tillåtet
        }
    }

    // Kollar hur många ingredienser som är på spättet
    private int CheckIngredientsOnSpett()
    {
        int count = 0;
        
        for (int i = 0; i < slot.positions.Length; i++)
        {
            if (slot.positions[i].obj != null)
            {
                count++;
            }
        }

       /* foreach (GameObject ingredient in ingredients)
        {
            if (ingredient != null && ingredient.transform.parent == transform)
            {
                count++;  // Räknar bara om ingrediensen är barn till spättet
            }
        }*/
        return count;
    }
}
