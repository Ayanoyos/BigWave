using UnityEngine;

public class JudgeZone : MonoBehaviour
{
    [SerializeField] private float perfectRange = 0.2f;
    [SerializeField] private float goodRange = 0.5f;

    public void Judge(Wave wave)
    {
        float distance = Mathf.Abs(transform.position.x - wave.transform.position.x);

        if (distance <= perfectRange)
        {
            Debug.Log("Perfect! " + wave.RequiredKey);
            GameManager.Instance.AddScore(2);
        }
        else if (distance <= goodRange)
        {
            Debug.Log("Good! " + wave.RequiredKey);
            GameManager.Instance.AddScore(1);
        }
        else
        {
            Debug.Log("Miss! " + wave.RequiredKey);
        }

        Destroy(wave.gameObject);
    }


    // ?? Sceneƒrƒ…[‚É”»’è”ÍˆÍ‚ð•\Ž¦
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, perfectRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, goodRange);
    }
}
