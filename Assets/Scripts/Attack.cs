using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject PlayerComponent;
    public GameObject ScoreComponent;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerComponent.GetComponent<Player1>() != null)
            {
                PlayerComponent.GetComponent<Player1>().GetHit();
                ScoreComponent.GetComponent<Score>().Player2Scored();
            }
            if (PlayerComponent.GetComponent<Player2>() != null)
            {
                PlayerComponent.GetComponent<Player2>().GetHit();
                ScoreComponent.GetComponent<Score>().Player1Scored();
            }
            if (PlayerComponent.GetComponent<AI>() != null)
            {
                PlayerComponent.GetComponent<AI>().GetHit();
                ScoreComponent.GetComponent<Score>().Player1Scored();
            }
            gameObject.SetActive(false);
        }
    }
}
