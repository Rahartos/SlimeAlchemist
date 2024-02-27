using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DisplayParty : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<int, GameObject> itemsDisplayed = new Dictionary<int, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay(); 
        
    }

    public void CreateDisplay(){
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
            //obj.GetComponent<Transform>().localPosition = GetPosition(i);
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

    public void UpdateDisplay(){

        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i].ID))
            {
                itemsDisplayed[inventory.Container[i].ID].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
                //obj.GetComponent<Transform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                Image itemImage = obj.GetComponentsInChildren<Image>()[1];
                if (itemImage != null)
                {
                    itemImage.sprite = inventory.Container[i].item.icon;
                }
                
                itemsDisplayed.Add(inventory.Container[i].ID, obj);
                
            }
        }
    }
}
