using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXp = 0;

    // You can set this in the Inspector or populate it in Awake()
    public int[] xpCap = { 0, 10, 25, 50, 100, 200, 400 }; 
    // index = level number, value = xp required to reach that level

    public void AddXp(int amount)
    {
        currentXp += amount;

        // Check if we passed the cap for the current level
        while (currentLevel < xpCap.Length - 1 && currentXp >= xpCap[currentLevel])
        {
            currentXp -= xpCap[currentLevel]; // carry over extra XP
            currentLevel++;
            LevelUp();
        }
    }

    void LevelUp()
    {
        Debug.Log("Level Up! Reached Level: " + currentLevel);

        // Do something on level up:
        // - Increase stats
        // - Unlock abilities
        // - Play animation
    }
}
