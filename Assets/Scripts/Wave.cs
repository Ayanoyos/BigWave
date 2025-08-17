using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode requiredKey = KeyCode.A;

    // 外から参照するキー
    public KeyCode RequiredKey { get; private set; }

    private void Start()
    {
        // SerializeFieldで指定したキーを初期化
        RequiredKey = requiredKey;
    }

    private void Update()
    {
        // 左に移動
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
