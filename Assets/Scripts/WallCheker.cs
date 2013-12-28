using UnityEngine;
using System.Collections;

public class WallCheker : MonoBehaviour {
	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	void OnTriggerEnter(){
		gameManager.GameOver();
	}
}