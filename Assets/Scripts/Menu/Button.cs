using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	protected GameManager gameManager;
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	protected virtual void OnClick(){

	}


}
