using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {

	public Camera camarita;
	public GameObject Canvasito;
	public GameObject Final;
	public GameObject finaltext;
	public GameObject Nadie;
	public GameObject[] pointstext = new GameObject[4];


	// Use this for initialization
	void Start () {
		GameController.control.TurnManager = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
