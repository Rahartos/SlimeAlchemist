
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// </summary>
public class GameManager : MonoBehaviour {
	public static GameManager Instance;

	private void Awake(){
		Instance = this;
	}

	/// <summary>
	/// This GameManager will check for input to restart the scene
	/// </summary>
	void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			RestartTheGame ();
		}
	}
		
	/// <summary>
	/// Reloads the current scene.
	/// </summary>
	public void RestartTheGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}

