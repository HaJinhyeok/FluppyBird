using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 2.0f;

    // 백그라운드1 + 백그라운드2를 배경에 깔고, 장애물 오브젝트보다 빠른속도 left이동
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= -6.4f)
            transform.Translate(new Vector2(12.8f, 0f));
    }
}
