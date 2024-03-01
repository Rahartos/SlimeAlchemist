using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class MyPlayerObject: ScriptableObject{
//     public GameObject playerObj;
// }

public class PlayerObject : MonoBehaviour
{
   public GameObject player;
   public GameObject swapPlayer;
   private GameObject obj;

   public InventoryObject partyInventory;
   static Dictionary<int, GameObject> myPlayers = new Dictionary<int, GameObject>();
   //public ItemObject item;

   void Start(){
        //player = GetComponentsInChildren<GameObject>();
        obj = Instantiate(player, this.transform);
        
   }

   void Update(){
    if(player!= swapPlayer){
        player = swapPlayer;
        Destroy(obj);
        obj = Instantiate(player, this.transform);

        if ((Input.GetKeyDown(KeyCode.Exclaim)) &&(partyInventory.Container[i].item.playableCharacter != null)){

        }
    }
   }

   public void playerAssign(ItemObject item){
    swapPlayer = item.playableCharacter;
   }

   public GameObject getPlayer(){
    return player;
   }

//    public void MakeParty(){
//     for (int i = 0; i < partyInventory.Container.Count; i++)
//         {
//             var obj = Instantiate(inventory.Container[i].item.prefab, this.transform);
//             obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");

//             Image itemImage = obj.GetComponentsInChildren<Image>()[1];
//             if (itemImage != null)
//             {
//                 itemImage.sprite = inventory.Container[i].item.icon;
//             }

//             // Use the item ID as the key
//             itemsDisplayed.Add(inventory.Container[i].ID, obj);
//         }
//    }
}
