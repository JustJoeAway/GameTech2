using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonConnect : MonoBehaviour {



    public string versionName = "0.1";
    public GameObject sectionView1, sectionView2, sectionView3;

    private void Awake()
    {
		
			PhotonNetwork.ConnectUsingSettings(versionName);
			Debug.Log("Connected  to photon....");
		
        
    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We R Connected to master");
    }

    private void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        Debug.Log("On Joined Lobby");

    }

	public void diskonek(){
		PhotonNetwork.Disconnect();
	}
	
    private void OnDisconnectedFromPhoton()
    {
        if (sectionView1.active)
            sectionView1.SetActive(false);
        if (sectionView2.active)
            sectionView2.SetActive(false);
        sectionView3.SetActive(true); 
        Debug.Log("Disconnected");
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
