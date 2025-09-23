using UnityEngine;

public class Player_2_Controller : MonoBehaviour
{
    public bool p2CanControl = false;

    public int p2HorizontalInput = 0;
    public int p2VerticalInput = 0;

    [SerializeField] float speed = 10f;

    private Transform ball;

    void Start()
    {


    }

    void Update()
    {
        if (p2CanControl)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                p2HorizontalInput = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                p2HorizontalInput = -1;
            }
            else
            {
                p2HorizontalInput = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                p2VerticalInput = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                p2VerticalInput = -1;
            }
            else
            {
                p2VerticalInput = 0;
            }
        }
    }
}
