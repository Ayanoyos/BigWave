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
                Application.Quit();   // ゲームを終了
                Debug.Log("ゲーム終了"); // エディタ上では確認用
                break;
        }
    }
}
