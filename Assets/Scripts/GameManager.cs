using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public int Score_P1 = 0;
    public int Score_P2 = 0;

    [SerializeField] private Transform ball;
    private Player_1_Controller[] p1_Players;
    private Player_2_Controller[] p2_Players;

    void Awake()
    {
        // Verificar que no exista otra instancia
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // limpiar al destruir
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Volver a buscar jugadores y la pelota en la nueva escena
        p1_Players = Object.FindObjectsByType<Player_1_Controller>(FindObjectsSortMode.None);
        p2_Players = Object.FindObjectsByType<Player_2_Controller>(FindObjectsSortMode.None);
        ball = GameObject.FindWithTag("Ball")?.transform;
    }

    void Start()
    {
        p1_Players = Object.FindObjectsByType<Player_1_Controller>(FindObjectsSortMode.None);
        p2_Players = Object.FindObjectsByType<Player_2_Controller>(FindObjectsSortMode.None);
    }

    void Update()
    {
        Debug.Log(Score_P1 + "a" +  Score_P2);

        Player_1_Controller closestPlayer_1 = null;
        Player_2_Controller closestPlayer_2 = null;
        float p1_MinDistance = Mathf.Infinity;
        float p2_MinDistance = Mathf.Infinity;

        foreach (Player_1_Controller p in p1_Players)
        {
            float dist = Vector3.Distance(p.transform.position, ball.position);
            if (dist < p1_MinDistance)
            {
                p1_MinDistance = dist;
                closestPlayer_1 = p;
            }
        }

        foreach (Player_2_Controller p in p2_Players)
        {
            float dist = Vector3.Distance(p.transform.position, ball.position);
            if (dist < p2_MinDistance)
            {
                p2_MinDistance = dist;
                closestPlayer_2 = p;
            }
        }


        // Desactivar control en todos
        foreach (Player_1_Controller p in p1_Players)
        {
            p.p1CanControl = false;
        }

        foreach (Player_2_Controller p in p2_Players)
        {
            p.p2CanControl = false;
        }



        // Activar solo el más cercano
        if (closestPlayer_1 != null)
        {
            closestPlayer_1.p1CanControl = true;
        }

        if (closestPlayer_2 != null)
        {
            closestPlayer_2.p2CanControl = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Score_P1 = 0;
            Score_P2 = 0;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
