using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;

    //public GameManager gameManager;
    private InGameRanking ig;

    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            if (ig.namesTxt[6].text == "Player")
            {
                PlayerFinished();
                Debug.Log("You Win!");
            }
            else
            {
                PlayerFinished();
                Debug.Log("Loser!");
            }
            
            
        }
        else if (other.CompareTag("SpeedBoost"))
        {
            playerController.runningSpeed += 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }

    void PlayerFinished()
    {
        playerController.runningSpeed = 0;
        GameManager.instance.isGameOver = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            transform.position = PlayerStartPos;
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerController.runningSpeed -= 3f;
        speedBoosterIcon.SetActive(false);
    }
}
