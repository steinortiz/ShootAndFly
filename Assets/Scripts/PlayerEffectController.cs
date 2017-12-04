using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectController : MonoBehaviour {
	public GameObject explotionEffect;
	public GameObject tile;
	public GameObject TileRender;
	public GameObject ExplotionRender;

	void Start(){
		explotionEffect = GameController.control.PlayerExplotion [this.GetComponent<PlayerComponents> ().PlayerType - 1];
		tile = GameController.control.PlayerTile [this.GetComponent<PlayerComponents> ().PlayerType - 1];

	}

	public void Explotion(){
		ExplotionRender = Instantiate (explotionEffect, this.transform.position, transform.rotation);
		ExplotionRender.GetComponent<AudioSource> ().Play ();
		Rigidbody rb = this.transform.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
		rb.useGravity = false;
		this.transform.GetComponent<PlayerComponents> ().dead = true;
		this.transform.GetComponent<PlayerMovement> ().flyMovement = false;
	}

	public void ShootEffect(){
		GameObject PrefabTile = tile;
		PrefabTile.transform.position = Vector3.zero;
		TileRender = Instantiate (PrefabTile,transform);
		TileRender.GetComponent<AudioSource> ().Play ();
	}
}