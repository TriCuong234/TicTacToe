using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    void OnButtonClickPvP()
    {
        SceneManager.LoadScene("TicTacToe");
    }

    private IEnumerator LoadSceneCoroutine()
    {
        while (!SceneManager.GetActiveScene().name.Equals("TicTacToe"))
        {
            yield return null;
        }

        ButtonClickHandler button = FindObjectOfType<ButtonClickHandler>();
        if (button != null)
        {
            button.start2Coroutine();
        }
        else
        {
            Debug.LogError("Không tìm thấy nút ButtonClickHandler.");
        }
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
