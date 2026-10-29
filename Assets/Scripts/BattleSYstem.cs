
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BattleSYstem : MonoBehaviour
{
    [Header("Characters")]
    public Transform[] partyCharacters;
    public Transform enemy;

    [Header("HP Text")]
    public TMP_Text enemyHPText;
    public TMP_Text[] playerHPTexts;

    [Header("Battle Button")]
    public Button attackButton;

    [Header("End Images")]
    public GameObject gameOverImage;
    public GameObject victoryImage;

    [Header("HP Settings")]
    public int enemyHP = 200;
    public int playerStartingHP = 100;
    public int attackDamage = 25;
    public int enemyDamage = 25;

    [Header("Jump Settings")]
    public float jumpHeight = 1f;
    public float jumpTime = 0.4f;
    public float distanceFromEnemy = 1.5f;

    private int[] playerHP;
    private bool isAttacking = false;
    private int nextTarget = 0;

    void Start()
    {
        // Give each player their own HP
        playerHP = new int[partyCharacters.Length];

        for (int i = 0; i < playerHP.Length; i++)
        {
            playerHP[i] = playerStartingHP;
        }

        if (gameOverImage != null)
            gameOverImage.SetActive(false);

        if (victoryImage != null)
            victoryImage.SetActive(false);

        UpdateHP();
    }

    public void PlayerAttack()
    {
        if (isAttacking || enemyHP <= 0 || AllPlayersDefeated())
            return;

        StartCoroutine(AttackTurn());
    }

    IEnumerator AttackTurn()
    {
        isAttacking = true;

        if (attackButton != null)
            attackButton.interactable = false;

        // All living players jump toward the enemy together
        yield return StartCoroutine(MoveParty(true));

        // The whole team deals 25 damage total
        enemyHP -= attackDamage;

        if (enemyHP < 0)
            enemyHP = 0;

        UpdateHP();

        // Check if the enemy is defeated
        if (enemyHP <= 0)
        {
            if (victoryImage != null)
                victoryImage.SetActive(true);

            yield break;
        }

        // All living players jump back together
        yield return StartCoroutine(MoveParty(false));

        // Enemy attacks one living player
        EnemyAttack();

        UpdateHP();

        // Check if everyone is defeated
        if (AllPlayersDefeated())
        {
            if (gameOverImage != null)
                gameOverImage.SetActive(true);

            yield break;
        }

        // Allow the next turn
        isAttacking = false;

        if (attackButton != null)
            attackButton.interactable = true;
    }

    void EnemyAttack()
    {
        // Find the next living player
        for (int i = 0; i < playerHP.Length; i++)
        {
            int index = (nextTarget + i) % playerHP.Length;

            if (playerHP[index] > 0)
            {
                playerHP[index] -= enemyDamage;

                if (playerHP[index] < 0)
                    playerHP[index] = 0;

                // Next time, target the next player
                nextTarget = (index + 1) % playerHP.Length;

                return;
            }
        }
    }

    IEnumerator MoveParty(bool attacking)
    {
        int count = partyCharacters.Length;

        Vector3[] startPositions = new Vector3[count];
        Vector3[] endPositions = new Vector3[count];

        // Remember where each player starts
        for (int i = 0; i < count; i++)
        {
            startPositions[i] = partyCharacters[i].position;

            if (attacking && playerHP[i] > 0)
            {
                // Give each player a different landing spot
                endPositions[i] = enemy.position +
                    new Vector3(
                        -distanceFromEnemy,
                        (i - (count - 1) / 2f) * 0.5f,
                        0f
                    );
            }
            else
            {
                endPositions[i] = startPositions[i];
            }
        }

        float timer = 0f;

        // Move all players at the same time
        while (timer < jumpTime)
        {
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(timer / jumpTime);

            for (int i = 0; i < count; i++)
            {
                if (playerHP[i] <= 0)
                    continue;

                Vector3 position = Vector3.Lerp(
                    startPositions[i],
                    endPositions[i],
                    t
                );

                // Make the player jump
                position.y += Mathf.Sin(t * Mathf.PI) * jumpHeight;

                partyCharacters[i].position = position;
            }

            yield return null;
        }

        // Finish at the exact destination
        for (int i = 0; i < count; i++)
        {
            if (playerHP[i] > 0)
                partyCharacters[i].position = endPositions[i];
        }
    }

    bool AllPlayersDefeated()
    {
        for (int i = 0; i < playerHP.Length; i++)
        {
            if (playerHP[i] > 0)
                return false;
        }

        return true;
    }

    void UpdateHP()
    {
        if (enemyHPText != null)
            enemyHPText.text = "Enemy HP: " + enemyHP;

        for (int i = 0; i < playerHP.Length; i++)
        {
            if (playerHPTexts != null &&
                i < playerHPTexts.Length &&
                playerHPTexts[i] != null)
            {
                playerHPTexts[i].text =
                    "Player " + (i + 1) + " HP: " + playerHP[i];
            }
        }
    }
}
