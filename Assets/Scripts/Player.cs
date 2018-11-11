using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed;

	void Start () {
		
		maxSpeed = 10f;
	}
	
	void Update () {

		var totalSpeed = Time.deltaTime * maxSpeed;

		transform.Translate(
			Input.GetAxis("Horizontal") * totalSpeed,
			 0f,
			Input.GetAxis("Vertical") * totalSpeed
		);
	}
}
