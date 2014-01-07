using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject body;

	private GameObject game_interface;
	private GameObject game_menu;
	private GameObject player;
	private GameObject road;

	private bool isOnPause = true;
	private bool firstStart = true;
	private bool gameOver = false;

	void Start () {
		game_interface = GameObject.FindGameObjectWithTag("Interface");
		game_interface.SetActive(false);

		game_menu = GameObject.FindGameObjectWithTag("Menu");
		game_menu.SetActive(true);

		player = GameObject.FindGameObjectWithTag("Player");
		player.rigidbody.isKinematic = true;
		player.GetComponent<Player>().enabled = false;

		road = GameObject.FindGameObjectWithTag("Road");
		road.GetComponent<Road>().enabled = false;
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && !firstStart){
			Pause();
		}
	}
	void Sound(bool off){
		if(off){
			AudioListener.volume = 0.0f;
		}
		else{
			AudioListener.volume = 1.0f;
		}


	}
	public void Pause(){
		if (gameOver)
			return;
		if(firstStart){
			Camera.main.GetComponent<ThirdPersonCamera>().enabled = true;
			firstStart = false;
		}

		isOnPause = !isOnPause;

		game_interface.SetActive(!isOnPause);
		game_menu.SetActive(isOnPause);
	
		player.rigidbody.isKinematic = isOnPause;
		player.GetComponentInChildren<Animator>().enabled = !isOnPause;
		player.GetComponent<Player>().enabled = !isOnPause;

		road.GetComponent<Road>().enabled = !isOnPause;
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void Exit(){
		Application.Quit();
	}

	public void GameOver(){
		gameOver = true;

		road.GetComponent<Road>().enabled = false;
		player.SetActive(false);

		body.transform.parent = null;
		body.SetActive(true);

		Invoke("Restart",4);
	}
}
