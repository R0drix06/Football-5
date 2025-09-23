using UnityEngine;

public class GK_1_Controller : Player_1_Controller
{
    [SerializeField] float gk1Speed = 2.5f;

    void Update()
    {
        if (transform.position.y <= 1.65)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * gk1Speed * Time.deltaTime;
            }
        }

        if (transform.position.y >= -1.65)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * gk1Speed * Time.deltaTime;
            }
        }

        if (p1CanControl)
        {
            if (Input.GetKey(KeyCode.D))
            {
                p1HorizontalInput = 1;
            }
            else
            {
                p1HorizontalInput = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                p1VerticalInput = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                p1VerticalInput = -1;
            }
            else
            {
                p1VerticalInput = 0;
            }
        }
        

    }
}
