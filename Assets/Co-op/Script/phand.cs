using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class phand : Photon.MonoBehaviour
{
	
    public PUNButton PB;
    public GameObject MainPlayer;
    public GameObject gamemeger;
    public bool istheregamemanager = false;
	private int playernumber;
	public Text inputnama;
	public Text MAP;
	public string namaplayer;
	private int scriptcount;
	
	
	private static phand phandelerer;
	
    private void Awake()
    {
		
		DontDestroyOnLoad(this.transform);	 
        PhotonNetwork.sendRate = 30;
        PhotonNetwork.sendRateOnSerialize = 20;
        SceneManager.sceneLoaded += OnFinishedLoading;
		scriptcount++;
		
    }
    public void CreateNewRoom()
    {
        PhotonNetwork.CreateRoom(PB.createroomInput.text, new RoomOptions()
        {
            MaxPlayers = 4  
        }, null);
    }
    public void JoinorCreateRoom()
    {
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(PB.joinroomInput.text, ro, TypedLobby.Default);

    }


    public void MoveScene()
    {
		if(MAP.text == "Map1"){
			PhotonNetwork.LoadLevel("Frame2");
		}
		else if(MAP.text == "Map2"){
			PhotonNetwork.LoadLevel("Frame3");
		}
		else if(MAP.text == "Map3"){
			PhotonNetwork.LoadLevel("Frame4");
		}
        
    }

    private void OnJoinedRoom()
    {
        MoveScene();
        Debug.Log("We r connected to the room :)");
    }
   

    private void OnFinishedLoading(Scene scene, LoadSceneMode mode)
    {
		if(Application.loadedLevel == 0){
			scriptcount = 0;
			PhotonNetwork.Disconnect();
		}
		Debug.Log("Asasdas");
		if(PhotonNetwork.inRoom && scriptcount==1){
			SpawnPlayer();
		}
        
    }
    private void SpawnPlayer()
    {
		namaplayer = inputnama.text;
		playernumber++;
		PhotonNetwork.Instantiate(MainPlayer.name,new Vector3(0.03f,1f,0f), MainPlayer.transform.rotation, 0);
		PhotonNetwork.Instantiate(gamemeger.name, gamemeger.transform.position, gamemeger.transform.rotation, 0);
		
    }
	
	public void returnto1frame(){
		PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
        PhotonNetwork.LeaveRoom();
		

	}
	public void OnLeftRoom()
    { 
		Destroy(this.gameObject);
        PhotonNetwork.LoadLevel("Main");
    }
	public void OnDisconnectedFromPhoton()
    {
		Destroy(this.gameObject);
        PhotonNetwork.LoadLevel("Main");
		
	}
	
	
}
