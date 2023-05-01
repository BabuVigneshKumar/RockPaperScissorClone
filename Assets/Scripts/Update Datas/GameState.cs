using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<PlayerState> Players = new List<PlayerState>();
    public List<PlayerState> WaitingPlayers = new List<PlayerState>();
    public List<PlayerState> KickOutPlayers = new List<PlayerState>();  
    public bool IsBot = false;

    public string rpsPlayerId;

    public int CurrentState = 0;
    public double GameStartTime = 0;
    public double GameEndTime = 0;

    public void GameBegins()
    {
        CurrentState = 0;
        GameStartTime = 0;
        GameEndTime= 0;

    }
}
