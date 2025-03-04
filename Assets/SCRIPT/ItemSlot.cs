using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DragDrop>(out DragDrop dragDrop))
        {
            print($"Collided with {collision.gameObject.name}");

            // Move the item to the slot position
            RectTransform itemRectTransform = collision.gameObject.GetComponent<RectTransform>();
            itemRectTransform.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            // Lock the item in place for 1 seconds
            dragDrop.StartCoroutine(LockItem(dragDrop, 1));
        }
    }

    private System.Collections.IEnumerator LockItem(DragDrop dragDrop, float duration)
    {
        dragDrop.SetLock(true);  // Lock the item
        yield return new WaitForSeconds(duration);
        dragDrop.SetLock(false);  // Unlock the item after 1 seconds
    }
}
