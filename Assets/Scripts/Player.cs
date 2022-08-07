using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameManager manager;
	public float moveSpeed;
	public GameObject deathParticles;
	public bool usesManager = true;

	private float maxSpeed = 5f;
	private Vector3 input;

	private Vector3 spawn;

	public AudioClip[] audioClip;


	// Use this for initialization
	void Start () {
		spawn = transform.position;
		if (usesManager)
		{
			manager = manager.GetComponent<GameManager>();
		}
	}

	void FixedUpdate () {
		input = new Vector3(Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		if(rigidbody.velocity.magnitude < maxSpeed)
		{
			rigidbody.AddRelativeForce(input * moveSpeed);
		}

		if (transform.position.y < -2) 
		{
			Die ();
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy")
		{
			Die();
		}
		if (other.transform.tag == "Token")
		{
			if (usesManager)
			{
				manager.tokenCount += 1;
			}
			PlaySound (0);
			Destroy(other.gameObject);
		}
		if (other.transform.tag == "Goal") 
		{
			PlaySound(1);
			Time.timeScale = 0f;
			manager.CompleteLevel();
		}
    }

	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}

	void Die()
	{
		Instantiate(deathParticles, transform.position, Quaternion.Euler(270,0,0));
		transform.position = spawn;
	}
}
