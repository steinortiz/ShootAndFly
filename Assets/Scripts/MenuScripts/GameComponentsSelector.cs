using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponentsSelector : MonoBehaviour {

	public int Player;
	public int selected = 0;
	public bool ball;
	public bool cannon;
	public bool tile;
	public bool expl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ball) {
			this.GetComponent<CanvasRenderer> ().SetTexture (GameController.control.BallsPrev [GameController.control.playersBallSelected [Player-1]]);
			selected = GameController.control.playersBallSelected [Player-1];
		}else if(cannon){
			this.GetComponent<CanvasRenderer> ().SetTexture (GameController.control.CannonPrev [GameController.control.playersCannonSelected [Player-1]]);
			selected = GameController.control.playersCannonSelected [Player-1];
		}else if(tile){
			this.GetComponent<CanvasRenderer> ().SetTexture (GameController.control.TilePrev [GameController.control.playersTileSelected [Player-1]]);
			selected = GameController.control.playersTileSelected [Player-1];
		}else if(expl){
			this.GetComponent<CanvasRenderer> ().SetTexture (GameController.control.ExplotionPrev [GameController.control.playersTileSelected [Player-1]]);
			selected = GameController.control.playersTileSelected [Player-1];
		}
	}

	public void RightButtonAction(){
		

		if (ball) {
			int temp = GameController.control.playersBallSelected [Player-1] + 1;
			if (temp == GameController.control.BallsPrev.Length) {
				temp = 0;
			}
			GameController.control.playersBallSelected [Player-1] = temp;

		}else if(cannon){
			int temp = GameController.control.playersCannonSelected [Player-1] + 1;
			if (temp == GameController.control.CannonPrev.Length) {
				temp = 0;
			}
			GameController.control.playersCannonSelected [Player-1] = temp;

			
		}else if(tile){
			int temp = GameController.control.playersTileSelected [Player-1] + 1;
			if (temp == GameController.control.TilePrev.Length) {
				temp = 0;
			}
			GameController.control.playersTileSelected [Player-1] = temp;

			
		}else if(expl){
			int temp = GameController.control.playersExplotionSelected [Player-1] + 1;
			if (temp == GameController.control.ExplotionPrev.Length) {
				temp = 0;
			}
			GameController.control.playersExplotionSelected [Player-1] = temp;
		}

	}

	public void LeftButtonAction(){
		if (ball) {
			int temp = GameController.control.playersBallSelected [Player-1];
			if (temp == 0) {
				temp = GameController.control.BallsPrev.Length;
			}
			temp -= 1;
			GameController.control.playersBallSelected [Player-1] = temp;

		}else if(cannon){
			int temp = GameController.control.playersCannonSelected [Player-1];
			if (temp == 0) {
				temp = GameController.control.CannonPrev.Length;
			}
			temp -= 1;
			GameController.control.playersCannonSelected [Player-1] = temp;


		}else if(tile){
			int temp = GameController.control.playersTileSelected [Player-1];
			if (temp == 0) {
				temp = GameController.control.TilePrev.Length;
			}
			temp -= 1;
			GameController.control.playersTileSelected [Player-1] = temp;


		}else if(expl){
			int temp = GameController.control.playersExplotionSelected [Player-1];
			if (temp == 0) {
				temp = GameController.control.ExplotionPrev.Length;
			}
			temp -= 1;
			GameController.control.playersExplotionSelected [Player-1] = temp;
		}
	}


}
