using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    private Button button;
    private Sprite xSprite;
    private Sprite oSprite;
    private int i, j;
    private Image imgSrc;
    private Sprite imgSrcOriginSprite;
    private GameObject player;
    [SerializeField]
    private GameObject timer;
    [SerializeField]
    private GameObject timerWaiter;
    public GameObject gameOverLayout;
    void Start()
    {
        CountdownTimer.Instance.TwoCaroutine(3, timerWaiter, 60, timer);
        imgSrc = this.GetComponent<Image>();
        imgSrcOriginSprite = imgSrc.sprite;
        ButtonManager.Instance.RegisterButton(this);
        player = GameObject.Find("Player");
        xSprite = Resources.Load<Sprite>("Sprites/XassetWhite");
        oSprite = Resources.Load<Sprite>("Sprites/OassetWhite");
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        int name = int.Parse(this.gameObject.name);
        if (name < 4)
        {
            i = 0;
            j = name % 10 - 1;
        }
        else
        {
            i = name / 10;
            j = name % 10 - 1;
        }
    }

    void OnButtonClick()
    {
        AudioManager.Instance.PlaySFX();

        button.interactable = false;
        // Thêm các tác vụ cần thiết tại đây
        GameObject myObject = GameObject.Find("ManagementPlay");
        if (myObject != null)
        {
            GamePlay managementScript = myObject.GetComponent<GamePlay>();
            managementScript.checkBoard(this.i, this.j);
            if (managementScript.playerNow())
            {
                imgSrc.type = Image.Type.Simple;
                imgSrc.sprite = xSprite;
            }
            else
            {
                imgSrc.type = Image.Type.Simple;
                imgSrc.sprite = oSprite;
            }
            switch (managementScript.checkWin(i, j))
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        CountdownTimer.Instance.StopAllCoroutines();
                        gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player1 Win!");
                        return;
                        break;
                    }
                case -1:
                    {
                        CountdownTimer.Instance.StopAllCoroutines();
                        gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player2 Win!");
                        return;
                        break;
                    }
                case -2:
                    {
                        CountdownTimer.Instance.StopAllCoroutines();
                        gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Draw!");
                        return;
                        break;
                    }
            }
            managementScript.playerChange();
        }
        CountdownTimer.Instance.StopAllCoroutines();
        CountdownTimer.Instance.StartCountdownToEnd(60, timer);

    }

    public void resetActive()
    {
        if (button != null)
        {
            button.interactable = true;

            imgSrc.type = Image.Type.Sliced;
            imgSrc.sprite = imgSrcOriginSprite;
        }
        else
        {

        }
    }

    public void startTimer()
    {
        CountdownTimer.Instance.TwoCaroutine(3, timerWaiter, 60, timer);
    }

    public void continueTimer()
    {
        CountdownTimer.Instance.StartCountdownToEnd(CountdownTimer.Instance.countdownTime, timer);
    }

    public void pauseTimer()
    {
        CountdownTimer.Instance.PauseCountdown();
        CountdownTimer.Instance.StopAllCoroutines();
    }
}
