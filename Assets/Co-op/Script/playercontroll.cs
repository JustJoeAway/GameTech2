using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroll : MonoBehaviour {
	public float kecepatan;
	private bool hadapKanan = true;
    public Animator anim;
	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D))
		{
            float h = Input.GetAxis("Horizontal");
            anim.SetFloat("Walk", Mathf.Abs(h));

			transform.Translate (Vector2.right * kecepatan * Time.deltaTime);
			if (hadapKanan == false)
			{
				Flip();
				hadapKanan = true;

			}
		}
		else if (Input.GetKey(KeyCode.A))
		{
			transform.Translate (Vector2.right * -kecepatan * Time.deltaTime);
			if (hadapKanan == true)
			{
				Flip();
				hadapKanan = false;

			}
		}

		else
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
	}
	void Flip() {
		hadapKanan = !hadapKanan;
		Vector3 Scale = transform.localScale;
		Scale.x = Scale.x * -1;
		transform.localScale = Scale;
	}
}
