﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeremain : Photon.MonoBehaviour
{

    public PhotonView pv;
    public float waktu = 120f;
    public Text timetext;
    public bool gamestarted;
	public bool gameover;
	public int scoreplayer1,scoreplayer2;

    // Use this for initialization
    void Start()
    {
        timetext = GameObject.Find("Canvas/timeremain").GetComponent<Text>();
		{
			if (pv.viewID == 1001)
			{
				this.gameObject.name += "1";
			}
			else if (pv.viewID == 2001)
			{
				this.gameObject.name += "2";
			}
		}
    }
    private void Update()
    {
		
        if (pv.viewID == 1001 && pv.isMine)
        {
			gamestarted = GameObject.Find ("Gamemanager 1(Clone)1").GetComponent<GameStartEnd> ().gamestarted;
			gameover = GameObject.Find ("Gamemanager 1(Clone)1").GetComponent<GameStartEnd> ().gameover;

			if (gamestarted) {
				countdown ();
				pv.RPC ("othercountdown", PhotonTargets.Others, waktu);
			} else if (gameover) {
				timetext.text = "Game Over!!!!!!";
				pv.RPC ("settextother", PhotonTargets.Others, timetext.text);
				scoreplayer1 = GameObject.Find ("MainPlayer (1)(Clone)1").GetComponent<PlayerStatus> ().PlayerScore;
				scoreplayer2 = GameObject.Find ("MainPlayer (1)(Clone)2").GetComponent<PlayerStatus> ().PlayerScore;
				if (scoreplayer1 > scoreplayer2) {
					timetext.text = "You WIN!!!!";
					pv.RPC ("settextother", PhotonTargets.Others, "You LOSE!!!!");
				} else {
					timetext.text = "You LOSE!!!!";
					pv.RPC ("settextother", PhotonTargets.Others, "You WIN!!!!");
				}

			} else {
				timetext.text = "Waiting For Other Player";
			}
            
        }
        
    }

    // Update is called once per frame
    public void countdown()
    {
		if (waktu > 0f) {
			waktu -= Time.deltaTime;
			timetext.text = "Time Remain : " + waktu.ToString ("F0");
		} else {
			GameObject.Find ("Gamemanager 1(Clone)1").GetComponent<GameStartEnd> ().gamestarted = false;
			GameObject.Find ("Gamemanager 1(Clone)1").GetComponent<GameStartEnd> ().gameover = true;
		}
        
    }

    [PunRPC]
    public void othercountdown(float tess)
    {
        timetext.text = "Time Remain : " + tess.ToString("F0");
    }

	[PunRPC]
	public void settextother(string tess)
	{
		timetext.text = tess;
	}


   



}
