using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PUNButton : MonoBehaviour {
    public InputField createroomInput, joinroomInput;
    
    public phand pHandler;

    public void OnClickCreateRoom()
    {
        pHandler.CreateNewRoom();
    }
    public void OnClickJoinRoom()
    {
        pHandler.JoinorCreateRoom();

    }
	

}
