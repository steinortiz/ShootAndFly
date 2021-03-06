using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMapController : MonoBehaviour {

	public int selected = 0;
	public Texture[] Maps = new Texture[3];

	void Start(){
		this.GetComponent<CanvasRenderer> ().SetTexture (Maps[selected]);
	}

	public void MoveLeft(){
		selected -= 1;
		if (selected < 0) {
			selected = Maps.Length - 1;
		}
		GameController.control.SceneToPlay = selected;
		this.GetComponent<CanvasRenderer> ().SetTexture (Maps[selected]);

	}

	public void MoveRight(){
		selected += 1;
		if (selected > Maps.Length - 1) {
			selected = 0;
		}
		GameController.control.SceneToPlay = selected;
		this.GetComponent<CanvasRenderer> ().SetTexture (Maps[selected]);
	}

	public void resetTexture(){
		selected = 0;
		this.GetComponent<CanvasRenderer> ().SetTexture (Maps[selected]);
		GameController.control.SceneToPlay = selected;
	}

}