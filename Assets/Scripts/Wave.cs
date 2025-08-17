using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode requiredKey = KeyCode.A;

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
}
