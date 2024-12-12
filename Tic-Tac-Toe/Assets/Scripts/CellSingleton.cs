using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }

    private List<ButtonClickHandler> buttons = new List<ButtonClickHandler>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterButton(ButtonClickHandler button)
    {
        if (!buttons.Contains(button))
        {
            buttons.Add(button);
        }
    }

    public void ChangeAllButtons()
    {
        foreach (ButtonClickHandler button in buttons)
        {
            button.resetActive();
        }
    }

    // public void StartTimerAll()
    // {
    //     foreach (ButtonClickHandler button in buttons)
    //     {
    //         button.startTimer();
    //     }
    // }

    public ButtonClickHandler getButton(){
        return buttons[0];
    }
}
