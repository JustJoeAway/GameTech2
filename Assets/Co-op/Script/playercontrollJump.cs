using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollJump : MonoBehaviour {
	public float kekuatanloncat;
	public Transform groundCheck;
	public LayerMask ground;
	private bool diTanah = true;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		diTanah = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
		if(Input.GetKeyDown(KeyCode.W) && diTanah == true ) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, kekuatanloncat));

		}
		else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);}
	}
}
