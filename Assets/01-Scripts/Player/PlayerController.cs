using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStatusSO PlayerStatus;

    private void Update()
    {
        PlayerStatus.RegenMana();

        if (PlayerStatus.CurrentHealth <= 0)
            GameManager.s_instance.UpdateGameState(GameState.Lose);
    }
}
