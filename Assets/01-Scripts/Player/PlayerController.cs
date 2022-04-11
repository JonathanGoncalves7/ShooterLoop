using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStatusSO PlayerStatus;

    private void Start()
    {
        PlayerStatus.Ini();
    }

    private void Update()
    {
        if (PlayerStatus.CurrentHealth <= 0)
            GameManager.s_instance.UpdateGameState(GameState.Lose);
    }
}
