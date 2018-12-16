using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rbComponent;
    bool started = false;
    bool gameOver = false;

    private void Awake()
    {

        rbComponent = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rbComponent.velocity = new Vector3(speed, 0, 0);
                started = true;
            }

        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rbComponent.velocity = new Vector3(0, -30f, 0);
            //Camera.main.GetComponent<CameraFollower>().gameOver = true;
           // FindObjectOfType<PlatformSpawner>().GetComponent<PlatformSpawner>().gameOver = true;
        }
        if (started)
        {
            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                SwitchDirection();
            }
        }

    }

    public void SwitchDirection()
    {
        if (rbComponent.velocity.z > 0)
        {
            rbComponent.velocity = new Vector3(speed, 0, 0);
        }
        else if (rbComponent.velocity.x > 0)
        {
            rbComponent.velocity = new Vector3(0, 0, speed);
        }
    }

}
