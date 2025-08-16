using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private KeyCode requiredKey = KeyCode.A;

    // ?? JudgeZoneから参照できるようにプロパティを追加
    public KeyCode RequiredKey => requiredKey;

    private JudgeZone judgeZone;

    private void Start()
    {
        // ?? Unity 2023以降推奨の書き方
        judgeZone = FindFirstObjectByType<JudgeZone>();
    }


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 入力判定
        if (Input.GetKeyDown(requiredKey))
        {
            Debug.Log("キー押された！ " + requiredKey); // ?? デバッグ
            judgeZone.Judge(this);
        }

        // 枠を過ぎたら強制ミス
        if (transform.position.x < judgeZone.transform.position.x - 1f)
        {
            Debug.Log("Miss (通過) " + requiredKey);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("JudgeZone"))
    //    {
    //        inJudgeZone = true;
    //        Debug.Log("Waveが判定範囲に入った！ " + requiredKey);
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
