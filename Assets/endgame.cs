using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endgame : MonoBehaviour {
	
	public Text name1,name2,score1,score2;
	public GameObject panelwin;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void gameended(string namest, string namend, int scorest, int scorend){
		panelwin.SetActive(true);
		name1.text = ""+namest;
		name2.text = ""+namend;
		score1.text = ""+scorest;
		score2.text = ""+scorend;
	}
}
