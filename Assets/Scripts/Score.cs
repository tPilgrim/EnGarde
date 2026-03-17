using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject Player1Component;
    public GameObject Player2Component;
    public GameObject ResumeButton;
    public GameObject RestartButton;
    public GameObject MenuButton;

    private float timeLeft = 59f;
    public Text timerText;
    public Text score1Text;
    public Text score2Text;
    public Text result;

    private int Player1 = 0;
    private int Player2 = 0;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        score1Text.text = Mathf.Ceil(Player1).ToString();
        score2Text.text = Mathf.Ceil(Player2).ToString();
        timerText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            RestartButton.SetActive(true);
            MenuButton.SetActive(true);
            if(Player1 > Player2)
            {
                Player1Component.GetComponent<Player1>().EndGame(true);
                if (Player2Component.GetComponent<Player2>() != null)
                    Player2Component.GetComponent<Player2>().EndGame(false);
                else
                    Player2Component.GetComponent<AI>().EndGame(false);
                result.text = "Player 1 wins";
            }
            else if (Player1 < Player2)
            {
                Player1Component.GetComponent<Player1>().EndGame(false);
                if (Player2Component.GetComponent<Player2>() != null)
                    Player2Component.GetComponent<Player2>().EndGame(true);
                else
                    Player2Component.GetComponent<AI>().EndGame(true);
                result.text = "Player 2 wins";
            }
            else
            {
                Player1Component.GetComponent<Player1>().EndGame(true);
                if (Player2Component.GetComponent<Player2>() != null)
                    Player2Component.GetComponent<Player2>().EndGame(true);
                else
                    Player2Component.GetComponent<AI>().EndGame(true);
                result.text = "Draw";
            }
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            ResumeButton.SetActive(true);
            MenuButton.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Player2Scored()
    {
        Player2++;
    }

    public void Player1Scored()
    {
        Player1++;
    }

    public void Resume()
    {
        ResumeButton.SetActive(false);
        MenuButton.SetActive(false);
    }
}
