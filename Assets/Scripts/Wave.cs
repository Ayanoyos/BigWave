using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode requiredKey = KeyCode.A;

    // ?? JudgeZone����Q�Ƃł���悤�Ƀv���p�e�B��ǉ�
    public KeyCode RequiredKey => requiredKey;

    private JudgeZone judgeZone;

    private void Start()
    {
        // ?? Unity 2023�ȍ~�����̏�����
        judgeZone = FindFirstObjectByType<JudgeZone>();
    }


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // ���͔���
        if (Input.GetKeyDown(requiredKey))
        {
            Debug.Log("�L�[�����ꂽ�I " + requiredKey); // ?? �f�o�b�O
            judgeZone.Judge(this);
        }

        // �g���߂����狭���~�X
        if (transform.position.x < judgeZone.transform.position.x - 1f)
        {
            Debug.Log("Miss (�ʉ�) " + requiredKey);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("JudgeZone"))
    //    {
    //        inJudgeZone = true;
    //        Debug.Log("Wave������͈͂ɓ������I " + requiredKey);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("JudgeZone"))
    //    {
    //        inJudgeZone = false;
    //    }
    //}
}
