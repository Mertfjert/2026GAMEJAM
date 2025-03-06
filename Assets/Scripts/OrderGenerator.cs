using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class OrderGenerator : MonoBehaviour
{
    public List<int> generatedOrder = new List<int>();
    public ItemSlot itemSlot;
    public TMP_Text orderText;

    public SpriteRenderer customerSpriteRenderer;
    public Sprite customerSprite1;
    public Sprite customerSprite2;
    public Sprite customerSprite3;
    public Sprite customerSprite4;




    private void Start()
    {
        orderText = GameObject.Find("OrderText").GetComponent<TMP_Text>();
        itemSlot = GameObject.Find("ItemSlot").GetComponent<ItemSlot>();
        customerSpriteRenderer = GameObject.FindGameObjectWithTag("CustomerIcon").GetComponent<SpriteRenderer>();
        generatedOrder = GenerateOrder();
    }

    private void Update()
    {
        foreach (var item in generatedOrder)
        {
            Debug.Log(item);
        }
    }


    // Genererar en array fr�n 3 till 7 storlek
    public List<int> GenerateOrder()
    {
        int orderLength = UnityEngine.Random.Range(3, 8);
        int customer = UnityEngine.Random.Range(1, 4);
        List<int> generateOrder = new List<int>();

        // V�ljer customer icon
        switch (customer)
        {
            case 1:
                customerSpriteRenderer.sprite = customerSprite1;
                break;
            case 2:
                customerSpriteRenderer.sprite = customerSprite2;
                break;
            case 3:
                customerSpriteRenderer.sprite = customerSprite3;
                break;
            case 4:
                customerSpriteRenderer.sprite = customerSprite4;
                break;
        }


        for (int i = 0; i < orderLength; i++)
        {
            int ingredientNumber = UnityEngine.Random.Range(1, 7);



            
            // V�ljer ingredienser
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
