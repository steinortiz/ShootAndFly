using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaController : MonoBehaviour {

	public AudioSource audioSource;



	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {		
	}

	void OnCollisionEnter(Collision evento){
		float Suma = 100 + evento.gameObject.GetComponentInParent<PlayerComponents> ().speed;
		GameController.control.puntos [evento.gameObject.GetComponentInParent<PlayerComponents> ().PlayerType-1] = Suma;
		GameController.control.Positions += 1;
	}

}

