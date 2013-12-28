using UnityEngine;
using System.Collections;

public class BtnNewGame : MonoBehaviour {
	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	void OnClick() {
		gameManager.Restart();
	}
}
