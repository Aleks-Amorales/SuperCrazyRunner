using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	public int bonusValue = 1;

	public Score score;

	void Start(){
		score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
	}

	void OnTriggerEnter(){
		PickUp();
	}

	void PickUp(){
		score.AddScore(bonusValue);
		Destroy(gameObject);
	}
}
