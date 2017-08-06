using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	
	void Start ()
	{
		Vector3 movement1 = new Vector3 (0.0f, 0.0f, 1.0f);
		rigidbody.velocity = movement1 * speed;

	}

	

}
