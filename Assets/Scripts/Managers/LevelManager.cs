using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    bool isGameOver = false;

    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(applePrefab);
        applePrefab.GetComponent<AppleController>().MoveApple();
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("GameOver!");
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
