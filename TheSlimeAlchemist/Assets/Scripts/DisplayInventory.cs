using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    public int X_START;
    public int Y_START;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    private bool transparencyToggled = false;
    private Image parentImage;
    void Start()
    {
        CreateDisplay();
        parentImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    { 
        UpdateDisplay(); 

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleTransparency();
        }
    }

    public void CreateDisplay(){
        for(int i = 0; i < inventory.Container.Count; i++){
            var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
            obj.GetComponent<Transform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            
            Image itemImage = obj.GetComponentsInChildren<Image>()[1];
            if(itemImage != null)
            {
                itemImage.sprite = inventory.Container[i].item.icon;
            }
            
            
            itemsDisplayed.Add(inventory.Container[i], obj);


        }
    }

    public Vector3 GetPosition(int i){
        return new Vector3(X_START +(X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMN)), 0f);
    }

    public void UpdateDisplay(){
        for(int i = 0; i < inventory.Container.Count; i++){
            if(itemsDisplayed.ContainsKey(inventory.Container[i])){
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else{
                var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
                obj.GetComponent<Transform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                Image itemImage = obj.GetComponentsInChildren<Image>()[1];
                if(itemImage != null)
                {
                itemImage.sprite = inventory.Container[i].item.icon;
                }
                itemsDisplayed.Add(inventory.Container[i], obj);
                obj.SetActive(transparencyToggled);
            }
        }

    }

    private void ToggleTransparency()
    {
        transparencyToggled = !transparencyToggled;

        if (parentImage != null)
        {
            // Toggle the transparency of the parent Image component
            Color imageColor = parentImage.color;
            imageColor.a = transparencyToggled ? 0.0f : 1.0f;
            parentImage.color = imageColor;
        }
        
        
        foreach (var kvp in itemsDisplayed)
        {
            GameObject displayObject = kvp.Value;
            if (displayObject != null)
            {
                // Toggle the visibility of the entire display
                displayObject.SetActive(!transparencyToggled);
            }
        }
    }
}
