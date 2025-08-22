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
        }
    }
}
