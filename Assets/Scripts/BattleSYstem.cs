
using UnityEngine;

public class BattleSYstem : MonoBehaviour
{
    public HPSystem hpSystem;

    public int attackDamage = 25;
    public int enemyDamage = 25;

    public GameObject victoryImage;
    public GameObject gameOverImage;

    private int nextTarget = 0;
    private bool isAttacking = false;

    void Start()
    {
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

        hpSystem.DamageEnemy(attackDamage);

        if (hpSystem.enemyHP <= 0)
        {
            if (victoryImage != null)
                victoryImage.SetActive(true);

            return;
        }

        EnemyAttack();

        if (hpSystem.AllPlayersDefeated())
        {
            if (gameOverImage != null)
                gameOverImage.SetActive(true);

            return;
        }

        isAttacking = false;
    }

    void EnemyAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = (nextTarget + i) % 4;

            if (hpSystem.playerHP[index] > 0)
            {
                hpSystem.DamagePlayer(index, enemyDamage);

                nextTarget = (index + 1) % 4;

                return;
            }
        }
    }
}
