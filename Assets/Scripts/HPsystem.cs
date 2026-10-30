
using UnityEngine;
using TMPro;

public class HPSystem : MonoBehaviour
{
    public int enemyHP = 300;
    public int playerStartingHP = 100;

    public int[] playerHP = new int[4];

    public TMP_Text enemyHPText;
    public TMP_Text[] playerHPTexts;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            playerHP[i] = playerStartingHP;
        }

        UpdateHP();
    }

    public void DamageEnemy(int damage)
    {
        enemyHP -= damage;
        enemyHP = Mathf.Max(0, enemyHP);

        UpdateHP();
    }

    public void DamagePlayer(int index, int damage)
    {
        if (index < 0 || index >= 4)
            return;

        if (playerHP[index] <= 0)
            return;

        playerHP[index] -= damage;
        playerHP[index] = Mathf.Max(0, playerHP[index]);

        UpdateHP();
    }

    public void UpdateHP()
    {
        if (enemyHPText != null)
            enemyHPText.text = "Enemy HP: " + enemyHP;

        for (int i = 0; i < 4; i++)
        {
            if (playerHPTexts != null &&
                i < playerHPTexts.Length &&
                playerHPTexts[i] != null)
            {
                playerHPTexts[i].text = playerHP[i].ToString();
            }
        }
    }

    public bool AllPlayersDefeated()
    {
        for (int i = 0; i < 4; i++)
        {
            if (playerHP[i] > 0)
                return false;
        }

        return true;
    }
}
