using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private bool isLocked = false;  // To prevent dragging during lock
    private Vector2 originalPosition;  // To snap back if needed

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isLocked) return;  // Prevent dragging if locked
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;  // Make item semi-transparent while dragging
        canvasGroup.blocksRaycasts = false;  // Allow raycasts to pass through while dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isLocked) return;  // Prevent dragging if locked
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isLocked) return;  // Prevent actions if locked
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;  // Restore opacity
        canvasGroup.blocksRaycasts = true;  // Restore raycast blocking
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (!isLocked)
        {
            StartCoroutine(LockItemForSeconds(1));  // Lock the item for 1 seconds
        }
    }

    private IEnumerator LockItemForSeconds(float seconds)
    {
        isLocked = true;
        yield return new WaitForSeconds(seconds);
        isLocked = false;
    }

    // ?? New Method to Fix the Error
    public void SetLock(bool lockStatus)
    {
        isLocked = lockStatus;
    }
}
