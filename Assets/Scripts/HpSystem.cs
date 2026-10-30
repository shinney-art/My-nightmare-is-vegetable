
using UnityEngine;
using TMPro;

public class HPSystem : MonoBehaviour
{
    public int enemyHP = 100;
    public int playerStartingHP = 100;

    public int[] playerHP = new int[5];

    public TMP_Text enemyHPText;
    public TMP_Text[] playerHPTexts;

    public int activePlayers = 4;
    public int currentPhase = 1;
    public GameObject[] playerObjects;
    void Start()
    {
        for (int i = 0; i < 5; i++)
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
        if (index < 0 || index >= activePlayers)
            return;

        if (playerHP[index] <= 0)
            return;

        playerHP[index] -= damage;
        playerHP[index] = Mathf.Max(0, playerHP[index]);

        // Make the player disappear when HP reaches 0
        if (playerHP[index] <= 0)
        {
            if (playerObjects != null &&
                index < playerObjects.Length &&
                playerObjects[index] != null)
            {
                playerObjects[index].SetActive(false);
            }
        }

        UpdateHP();
    }



    public void StartPhaseTwo()
    {
        currentPhase = 2;
        activePlayers = 5;

        enemyHP = 500;

        // Reset everyone's HP and make them reappear
        for (int i = 0; i < 5; i++)
        {
            playerHP[i] = playerStartingHP;

            if (playerObjects != null &&
                i < playerObjects.Length &&
                playerObjects[i] != null)
            {
                playerObjects[i].SetActive(true);
            }
        }

        UpdateHP();
    }


    public void UpdateHP()
    {
        if (enemyHPText != null)
            enemyHPText.text = "Boss HP: " + enemyHP;

        for (int i = 0; i < 5; i++)
        {
            if (playerHPTexts != null &&
                i < playerHPTexts.Length &&
                playerHPTexts[i] != null)
            {
                if (i < activePlayers)
                    playerHPTexts[i].text = playerHP[i].ToString();
                else
                    playerHPTexts[i].text = "";
            }
        }
    }

    public bool AllPlayersDefeated()
    {
        for (int i = 0; i < activePlayers; i++)
        {
            if (playerHP[i] > 0)
                return false;
        }

        return true;
    }
}
