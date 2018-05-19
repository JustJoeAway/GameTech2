using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakbehavior : MonoBehaviour {
	private PlayerStatus pstatus;
	// Use this for initialization
	void Start () {
		pstatus = FindObjectOfType<PlayerStatus>();
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
        pstatus.touchitem(0);

    }
}
