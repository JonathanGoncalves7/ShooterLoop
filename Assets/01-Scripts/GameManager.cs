using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;

    [SerializeField] List<GameObject> Enemys;
    [SerializeField] GameObject EnemysGroup;
    [SerializeField] GameObject RespawnPoints;
    [SerializeField] int CountEnemyBaseWave = 5;
    [SerializeField] int EnemysEachWave = 2;

    public GameState State;

    GameObject _player;
    int _currentWave = 0;
    List<GameObject> _respawnPoints = new List<GameObject>();

    private void Awake()
    {
        s_instance = this;
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        UpdateGameState(GameState.StartGame);
    }

    private void Update()
    {
        if (EnemysGroup.transform.childCount == 0 && State != GameState.NextWave)
        {
            UpdateGameState(GameState.NextWave);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartGame:
                HandleStartGame();
                break;
            case GameState.PrepareWave:
                HandlePrepareWave();
                break;
            case GameState.NextWave:
                HandleNextWave();
                break;
            case GameState.Lose:
                HandleLose();
                break;
        }
    }

    private void HandleStartGame()
    {
        _currentWave = 0;

        for (var i = 0; i < RespawnPoints.transform.childCount; i++)
        {
            _respawnPoints.Add(RespawnPoints.transform.GetChild(i).gameObject);
        }
    }

    private void HandlePrepareWave()
    {
        StartCoroutine(this.CRRespawn());
    }

    private void HandleNextWave()
    {
        _currentWave++;

        UpdateGameState(GameState.PrepareWave);
    }

    private void HandleLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator CRRespawn()
    {
        while (EnemysGroup.transform.childCount < NumberEnemysWave())
        {
            Respawn();
        }

        yield return null;
    }

    private void Respawn()
    {
        int respawnPointIndex = UnityEngine.Random.Range(0, _respawnPoints.Count);

        GameObject newEnemy = Instantiate(Enemys[0], _respawnPoints[respawnPointIndex].transform.position, Quaternion.identity);

        newEnemy.transform.SetParent(EnemysGroup.transform);
    }

    int NumberEnemysWave()
    {
        return CountEnemyBaseWave + (_currentWave * EnemysEachWave);
    }
}
