using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isAlive;

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }
    private void Start()
    {
        isAlive = false;
    }
    void Update()
    {
        transform.Translate(Vector3.left * PipeController.speed * Time.deltaTime);
    }
}
