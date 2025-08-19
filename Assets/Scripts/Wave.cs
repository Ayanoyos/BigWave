using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode requiredKey = KeyCode.A;

    public int heightLevel = 1; // 1=��, 2=��, 3=��

    // �O����Q�Ƃ���L�[
    public KeyCode RequiredKey { get; private set; }

    private void Start()
    {
        // SerializeField�Ŏw�肵���L�[��������
        RequiredKey = requiredKey;
    }

    private void Update()
    {
        // ���Ɉړ�
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public float GetHeightPosition()
    {
        // �����ɑΉ����郏�[���h���W��Ԃ�
        switch (heightLevel)
        {
            case 1: return 1f; // ��g�̍���
            case 2: return 2f; // ���g�̍���
            case 3: return 3f; // ���g�̍���
            default: return 1f;
        }
    }
}
