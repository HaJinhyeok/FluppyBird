using UnityEngine;

public class PipeController : MonoBehaviour
{
    public static float speed = 2.0f;
    public GameObject coin;

    // 파이프 두개+코인을 묶어서 하나의 장애물 오브젝트로 만들고, 스폰 좌표를 세가지 정도로 저장해 그중 임의의 위치에서 생성
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

        // 백그라운드1의 왼쪽 밖으로 나가면, 포지션을 다시 백그라운드2에 랜덤 재배치
        if (transform.position.x <= -4.5f)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Vector3 newPos = pipePosition[Random.Range(0, pipePosition.Length)];
        // 코인 활성화
        if (coin.GetComponent<Coin>().IsAlive == false)
        {
            coin.GetComponent<Coin>().transform.position = newPos;
            coin.gameObject.SetActive(true);
            coin.GetComponent<Coin>().IsAlive = true;
        }
        transform.position = newPos;
    }
}