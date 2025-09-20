using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ball;
    private PlayerController[] players;

    void Start()
    {
        players = Object.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
    }

    void Update()
    {
        PlayerController closestPlayer = null;
        float minDistance = Mathf.Infinity;

        foreach (PlayerController p in players)
        {
            float dist = Vector3.Distance(p.transform.position, ball.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closestPlayer = p;
            }
        }

        // Desactivar control en todos
        foreach (PlayerController p in players)
        {
            p.canControl = false;
        }

        // Activar solo el más cercano
        if (closestPlayer != null)
        {
            closestPlayer.canControl = true;
        }
    }
}
