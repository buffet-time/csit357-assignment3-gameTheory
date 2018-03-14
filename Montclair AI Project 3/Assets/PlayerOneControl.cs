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
	public int health;
	private bool punching = false;

	/// <summary>
	/// Intialization
	/// </summary>
	void Start()
	{
		health = (int) Random.Range(1.0f, 99.0f);
		rigidBody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
	}
	
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate()
	{
		if (transform.position.y < -2.71)
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
        if (!punching && Input.GetKeyDown(KeyCode.Z)) 
		{
        	StartCoroutine(Punch(0.5f, 1.25f, transform.forward));
        }
	}

	IEnumerator Punch(float time, float distance, Vector3 direction) 
	{
		punching = true;

		float timer = 0.0f;
		Vector3 orgPos = transform.position;
		direction.Normalize();

		while (timer <= time) 
		{
			Debug.Log("----");
			transform.position = orgPos + (Mathf.Sin(timer / time * Mathf.PI) + 1.0f) * direction;
			yield return null;
			timer += Time.deltaTime;
		}
		transform.position = orgPos;

		punching = false;
		}
}