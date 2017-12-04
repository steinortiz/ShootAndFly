using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBallC : MonoBehaviour {

	void OnCollisionEnter(Collision collition){
		this.transform.parent.gameObject.GetComponent<PlayerEffectController> ().Explotion ();
		this.transform.parent.gameObject.GetComponent<PlayerEffectController> ().TileRender.transform.GetComponent<ParticleSystem> ().Stop ();
		this.transform.parent.gameObject.GetComponent<PlayerEffectController> ().TileRender.GetComponent<AudioSource> ().Stop ();
		Destroy(this.gameObject);

	}
}
