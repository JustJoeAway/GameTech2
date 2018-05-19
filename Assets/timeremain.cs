using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeremain : Photon.MonoBehaviour
{

    public PhotonView pv;
    public float waktu = 120f;
    public Text timetext;
    public bool gamestarted = false;
    public bool gameover = false;
    public bool player2;
    public bool player1;

    // Use this for initialization
    void Start()
    {
        
        timetext = GameObject.Find("Canvas/timeremain").GetComponent<Text>();
    }
    private void Update()
    {
        if (pv.viewID == 1001 && pv.isMine)
        {
            countdown();
            pv.RPC("othercountdown", PhotonTargets.Others, waktu);
        }
        
    }

    // Update is called once per frame
    public void countdown()
    {
        waktu -= Time.deltaTime;
        timetext.text = "Time Remain : " + waktu.ToString("F0");
    }

    [PunRPC]
    public void othercountdown(float tess)
    {
        timetext.text = "Time Remain : " + tess.ToString("F0");
    }

   



}
