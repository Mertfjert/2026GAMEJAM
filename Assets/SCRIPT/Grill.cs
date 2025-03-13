using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrillPosition
{
    public RectTransform transform;
    public bool isOccupied;
    public ItemSlot obj;
}

public class Grill : MonoBehaviour
{
    //public List<int> ingredientsContact = new List<int>();
    public GrillPosition[] positions;
   
    
    
    /*private GameObject currentItem;
    public GameObject currentOrderGenerator;
    public GameObject newOrderGenerator;




    public ScoreSystem scoreSystem;*/



    private void Awake()
    {
       /* currentOrderGenerator = GameObject.FindGameObjectWithTag("Order Generator");
        scoreSystem = GameObject.FindGameObjectWithTag("Score System").GetComponent<ScoreSystem>();*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("kollision");
        if (collision.gameObject.TryGetComponent<ItemSlot>(out ItemSlot skewer))
        {
            print("skewer");
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
                print("kollar platser");
                if (positions[i].isOccupied == false)
                {
                    skewer.ResetIngredientsPos();
                    itemRectTransform.anchorMax = positions[i].transform.anchorMax;
                    itemRectTransform.anchorMin = positions[i].transform.anchorMin;
                    itemRectTransform.pivot = positions[i].transform.pivot;
                    itemRectTransform.position = positions[i].transform.position;
                    skewer.ResetIngredientsPos();
                    positions[i].isOccupied = true;
                    positions[i].obj = skewer;
                    break;
                }
            }



            StartCoroutine(LockItem(skewer, 1));
           // dragDrop.isSkewered = true;



            // currentItem = collision.gameObject;

            print($"Item {collision.gameObject.name} added to the slot.");

           // ingredientsContact.Add(CheckIngredient(collision.gameObject));

          /*  foreach (var item in ingredientsContact)
            {
                Debug.Log(item);
            }
            CheckCompletion(ingredientsContact, newOrderGenerator);*/

        }
    }

   public void ResetSkewersPos()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i].obj.transform.position = positions[i].transform.position;
        }
    }

    private void Update()
    {

        // Kollar om det är klart
       /* currentOrderGenerator = GameObject.FindGameObjectWithTag("Order Generator");
        CheckCompletion(ingredientsContact, newOrderGenerator);*/


        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i].obj != null)
            {
                if (Vector2.Distance(positions[i].transform.position, positions[i].obj.transform.position) > 1)
                {
                    ClearSlot(i);
                    break;
                }
            }
          
        }
    }


    private System.Collections.IEnumerator LockItem(ItemSlot slot, float duration) //Kanske vill ändra
    {
        SpettDragDrop spett = slot.gameObject.GetComponent<SpettDragDrop>();
        spett.SetLock(true);
        yield return new WaitForSeconds(duration);
        spett.SetLock(false);
    }


    public void ClearSlot(int index)
    {


        positions[index].obj.transform.SetParent(transform.parent);
      //  positions[index].obj.GetComponent<DragDrop>().isSkewered = false;

       // ingredientsContact.Remove(CheckIngredient(positions[index].obj));
        positions[index].isOccupied = false;
        positions[index].obj = null;



        /*  RectTransform itemRectTransform = currentItem.GetComponent<RectTransform>();
          itemRectTransform.anchoredPosition = itemRectTransform.anchoredPosition;*/


        //currentItem = null;

        print("Slot cleared.");

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        /* for (int i = 0; i < positions.Length; i++)
         {
             if (positions[i].obj == collision.gameObject)
             {
                 ClearSlot(i);
                 break;
             }
         }*/
    }

  /*  // Kollar vilken ingredient det är och lägger till i listan
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

    // Kollar om listan är lika med varandra
    private void CheckCompletion(List<int> ingredientsOnSkewer, GameObject newOrderGenerator)
    {
        if (ingredientsOnSkewer.SequenceEqual(currentOrderGenerator.GetComponent<OrderGenerator>().generatedOrder))
        {
            Debug.Log("Gameobject deleted");
            Destroy(currentOrderGenerator);
            ingredientsOnSkewer.Clear();
            Instantiate(newOrderGenerator);
            scoreSystem.IncreaseScore();

        }
        if (ingredientsOnSkewer.Count == currentOrderGenerator.GetComponent<OrderGenerator>().generatedOrder.Count)
        {
            Debug.Log("Gameobject deleted");
            Destroy(currentOrderGenerator);
            ingredientsOnSkewer.Clear();
            Instantiate(newOrderGenerator);
            scoreSystem.DecreaseScore();

        }
    }*/
}
