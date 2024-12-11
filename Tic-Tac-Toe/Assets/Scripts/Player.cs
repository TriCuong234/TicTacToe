using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private int player1Point = 0;
    private int player2Point = 0;
    [SerializeField]
    private GameObject player1Output;
    [SerializeField]
    private GameObject player2Output;

    public GameObject timer;

    public GameObject timerWaiter;

    void Start()
    {
        timerWaiter.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerUpPoint(bool player)
    {
        if (player) this.player1Point++;
        else this.player2Point++;
    }

    public int getPlayerPoint(bool player)
    {
        if (player) return this.player1Point;
        return this.player2Point;
    }

    public void UpdatePointPlayer(int player)
    {
        if (player == 1)
        {
            playerUpPoint(true);
            player1Output.GetComponent<Text>().text = this.player1Point.ToString();
            return;
        }
        if (player == 0)
        {
            return;
        }
        playerUpPoint(false);
        player2Output.GetComponent<Text>().text = this.player2Point.ToString();

    }
}
