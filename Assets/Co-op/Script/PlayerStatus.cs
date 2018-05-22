using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : Photon.MonoBehaviour {

	// Use this for initialization
	public bool isthereanitem;
    public Sprite sprite1, sprite2, sprite3;
    public int itemlist = 0;
	public int PlayerScore;
	public Text scoretext;
    private bool sasd;
    public PhotonView pv;
    private Cointbehavior co1;
    private cointbehavior2 co2;
	public Animator anim;
    private void Start()
    {
        isthereanitem = false;
    }
    private void Update()
    {
        if (!pv.isMine)
        {
            isthereanitem = sasd;
        }
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "COIN1" && !isthereanitem && pv.isMine)
        {
            touchitem(2);
            itemlist = 1;
        }
        else if (col.gameObject.tag == "COIN2" && !isthereanitem && pv.isMine)
        {
            touchitem(1);
            col.transform.position = new Vector2(-20, -10);
            co2 = col.GetComponent<cointbehavior2>();
            co2.backtoloop();
            itemlist = 2;

        }
        else if(col.gameObject.tag == "BAG" && isthereanitem && pv.isMine)
        {
			if (itemlist == 1 && col.gameObject.name == "BAK1")
            {
                addscore(500);
                pv.RPC("addscore", PhotonTargets.Others, 500);
				touchitem(0);
				itemlist = 0;
            }
			else if(itemlist == 2 && col.gameObject.name == "BAK2")
            {
                addscore(1000);
                pv.RPC("addscore", PhotonTargets.Others, 1000);
				touchitem(0);
				itemlist = 0;
            }
            
            Debug.Log("BAG TOUCH");
        }
    }


    public void touchitem(int itemid){
        if (pv.isMine)
        {
            if (itemid == 1 && !isthereanitem)
            {
                itemlist = 1;
                isthereanitem = true;
                this.GetComponent<SpriteRenderer>().sprite = sprite2;
				anim.SetTrigger ("Sprite2Idle");
                pv.RPC("setsprite2", PhotonTargets.Others);

                
            }
            else if (itemid == 2 && !isthereanitem)
            {
                itemlist = 2;
                isthereanitem = true;
                this.GetComponent<SpriteRenderer>().sprite = sprite3;
				anim.SetTrigger ("Sprite3Idle");
                pv.RPC("setsprite3", PhotonTargets.Others);
            }

            else
            {
				anim.SetTrigger ("Sprite1Idle");
                itemlist = 0;
                isthereanitem = false;
                this.GetComponent<SpriteRenderer>().sprite = sprite1;
                pv.RPC("setsprite1", PhotonTargets.Others);
            }
        }
		
	}
    [PunRPC]
    public void setsprite1()
    {
        if (!pv.isMine) {
			anim.SetTrigger ("Sprite1Idle");
            this.isthereanitem = false;
            this.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
    }
    [PunRPC]
    public void setsprite2()
    {
			anim.SetTrigger ("Sprite2Idle");
            this.isthereanitem = true;
            this.GetComponent<SpriteRenderer>().sprite = sprite2;
        
    }
        
    [PunRPC]
    public void setsprite3()
    {
		anim.SetTrigger ("Sprite3Idle");
            this.isthereanitem = true;
            this.GetComponent<SpriteRenderer>().sprite = sprite3;
        
    }

    [PunRPC]
    public void senttopool(GameObject jam)
    {
        jam.transform.position = new Vector2(-20, -10);
    }




    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(isthereanitem);
        }
        else
        {
            sasd = (bool)stream.ReceiveNext();
        }
    }

    [PunRPC]
    public void addscore(int score){
		PlayerScore += score;
		scoretext.text = "Score : " + PlayerScore; 
	}

}
