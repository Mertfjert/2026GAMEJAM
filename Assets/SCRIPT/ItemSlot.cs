using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkewerPosition
{
   public RectTransform transform;
   public bool isOccupied;
   public GameObject obj;
}


public class ItemSlot : MonoBehaviour
{
    public List<int> ingredientsContact = new List<int>();
    public SkewerPosition[] positions;
    private GameObject currentItem;
    public OrderGenerator orderGenerator;
   
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<DragDrop>(out DragDrop dragDrop))
        {

          /*  if (currentItem != null)
            {
                print("Slot already contains an item!");
                return;
            }*/


            RectTransform itemRectTransform = collision.gameObject.GetComponent<RectTransform>();
            // RectTransform rect = GetComponent<RectTransform>();

            /*     itemRectTransform.anchorMax = rect.anchorMax;
                 itemRectTransform.anchorMin = rect.anchorMin;
                 itemRectTransform.pivot = rect.pivot;
                 itemRectTransform.anchoredPosition =  rect.anchoredPosition;
            */

            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i].isOccupied == false)
                {
                    itemRectTransform.anchorMax = positions[i].transform.anchorMax;
                    itemRectTransform.anchorMin = positions[i].transform.anchorMin;
                    itemRectTransform.pivot = positions[i].transform.pivot;
                    itemRectTransform.position = positions[i].transform.position;
                    positions[i].isOccupied = true;
                    positions[i].obj = itemRectTransform.gameObject;
                    break;
                }
            }
           
           

            dragDrop.StartCoroutine(LockItem(dragDrop, 1));
            dragDrop.isSkewered = true;



           // currentItem = collision.gameObject;

            print($"Item {collision.gameObject.name} added to the slot.");

            ingredientsContact.Add(CheckIngredient(collision.gameObject));

            foreach (var item in ingredientsContact)
            {
                Debug.Log(item);
            }
            CheckCompletion(ingredientsContact);

        }
    }

    private void Update()
    {
        CheckCompletion(ingredientsContact);
    }


    private System.Collections.IEnumerator LockItem(DragDrop dragDrop, float duration)
    {
        dragDrop.SetLock(true);
        yield return new WaitForSeconds(duration);
        dragDrop.SetLock(false);
    }


    public void ClearSlot(int index)
    {


            positions[index].obj.transform.SetParent(transform.parent);
            positions[index].obj.GetComponent<DragDrop>().isSkewered = false;

            ingredientsContact.Remove(CheckIngredient(positions[index].obj));
            positions[index].isOccupied = false;
            positions[index].obj = null;

       

            /*  RectTransform itemRectTransform = currentItem.GetComponent<RectTransform>();
              itemRectTransform.anchoredPosition = itemRectTransform.anchoredPosition;*/


            //currentItem = null;

            print("Slot cleared.");
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].obj == collision.gameObject)
            {
                ClearSlot(i);
                break;
            }
        }
    }

    private int CheckIngredient(GameObject collidedIngredient)
    {
        if (collidedIngredient.tag == "Zucchini")
        {
            return 1;
        }
        else if (collidedIngredient.tag == "Tomato")
        {
            return 2;
        }
        else if (collidedIngredient.tag == "Mushrooms")
        {
            return 3;
        }
        else if (collidedIngredient.tag == "Red Onion")
        {
            return 4;
        }
        else if (collidedIngredient.tag == "Onion")
        {
            return 5;
        }
        else if (collidedIngredient.tag == "Bell Pepper")
        {
            return 6;
        }
        else if (collidedIngredient.tag == "Corn")
        {
            return 7;
        }
        else if (collidedIngredient.tag == "Meatslab")
        {
            return 8;
        }
        return 0;
    }

    private void CheckCompletion(List<int> ingredientsOnSkewer)
    {
        if (ingredientsOnSkewer == orderGenerator.generatedOrder)
        {
            Destroy(orderGenerator);
        }
    }
}
