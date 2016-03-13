using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour
{
	// Attach this script to a bullet prefab

	public float speed;
	void Start()
	{
		// Tells the bullet to shoot straight forward
		// This is in the 'Start' method so it's run every time it's instantiated
		// by the 'PlayerMovement' script
		Rigidbody r = (Rigidbody)GetComponent(typeof(Rigidbody));
		r.velocity = transform.up * speed;
	}
}
