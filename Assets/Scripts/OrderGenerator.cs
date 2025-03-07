using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class OrderGenerator : MonoBehaviour
{
    // Listan för skapade order
    public List<int> generatedOrder = new List<int>();


    public TMP_Text orderText;

    // Sprites för kunder
    public SpriteRenderer customerSpriteRenderer;
    public List<Sprite> customerSprites = new List<Sprite>();

    // Hittar alla variablar baserat på namn, samt generera en order
    private void Start()
    {
        orderText = GameObject.Find("OrderText").GetComponent<TMP_Text>();
        customerSpriteRenderer = GameObject.FindGameObjectWithTag("CustomerIcon").GetComponent<SpriteRenderer>();
        generatedOrder = GenerateOrder();
    }



    // Generera order och customer
    public List<int> GenerateOrder()
    {
        // Randomiserar siffror som används senare
        int orderLength = UnityEngine.Random.Range(3, 8);
        int customer = UnityEngine.Random.Range(0, 2);

        // Skapar en lista
        List<int> generateOrder = new List<int>();

        // Väljer customer icon baserat på den randomiserade siffran
        switch (customer)
        {
            case 0:
                customerSpriteRenderer.sprite = customerSprites[customer];
                break;
            case 1:
                customerSpriteRenderer.sprite = customerSprites[customer];
                break;
            case 2:
                customerSpriteRenderer.sprite = customerSprites[customer];
                break;

        }


        // För antal värde i den randomiserade siffrar körs koden så många gånger
        for (int i = 0; i < orderLength; i++)
        {

            // Slumpar ingredienser baserat på siffra
            int ingredientNumber = UnityEngine.Random.Range(1, 7);
            
            // Väljer ingredienser
            switch (ingredientNumber)
            {
                case 1:
                    // return Zucchini
                    orderText.text += "\n Zucchini";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 2:
                    // return tomato
                    orderText.text += "\n Tomato";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 3:
                    // return mushroom
                    orderText.text += "\n Mushroom";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 4:
                    // return red onion
                    orderText.text += "\n Red Onion";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 5:
                    // return onion
                    orderText.text += "\n Onion";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 6:
                    // return bell pepper
                    orderText.text += "\n Bell Pepper";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 7:
                    // return corn
                    orderText.text += "\n Corn";
                    generateOrder.Add(ingredientNumber);
                    break;
                case 8:
                    // return meatslab
                    orderText.text += "\n Meatslab";
                    generateOrder.Add(ingredientNumber);
                    break;
            }

        }
        return generateOrder;
    }
}
