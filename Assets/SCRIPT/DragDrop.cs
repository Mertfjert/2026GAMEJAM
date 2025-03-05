using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool isLocked = false;  // To prevent dragging during lock
    private Vector2 originalPosition;  // To snap back if needed
    private Canvas canvas;
    public bool isSkewered = false;
    public Sprite skewerSprite;
    Sprite originalSprite;
    Image renderer;

    
    private Vector2 snapPosition = new Vector2(-336, -137);

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        renderer = GetComponent<Image>();
        canvas = FindObjectOfType<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
        originalSprite = renderer.sprite;

        if (canvasGroup == null)
        {
            Debug.LogWarning("CanvasGroup saknas på objektet: " + gameObject.name);
        }
    }

    private void Update()
    {
        if (isSkewered)
        {
            renderer.sprite = skewerSprite;
            renderer.SetNativeSize();
        }
        else
        {
            renderer.sprite = originalSprite;
            renderer.SetNativeSize();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        Debug.Log("OnBeginDrag");

        
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isLocked) return;
        Debug.Log("OnEndDrag");


        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }


        
        rectTransform.anchoredPosition = snapPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (!isLocked)
        {
            StartCoroutine(LockItemForSeconds(1));
        }
    }

    private IEnumerator LockItemForSeconds(float seconds)
    {
        isLocked = true;
        yield return new WaitForSeconds(seconds);
        isLocked = false;
    }

    
    public void SetLock(bool lockStatus)
    {
        isLocked = lockStatus;
        Debug.Log("Lock status ändrad till: " + lockStatus);
    }

}
