using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Coin"))
        {
            //Debug.Log(other.gameObject.name);
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);

        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
