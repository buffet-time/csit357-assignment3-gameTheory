using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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
	public Text winner;

	void Start()
	{
		health = (int) Random.Range(1.0f, 99.0f);
		rigidBody = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.gameObject.CompareTag("PlayerTwo") && punching)
		{
			playerTwoControl = player.GetComponentInChildren<PlayerTwoControl>();
			playerTwoControl.health -= (int) Random.Range(5.0f, 40.0f);
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
			// start punch animation here
        	StartCoroutine(Punch());
        }
        if (!punching && Input.GetKeyDown(KeyCode.X)) 
		{
			// start kick animation here
        	StartCoroutine(Punch());
        }
	}

	IEnumerator Punch() 
	{
		BoxCollider2D b = playerOne.GetComponent<Collider2D>() as BoxCollider2D;

		punching = true;
		b.size = new Vector2(1f, 0.6644267f);

		yield return new WaitForSeconds(0.1f);
		
		punching = false;
		b.size = new Vector2(0.5150453f, 0.6644267f);
	}

	void Quit()
	{
		float random = Random.Range(0.0f, 10.0f);
		
		if ( random <= 5.0f)
		{
			winner.text = "PLAYER ONE WINS!";

			Time.timeScale = 0f;
		}
		else
		{
			winner.text = "PLAYER TWO WINS!";

			Time.timeScale = 0f;
		}
	}
}