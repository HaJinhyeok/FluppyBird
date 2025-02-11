using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 2.0f;

    // ��׶���1 + ��׶���2�� ��濡 ���, ��ֹ� ������Ʈ���� �����ӵ� left�̵�
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= -6.4f)
            transform.Translate(new Vector2(12.8f, 0f));
    }
}
