using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public GameObject portalUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            portalUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            portalUI.SetActive(false);
        }
    }
}