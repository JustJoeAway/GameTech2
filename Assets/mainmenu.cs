using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void loadframe1(){
		PhotonNetwork.LoadLevel("Frame1");
	}
	public void Keluar(){
		Application.Quit();
	}
	
	
}
