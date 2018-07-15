using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStartEnd : Photon.MonoBehaviour{

    public PhotonView pv;
    public bool gamestarted = false;
    public bool gameover = false;
    public bool player2;
    public bool player1;
	public GameStartEnd gob1, gob2; 
    // Use this for initialization
	void Awake(){
		
	}
    void Start()
    {
        if (pv.viewID == 1002)
        {
            player1 = true;
			this.gameObject.name += "1";
        }
        else if (pv.viewID == 2002)
        {
            player2 = true;
			this.gameObject.name += "2";
        }
    }
	void Update(){
		if (gob1==null || gob2==null) {
			gob1 = GameObject.Find("Gamemanager 1(Clone)1").GetComponent<GameStartEnd>();
			gob2 = GameObject.Find("Gamemanager 1(Clone)2").GetComponent<GameStartEnd>();
		}
		if (gob1!=null && gob2!=null && !gameover) {
			gamestarted = true;
		} else {
			gamestarted = false;
			gameover = true;
		}
	}
	public void loadframe1(){
		SceneManager.LoadScene ("Frame1");
	}

}
