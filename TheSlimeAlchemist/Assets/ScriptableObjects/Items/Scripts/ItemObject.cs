using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Slime,
    Coin,
    Default
}

[CreateAssetMenu(fileName = "default", menuName = "InventorySystem/Items/Default")]
public abstract class ItemObject : ScriptableObject{
    public string id;
    public string displayName;
    public Sprite icon;
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}