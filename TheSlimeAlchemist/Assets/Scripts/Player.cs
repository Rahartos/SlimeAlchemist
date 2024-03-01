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
    public bool reachedDoor = false;

    // for next scene
    private GameObject levelManager;
    public string nextScene;

    public string scene;

    void Start()
    {
        levelManager = GameObject.FindWithTag("GameController");
        if (levelManager != null)
        {
            Debug.Log("Found levelManager: " + levelManager.name);
        }
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
            //Debug.Log("metOxy: " + metOxy);

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

<<<<<<< HEAD
        if (other.gameObject.CompareTag("ENEMY"))
        {
            touchedFire = true;
            Respawn();
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Respawn point: " + transform.position);
            respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
            
        }
=======
             if (other.gameObject.CompareTag("ENEMY")) {
            //     // if slime hits an enemy,
            //     // 1. decrease health
            //     // abc...
            //     // 2. and if healthy reaches 0, respawn?
            //     // if health < 0
            //gameLevelManager.Respawn();
            

            //gameLevelManager.OpenScene(scene);

             }
>>>>>>> Rain5

        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("Reached door");
            reachedDoor = true;

        }

<<<<<<< HEAD
    }

    void Respawn()
    {
        transform.position = respawnPoint;
    }

    public void NextScene()
    {
        levelManager.GetComponent<LevelManager>().OpenScene(nextScene);
    }
     

        void OnApplicationQuit()
        {
            inventory.Container.Clear();
=======
        void OnApplicationQuit() {
            //inventory.Container.Clear();
>>>>>>> Rain5
            inventory.coinAmount = 10;
            //partyinventory.Container.Clear();

            mainDatabase.ResetInPartyValues();
        }
}