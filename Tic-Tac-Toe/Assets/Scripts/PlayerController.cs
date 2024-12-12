using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GamePlay gamePlay;

    void Start()
    {
        gamePlay = GameObject.Find("ManagementPlay").GetComponent<GamePlay>();
    }

    public void PlayerMove(int i, int j)
    {
        if (gamePlay.board[i, j] == 0)
        {
            gamePlay.board[i, j] = gamePlay.playerNow() ? 1 : -1;
            gamePlay.UpdateBoardDisplay(i, j, !gamePlay.playerNow());

            switch (gamePlay.checkWin(i, j))
            {
                case 1:
                    CountdownTimer.Instance.StopAllCoroutines();
                    gamePlay.gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player1 Win!");
                    return;
                case -1:
                    CountdownTimer.Instance.StopAllCoroutines();
                    gamePlay.gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player2 Win!");
                    return;
                case -2:
                    CountdownTimer.Instance.StopAllCoroutines();
                    gamePlay.gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Draw!");
                    return;
                case 0:
                    gamePlay.playerChange();
                    break;
            }
        }
    }
}
