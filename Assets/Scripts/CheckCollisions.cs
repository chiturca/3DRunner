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
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject FinishPanel;

    //public GameManager gameManager;
    private InGameRanking ig;

    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();
        PlayerAnim = Player.GetComponentInChildren<Animator>();
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
            if (ig.namesTxt[6].text == "Player" && score >= maxScore)
            {
                PlayerFinished();
                //Debug.Log("You Win!");
                PlayerAnim.SetBool("Win", true);
            }
            else
            {
                PlayerFinished();
                //Debug.Log("Loser!");
                PlayerAnim.SetBool("Lose", true);
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
        transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
        GameManager.instance.isGameOver = true;
        FinishPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
