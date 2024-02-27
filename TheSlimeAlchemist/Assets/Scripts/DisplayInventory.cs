using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject partyInventory;

    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int X_START;
    public int Y_START;
    
    // Change the dictionary to be more flexible
    Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();

    private bool transparencyToggled = false;
    private Image parentImage;

    void Start()
    {
        CreateDisplay();
        parentImage = GetComponent<Image>();
    }

    void Update()
    { 
        UpdateDisplay(); 

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleTransparency();

            Debug.Log("Dictionary Contents:");

        foreach (var kvp in itemsDisplayed)
        {
            Debug.Log($"Key: {kvp.Key}, Item: {kvp.Value}");
        }
        
        }

        
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
            obj.GetComponent<Transform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

            Image itemImage = obj.GetComponentsInChildren<Image>()[1];
            if (itemImage != null)
            {
                itemImage.sprite = inventory.Container[i].item.icon;
            }

            // Use the item ID as the key
            itemsDisplayed.Add(inventory.Container[i].ID, obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START +(X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i].ID))
            {
                itemsDisplayed[inventory.Container[i].ID].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
                obj.GetComponent<Transform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                Image itemImage = obj.GetComponentsInChildren<Image>()[1];
                if (itemImage != null)
                {
                    itemImage.sprite = inventory.Container[i].item.icon;
                }
                
                itemsDisplayed.Add(inventory.Container[i].ID, obj);
                obj.SetActive(transparencyToggled);
            }
        }
    }

    private void ToggleTransparency()
    {
        transparencyToggled = !transparencyToggled;

        if (parentImage != null)
        {
            Color imageColor = parentImage.color;
            imageColor.a = transparencyToggled ? 0.0f : 1.0f;
            parentImage.color = imageColor;
        }

        foreach (var kvp in itemsDisplayed)
        {
            GameObject displayObject = kvp.Value;
            if (displayObject != null)
            {
                displayObject.SetActive(!transparencyToggled);
            }
        }
    }

    public void AddToParty(SlimeObject _item)
    {
        if (_item != null && inventory.Container.Any(slot => slot.item == _item))
        {
            InventorySlot inventorySlot = inventory.Container.Find(slot => slot.item == _item);

            if (!_item.inParty)
            {
                partyInventory.AddItem(_item, 1);
                inventory.RemoveItem(_item, 1);
                _item.inParty = true;
            }
            else
            {
                inventory.AddItem(_item, 1);
                partyInventory.RemoveItem(_item, 1);
                _item.inParty = false;
            }

            // Clear the dictionary
            itemsDisplayed.Clear();
            // Recreate the display
            CreateDisplay();
        }
    }
}
