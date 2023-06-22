using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    public float speed = 1f;
    public float strength = 2.5f;
    private float randomOffset;
    void Start()
    {
        randomOffset = Random.Range(-2.5f, 2.5f);
    }

    
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed + randomOffset) * strength;
        transform.position = pos;
    }
}
