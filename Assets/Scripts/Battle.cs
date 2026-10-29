
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    // Bat, Fists, Pencil, Whisk
    public int[] playerHP = { 100, 100, 100, 100 };
    public int[] playerDamage = { 35, 15, 10, 20 };

    public int enemyHP = 500;
    public int enemyDamage = 25;

    public HealthBar[] playerBars;
    public HealthBar enemyBar;

    public Button attackButton;
    public Button guardButton;

    int currentPlayer = 0;
    bool battleOver = false;

    void Start()
    {
        attackButton.onClick.AddListener(Attack);
        guardButton.onClick.AddListener(Guard);

        UpdateBars();
    }

    void Attack()
    {
        if (battleOver) return;

        // Current character attacks
        enemyHP -= playerDamage[currentPlayer];

        if (enemyHP < 0)
            enemyHP = 0;

        UpdateBars();

        if (enemyHP == 0)
        {
            battleOver = true;
            return;
        }

        EnemyTurn(false);
    }

    void Guard()
    {
        if (battleOver) return;

        // Guard blocks the next enemy attack
        EnemyTurn(true);
    }

    void EnemyTurn(bool guarding)
    {
        if (!guarding)
        {
            playerHP[currentPlayer] -= enemyDamage;

            if (playerHP[currentPlayer] < 0)
                playerHP[currentPlayer] = 0;
        }

        UpdateBars();

        // Check if everyone is defeated
        bool allDead = true;

        for (int i = 0; i < playerHP.Length; i++)
        {
            if (playerHP[i] > 0)
                allDead = false;
        }

        if (allDead)
        {
            battleOver = true;
            return;
        }

        // Move to the next living character
        for (int i = 0; i < playerHP.Length; i++)
        {
            currentPlayer++;

            if (currentPlayer >= playerHP.Length)
                currentPlayer = 0;

            if (playerHP[currentPlayer] > 0)
                break;
        }
    }

    void UpdateBars()
    {
        // Update each player's HP image
        for (int i = 0; i < playerHP.Length; i++)
        {
            int barHP = Mathf.CeilToInt(playerHP[i] / 10f);
            playerBars[i].UpdateBar(barHP);
        }

        // Enemy has 500 HP, so each square represents 50 HP
        int enemyBarHP = Mathf.CeilToInt(enemyHP / 50f);
        enemyBar.UpdateBar(enemyBarHP);
    }
}
