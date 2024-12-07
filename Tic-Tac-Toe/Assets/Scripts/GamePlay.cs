using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{

    private int[,] board = new int[3, 3];
    private bool player;

    void Start()
    {
        this.player = true;
        for (int i = 0; i < board.GetLength(0); i++) { for (int j = 0; j < board.GetLength(1); j++) { board[i, j] = 0; } }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerChange()
    {
        this.player = !this.player;
    }

    public bool playerNow()
    {
        return this.player;
    }

    public void checkBoard(int i, int j)
    {

        this.board[i, j] = this.player ? 1 : -1;

    }


    public void showBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
                print(i + "," + j + ":" + board[i, j]);
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
                };
            }
        }
        return count;
    }
    private int checkMetCondition(int i, int j)
    {
        if ((board[i, 0] == board[i, 1]) && (board[i, 1] == board[i, 2]))
        {
            return 1;
        }

        if ((board[0, j] == board[1, j]) && (board[1, j] == board[2, j]))
        {
            return 1;
        }

        if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2]))
        {
            return 1;
        }
        if ((board[0, 2] == board[1, 1]) && (board[1, 1] == board[2, 0])) { return 1; }
        if (countChess() == 9)
        {
            return -1;
        }
        return 0;
    }
    public int checkWin(int i, int j)
    {

        if (countChess() > 4)
        {
            if(checkMetCondition(i, j) == 1){
                return this.player ? 1 : -1;
            }
            if(checkMetCondition(i, j) == -1){
                return -2;
            }
        }
        return 0;
    }

    public void reset()
    {
        for (int i = 0; i < board.GetLength(0); i++) { for (int j = 0; j < board.GetLength(1); j++) { board[i, j] = 0; } }
    }
}
