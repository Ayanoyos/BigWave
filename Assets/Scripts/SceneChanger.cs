using UnityEngine;
using  UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ��: �Q�[���V�[���ɐ؂�ւ�
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
