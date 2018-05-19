using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermove : Photon.MonoBehaviour {
    public bool DevTesting = false;
    public PhotonView pv;
    public SpriteRenderer sprite;
    public float movespeed = 5;
    public float jumpforce = 500;
    public float h;
    private Vector3 selfPOs;
    public Rigidbody2D rg;
    public bool grd = false;
    public Text pnametext;
    public GameObject pcam;
    private GameObject scenecam;
    public Animator anim;

    private void Awake()
    {
        
        if(!DevTesting && pv.isMine)
        {
            scenecam = GameObject.Find("Main Camera");
            scenecam.SetActive(false);
            pcam.SetActive(true);
        }
    }
    private void Update()
    {
       
        if (!DevTesting)
        {
            if (pv.isMine)
                CheckInput();
            else
                SmoothNetMovement();
        }
        else
            CheckInput();
        
    }

    private void CheckInput()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * movespeed * Time.deltaTime;
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Walk", Mathf.Abs(h));
        anim.SetBool("GROUND", grd);
        if (Input.GetKeyDown(KeyCode.W) && grd == true)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = false;
            pv.RPC("OnSpriteFlipFalse", PhotonTargets.Others);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = true;
            pv.RPC("OnSpriteFlipTrue", PhotonTargets.Others);
        }
    }

    void Jump()
    {
       // rg.AddForce(Vector2.up * jumpforce);
        rg.AddForce(new Vector2(0,jumpforce));
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!DevTesting)
        {
            if (pv.isMine)
            {
                if(coll.gameObject.tag == "Ground")
                        {
                             grd = true;
                    
                }
            }   
        }
        else
        {
            if (coll.gameObject.tag == "Ground")
            {
                grd = true;
            }
        }
       
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (!DevTesting)
        {
            if (pv.isMine)
            {
                if (coll.gameObject.tag == "Ground")
                {
                    grd = false;
                    
                }
            }
        }
        else
        {
            if (coll.gameObject.tag == "Ground")
            {
                grd = false;
            }
        }
    }
    private void SmoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPOs, Time.deltaTime * 8);
        anim.SetFloat("Walk", Mathf.Abs(h));
        anim.SetBool("GROUND", grd);
    }

    [PunRPC]
    private void OnSpriteFlipFalse()
    {
        sprite.flipX = false;
    }
    [PunRPC]
    private void OnSpriteFlipTrue()
    {
        sprite.flipX = true;
    }
    private void OnPhotonSerializeView (PhotonStream stream,PhotonMessageInfo info)
      {
	     if (stream.isWriting)
	      {
	            stream.SendNext(transform.position);
	            stream.SendNext(h);
	            stream.SendNext(grd);

	        }
	      else
	      {
	          selfPOs = (Vector3)stream.ReceiveNext();
	            h = (float)stream.ReceiveNext();
	            grd = (bool)stream.ReceiveNext();
	      }
      }

}
