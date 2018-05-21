using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class phand : Photon.MonoBehaviour
{
    public PUNButton PB;
    public GameObject MainPlayer;
    public GameObject gamemeger;
    public bool istheregamemanager = false;
	private int playernumber;
    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        PhotonNetwork.sendRate = 30;
        PhotonNetwork.sendRateOnSerialize = 20;
        SceneManager.sceneLoaded += OnFinishedLoading;
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
        PhotonNetwork.LoadLevel("Frame2");
    }

    private void OnJoinedRoom()
    {
        MoveScene();
        Debug.Log("We r connected to the room :)");
    }
   

    private void OnFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Frame2")
        {
            SpawnPlayer();
        }
    }
    private void SpawnPlayer()
    {
		playernumber++;
        PhotonNetwork.Instantiate(MainPlayer.name,MainPlayer.transform.position, MainPlayer.transform.rotation, 0);
		PhotonNetwork.Instantiate(gamemeger.name, gamemeger.transform.position, gamemeger.transform.rotation, 0);
    }
}
