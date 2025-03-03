
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    int[] generatedOrder;

    private void Start()
    {
        generatedOrder = GenerateOrder();
    }
    private void Update()
    {
        
        for (int i = 0; i == generatedOrder.Length; i++)
        {
            Debug.Log(generatedOrder[i]);
        }
    }


    public static int[] GenerateOrder()
    {
        int orderLength = Random.Range(3, 8);
        int[] ingredientArray = new int[orderLength];

        for (int i = 0; i == orderLength; i++)
        {
            int ingredientNumber = Random.Range(1, 7);
            

            switch (ingredientNumber)
            {
                case 1:
                    // return zuccini
                    ingredientArray[i] = ingredientNumber;
                    break;
                case 2:
                    // return tomato
                    ingredientArray[i] = ingredientNumber;
                    break;
                case 3:
                    // return mushroom
                    ingredientArray[i] = ingredientNumber;
                    break;
                case 4:
                    // return red onion
                    ingredientArray[i] = ingredientNumber;  
                    break;
                case 5:
                    // return onion
                    ingredientArray[i] = ingredientNumber;
                    break;
                case 6:
                    // return bell pepper
                    ingredientArray[i] = ingredientNumber;
                    break;
                case 7:
                    // return corn
                    ingredientArray[i] = ingredientNumber;
                    break;
            }

        }
        return ingredientArray;
    }
}
