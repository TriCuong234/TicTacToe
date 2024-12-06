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

    public void nameToPoint(int name)
    {
        int i = 0;
        int j = 0;
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
}
