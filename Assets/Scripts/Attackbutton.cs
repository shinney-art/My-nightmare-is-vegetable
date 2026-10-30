
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    public BattleManager battleManager;
    public Button attackButton;

    void Start()
    {
        attackButton.onClick.AddListener(ClickAttack);
    }

    void ClickAttack()
    {
        battleManager.PlayerAttack();
    }
}
