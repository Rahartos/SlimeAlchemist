using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;

    private Transform spawnPoint;
    private Transform playerPos;

    private Player player;

    private AudioSource audioSource;


    void Awake()
    {
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


    public void OpenScene(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }

    void Start()
    {
        //gameObject = Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
