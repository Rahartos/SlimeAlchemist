using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    private void Update(){

        if(Input.GetKeyDown(KeyCode.S)){
            inventory.Save();
        }     
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Item")){
            Debug.Log("Hit object: " + other.GetComponent<Collider2D>().gameObject.name);
            if (other != null){
            var item = other.GetComponent<Item>();
            if(item){
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }
        }

        if(other.gameObject.CompareTag("Coin")){
            Debug.Log("Hit object: " + other.GetComponent<Collider2D>().gameObject.name);
            if (other != null){
            var item = other.GetComponent<Item>();
            if(item){
                inventory.AddCoinAmount(1);
                Destroy(other.gameObject);
            }

        }
    }
    }

   void OnApplicationQuit(){
        inventory.Container.Clear();
        inventory.coinAmount = 10;
    }
    
}
