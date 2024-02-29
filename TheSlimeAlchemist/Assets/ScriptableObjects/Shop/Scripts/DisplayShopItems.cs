using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
public class DisplayShopItems : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject shopInventory;
    // Start is called before the first frame update
    static Dictionary<int, bool> itemEnabled = new Dictionary<int, bool>();
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < shopInventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.shopPrefab, this.transform);
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
}
