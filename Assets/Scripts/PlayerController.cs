using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canControl = false;

    [SerializeField] float speed = 10f;

    private Transform ball;

    void Start()
    {
        

    }

    void Update()
    {
        if (canControl)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}
