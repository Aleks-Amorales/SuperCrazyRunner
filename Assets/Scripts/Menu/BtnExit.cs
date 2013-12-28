using UnityEngine;
using System.Collections;

public class BtnExit : MonoBehaviour {
	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	void OnClick() {
		gameManager.Exit();
	}

}
