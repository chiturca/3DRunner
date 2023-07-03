using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float touchXDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitX;

    private Animator animator;
    private bool isRunning = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        SetRunning(false);
    }

    [System.Obsolete]
    void Update()
    {
        SwipeCheck();
    }

    [System.Obsolete]
    private void SwipeCheck()
    {
        if (!isRunning)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                GameManager.instance.StartGame();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.StartGame();
            }
        }

        if (isRunning)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }
            else if (Input.GetMouseButton(0))
            {
                touchXDelta = Input.GetAxis("Mouse X");
            }
            else
            {
                touchXDelta = 0;
            }
            newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);

            Vector3 newPosition = new(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
    }

    public void StartRunning()
    {
        isRunning = true;
        SetRunning(true);
    }
    void SetRunning(bool running)
    {
        if (animator != null)
        {
            animator.SetBool("Running", running);
        }
    }
}
