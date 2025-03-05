using System;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    public List<int> generatedOrder = new List<int>();
    public ItemSlot itemSlot;

    private void Start()
    {
        generatedOrder = GenerateOrder();
 
    }
    private void Update()
    {
        foreach (var item in generatedOrder)
        {
            Debug.Log(item);
        }
            

    }


    // Genererar en array från 3 till 7 storlek
    public List<int> GenerateOrder()
    {
        int orderLength = UnityEngine.Random.Range(3, 8);
        List<int> generateOrder = new List<int>();

        for (int i = 0; i < orderLength; i++)
        {
            int ingredientNumber = UnityEngine.Random.Range(1, 7);
            

            switch (ingredientNumber)
            {
                case 1:
                    // return zuccini
                    generateOrder.Add(ingredientNumber);
                    break;
                case 2:
                    // return tomato
                    generateOrder.Add(ingredientNumber);
                    break;
                case 3:
                    // return mushroom
                    generateOrder.Add(ingredientNumber);
                    break;
                case 4:
                    // return red onion
                    generateOrder.Add(ingredientNumber);
                    break;
                case 5:
                    // return onion
                    generateOrder.Add(ingredientNumber);
                    break;
                case 6:
                    // return bell pepper
                    generateOrder.Add(ingredientNumber);
                    break;
                case 7:
                    // return corn
                    generateOrder.Add(ingredientNumber);
                    break;
            }

        }
        return generateOrder;
    }
}
