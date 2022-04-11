using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text Health;
    [SerializeField] TMP_Text Mana;

    PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        Health.text = _playerController.Health.CurrentHealth.ToString();
        Mana.text = _playerController.Mana.GetCurrentMana().ToString();
    }
}
