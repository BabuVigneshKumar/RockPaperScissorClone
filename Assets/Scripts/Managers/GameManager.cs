using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerState ps;

    public NetworkMatch GameNetworkMatch;



    public int playerPick = -1;
    [Header("Bot Turn")]
    public int botPick = -1;
    [Header("NextPlayer Turn")]
    public int nextPlayerChoose = -1;
    [Header("GameState")]
    public int currentState;

    [Header("Game Start")]
    [SyncVar]
    public int gameCount = 3;
    public bool isGameStart;
    public TMP_Text gameCountTxt;

    private void Start()
    {

        CurrentGameState();
    }

    public void RPSChoice()
    {
        if (ps.playerTurn && playerPick == -1) return;
        playerPick = -1;
        ps.playerTurn = true;


    }
    public void CreateMatch()
    {
       
    }

    public void PlayerChoose(int Choose)
    {
        playerPick = Choose;
        if (playerPick == 1)
        {
            GameHud.instance.playerPickImage.GetComponent<Image>().sprite = GameHud.instance.scissorImg;

        }
        if (playerPick == 2)
        {
            GameHud.instance.playerPickImage.GetComponent<Image>().sprite = GameHud.instance.paperImg;

        }
        if (playerPick == 3)
        {
            GameHud.instance.playerPickImage.GetComponent<Image>().sprite = GameHud.instance.rockImg;

        }
        ps.playerTurn = false;
        GameHud.instance.playerPickImage.gameObject.SetActive(true);
        GameHud.instance.gameButtons.SetActive(false);
        StartCoroutine(BotChoose());
    }
    #region BotTurn
    private IEnumerator BotChoose()
    {
        yield return new WaitForSeconds(0.1f);
        botPick = Random.Range(1, 4);
        GameHud.instance.botPickImage.gameObject.SetActive(true);
        if (botPick == 1)
        {
            GameHud.instance.botPickImage.GetComponent<Image>().sprite = GameHud.instance.scissorImg;

        }
        if (botPick == 2)
        {
            GameHud.instance.botPickImage.GetComponent<Image>().sprite = GameHud.instance.paperImg;

        }
        if (botPick == 3)
        {
            GameHud.instance.botPickImage.GetComponent<Image>().sprite = GameHud.instance.rockImg;

        }
        UpdateCurrentState(1);
        StartCoroutine(ResetGame());
    }
    #endregion


    #region Winner State
    public void Winnerstate()
    {
        Debug.Log("Entered WinState");
        if (playerPick == botPick)
        {
            // draw
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "DRAW";
        }
        else if (playerPick == (int)RPSType.Paper && botPick == (int)RPSType.Rock)
        {
            //Player Wins
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "PLAYER WINS";

        }
        else if (playerPick == (int)RPSType.Rock && botPick == (int)RPSType.Paper)
        {
            //BotWins
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "BOT WINS";

        }
        else if (playerPick == (int)RPSType.Scissor && botPick == (int)RPSType.Paper)
        {
            //Player Wins
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "PLAYER WINS";

        }
        else if (playerPick == (int)RPSType.Paper && botPick == (int)RPSType.Scissor)
        {
            // BotWins
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "BOT WINS";
        }
        else if (playerPick == (int)RPSType.Rock && botPick == (int)RPSType.Scissor)
        {
            // PlayerWins
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "PLAYER WINS";
        }
        else if (playerPick == (int)RPSType.Scissor && botPick == (int)RPSType.Rock)
        {
            // BotWins
            GameHud.instance.winnerTxt.GetComponent<TMP_Text>().text = "BOT WINS";
        }

    }
    #endregion

    #region ResetGame
    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
        currentState = 0;
        ClearUI();
        UpdateCurrentState(0);
        yield return new WaitForSeconds(0.5f);
    }

    public void ClearUI()
    {
        GameHud.instance.winnerTxt.text = string.Empty;
        GameHud.instance.playerPickImage.gameObject.SetActive(false);
        GameHud.instance.botPickImage.gameObject.SetActive(false);
    }
    #endregion




    #region Game State
    public void UpdateCurrentState(int index)
    {
        currentState += index;
        Debug.Log("<color=blue>Current State:</color> " + currentState);
        CurrentGameState();
    }

    public void CurrentGameState()
    {
        if (currentState == 0)
        {
            StartCoroutine(GameBegin());
        }
        if (currentState == 1)
        {
            Winnerstate();

        }
    }
    #endregion

    #region Game Starts
    public IEnumerator GameBegin()
    {
        for (int i = gameCount; i > 0; i--)
        {

            gameCountTxt.text = gameCount.ToString();
            yield return new WaitForSeconds(1f);
            gameCount--;
            GameHud.instance.gameButtons.SetActive(false);
        }
        gameCountTxt.text = "Game Starts ";
        yield return new WaitForSeconds(0.5f);
        gameCountTxt.gameObject.SetActive(false);
        GameHud.instance.gameButtons.SetActive(true);
        RPSChoice();


    }
    #endregion

}
