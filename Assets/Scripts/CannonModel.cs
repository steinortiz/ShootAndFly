using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonModel : MonoBehaviour {
	public GameObject smokeEffect;
	public GameObject shootEffect;
	public GameObject leftWheel;
	public GameObject rightWheel;
	public float wheelSpinVelocity = 10f;
	public bool HasWheels;
	public float showinput;


	public void PlaySmoke(){
		smokeEffect.GetComponent<ParticleSystem> ().Play (true);
	}

	public void PlayShoot(){
		shootEffect.GetComponent<ParticleSystem> ().Play (true);
	}

	public void SpinWheelRL(float rightmovement){
		if (HasWheels) {
			if (rightmovement > 0) {
				rightWheel.transform.Rotate (new Vector3 (0f, 0f, wheelSpinVelocity));
				leftWheel.transform.Rotate (new Vector3 (0f, 0f, -wheelSpinVelocity));
			} else if(rightmovement < 0){
				rightWheel.transform.Rotate (new Vector3 (0f, 0f, -wheelSpinVelocity));
				leftWheel.transform.Rotate (new Vector3 (0f, 0f, wheelSpinVelocity));
			}
		}
	}
}