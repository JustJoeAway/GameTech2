using System.Collections;
using System.Collections.Generic;
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
        }
        else if (pv.viewID == 2002)
        {
            player2 = true;
        }
    }
	void Update(){
		if (gob1==null || gob2==null) {
			gob1 = GameObject.Find("Gamemanager 1(Clone)").GetComponent<GameStartEnd>();
			gob2 = GameObject.Find("Gamemanager 2(Clone)").GetComponent<GameStartEnd>();
		}
		if (gob1.player1 && gob2.player2) {
			gamestarted = true;
			Debug.Log("asdasdasd");
		}
	}

    [PunRPC]
    public void Player2login(bool test)
    {
    	this.player1 = true;
		this.player2 = true;
        Debug.Log("Player 2 message");
    }

}
