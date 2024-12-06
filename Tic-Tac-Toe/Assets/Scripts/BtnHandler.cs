using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    private Button button;
    private Sprite xSprite;
    private Sprite oSprite;

    void Start()
    {
        xSprite = Resources.Load<Sprite>("Sprites/XassetWhite");
        oSprite = Resources.Load<Sprite>("Sprites/OassetWhite");
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
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
            managementScript.nameToPoint(int.Parse(this.name));
            if(managementScript.playerNow()){
                Image imgSrc = this.GetComponent<Image>();
                imgSrc.type = Image.Type.Simple;
                imgSrc.sprite = xSprite;
            } else {
                Image imgSrc = this.GetComponent<Image>();
                imgSrc.type = Image.Type.Simple;
                imgSrc.sprite = oSprite;
            }


            managementScript.playerChange();
        }
    }
}
