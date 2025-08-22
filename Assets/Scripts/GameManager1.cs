using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance; // シングルトンでどこからでも呼べる

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float startTime = 60f; // 初期タイマー時間（60秒）

    private int score = 0;
    private float elapsedTime = 0f;
    private bool isTimeUp = false;

    private void Awake()
    {
        // シングルトン化
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーン切り替えでも消えない
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        elapsedTime = startTime;
    }

    private void Update()
    {
        if (!isTimeUp)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0)
            {
                elapsedTime = 0;
                isTimeUp = true;

                // ここでリザルト画面へ
                SceneManager.LoadScene("ResultScene");
            }
        }

        if (timeText != null)
        {
            timeText.text = $"Time: {elapsedTime:F1}";
        }
    }

    // スコア加算
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    // 時間取得
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // スコア取得
    public int GetScore()
    {
        return score;
    }


}

