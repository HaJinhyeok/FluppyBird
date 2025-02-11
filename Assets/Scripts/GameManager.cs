using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;

    private void Start()
    {
        scoreText.text = $"Score : {score}";
    }

    public void GetScore()
    {
        score += 10;
        scoreText.text = $"Score : {score}";
    }
}
