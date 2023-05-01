using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MirrorManager : NetworkBehaviour
{
    public static MirrorManager instance;
    public bool IsConnectedToServer;
    public List<string> roomIDs = new List<string>();
    public List<RoomInfo> roomList = new List<RoomInfo>();
    public List<string> emptyRoomList = new List<string>();

    public GameObject GameManagerPrefab;

    private NetworkMatch networkMatch;


    private void Awake()
    {
        instance = this;
        networkMatch = GetComponent<NetworkMatch>();
    }

    //public bool HostGame(string matchID, string playerID , GameObject player , out NetworkIdentity gameManagerNetID)
    //{
    //    gameManagerNetID = GetComponent<NetworkIdentity>();
    //    lock (roomList)
    //    {
    //        if(!roomIDs.Contains(matchID))
    //        {
    //            //create a new room
    //            GameObject go = Instantiate(GameManagerPrefab);
    //            NetworkServer.Spawn(go);
    //            //go.GetComponent<GameManager>().GameNetworkMatch.matchId = matchID.ToGuid();
                    
    //        }
    //    }

    //}












}
[System.Serializable]
public class RoomInfo
{
    public string roomName;
    public string lobbyName;
    public bool isClosed;
    public bool isRoomFull;
    public bool isVisible;


}
[System.Serializable] 
public class MirrorPlayer
{
    public string PlayerId;
    public PlayerManager pm;

}
