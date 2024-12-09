using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLayout : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textWin;
    public Button btnContinue;
    public Button btnExit;

    void Start()

    {
        btnContinue.onClick.AddListener(OnButtonContinueClick);
        btnExit.onClick.AddListener(OnButtonExitClick);
        this.gameObject.SetActive(false);
        textWin.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -0.2f * this.GetComponent<RectTransform>().rect.height);
        btnContinue.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -0.4f * this.GetComponent<RectTransform>().rect.height);
        btnExit.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -0.55f * this.GetComponent<RectTransform>().rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getPlayerWinName(String player){
        
        textWin.GetComponent<Text>().text = player;
        
        this.gameObject.SetActive(true);
    }

    void OnButtonContinueClick(){
        //rs
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().UpdatePointPlayer(GetPlayerWin());
        ButtonManager.Instance.ChangeAllButtons();
        GameObject gameBoard = GameObject.Find("ManagementPlay");
        gameBoard.GetComponent<GamePlay>().ResetBoard();
        Deactive();
    }
    void OnButtonExitClick(){
        //chuyen ve scene MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    public void Deactive(){
        this.gameObject.SetActive(false);
    }

    int GetPlayerWin(){
        if (textWin.GetComponent<Text>().text.Contains("Player1"))
        return 1;
        if (textWin.GetComponent<Text>().text.Contains("Player2"))
        return -1;
        return 0;
    }
}
