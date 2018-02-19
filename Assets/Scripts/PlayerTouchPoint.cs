using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTouchPoint : MonoBehaviour
{
	public float speed = 1f;
	private Rigidbody2D mRigidbody2D;
	private Vector3 newPos = Vector3.zero;
	public Text t;

	void Start ()
	{
		mRigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		//transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime);
		transform.position = Vector3.MoveTowards (transform.position, newPos, Time.deltaTime * 100f);
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Began) {
				newPos = Camera.main.ScreenToWorldPoint (touch.position);
				newPos.z = transform.position.z;
			} else if (touch.phase == TouchPhase.Moved) {
				newPos = Camera.main.ScreenToWorldPoint (touch.position);
				newPos.z = transform.position.z;
			} else if (touch.phase == TouchPhase.Ended) {
				newPos = Camera.main.ScreenToWorldPoint (touch.position);
				newPos.z = transform.position.z;
			}
		}
		t.text = newPos.ToString ();
	}

	void FixedUpdate ()
	{
		//mRigidbody2D.MovePosition (Vector3.Lerp (transform.position, newPos, Time.fixedDeltaTime));
		//mRigidbody2D.MovePosition (Vector3.MoveTowards (transform.position, newPos, Time.fixedDeltaTime * 100f));
		//mRigidbody2D.MovePosition (newPos);
	}
}
