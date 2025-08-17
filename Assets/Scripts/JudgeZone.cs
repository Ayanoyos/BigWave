using UnityEngine;

public class JudgeZone : MonoBehaviour
{
    [SerializeField] private float perfectRange = 0.2f;
    [SerializeField] private float goodRange = 0.5f;
    [SerializeField] private UnityEngine.UI.Image aButtonImage;
    [SerializeField] private UnityEngine.UI.Image sButtonImage;
    [SerializeField] private UnityEngine.UI.Image dButtonImage;
    [SerializeField] private float displayTime = 0.3f;

    private Wave currentWave;

    private void Update()
    {
        if (currentWave != null && Input.GetKeyDown(currentWave.RequiredKey))
        {
            Judge(currentWave);
            currentWave = null;
        }
    }

    public void ShowButtonImage(KeyCode key)
    {
        UnityEngine.UI.Image img = null;

        switch (key)
        {
            case KeyCode.A: img = aButtonImage; break;
            case KeyCode.S: img = sButtonImage; break;
            case KeyCode.D: img = dButtonImage; break;
        }

        if (img != null)
        {
            StartCoroutine(DisplayImage(img));
        }
    }

    private System.Collections.IEnumerator DisplayImage(UnityEngine.UI.Image img)
    {
        img.enabled = true;
        yield return new WaitForSeconds(displayTime);
        img.enabled = false;
    }

    public void Judge(Wave wave)
    {
        float distance = Mathf.Abs(transform.position.x - wave.transform.position.x);

        if (distance <= perfectRange)
        {
            Debug.Log("Perfect! " + wave.RequiredKey);
            GameManager.Instance.AddScore(2);
            ShowButtonImage(wave.RequiredKey);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wave"))
        {
            currentWave = collision.GetComponent<Wave>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wave"))
        {
            if (currentWave != null && currentWave.gameObject == collision.gameObject)
            {
                currentWave = null;
                Debug.Log("Miss!");
            }
        }
    }

    // SceneÉrÉÖÅ[Ç≈îÕàÕÇâ¬éãâª
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, perfectRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, goodRange);
    }
}
