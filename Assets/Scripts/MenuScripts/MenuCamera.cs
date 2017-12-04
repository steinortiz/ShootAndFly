using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

	public GameObject Cannon;
	public GameObject Ball;
	public GameObject Build;
	public GameObject[] BuildModel=new GameObject[2];
	public int builSellected=0;
	public bool CannonMovement;
	public bool flyMovement;
	public bool buildMovement;
	public GameObject texto;

	// Use this for initialization
	void Start () {
		this.transform.SetPositionAndRotation(new Vector3(210.72f, 58.3f, 396.13f), Quaternion.Euler(0f, -90f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
		if (buildMovement) {
			buildChange();
			buildupdown ();
			buildspin();
			buildforward();
			buildLR();
		}

		if (CannonMovement) {
			float suma = 360 - (int)Cannon.transform.eulerAngles.x;
			texto.transform.GetComponent<Text> ().text = suma.ToString ();
			cannonUpDown ();
			cannonLeftRight ();
		}
		if (flyMovement) {
			Ball.transform.forward = this.transform.forward;
			flyUpDown ();
			flyLeftRight ();
		}
	}

	void cannonUpDown(){
		float CannonAngle = Cannon.transform.eulerAngles.x;
		if (CannonAngle > 280 && Input.GetAxis ("Vertical") < 0) {
			Cannon.transform.Rotate (new Vector3 (1 * Input.GetAxis ("Vertical"), 0f, 0f));
		}
		if (CannonAngle < 350 && Input.GetAxis ("Vertical") > 0) {
			Cannon.transform.Rotate (new Vector3 (1 * Input.GetAxis ("Vertical"), 0f, 0f));
		}
	}
	void cannonLeftRight (){
		transform.RotateAround (Cannon.transform.position , Vector3.up ,1*Input.GetAxis ("Horizontal"));
		Cannon.transform.RotateAround( Cannon.transform.position, Vector3.up, 1*Input.GetAxis ("Horizontal"));
		Cannon.GetComponent<CannonModel> ().SpinWheelRL (Input.GetAxis ("Horizontal"));
	}

	void flyUpDown (){
		transform.RotateAround (Ball.transform.position , this.transform.right, Input.GetAxis ("Vertical"));
	}
	void flyLeftRight (){
		transform.RotateAround (Ball.transform.position,this.transform.forward, -Input.GetAxis ("Horizontal"));
	}

	public void CannonCanMove(){
		CannonMovement = true;
		flyMovement = false;
		buildMovement = false;
	}
	public void BallCanMove(){
		CannonMovement = false;
		flyMovement = true;
		buildMovement = false;
	}
	public void BuildCanMove(){
		CannonMovement = false;
		flyMovement = false;
		buildMovement = true;
	}
	public void StopCanMove(){
		CannonMovement = false;
		flyMovement = false;
		buildMovement = false;
	}

	public void MovetoCannon(){
		Cannon.transform.SetPositionAndRotation (new Vector3 (100f, 1.14f, 1.643596f), Quaternion.Euler (-20f, 0f, 0f));
		this.transform.SetPositionAndRotation(new Vector3(100f,1.97f,-2.01f), Quaternion.Euler(0f, Cannon.transform.eulerAngles.y,0f));
	}

	public void MovetoBall(){
		Ball.transform.SetPositionAndRotation (new Vector3 (200f, 20f, 1.643596f), Quaternion.Euler (0f, 0f, 0f));
		this.transform.SetPositionAndRotation(new Vector3(200f,20f,-2.01f), Quaternion.Euler(0f, 0f,0f));
	}
	public void MovetoBuild(){
		Build = Instantiate (BuildModel[builSellected]);
		Build.transform.SetPositionAndRotation (new Vector3(243f,0f,352f), Quaternion.Euler (Vector3.zero));
		this.transform.SetPositionAndRotation(new Vector3(195f,53f,240f), Quaternion.Euler(15f, 0f,0f));
	}

	public void DestroyBuild(){
		Destroy (Build);
		buildMovement = false;
	}

	public void MovetoMenu(){
		this.transform.SetPositionAndRotation(new Vector3(514.25f, 12.1f, 477.57f), Quaternion.Euler(-9f, 35.7f, 0f));
	}

	public void MoveToRace(){
		this.transform.SetPositionAndRotation(new Vector3(215.9f, 35.8f, -81.7f), Quaternion.Euler(4.6f, 145.8f, 1.482f));
	}

	public void MoveToBattle(){
		this.transform.SetPositionAndRotation(new Vector3(250.1f, 24.11f, 576.5f), Quaternion.Euler(14.198f, 225.84f, 0f));
	}

	public void MoveToCredits(){
		this.transform.SetPositionAndRotation(new Vector3(238.639f, 27.33f, -69.818f), Quaternion.Euler(0f, 180f, 0f));
	}

	public void MovetoPlayerSettings(){
		if (GameController.control.PlayersNumber == 2) {
			this.transform.SetPositionAndRotation(new Vector3(5.5f, 2f, 0f), Quaternion.Euler(0f, 0f, 0f));
		}else if (GameController.control.PlayersNumber == 3)  {
			this.transform.SetPositionAndRotation(new Vector3(11f, 2f, 0f), Quaternion.Euler(0f, 0f, 0f));
		}else {
			this.transform.SetPositionAndRotation(new Vector3(0f, 2f, 0f), Quaternion.Euler(0f, 0f, 0f));
		} 

	}

	void buildChange(){
		if (Input.GetButtonDown ("Y_button1")) {
			Vector3 tempPos = Build.transform.position;
			Quaternion temrot = Build.transform.rotation;
			GameObject tempObject = Build;
			builSellected += 1;
			if (builSellected == BuildModel.Length) {
				builSellected = 0;
			}
			Build = Instantiate (BuildModel [builSellected], tempPos, temrot);
			Destroy (tempObject);
		}
	}

	void buildupdown (){
		Build.transform.position= new Vector3(Build.transform.position.x , Build.transform.position.y + Input.GetAxis ("LRB1"), Build.transform.position.z);
	}

	void buildspin(){
		Build.transform.RotateAround(Build.transform.position, Vector3.up, 1*Input.GetAxis ("LRT1"));
	}

	void buildforward(){
		Build.transform.position = new Vector3(Build.transform.position.x, Build.transform.position.y, Build.transform.position.z + Input.GetAxis ("Vertical"));
	}
	void buildLR(){
		Build.transform.position = new Vector3(Build.transform.position.x + Input.GetAxis ("Horizontal"), Build.transform.position.y, Build.transform.position.z);
	}
		
}
