using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMobile1 : MonoBehaviour
{

	public float speed = 5f;

	private Rigidbody2D mRigidbody2D;
	private Vector2 movement;
	public Text debugText;
	public Text speedText;


	// Use this for initialization
	void Start ()
	{
		mRigidbody2D = GetComponent<Rigidbody2D> ();
		movement = Vector2.zero;
	}

	void Update ()
	{
		movement = Vector2.zero;
		if (Input.touchCount > 0) {
			var touch = Input.touches [0];
			if (touch.phase == TouchPhase.Moved) {
				movement = touch.deltaPosition;
				movement.Normalize ();
				debugText.text = "Move:" + movement.ToString ();
			}
		} else {
			var h = Input.GetAxis ("Horizontal");
			var v = Input.GetAxis ("Vertical");
			movement = new Vector2 (h, v);
		}
	}

	void FixedUpdate ()
	{
		mRigidbody2D.AddForce (movement * speed);
		// MovePositionのサンプル。
		// この場合、瞬間移動なので、壁を突き抜ける。
		//mRigidbody2D.MovePosition (new Vector2 (transform.position.x + movement.x, transform.position.y + movement.y));
		debugText.text = "Move:" + movement.ToString ();

		speedText.text = "Speed:" + speed;
	}

	public void SpeedUp ()
	{
		speed += 0.5f;
	}

	public void SpeedDown ()
	{
		speed -= 0.5f;
	}
}
