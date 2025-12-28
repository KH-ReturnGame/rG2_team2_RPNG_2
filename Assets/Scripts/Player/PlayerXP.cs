using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public static PlayerXP Instance;

    public int currentLevel = 1;
    public int currentXp = 0;
    public int[] xpCap = { 0, 10, 25, 50, 100, 200, 400 }; 

    void Awake()
    {
        // Singleton pattern (only one PlayerXP allowed)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddXp(int amount)
    {
        currentXp += amount;

        while (currentLevel < xpCap.Length && currentXp >= xpCap[currentLevel])
        {
            currentXp -= xpCap[currentLevel];
            currentLevel++;
            LevelUp();
        }
    }

    void LevelUp()
    {
        Debug.Log("Level Up! Level: " + currentLevel);
    }
}


