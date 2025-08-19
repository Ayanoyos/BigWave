using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode requiredKey = KeyCode.A;

    public int heightLevel = 1; // 1=低, 2=中, 3=高

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

    public float GetHeightPosition()
    {
        // 高さに対応するワールド座標を返す
        switch (heightLevel)
        {
            case 1: return 1f; // 低波の高さ
            case 2: return 2f; // 中波の高さ
            case 3: return 3f; // 高波の高さ
            default: return 1f;
        }
    }
}
