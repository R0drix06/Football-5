using UnityEngine;

public class Player_1_Controller : MonoBehaviour
{
    public bool p1CanControl = false;

    public int p1HorizontalInput = 0;
    public int p1VerticalInput = 0;

    [SerializeField] float speed = 10f;

    private Transform ball;

    void Start()
    {
        

    }

    void Update()
    {
        if (p1CanControl)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                p1HorizontalInput = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                p1HorizontalInput = -1;
            }
            else
            {
                p1HorizontalInput = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                p1VerticalInput = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                p1VerticalInput = -1;
            }
            else
            {
                p1VerticalInput = 0;
            }
        }
    }
}
