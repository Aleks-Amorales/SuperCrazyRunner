using UnityEngine;
using System.Collections;

public class BtnNewGame : Button {

	protected override void OnClick() {
		gameManager.Restart();
	}
}
