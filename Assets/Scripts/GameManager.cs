using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private InGameRanking ig;

    private GameObject[] runners;
    List<RankingSystem> sortArray = new();

    public bool isGameOver = false;

    private bool isGameStarted = false;

    private void Awake()
    {
        instance = this;
        runners = GameObject.FindGameObjectsWithTag("Runner");
        ig = FindObjectOfType<InGameRanking>();
    }
    void Start()
    {
        for (int i = 0; i < runners.Length; i++)
        {

            sortArray.Add(runners[i].GetComponent<RankingSystem>());
        }
    }


    void CalculateRank()
    {
        sortArray = sortArray.OrderBy(x => x.distance).ToList();
        sortArray[0].rank = 1;
        sortArray[1].rank = 2;
        sortArray[2].rank = 3;
        sortArray[3].rank = 4;
        sortArray[4].rank = 5;
        sortArray[5].rank = 6;
        sortArray[6].rank = 7;

        ig.a = sortArray[6].name;
        ig.b = sortArray[5].name;
        ig.c = sortArray[4].name;
        ig.d = sortArray[3].name;
        ig.e = sortArray[2].name;
        ig.f = sortArray[1].name;
        ig.g = sortArray[0].name;
    }

    [System.Obsolete]
    void Update()
    {
        CalculateRank();

        if (!isGameStarted && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            StartGame();
        }
    }

    [System.Obsolete]
    public void StartGame()
    {
        if (!isGameStarted)
        {
            isGameStarted = true;

            foreach (GameObject runner in runners)
            {
                PlayerController playerController = runner.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.StartRunning();
                }
                else
                {
                    Opponent opponent = runner.GetComponent<Opponent>();
                    if (opponent != null)
                    {
                        opponent.StartRunning();
                    }
                }
            }
        }
    }
}
