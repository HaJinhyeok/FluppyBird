using UnityEngine;

public class PipeController : MonoBehaviour
{
    public static float speed = 2.0f;
    public GameObject coin;

    // ������ �ΰ�+������ ��� �ϳ��� ��ֹ� ������Ʈ�� �����, ���� ��ǥ�� ������ ������ ������ ���� ������ ��ġ���� ����
    private Vector3[] pipePosition = { new Vector3(6.4f, 3f, 0f), new Vector3(6.4f, 1f, 0f), new Vector3(6.4f, -1f, 0f), new Vector3(6.4f, -3f, 0f) };

    private void Start()
    {
        Respawn();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // ��׶���1�� ���� ������ ������, �������� �ٽ� ��׶���2�� ���� ���ġ
        if (transform.position.x <= -4.5f)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Vector3 newPos = pipePosition[Random.Range(0, pipePosition.Length)];
        // ���� Ȱ��ȭ
        if (coin.GetComponent<Coin>().IsAlive == false)
        {
            coin.GetComponent<Coin>().transform.position = newPos;
            coin.gameObject.SetActive(true);
            coin.GetComponent<Coin>().IsAlive = true;
        }
        transform.position = newPos;
    }
}