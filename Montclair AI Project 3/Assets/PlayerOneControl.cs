using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerOneControl : MonoBehaviour 
{
	public float horizontalSpeed;	// higher the number the slower you move
	public float jumpSpeed; 
	private Rigidbody2D rigidBody;	// reference to the rigidBody
	public Vector3 jump;
	public float jumpForce = 2.0f;
	public bool isGrounded = true;

	/// <summary>
	/// Intialization
	/// </summary>
	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
	}
	
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate()
	{
		if (transform.position.y < -2.6)
		{
			isGrounded = true;
		}
        if (Input.GetKey(KeyCode.A))
        {
			rigidBody.AddForce(transform.right * -horizontalSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
			rigidBody.AddForce(transform.right * horizontalSpeed);
        }
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rigidBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			isGrounded = false;
		}
	}
}