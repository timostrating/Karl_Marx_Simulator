using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	// Player speed
	public float speed = 6f;

	// Player Fire rate...  0.25 = 4 fires per second.
	public float fireRate = 0.25f;

	// For shot to work you must have a bullet prefab attached to 'Shot' in the inspector
	// on this script, while this script is attached to the player game object.  
	public GameObject shot;
	
	// For shotSpawn to work you must do the same thing as with the 'shot' GameObject.
	// What I did is have an empty game object positioned where I want the bullet to be instantiated
	// I called it 'ShotSpawn' and made it a child of the 'player' game object. Attach it to 'Shot Spawn'
	// in the inspector of the player game object.
	public Transform shotSpawn;


	public float nextFire;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		// Basic controls to control the character.
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
		}

		if (Input.GetKey(KeyCode.W))
		{
			transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
		}
	}
}
