using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class TouchPadPlayer : MonoBehaviour
{

	private Rigidbody2D mRigidbody2D;
	public Text debugText;
	private Vector2 movement;

	void Start ()
	{
		mRigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		debugText.text = new Vector2 (h, v).ToString ();
		movement = new Vector2 (h, v);
	}

	void FixedUpdate ()
	{
		mRigidbody2D.AddForce (movement * 1f);
	}
}
