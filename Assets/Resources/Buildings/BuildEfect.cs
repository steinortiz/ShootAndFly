using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEfect : MonoBehaviour {

	public bool IsBoomb;
	public bool Kill=false;
	public GameObject Objetivo;
	public int objetos=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AplyEffect(){
		if (IsBoomb) {
			Kill = true;
		}
	}

	void OnTiggerEnter(Collider other){
		Objetivo = other.gameObject;
		if (other == null) {
			if (Kill) {
				Destroy (this.gameObject);
			}
		}
		if (Kill) {
			Destroy (Objetivo);
		}
	}
}
