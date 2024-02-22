using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "InventorySystem/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemDatabaseObject[] Items;
    public Dictionary<ItemDatabaseObject, int> GetId = new Dictionary<ItemDatabaseObject, int>();

    public void OnAfterDeserialize(){
        GetId = new Dictionary<ItemDatabaseObject, int>();
        for (int i = 0; i < Items.Length; i++){
            GetId.Add(Items[i], i);
        }

    }
    public void OnBeforeSerialize(){

    }
}

