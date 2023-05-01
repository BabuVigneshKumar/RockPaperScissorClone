using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerManager : NetworkBehaviour
{
    public static PlayerManager LocalPlayer;

    public PlayerState LocalPlayerState = new PlayerState();

    public PlayerData LocalPlayerData = new PlayerData();
    [SyncVar]
    public string PlayerId;
    [SyncVar]
    public bool Isbot;
    [SyncVar]
    public string RoomName;

    public override void OnStartClient()
    {
        if (isLocalPlayer)
        {
            LocalPlayer = this;
        }
    }
    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;

    }
    public void UpdatePlayerData(string playerDataRaw)
    {
        PlayerData pd = JsonUtility.FromJson<PlayerData>(playerDataRaw);
        LocalPlayerData = pd;
        PlayerId = pd.PlayerId;
        PlayerState ps = new PlayerState();
        ps.playerData = pd;
    }

    public void HostGame()
    {
        string matchID = "Room " + System.DateTime.UtcNow;

    }

    private void CmdHostGame(string matchID)
    {
        RoomName = matchID;

    }


}
