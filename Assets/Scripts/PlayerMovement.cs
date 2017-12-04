using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private float spinSpeed =1;
	public float CannonAngle;
	public bool buildmovement = false;
	public int builSellected;
	public bool CannonMovement = false;
	public bool flyMovement = false;
	private float angle;
	private Rigidbody rb;
	public float initialSpeed;
	private Vector3 speed;
	public float roce;
	public float timer=0;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		timer = 0;

	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 2f && timer >1f) {
			this.GetComponent<shootController> ().CanShoot = true;
		}
		if (buildmovement) {
			this.GetComponent<shootController> ().CanShoot = false;
			buildChange();
			buildupdown ();
			buildspin();
			buildrforward();
			buildLR();
			buildset();
		}
		
		if (CannonMovement) {
			angle = 0f;
			int suma = 360 - (int)CannonAngle;
			this.gameObject.GetComponent<PlayerComponents> ().angle.GetComponent<Text> ().text = suma.ToString();
			cannonUpDown ();
			cannonLeftRight ();
		}
		if (flyMovement) {
			speed = rb.velocity;
			float breaks = 1 - roce;
			rb.velocity = speed * breaks;
			transform.forward = rb.velocity;
			transform.Rotate (0f, 0f, angle);
			flyUpDown ();
			flyLeftRight ();
		}

		
	}
	void cannonUpDown(){
		CannonAngle = this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.eulerAngles.x;
		 
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			if (CannonAngle > 280 && Input.GetAxis ("Vertical") < 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical"), 0f, 0f));
			}
			if (CannonAngle < 350 && Input.GetAxis ("Vertical") > 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical"), 0f, 0f));
			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 2){
			if (CannonAngle > 280 && Input.GetAxis ("Vertical2") < 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical2"), 0f, 0f));
			}
			if (CannonAngle < 350 && Input.GetAxis ("Vertical2") > 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical2"), 0f, 0f));
			}
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 3){
			if (CannonAngle > 280 && Input.GetAxis ("Vertical3") < 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical3"), 0f, 0f));
			}
			if (CannonAngle < 350 && Input.GetAxis ("Vertical3") > 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical3"), 0f, 0f));
			}
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 4){
			if (CannonAngle > 280 && Input.GetAxis ("Vertical4") < 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical4"), 0f, 0f));
			}
			if (CannonAngle < 350 && Input.GetAxis ("Vertical4") > 0) {
				this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical4"), 0f, 0f));
			}
		}

	}
	void cannonLeftRight(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType== 1) {
			transform.Rotate (new Vector3 (0f, spinSpeed*Input.GetAxis ("Horizontal"), 0f));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.RotateAround( this.transform.position, Vector3.up, spinSpeed*Input.GetAxis ("Horizontal"));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.GetComponent<CannonModel> ().SpinWheelRL (Input.GetAxis ("Horizontal"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2){
			transform.Rotate (new Vector3 (0f, spinSpeed*Input.GetAxis ("Horizontal2"), 0f));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.RotateAround( this.transform.position, Vector3.up, spinSpeed*Input.GetAxis ("Horizontal2"));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.GetComponent<CannonModel> ().SpinWheelRL (Input.GetAxis ("Horizontal2"));
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3){
			transform.Rotate (new Vector3 (0f, spinSpeed*Input.GetAxis ("Horizontal3"), 0f));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.RotateAround( this.transform.position, Vector3.up, spinSpeed*Input.GetAxis ("Horizontal3"));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.GetComponent<CannonModel> ().SpinWheelRL (Input.GetAxis ("Horizontal3"));
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4){
			transform.Rotate (new Vector3 (0f, spinSpeed*Input.GetAxis ("Horizontal4"), 0f));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.transform.RotateAround( this.transform.position, Vector3.up, spinSpeed*Input.GetAxis ("Horizontal4"));
			this.gameObject.GetComponent<PlayerComponents> ().Cannon.GetComponent<CannonModel> ().SpinWheelRL (Input.GetAxis ("Horizontal4"));
		}
	}
	void flyUpDown(){


		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==1) {
			transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical"), 0f, 0f));
			float magnitude = rb.velocity.magnitude;
			rb.velocity = transform.forward.normalized * magnitude;
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical2"), 0f, 0f));
			float magnitude = rb.velocity.magnitude;
			rb.velocity = transform.forward.normalized * magnitude;
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical3"), 0f, 0f));
			float magnitude = rb.velocity.magnitude;
			rb.velocity = transform.forward.normalized * magnitude;
		}else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			transform.Rotate (new Vector3 (spinSpeed * Input.GetAxis ("Vertical4"), 0f, 0f));
			float magnitude = rb.velocity.magnitude;
			rb.velocity = transform.forward.normalized * magnitude;
		}

	}
	void flyLeftRight(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			angle += -spinSpeed * Input.GetAxis ("Horizontal");
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			angle+= -spinSpeed*Input.GetAxis ("Horizontal2");
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			angle+= -spinSpeed*Input.GetAxis ("Horizontal3");
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			angle+= -spinSpeed*Input.GetAxis ("Horizontal4");
		}
	}


	void buildChange(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			if (Input.GetButtonDown ("Y_button1")) {
				Vector3 tempPos = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position;
				Quaternion temrot = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.rotation;
				GameObject tempObject = this.gameObject.GetComponent<PlayerComponents> ().Build;
				builSellected += 1;
				if (builSellected == GameController.control.ElementsBuild.Length) {
					builSellected = 0;
				}
				this.gameObject.GetComponent<PlayerComponents> ().Build = Instantiate (GameController.control.ElementsBuild [builSellected], tempPos, temrot);
				Destroy(tempObject);
			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			if (Input.GetButtonDown ("Y_button2")) {
				Vector3 tempPos = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position;
				Quaternion temrot = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.rotation;
				GameObject tempObject = this.gameObject.GetComponent<PlayerComponents> ().Build;
				builSellected += 1;
				if (builSellected == GameController.control.ElementsBuild.Length) {
					builSellected = 0;
				}
				this.gameObject.GetComponent<PlayerComponents> ().Build = Instantiate (GameController.control.ElementsBuild [builSellected], tempPos, temrot);
				Destroy(tempObject);
			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			if (Input.GetButtonDown ("Y_button3")) {
				Vector3 tempPos = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position;
				Quaternion temrot = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.rotation;
				GameObject tempObject = this.gameObject.GetComponent<PlayerComponents> ().Build;
				builSellected += 1;
				if (builSellected == GameController.control.ElementsBuild.Length) {
					builSellected = 0;
				}
				this.gameObject.GetComponent<PlayerComponents> ().Build = Instantiate (GameController.control.ElementsBuild [builSellected], tempPos, temrot);
				Destroy(tempObject);
			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			if (Input.GetButtonDown ("Y_button4")) {
				Vector3 tempPos = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position;
				Quaternion temrot = this.gameObject.GetComponent<PlayerComponents> ().Build.transform.rotation;
				GameObject tempObject = this.gameObject.GetComponent<PlayerComponents> ().Build;
				builSellected += 1;
				if (builSellected == GameController.control.ElementsBuild.Length) {
					builSellected = 0;
				}
				this.gameObject.GetComponent<PlayerComponents> ().Build = Instantiate (GameController.control.ElementsBuild [builSellected], tempPos, temrot);
				Destroy(tempObject);
			}
		}
	}

	void buildupdown (){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position= new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x , this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y + Input.GetAxis ("LRB1"), this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position= new Vector3( this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x , this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y + Input.GetAxis ("LRB2"), this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position= new Vector3( this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x , this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y + Input.GetAxis ("LRB3"), this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position= new Vector3( this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x , this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y + Input.GetAxis ("LRB4"), this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		}
	}

	void buildspin(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.RotateAround(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position, Vector3.up, 1*Input.GetAxis ("LRT1"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.RotateAround(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position, Vector3.up, 1*Input.GetAxis ("LRT2"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.RotateAround(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position, Vector3.up, 1*Input.GetAxis ("LRT3"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.RotateAround(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position, Vector3.up, 1*Input.GetAxis ("LRT4"));
		}
	}

	void buildrforward(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z +Input.GetAxis ("Vertical"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z +Input.GetAxis ("Vertical2"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z +Input.GetAxis ("Vertical3"));
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z +Input.GetAxis ("Vertical4"));
		}
	}
	void buildLR(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x + Input.GetAxis ("Horizontal"),this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x + Input.GetAxis ("Horizontal2"),this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x +Input.GetAxis ("Horizontal3"),this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position = new Vector3(this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.x+ Input.GetAxis ("Horizontal4"),this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.y,this.gameObject.GetComponent<PlayerComponents> ().Build.transform.position.z);
		}
	}
	void buildset(){
		if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType == 1) {
			if (Input.GetButtonDown("Fire1")) {
				buildmovement = false;
				CannonMovement = true;
				timer = 3f;
				GameController.control.playersReady += 1;
				this.GetComponent<PlayerComponents> ().Build.GetComponent<BuildEfect> ().AplyEffect();
				this.gameObject.GetComponent<PlayerComponents> ().Canvas.GetComponent<Canvas> ().enabled = true;
			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==2) {
			if (Input.GetButtonDown ("Fire2") ) {
				buildmovement = false;
				CannonMovement = true;
				timer = 3f;
				GameController.control.playersReady += 1;
				this.GetComponent<PlayerComponents> ().Build.GetComponent<BuildEfect> ().AplyEffect();
				this.gameObject.GetComponent<PlayerComponents> ().Canvas.GetComponent<Canvas> ().enabled = true;
			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==3) {
			if (Input.GetButtonDown ("Fire3") ) {
				buildmovement = false;
				CannonMovement = true;
				timer = 3f;
				GameController.control.playersReady += 1;
				this.GetComponent<PlayerComponents> ().Build.GetComponent<BuildEfect> ().AplyEffect();
				this.gameObject.GetComponent<PlayerComponents> ().Canvas.GetComponent<Canvas> ().enabled = true;

			}
		} else if (this.gameObject.GetComponent<PlayerComponents> ().PlayerType==4) {
			if (Input.GetButtonDown ("Fire4")) {
				buildmovement = false;
				CannonMovement = true;
				timer = 3f;
				GameController.control.playersReady += 1;
				this.GetComponent<PlayerComponents> ().Build.GetComponent<BuildEfect> ().AplyEffect();
				this.gameObject.GetComponent<PlayerComponents> ().Canvas.GetComponent<Canvas> ().enabled = true;
			}
		}
	}
}
