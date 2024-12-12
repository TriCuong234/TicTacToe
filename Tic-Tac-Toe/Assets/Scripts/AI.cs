using UnityEngine;

public class AI
{
    private GamePlay gamePlay;

    public AI(GamePlay gamePlay)
    {
        this.gamePlay = gamePlay;
    }

    public int Minimax(int[,] board, int depth, bool isMaximizing)
    {
        if (gamePlay.CheckWinner(board, -1)) return 1; // AI thắng
        if (gamePlay.CheckWinner(board, 1)) return -1; // Người chơi thắng
        if (gamePlay.IsDraw(board)) return 0; // Hòa

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = -1; // AI move
                        int score = Minimax(board, depth + 1, false);
                        board[i, j] = 0;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = 1; // Người chơi move
                        int score = Minimax(board, depth + 1, true);
                        board[i, j] = 0;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }

    public Vector2Int BestMove(int[,] board)
    {
        int bestScore = int.MinValue;
        Vector2Int move = new Vector2Int(-1, -1);
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == 0)
                {
                    board[i, j] = -1; // AI move
                    int score = Minimax(board, 0, false);
                    board[i, j] = 0;
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = new Vector2Int(i, j);
                    }
                }
            }
        }
        return move;
    }
}
