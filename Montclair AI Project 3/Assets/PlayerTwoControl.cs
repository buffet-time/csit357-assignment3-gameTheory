using System.Collections;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]

public class PlayerTwoControl : MonoBehaviour 
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
	public GameObject playerTwo;
	private PlayerOneControl playerOneControl;

	void Start()
	{
		health = (int) Random.Range(1.0f, 99.0f);
		rigidBody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.gameObject.CompareTag("PlayerOne") && punching)
		{
			playerOneControl = player.GetComponentInChildren<PlayerOneControl>();
			playerOneControl.health -= (int) Random.Range(5.0f, 40.0f);
		}
	}

	void FixedUpdate()
	{
		if (health <= 0)
		{
			Quit();
		}
		if (transform.position.y < -1.8)
		{
			isGrounded = true;
		}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
			rigidBody.AddForce(transform.right * -horizontalSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
			rigidBody.AddForce(transform.right * horizontalSpeed);
        }
		if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
		{
			rigidBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			isGrounded = false;
		}
        if (!punching && Input.GetKeyDown(KeyCode.K)) 
		{
			// start punch animation here
        	StartCoroutine(Punch());
        }
        if (!punching && Input.GetKeyDown(KeyCode.L)) 
		{
			// start kick animation here
        	StartCoroutine(Punch());
        }
	}

	IEnumerator Punch() 
	{
		BoxCollider2D b = playerTwo.GetComponent<Collider2D>() as BoxCollider2D;

		punching = true;
		b.size = new Vector2(1f, 0.6644267f);

		yield return new WaitForSeconds(0.1f);
		
		punching = false;
		b.size = new Vector2(0.5150453f, 0.6644267f);
	}

	void Quit()
	{
		float random = Random.Range(0.1f, 10.0f);
		
		if ( random <= 5.1f)
		{
			print("Player One Won");

			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;

			#else 
				Application.Quit();

			#endif
		}
		else
		{
			print("Player Two Won");

			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;

			#else 
				Application.Quit();

			#endif
		}
	}
}