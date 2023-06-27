using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    Vector3 OpponentStartPos;
    public GameObject speedBoosterIcon;
    public GameObject slownessIcon;

    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
    }

    [System.Obsolete]
    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
        if (GameManager.instance.isGameOver)
        {
            OpponentAgent.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            transform.position = OpponentStartPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            OpponentAgent.speed += 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
        else if (other.CompareTag("SlownessObs"))
        {
            OpponentAgent.speed -= 3f;
            slownessIcon.SetActive(true);
            StartCoroutine(FastAfterAWhileCoroutine());
        }
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed -= 3f;
        speedBoosterIcon.SetActive(false);
    }

    private IEnumerator FastAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        OpponentAgent.speed += 3f;
        slownessIcon.SetActive(false);
    }
}
