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
    private int i,j;

    public GameObject gameOverLayout;
    void Start()
    {
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
        button.interactable = false;
        // Thêm các tác vụ cần thiết tại đây
        GameObject myObject = GameObject.Find("ManagementPlay");
        if (myObject != null)
        {
            GamePlay managementScript = myObject.GetComponent<GamePlay>();
            managementScript.checkBoard(this.i, this.j);
            if(managementScript.playerNow()){
                Image imgSrc = this.GetComponent<Image>();
                imgSrc.type = Image.Type.Simple;
                imgSrc.sprite = xSprite;
            } else {
                Image imgSrc = this.GetComponent<Image>();
                imgSrc.type = Image.Type.Simple;
                imgSrc.sprite = oSprite;
            }
            managementScript.checkWin(i,j);
            switch(managementScript.checkWin(i,j)){
                case 0:{
                    break;
                }
                case 1:{
                    gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player1 Win!");
                    break;
                }
                case -1:{
                    gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player2 Win!");
                    break;
                }
                case -2:{
                    gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Draw!");
                    break;
                }
            }
            managementScript.playerChange();
        }
    }

    public void resetActive(){
        button.interactable = true;
    }

}
