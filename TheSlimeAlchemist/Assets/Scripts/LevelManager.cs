using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    static string previousScene;
    static string currentScene; 

    public InventoryObject inventory;
    public InventoryObject partyinventory;

    public ItemDatabaseObject mainDatabase;

    private Transform spawnPoint;
    private Transform playerPos;

    private Player player;

    private AudioSource audioSource;
    static List<bool> levelUnlock = new List<bool>();
    


    async void Awake()
    {
        for (int i = 0; i<5; i++){
            levelUnlock.Add(false);
        }
        levelUnlock[0] = true;
        //previousScene = SceneManager.GetActiveScene ().name;
        // makes audio manager persist between scenes
        //DontDestroyOnLoad(gameObject);

        /*
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        */
    }

    void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
        if (Input.GetKeyDown (KeyCode.M) && (SceneManager.GetActiveScene ().name != "MixingScene") && (SceneManager.GetActiveScene ().name != "ShopScreen")) {
            OpenScene("MixingScene");
			
		}
        if (Input.GetKeyDown (KeyCode.O)) {
            OpenScene("ShopScreen");
			
		}
	}


    public void OpenScene(string levelName)
    {
        previousScene = SceneManager.GetActiveScene ().name;
        SceneManager.LoadScene(levelName);

    }

    public void OpenLevel(int i)
    {
        if(levelUnlock[i-1] == true){
            previousScene = SceneManager.GetActiveScene ().name;
            SceneManager.LoadScene("Scene " + i);
        }
        

    }

    public string getSceneName(){
        return SceneManager.GetActiveScene ().name;

    }

    public void UnlockScene(){
        if(SceneManager.GetActiveScene ().name == "Level0"){
            levelUnlock[1] = true;
        } else if(SceneManager.GetActiveScene ().name == "Scene 2"){
            levelUnlock[2] = true;
        }else if(SceneManager.GetActiveScene ().name == "Scene 3"){
            levelUnlock[3] = true;
        }else if(SceneManager.GetActiveScene ().name == "Scene 4"){
            levelUnlock[4] = true;
        }
    }


    public void OpenPrevScene()
    {
        SceneManager.LoadScene(previousScene);

    }

    void Start()
    {
        //gameObject = Find("LevelManager").GetComponent<LevelManager>();
    }

    void OnApplicationQuit()
    {
        inventory.Container.Clear();
        inventory.coinAmount = 10;
        partyinventory.Container.Clear();

        mainDatabase.ResetInPartyValues();
    }


    
}
