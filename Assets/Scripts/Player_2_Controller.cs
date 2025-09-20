using UnityEngine;

public class Player_2_Controller : MonoBehaviour
{
    public bool p2CanControl = false;

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
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}
