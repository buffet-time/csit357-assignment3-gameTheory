using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed;	// higher the number the slower you move
	private Transform player;
	private Rigidbody2D rigidBody;	// reference to the rigidBody

	/// <summary>
	/// Intialization
	/// </summary>
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("Player").transform;
	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		transform.position += new Vector3(moveHorizontal/ speed, 0, 0);
	}
}