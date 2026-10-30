
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [Header("HP System")]
    public HPSystem hpSystem;

    [Header("Boss Appearance")]
    public SpriteRenderer bossSprite;
    public Sprite phaseOneSprite;
    public Sprite phaseTwoSprite;

    [Header("Background")]
    public SpriteRenderer backgroundSprite;
    public Sprite phaseOneBackground;
    public Sprite phaseTwoBackground;

    [Header("Damage")]
    public int attackDamage = 25;
    public int enemyDamage = 25;

    [Header("Phase 2")]
    public GameObject fifthPlayer;

    [Header("Cutscene")]
    public GameObject phaseTwoCutscene;
    public Button attackButton;

    [Header("End Screens")]
    public GameObject victoryImage;
    public GameObject gameOverImage;

    private int nextTarget = 0;
    private bool isAttacking = false;

    void Start()
    {
        // Hide fifth player
        if (fifthPlayer != null)
            fifthPlayer.SetActive(false);

        // Set boss appearance
        if (bossSprite != null)
            bossSprite.sprite = phaseOneSprite;

        // Set background
        if (backgroundSprite != null)
            backgroundSprite.sprite = phaseOneBackground;

        // Hide cutscene and end screens
        if (phaseTwoCutscene != null)
            phaseTwoCutscene.SetActive(false);

        if (victoryImage != null)
            victoryImage.SetActive(false);

        if (gameOverImage != null)
            gameOverImage.SetActive(false);
    }

    public void PlayerAttack()
    {
        if (isAttacking)
            return;

        if (hpSystem == null)
            return;

        if (hpSystem.enemyHP <= 0 ||
            hpSystem.AllPlayersDefeated())
            return;

        isAttacking = true;

        // Players attack boss
        hpSystem.DamageEnemy(attackDamage);

        // Check if Phase 1 boss is defeated
        if (hpSystem.currentPhase == 1 &&
            hpSystem.enemyHP <= 0)
        {
            ShowPhaseTwoCutscene();
            return;
        }

        // Check if Phase 2 boss is defeated
        if (hpSystem.currentPhase == 2 &&
            hpSystem.enemyHP <= 0)
        {
            if (victoryImage != null)
                victoryImage.SetActive(true);

            return;
        }

        // Boss attacks one living player
        EnemyAttack();

        // Check Game Over
        if (hpSystem.AllPlayersDefeated())
        {
            if (gameOverImage != null)
                gameOverImage.SetActive(true);

            return;
        }

        isAttacking = false;
    }

    void ShowPhaseTwoCutscene()
    {
        // Stop attack button
        if (attackButton != null)
            attackButton.interactable = false;

        // Show cutscene picture
        if (phaseTwoCutscene != null)
            phaseTwoCutscene.SetActive(true);
    }

    public void ContinueToPhaseTwo()
    {
        // Hide cutscene
        if (phaseTwoCutscene != null)
            phaseTwoCutscene.SetActive(false);

        // Reset HP and bring back all players
        hpSystem.StartPhaseTwo();

        // Change boss appearance
        if (bossSprite != null)
            bossSprite.sprite = phaseTwoSprite;

        // Change background
        if (backgroundSprite != null)
            backgroundSprite.sprite = phaseTwoBackground;

        // Reveal fifth player
        if (fifthPlayer != null)
            fifthPlayer.SetActive(true);

        // Reset enemy targeting
        nextTarget = 0;

        // Allow attacking again
        isAttacking = false;

        if (attackButton != null)
            attackButton.interactable = true;
    }

    void EnemyAttack()
    {
        for (int i = 0; i < hpSystem.activePlayers; i++)
        {
            int index =
                (nextTarget + i) % hpSystem.activePlayers;

            if (hpSystem.playerHP[index] > 0)
            {
                hpSystem.DamagePlayer(index, enemyDamage);

                nextTarget =
                    (index + 1) % hpSystem.activePlayers;

                return;
            }
        }
    }
}
