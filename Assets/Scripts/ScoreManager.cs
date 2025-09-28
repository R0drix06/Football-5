using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public Text ScoreText;
    private Text Score_P1;
    private Text Score_P2;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ScoreText = Object.FindAnyObjectByType<Text>();

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = GameManager.Instance.Score_P1.ToString() + " " + GameManager.Instance.Score_P2.ToString();
    }
}
