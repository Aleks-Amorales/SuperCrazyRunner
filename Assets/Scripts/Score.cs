using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public UILabel scoreLabel;

	private int score = 0;

	public void AddScore(int addValue){
		score += addValue;
		scoreLabel.text = score.ToString();
	}
}
