using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLayout : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textWin;
    public GameObject btnContinue;
    public GameObject btnExit;

    

    void Start()

    {
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
}
