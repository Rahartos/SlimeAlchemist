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

    // for the tutorial dialogue
    public bool gotCoin = false;
    public bool metOxy = false;
    public bool touchedFire = false;


    void Start()
    {
        // initial respawn point is start position of player
        respawnPoint = transform.position;

        // playerAnimation = GetComponent<Animator>();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            metOxy = true;
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
            gotCoin = true;
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            touchedFire = true;
            Respawn();
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawn point: " + transform.position);
            respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
            
        }

    }

    void Respawn()
    {
        transform.position = respawnPoint;
    }
     

        void OnApplicationQuit()
        {
            inventory.Container.Clear();
            inventory.coinAmount = 10;
            partyinventory.Container.Clear();

            mainDatabase.ResetInPartyValues();
        }
}