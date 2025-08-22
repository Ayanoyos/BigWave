using UnityEngine;
using  UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneCollect(string str)
    {
        switch (str)
        {
            case "game":
                SceneManager.LoadScene("GameScene");
                break;

            case "title":
                SceneManager.LoadScene("TitleScene");
                break;

            case "quit":
                Application.Quit();   // �Q�[�����I��
                Debug.Log("�Q�[���I��"); // �G�f�B�^��ł͊m�F�p
                break;
        }
    }
}
