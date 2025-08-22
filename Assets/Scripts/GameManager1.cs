using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance; // �V���O���g���łǂ�����ł��Ăׂ�

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float startTime = 60f; // �����^�C�}�[���ԁi60�b�j

    private int score = 0;
    private float elapsedTime = 0f;
    private bool isTimeUp = false;

    private void Awake()
    {
        // �V���O���g����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���؂�ւ��ł������Ȃ�
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

                // �����Ń��U���g��ʂ�
                SceneManager.LoadScene("ResultScene");
            }
        }

        if (timeText != null)
        {
            timeText.text = $"Time: {elapsedTime:F1}";
        }
    }

    // �X�R�A���Z
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    // ���Ԏ擾
    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    // �X�R�A�擾
    public int GetScore()
    {
        return score;
    }


}

