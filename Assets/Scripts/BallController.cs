using UnityEngine;

public class BallController : MonoBehaviour
{
    private Transform currentPlayer;

    public static bool ballIsControlled = false;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private float passSpeed = 5f;
    [SerializeField] private float shootSpeed = 5f;

    private float shootTime = 0.3f;
    private float shootCurrentTime = 0;

    Rigidbody2D rb2d;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        shootCurrentTime += Time.deltaTime;
        Debug.Log(shootCurrentTime);

        if (ballIsControlled)
        {
            if (horizontalInput != 0 || verticalInput != 0)
            {
                transform.localPosition = new Vector3(horizontalInput, verticalInput, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shootCurrentTime = 0;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (shootCurrentTime > shootTime)
                {
                    transform.parent = null;
                    ballIsControlled = false;

                    rb2d.linearVelocity = new Vector2(horizontalInput * shootSpeed, verticalInput * shootSpeed);
                }
                else
                {
                    PassToClosestPlayer();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb2d.linearVelocity = new Vector2(0, 0);

            ballIsControlled = true;

            transform.parent = collision.transform;

            currentPlayer = collision.transform;
        }
    }

    private void PassToClosestPlayer()
    {
        PlayerController[] players = Object.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (PlayerController p in players)
        {
            if (p.transform == currentPlayer) continue; // ignorar al que ya tiene la pelota

            float dist = Vector3.Distance(p.transform.position, transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = p.transform;
            }
        }

        if (closest != null)
        {
            ballIsControlled = false;
            transform.parent = null;
            currentPlayer = null;

            // Direccion hacia el jugador más cercano
            Vector2 dir = (closest.position - transform.position).normalized;

            rb2d.linearVelocity = dir * passSpeed; // velocidad del pase
        }
    }
}
