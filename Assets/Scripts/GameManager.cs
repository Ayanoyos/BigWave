using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // シングルトンでどこからでも呼べる

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;

    private int score = 0;
    private float elapsedTime = 0f;

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

    private void Update()
    {
        elapsedTime += Time.deltaTime;
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

