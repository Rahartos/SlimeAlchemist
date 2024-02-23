using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public ItemObject coins;
    public int coinAmount = 0;
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddCoinAmount(int value){
        coinAmount += value;
    }
    public void AddItem(ItemObject _item, int _amount){
        
        for(int i = 0; i < Container.Count; i++){

            if(Container[i].item == _item){
                Container[i].AddAmount(_amount);
                return;
            }
        }    
        Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
   }

   public void OnAfterDeserialize(){
        
        for (int i = 0; i < Container.Count; i++){
            Container[i].item = database.GetItem[Container[i].ID];
        }

    }
    public void OnBeforeSerialize(){

    }

    public void Save(){
        
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();

    }

    public void Load(){

    }
}



[System.Serializable] //class will show up in the editor in unity
public class InventorySlot{
    public ItemObject item;
    public int amount;
    public int ID;
    public InventorySlot(int _id, ItemObject _item, int _amount){
        ID = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value){
        amount += value;
    }   
}
