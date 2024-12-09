using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button pvpBtn;
    public Button pveBtn;
    public Button exitBtn;
    void Start()
    {
        pvpBtn.onClick.AddListener(OnButtonClickPvP);
        pveBtn.onClick.AddListener(OnButtonClickPvE);
        exitBtn.onClick.AddListener(OnButtonClickExit);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnButtonClickPvP()
    {
        print("hehe");
    }

    void OnButtonClickPvE()
    {
        print("hehe");
    }

    void OnButtonClickExit()
    {
        Application.Quit();

        Debug.Log("Game is exiting.");
    }
}
