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


    public void OpenScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
