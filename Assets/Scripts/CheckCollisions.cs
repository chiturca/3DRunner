using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Debug.Log(other.gameObject.name);
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            Debug.Log("Congrats!");
            playerController.runningSpeed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Found Obstacle!!");
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
