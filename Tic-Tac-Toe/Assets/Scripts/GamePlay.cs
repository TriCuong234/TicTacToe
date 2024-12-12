using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public int[,] board = new int[3, 3];
    private bool player;
    private AI ai;
    public GameObject gameOverLayout;
    public bool isPvP; // Biến xác định chế độ chơi

    void Start()
    {
        this.player = true;
        this.isPvP = true;
        for (int i = 0; i < board.GetLength(0); i++) 
        {
            for (int j = 0; j < board.GetLength(1); j++) 
            { 
                board[i, j] = 0; 
            }
        }
        ai = new AI(this); // Khởi tạo AI
    }

    public void playerChange()
    {
        this.player = !this.player;
        if (!this.player && !isPvP)
        {
            AITurn();

        }
    }

    public bool playerNow()
    {
        return this.player;
    }

    public void checkBoard(int i, int j)
    {
        this.board[i, j] = this.player ? 1 : -1;
    }

    public void UpdateBoardDisplay(int i, int j, bool isAI)
    {
        string buttonName = $"{i}{j + 1}";
        GameObject buttonObject = GameObject.Find(buttonName);
        if (buttonObject != null)
        {
            Image imgSrc = buttonObject.GetComponent<Image>();
            if (isAI)
            {
                imgSrc.sprite = Resources.Load<Sprite>("Sprites/OassetWhite");
            }
            else
            {
                imgSrc.sprite = Resources.Load<Sprite>("Sprites/XassetWhite");
            }
            buttonObject.GetComponent<Button>().interactable = false;
        }
    }

    public int countChess()
    {
        int count = 0;
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != 0)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public bool CheckWinner(int[,] board, int player)
    {
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                return true;
        }
        if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
            (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            return true;
        return false;
    }

    public bool IsDraw(int[,] board)
    {
        foreach (var spot in board)
        {
            if (spot == 0) return false;
        }
        return true;
    }

    public int checkWin(int i, int j)
    {
        if (countChess() > 4)
        {
            if (CheckWinner(board, board[i, j])) return board[i, j] == 1 ? 1 : -1;
            if (IsDraw(board)) return -2;
        }
        return 0;
    }

    public void ResetBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++) 
        {
            for (int j = 0; j < board.GetLength(1); j++) 
            { 
                board[i, j] = 0; 
            }
        }
    }

    public void SetButtonsInteractable(bool state)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string buttonName = $"{i}{j + 1}";
                GameObject buttonObject = GameObject.Find(buttonName);
                if (buttonObject != null)
                {
                    // Chỉ kích hoạt lại các nút trống
                    if (board[i, j] == 0)
                    {
                        buttonObject.GetComponent<Button>().interactable = state;
                    }
                }
            }
        }
    }

    private void AITurn()
    {
        SetButtonsInteractable(false); // Vô hiệu hóa các nút
                
        Vector2Int move = ai.BestMove(board);
        board[move.x, move.y] = -1; // AI đánh dấu
        UpdateBoardDisplay(move.x, move.y, true); // Cập nhật hiển thị cho AI

        // Kiểm tra điều kiện thắng sau khi AI thực hiện nước đi
        switch (checkWin(move.x, move.y))
        {
            case 1:
                CountdownTimer.Instance.StopAllCoroutines();
                gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player1 Win!");
                break;
            case -1:
                CountdownTimer.Instance.StopAllCoroutines();
                gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Player2 Win!");
                SetButtonsInteractable(true);
                break;
            case -2:
                CountdownTimer.Instance.StopAllCoroutines();
                gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName("Draw!");
                return;
        }

        SetButtonsInteractable(true); // Kích hoạt lại các nút trống
        playerChange(); // Đổi lượt về người chơi
    }


    public void showBoard(){
        for (int i = 0; i < board.GetLength(0); i++) 
        {
            for (int j = 0; j < board.GetLength(1); j++) 
            { 
                print(board[i,j]); 
            }
        }
    }

    public void showPlayerWinTimeEnd(){
        gameOverLayout.GetComponent<GameOverLayout>().getPlayerWinName(player ? "Player2": "Player1"+" Win!");
    }
}
