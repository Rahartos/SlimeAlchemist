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

    static List<GameObject> childSlots = new List<GameObject>();
    static Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();

    public GameObject icon;

    static List<string> recipes = new List<string>();

    void Start()
    {
        // Iterate through all children of the parent object
        foreach (Transform child in transform)
        {
            // Check if the child has an Image component
            GameObject myChild = child.GetComponent<GameObject>();
            if (myChild != null)
            {
                // Add the Image component to the list
                childSlots.Add(myChild);
            }
        }
    }

    void Update()
{
    for (int i = 0; i < mixingInventory.Container.Count && i < childSlots.Count; i++)
    {
        // Check if the item is present in the mixing inventory and has a positive amount
        if (mixingInventory.Container[i].item != null && mixingInventory.Container[i].amount > 0)
        {
            // Check if the item is already displayed
            if (!itemsDisplayed.ContainsKey(i))
            {
                // Instantiate the icon and set it as a child of the corresponding child slot
                GameObject obj = Instantiate(icon, childSlots[i].transform);
                Image itemImage = obj.GetComponent<Image>(); // Get the Image component of the instantiated icon
                
                if (itemImage != null)
                {
                    itemImage.sprite = mixingInventory.Container[i].item.icon;
                }

                // Add the instantiated icon to the dictionary with the corresponding index
                itemsDisplayed.Add(i, obj);
            }
        }
        else
        {
            // If the item is not present or has a zero amount, remove it from the displayed items
            if (itemsDisplayed.ContainsKey(i))
            {
                Destroy(itemsDisplayed[i]); // Destroy the icon GameObject
                itemsDisplayed.Remove(i); // Remove the entry from the dictionary
            }
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
