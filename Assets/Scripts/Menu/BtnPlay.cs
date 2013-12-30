using UnityEngine;
using System.Collections;

public class BtnPlay : Button {

	protected override void OnClick() {
		gameManager.Pause();
	}
}
