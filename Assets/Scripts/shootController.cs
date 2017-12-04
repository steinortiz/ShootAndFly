using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootController : MonoBehaviour {
	public bool CanShoot = true;
	private bool Fire = false;
	private bool Fire2 = false;
	public float powerShoot;
	public float time = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(this.gameObject.GetComponent<PlayerComponents> ().PlayerType==1){
			if(Input.GetButtonDown ("Fire1") && CanShoot){
				if (Fire== false) {
					Fire2 = false;
					this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.GetComponent<CannonModel> ().PlaySmoke ();
					Fire = true;
					this.gameObject.GetComponent<PlayerComponents> ().arrow.GetComponent<ArrowController> ().ActiveThePower ();
				}else {
					powerShoot = this.gameObject.GetComponent<PlayerComponents> ().arrow.GetComponent<ArrowController> ().PowerValue * 0.7f;
					Fire2 = true;
					this.gameObject.GetComponent<PlayerComponents> ().arrow.GetComponent<ArrowController> ().DesactiveThePower ();
				}

			}
		}else if(this.gameObject.GetComponent<PlayerComponents> ().PlayerType== 2){
			if (Input.GetButtonDown ("Fire2") && CanShoot) {
				if (Fire== false) {
					Fire2 = false;
					this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.GetComponent<CannonModel> ().PlaySmoke ();
					Fire = true;
					this.gameObject.GetComponent<PlayerComponents> ().arrow.GetComponent<ArrowController> ().ActiveThePower ();
				} else {
					powerShoot = this.gameObject.GetComponent<PlayerComponents> ().arrow.GetComponent<ArrowController> ().PowerValue * 0.7f;
					Fire2 = true;
					this.gameObject.GetComponent<PlayerComponents> ().arrow.GetComponent<ArrowController> ().DesactiveThePower ();
				}
			}
		}

		if (Fire) {
			this.gameObject.GetComponent<PlayerMovement> ().CannonMovement = false;
			if (Fire2) {
				Fire = false;
				Fire2 = false;
				preparingShoot();
			}
		}
	}

	void preparingShoot(){
		CanShoot = false;
		this.gameObject.GetComponent<PlayerMovement> ().flyMovement = true;
		this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.GetComponent<CannonModel> ().PlayShoot ();
		this.gameObject.GetComponent<PlayerComponents> ().Canvas.GetComponent<Canvas> ().enabled = false;
		Shoot ();
	}
		

	void Shoot(){
		transform.position = this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.position + this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.forward *10;
		GameObject NewBall = Instantiate (this.gameObject.GetComponent<PlayerComponents> ().Ball) as GameObject;
		NewBall.transform.position = this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.position + this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.forward *10;
		NewBall.transform.parent = this.transform;

		NewBall.transform.forward = this.transform.forward;
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.useGravity = true;
		this.transform.forward = this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.forward;
		rb.velocity = this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.forward * powerShoot;
		transform.GetComponent<PlayerEffectController> ().ShootEffect();

	}
}
