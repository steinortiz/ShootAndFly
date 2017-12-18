using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEfect : MonoBehaviour {

	public bool IsBoomb;
	public bool IsReady =false;
	public float radio;
	public Collider[] objetos;
	public GameObject Boom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void AplyEffect(){
		IsReady = true;
		if (IsBoomb) {

			boomb ();
		}
	}


	public void boomb(){
		Instantiate (Boom, transform.position, transform.rotation);
		Collider[] objetos = Physics.OverlapSphere (transform.position, radio);
		foreach (Collider objeto in objetos) {
			if (objeto.gameObject.CompareTag("build") && objeto.GetComponent<BuildEfect>().IsReady){
				Destroy(objeto.gameObject);
			}
		}
		Destroy(this.gameObject);
	}
		
}
