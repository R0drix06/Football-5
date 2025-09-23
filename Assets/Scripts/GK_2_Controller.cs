using UnityEngine;

public class GK_2_Controller : Player_2_Controller
{
    [SerializeField] float gk2Speed = 2.5f;

    void Update()
    {
        if (transform.position.y <= 1.65)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * gk2Speed * Time.deltaTime;
            }
        }

        if (transform.position.y >= -1.65)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * gk2Speed * Time.deltaTime;
            }
        }

        if (p2CanControl)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                p2HorizontalInput = -1;
            }
            else
            {
                p2HorizontalInput = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                p2VerticalInput = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                p2VerticalInput = -1;
            }
            else
            {
                p2VerticalInput = 0;
            }
        }
    }
}
