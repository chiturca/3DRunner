using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
