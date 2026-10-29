
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    // The 4 characters
    public int[] playerHP = { 100, 100, 100, 100 };

    // Bat, Fists, Pencil, Whisk
    public int[] playerDamage = { 35, 15, 10, 20 };

    // The enemy
    public int enemyHP = 500;
    public int enemyDamage = 25;

    public Text playerHPText;
    public Text enemyHPText;

    public Button attackButton;
    public Button guardButton;

    int currentPlayer = 0;
    bool isGuarding = false;
    bool battleOver = false;

    void Start()
    {
        UpdateHP();

        attackButton.onClick.AddListener(Attack);
        guardButton.onClick.AddListener(Guard);
    }

    void Attack()
    {
        if (battleOver) return;

        // Current character attacks
        enemyHP -= playerDamage[currentPlayer];

        if (enemyHP <= 0)
        {
            enemyHP = 0;
            battleOver = true;
        }
        else
        {
            EnemyTurn();
        }

        UpdateHP();
    }

    void Guard()
    {
        if (battleOver) return;

        // Block the enemy's next attack
        isGuarding = true;
        EnemyTurn();

        UpdateHP();
    }

    void EnemyTurn()
    {
        if (isGuarding)
        {
            isGuarding = false;
        }
        else
        {
            playerHP[currentPlayer] -= enemyDamage;

            if (playerHP[currentPlayer] <= 0)
            {
                playerHP[currentPlayer] = 0;
            }
        }

        // Move to the next character
        currentPlayer++;

        if (currentPlayer >= playerHP.Length)
        {
            currentPlayer = 0;
        }

        // Check if everyone is defeated
        bool allDead = true;

        for (int i = 0; i < playerHP.Length; i++)
        {
            if (playerHP[i] > 0)
            {
                allDead = false;
                break;
            }
        }

        if (allDead)
        {
            battleOver = true;
        }
    }

    void UpdateHP()
    {
        playerHPText.text =
            "Bat: " + playerHP[0] +
            " | Fists: " + playerHP[1] +
            " | Pencil: " + playerHP[2] +
            " | Whisk: " + playerHP[3];

        enemyHPText.text = "Enemy HP: " + enemyHP;
    }
}

