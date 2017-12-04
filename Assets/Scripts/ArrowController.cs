using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ArrowController : MonoBehaviour {


	public bool Active = false;
	private bool switcher = false;
	public float PowerValue = 0;
	public GameObject texto;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Active) {
			if (switcher) {
				PowerValue = this.GetComponent<RectTransform> ().position.y - 0.5f;
			} else {
				PowerValue = this.GetComponent<RectTransform> ().position.y + 0.5f;
			}

			if (PowerValue >= 100) {
				switcher = true;
			} else if (PowerValue <= 0) {
				switcher = false;
			}
			this.GetComponent<RectTransform>().position= new Vector3(0f,PowerValue,0f);
			int nuevo = (int)PowerValue;
			texto.GetComponent<Text> ().text = nuevo.ToString ();
		}
	}

	public void ActiveThePower(){
		switcher= false;
		PowerValue= 0;
		this.GetComponent<RectTransform>().position = new Vector3(0f,0f,0f);
		Active = true;
	}
	public void DesactiveThePower(){
		switcher= false;
		this.GetComponent<RectTransform>().position = new Vector3(0f,0f,0f);
		Active = false;
	}
}
