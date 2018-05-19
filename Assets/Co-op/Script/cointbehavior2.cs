using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cointbehavior2 : Photon.MonoBehaviour
{
    public Vector3 selfPOs;
    public PhotonView pv;
    public bool touched;
    // Use this for initialization
    void Start()
    {
        touched = false;
    }
    void Update()
    {
        if (!pv.isMine)
        {
            SmoothNetMovement(selfPOs);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!col.GetComponent<PlayerStatus>().isthereanitem)
            {
                backtoloop();
                pv.RPC("backtoloop", PhotonTargets.Others);
            }
        }
    }

    public void SmoothNetMovement(Vector3 jam)
    {
        transform.position = Vector3.Lerp(transform.position, jam, Time.deltaTime * 8);
    }
    [PunRPC]
    public void backtoloop()
    {
        transform.position = new Vector2(-20, -30);
        selfPOs = new Vector3(-20, -30, 0);

    }
    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(touched);
        }
        else
        {
            selfPOs = (Vector3)stream.ReceiveNext();
            touched = (bool)stream.ReceiveNext();
        }
    }
}
