using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float speed = 100.0f;
    public GameManager manager;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f; if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f; if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 최대 속도 제한을 걸 수가 있나?
            rb.AddForce(Vector2.up * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(Define.pipe))
        {
            // 게임 종료
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Define.coin))
        {
            // 점수 획득
            manager.GetComponent<GameManager>().GetScore();
            collision.gameObject.SetActive(false);
            collision.GetComponent<Coin>().IsAlive = false;
        }

    }

    void Die()
    {
        SceneManager.LoadScene(Define.main);
    }
}
