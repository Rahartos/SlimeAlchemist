using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public Player gamePlayer;

    public void OpenScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = gamePlayer.GetComponent<Player>();
    }

    public void Respawn()
    {
        gamePlayer.gameObject.SetActive(false);
        // put player back into respawn point
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
