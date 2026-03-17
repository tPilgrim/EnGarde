using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public GameObject AIComponent;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AIComponent.GetComponent<AI>().Attack();
        }
    }
}
