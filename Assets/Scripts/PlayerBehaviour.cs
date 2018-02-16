using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{

	public float speed = 5;
	public Text ScoreText;
	public Text WinText;
	private Rigidbody2D rb2d;
	private int score = 0;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);

		#if UNITY_ANDROID || UNITY_IOS
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {

				Vector3 v = Camera.main.ScreenToWorldPoint (touch.position);

				//Debug.Log ((v - touch.position));
				rb2d.AddForce ((v - transform.position) * speed);
			}
		}
		#endif
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Pickup")) {
			//Destroy (other.gameObject);
			other.gameObject.SetActive (false);
			score += 10;
			ScoreText.text = "SCORE:" + score.ToString ("0000");
		}
		if (KilledAllEnemies ()) {
			WinText.gameObject.SetActive (true);
		}
	}

	bool KilledAllEnemies ()
	{
		var pickups = GameObject.Find ("Pickups").transform.Cast<Transform> ();
		int activeCounts = pickups.Count (o => o.gameObject.activeSelf);
		return (activeCounts == 0);
	}
}
