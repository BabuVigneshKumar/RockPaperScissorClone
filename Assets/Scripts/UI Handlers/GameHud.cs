using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHud : MonoBehaviour
{
    [Header("Button UI")]
    public GameObject gameButtons;

    [Header("Game Asset")]
    public Sprite rockImg;
    public Sprite paperImg;
    public Sprite scissorImg;
    public Image playerPickImage;
    public Image botPickImage;

    [Header("Game Winner")]
    public TMP_Text winnerTxt;

    public static GameHud instance;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
