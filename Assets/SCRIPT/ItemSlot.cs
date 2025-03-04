using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private GameObject currentItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<DragDrop>(out DragDrop dragDrop))
        {

            if (currentItem != null)
            {
                print("Slot already contains an item!");
                return;
            }


            RectTransform itemRectTransform = collision.gameObject.GetComponent<RectTransform>();
            RectTransform rect = GetComponent<RectTransform>();

            itemRectTransform.anchorMax = rect.anchorMax;
            itemRectTransform.anchorMin = rect.anchorMin;
            itemRectTransform.pivot = rect.pivot;
            itemRectTransform.anchoredPosition = rect.anchoredPosition;


            dragDrop.StartCoroutine(LockItem(dragDrop, 1));
            dragDrop.isSkewered = true;


            currentItem = collision.gameObject;

            print($"Item {collision.gameObject.name} added to the slot.");
        }
    }


    private System.Collections.IEnumerator LockItem(DragDrop dragDrop, float duration)
    {
        dragDrop.SetLock(true);
        yield return new WaitForSeconds(duration);
        dragDrop.SetLock(false);
    }


    public void ClearSlot()
    {
        if (currentItem != null)
        {

            currentItem.transform.SetParent(null);


            RectTransform itemRectTransform = currentItem.GetComponent<RectTransform>();
            itemRectTransform.anchoredPosition = itemRectTransform.anchoredPosition;


            currentItem = null;

            print("Slot cleared.");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentItem)
        {
            ClearSlot();
        }
    }

    private int CheckIngredient(GameObject collidedIngredient)
    {
        if (collidedIngredient.tag == "Zuccini")
        {
            return 1;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 2;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 3;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 4;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 5;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 6;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 7;
        }
        return 0;
    }
}
