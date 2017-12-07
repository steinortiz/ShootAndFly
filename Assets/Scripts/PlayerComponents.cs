using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerComponents : MonoBehaviour {

	public bool WillPlay;
	public Camera cameraplayer;
	public int PlayerType;
	public GameObject Cannon;
	public GameObject Ball;
	public Vector3 cannonPosition;
	public Vector3 cannonRotation;
	public bool dead =false;
	public bool alreadyShoot=false;

	public GameObject Build;

	public GameObject Canvas;
	public GameObject CanvasAFK;
	public GameObject angle;
	public GameObject power;
	public GameObject arrow;
	public float speed;


	void Start(){
		if (WillPlay) {
			SetCamera ();
			Ball = GameController.control.PlayerBall [PlayerType - 1];
			Revive ();
		} else {
			CanvasAFK.GetComponent<Canvas> ().enabled = true;
		}
	}

	void Update () {
		if (dead) {
			alreadyShoot = true;
			cameraplayer.fieldOfView += 0.15f;
			if (cameraplayer.fieldOfView > 100) {
				cameraplayer.fieldOfView = 60;
				GameController.control.ReadyCollition += 1;
				Revive ();
			}
		}
		speed = this.GetComponent<Rigidbody> ().velocity.magnitude;
					
	}

	void SetCamera (){
		if (GameController.control.PlayersNumber == 2) {
			if (PlayerType == 1) {
				cameraplayer.rect = new Rect(0f, 0.5f, 1f, 0.5f);
			} else {
				cameraplayer.rect = new Rect(0f, 0f, 1f, 0.5f);
			}
		} else {
			if (PlayerType == 1) {
				cameraplayer.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
			} else if (PlayerType == 2) {
				cameraplayer.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
			} else if (PlayerType == 3) {
				cameraplayer.rect = new Rect (0f, 0f, 0.5f, 0.5f);
			} else {
				cameraplayer.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
			}
		}
	}

	public void SetCannonView(){
		this.gameObject.GetComponent<PlayerMovement> ().flyMovement = false;
		this.gameObject.GetComponent<PlayerMovement> ().CannonMovement = true;
		this.gameObject.GetComponent<PlayerMovement> ().buildmovement = false;
		Canvas.GetComponent<Canvas> ().enabled = true;
	}

	public void SetBallView(){
		this.gameObject.GetComponent<PlayerMovement> ().flyMovement = true;
		this.gameObject.GetComponent<PlayerMovement> ().CannonMovement = false;
		this.gameObject.GetComponent<PlayerMovement> ().buildmovement = false;
		Canvas.GetComponent<Canvas> ().enabled = false;
	}
	public void SetBuildView(){
		this.gameObject.GetComponent<PlayerMovement> ().flyMovement = false;
		this.gameObject.GetComponent<PlayerMovement> ().CannonMovement = false;
		this.gameObject.GetComponent<PlayerMovement> ().buildmovement = true;
		Canvas.GetComponent<Canvas> ().enabled = false;
	}

	void Revive(){
		dead = false;
		if (this.gameObject.GetComponent<PlayerEffectController> ().TileRender != null) {
			Destroy (this.gameObject.GetComponent<PlayerEffectController> ().TileRender);
			Destroy (this.gameObject.GetComponent<PlayerEffectController> ().ExplotionRender);
		}
		this.transform.SetPositionAndRotation(Cannon.transform.position, Quaternion.Euler(0f, Cannon.transform.eulerAngles.y,0f));
	}
}
