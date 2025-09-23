using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    SceneManager sceneManager;

    private Transform currentPlayer;

    public static bool ballIsControlled = false;
    public int controllingPlayer = 0;

    private Player_1_Controller player_1_Controller;
    private Player_2_Controller player_2_Controller;

    [SerializeField] private float passSpeed = 5f;
    [SerializeField] private float shootSpeed = 5f;

    private float shootTime = 0.3f;
    private float shootCurrentTime = 0;

    Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        shootCurrentTime += Time.deltaTime;

        if (ballIsControlled)
        {
            if (controllingPlayer == 1)
            {
                if (player_1_Controller.p1HorizontalInput != 0 || player_1_Controller.p1VerticalInput != 0)
                {
                    transform.localPosition = new Vector3(player_1_Controller.p1HorizontalInput, player_1_Controller.p1VerticalInput, 0);
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
                        controllingPlayer = 0;

                        rb2d.linearVelocity = new Vector2(player_1_Controller.p1HorizontalInput * shootSpeed, player_1_Controller.p1VerticalInput * shootSpeed);
                    }
                    else
                    {
                        PassToClosestPlayer_1();
                    }
                }
            }
            else if (controllingPlayer == 2)
            {
                if (player_2_Controller.p2HorizontalInput != 0 || player_2_Controller.p2VerticalInput != 0)
                {
                    transform.localPosition = new Vector3(player_2_Controller.p2HorizontalInput, player_2_Controller.p2VerticalInput, 0);
                }

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    shootCurrentTime = 0;
                }

                if (Input.GetKeyUp(KeyCode.Alpha1))
                {
                    if (shootCurrentTime > shootTime)
                    {
                        transform.parent = null;
                        ballIsControlled = false;
                        controllingPlayer = 0;

                        rb2d.linearVelocity = new Vector2(player_2_Controller.p2HorizontalInput * shootSpeed, player_2_Controller.p2VerticalInput * shootSpeed);
                    }
                    else
                    {
                        PassToClosestPlayer_2();
                    }
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P1"))
        {
            rb2d.linearVelocity = new Vector2(0, 0);

            ballIsControlled = true;

            transform.parent = collision.transform;

            currentPlayer = collision.transform;

            controllingPlayer = 1;

            player_1_Controller = collision.gameObject.GetComponent<Player_1_Controller>();
        }

        if (collision.gameObject.CompareTag("P2"))
        {
            rb2d.linearVelocity = new Vector2(0, 0);

            ballIsControlled = true;

            transform.parent = collision.transform;

            currentPlayer = collision.transform;

            controllingPlayer = 2;

            player_2_Controller = collision.gameObject.GetComponent<Player_2_Controller>();
        }

        if (collision.gameObject.CompareTag("Arco_P2"))
        {
            GameManager.Instance.Score_P1++;
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag("Arco_P1"))
        {
            GameManager.Instance.Score_P2++;
            SceneManager.LoadScene(0);
        }
    }

    private void PassToClosestPlayer_1()
    {
        Player_1_Controller[] players = Object.FindObjectsByType<Player_1_Controller>(FindObjectsSortMode.None);
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (Player_1_Controller p in players)
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

    private void PassToClosestPlayer_2()
    {
        Player_2_Controller[] players = Object.FindObjectsByType<Player_2_Controller>(FindObjectsSortMode.None);
        Transform closest = null;
        float minDistance = Mathf.Infinity;

        foreach (Player_2_Controller p in players)
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
