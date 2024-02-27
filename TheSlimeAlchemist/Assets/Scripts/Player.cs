using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject partyinventory;

    public ItemDatabaseObject mainDatabase;

    // for respawning
    public Vector3 respawnPoint;
    public LevelManager gameLevelManager;

    void Start()
    {
        respawnPoint = transform.position;
        // playerAnimation = GetComponent<Animator>();
        gameLevelManager = GetComponent<LevelManager>();

    }


         void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Item"))
            {
                Debug.Log("Hit object: " + other.GetComponent<Collider2D>().gameObject.name);
                if (other != null)
                {
                    var item = other.GetComponent<Item>();
                    if (item)
                    {
                        inventory.AddItem(item.item, 1);
                        Destroy(other.gameObject);
                    }
                }
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                Debug.Log("Hit object: " + other.GetComponent<Collider2D>().gameObject.name);
                if (other != null)
                {
                    var item = other.GetComponent<Item>();
                    if (item)
                    {
                        inventory.AddCoinAmount(1);
                        Destroy(other.gameObject);
                    }

                }
            }

            // if (other.gameObject.CompareTag("Enemy")) {
            //     // if slime hits an enemy,
            //     // 1. decrease health
            //     // abc...
            //     // 2. and if healthy reaches 0, respawn?
            //     // if health < 0
            //     gameLevelManager.Respawn();

            // }

            // if (other.gameObject.CompareTag("Checkpoint"))
            // {
            //     respawnPoint = transform.position;
            // }

        }

        void OnApplicationQuit() {
            inventory.Container.Clear();
            inventory.coinAmount = 10;
            partyinventory.Container.Clear();

            mainDatabase.ResetInPartyValues();
        }

    
}
