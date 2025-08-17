using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // �V���O���g���łǂ�����ł��Ăׂ�

    private int score = 0;
    private float elapsedTime = 0f;

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

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    // �X�R�A���Z
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
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

