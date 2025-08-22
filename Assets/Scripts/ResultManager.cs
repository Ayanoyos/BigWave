using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    void Start()
    {
       int popoo = GameManager.Instance.GetScore();
        scoreText.text = $"Score: {popoo}";
    }
}