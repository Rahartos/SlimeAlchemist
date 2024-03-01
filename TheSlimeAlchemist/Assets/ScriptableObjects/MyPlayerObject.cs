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
    }
   }

   public void playerAssign(ItemObject item){
    swapPlayer = item.playableCharacter;
   }

   public GameObject getPlayer(){
    return player;
   }
}
