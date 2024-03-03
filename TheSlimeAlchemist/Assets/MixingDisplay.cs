using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class MixingDisplay : MonoBehaviour
{
    public InventoryObject mixingInventory;
    //public InventoryObject inventory;

    public List<GameObject> childSlots = new List<GameObject>();
    static Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();

    void Start()
    {
        // Iterate through all children of the parent object
        foreach (Transform child in transform)
        {
            // Check if the child has an Image component
            GameObject imageComponent = child.GetComponent<GameObject>();
            if (imageComponent != null)
            {
                // Add the Image component to the list
                childSlots.Add(imageComponent);
            }
        }
    }

    void Update()
    {
        
        for (int i = 0; i < mixingInventory.Container.Count && i < childSlots.Count; i++)
        {
            Image itemImage = childSlots[i].GetComponentsInChildren<Image>()[1];
            
            //int temp amount = 

            // Check if the item has an icon before assigning it
            if (mixingInventory.Container[i].item.icon != null)
            {
                itemImage.sprite = mixingInventory.Container[i].item.icon;
            }
        }
    }


    //  int iconCounter = 0;
    //     int tempAmount = mixingInventory.Container[i].item.amount;

    //     for (int i = 0; i < mixingInventory.Container.Count && i < childImages.Count; i++)
    //     {
    //         Image itemImage = childSlots[i].GetComponentsInChildren<Image>()[1];
            
    //         if(tempAmount > 1){
                
    //         }
    //         // Check if the item has an icon before assigning it
    //         if (mixingInventory.Container[i].item.icon != null)
    //         {
    //             imageComponent.sprite = mixingInventory.Container[i].item.icon;
    //         }
    //     }
}
