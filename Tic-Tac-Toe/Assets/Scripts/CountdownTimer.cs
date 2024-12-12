using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public static CountdownTimer Instance { get; private set; }
    public GameObject gameOverLayout;
    public float countdownTime;
    public Text countdownDisplay;
    private bool isPaused = false;
    private float currentTime;
    private GamePlay gamePlay;

    void Awake()
    {
        // Thiết lập Singleton
        if (Instance == null)
        {
            Instance = this;
            currentTime = 0;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }   

    public void StartCountdown(float time, GameObject gobject)
    {
        currentTime = time;
        isPaused = false;
        StartCoroutine(CountdownToStartWithTime(time, gobject));
    }

    public void StartCountdown()
    {
        isPaused = false;
        StartCoroutine(CountdownToStart());
    }

    public void StartCountdownToEnd(float time, GameObject gobject)
    {
        this.isPaused = false;
        StartCoroutine(CountdownToEndGame(time, gobject));
    }

    public void PauseCountdown()
    {
        this.isPaused = true;
    }

    public bool getIsPaused(){
        return this.isPaused;
    }

    public void TwoCaroutine(float time, GameObject gobject, float time2, GameObject gobject2)
    {
        StopAllCoroutines();
        StartCoroutine(MainCoroutineSequence(time, gobject, time2, gobject2));
    }

    IEnumerator MainCoroutineSequence(float time, GameObject gobject, float time2, GameObject gobject2)
    {
        yield return StartCoroutine(CountdownToStartWithTime(time, gobject));
        yield return StartCoroutine(CountdownToEndGame(time2, gobject2));
    }

    IEnumerator CountdownToStartWithTime(float time, GameObject gobject)
    {
        this.currentTime = time;
        
        gobject.SetActive(true);
        Text timerDisplay = gobject.GetComponentInChildren<Text>();
        while (this.currentTime > 0 && !isPaused)
        {
            timerDisplay.text = this.currentTime.ToString("F0");
            yield return new WaitForSeconds(1f);
            this.currentTime--;
        }
        if (this.currentTime <= 0)
        {
            gobject.SetActive(false);
        }
    }

    IEnumerator CountdownToEndGame(float time, GameObject gobject)
    {
        this.countdownTime = time;
        Text timerDisplay = gobject.GetComponentInChildren<Text>();
        while (this.countdownTime > 0 && !isPaused)
        {
            timerDisplay.text = this.countdownTime.ToString("F0");
            yield return new WaitForSeconds(1f);
            this.countdownTime--;
        }
        if (this.countdownTime <= 0)
        {
            gamePlay = GameObject.Find("ManagementPlay").GetComponent<GamePlay>();
            gamePlay.showPlayerWinTimeEnd();
            
        }
    }

    IEnumerator CountdownToStart()
    {
        while (this.currentTime > 0 && !isPaused)
        {
            yield return new WaitForSeconds(1f);
            this.currentTime--;
        }
    }
}
