using UnityEngine;

public class XpOrb : MonoBehaviour
{
    public int xpValue = 5; // How much XP this orb gives

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerXP playerXp = collision.GetComponent<PlayerXP>();
        if (playerXp != null)
        {
            playerXp.AddXp(xpValue);
            Destroy(gameObject); // remove orb
        }
    }
}
