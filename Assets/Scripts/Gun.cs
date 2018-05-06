using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Gun : MonoBehaviour
{
	public GameObject rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.


	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;	
	// Reference to the Animator component.
	public bool check = true;


	public float timeBetweenShots = 0.3333f;  // Allow 3 shots per second
	public float timestamp;

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
	}






	public void Shoot()
	{
		if (Time.time < timestamp)
			return;
		check = true;
		timestamp = Time.time + timeBetweenShots;

		// ... set the animator Shoot trigger parameter and play the audioclip.
		anim.SetTrigger ("Shoot");
		GetComponent<AudioSource> ().Play ();

		GameObject bulletInstance;
		// If the player is facing right...
		if (playerCtrl.facingRight) {
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			bulletInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0);
		} else {
			// Otherwise instantiate the rocket facing left and set it's velocity to the left.
			bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			bulletInstance.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, 0);
		}

		NetworkServer.Spawn (bulletInstance);
	}

}
