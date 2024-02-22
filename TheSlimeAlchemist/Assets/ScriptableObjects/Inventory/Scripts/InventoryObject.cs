using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemObject coins;
    public int coinAmount = 0;
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddCoinAmount(int value){
        coinAmount += value;
    }
    public void AddItem(ItemObject _item, int _amount){
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++){
            if(Container[i].item == _item){
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }

        if(!hasItem){
            Container.Add(new InventorySlot(_item, _amount));
        }

   }
}



[System.Serializable] //class will show up in the editor in unity
public class InventorySlot{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount){
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value){
        amount += value;
    }   
}
