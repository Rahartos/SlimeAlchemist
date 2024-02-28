using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;

    private Transform spawnPoint;
    private Transform playerPos;


    public void OpenScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    public void Respawn()
    {
        // put player back into respawn point
        //playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
    }


// Update is called once per frame
void Update()
    {
                
    }
}
