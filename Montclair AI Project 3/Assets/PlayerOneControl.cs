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
	public GameObject player;
	public GameObject playerOne;
	private PlayerTwoControl playerTwoControl;

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
	/// For clarity: collision.collider is what the bullet is colliding with
	///            : collision.othercollider is the bullet
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.gameObject.CompareTag("PlayerTwo") && punching)
		{
			playerTwoControl = player.GetComponentInChildren<PlayerTwoControl>();
			playerTwoControl.health -= (int) Random.Range(5.0f, 40.0f);
		}
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
        	StartCoroutine(Punch());
        }
	}

	IEnumerator Punch() 
	{
		BoxCollider2D b = playerOne.GetComponent<Collider2D>() as BoxCollider2D;

		punching = true;
		b.size = new Vector2(3.0f, 3.6f);
		print("extended size");

		yield return new WaitForSeconds(0.1f);
		
		punching = false;
		b.size = new Vector2(2.36f, 3.6f);
		print("retracted size");
	}
}