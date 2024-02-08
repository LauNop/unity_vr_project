using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Utilisez TMP_Text pour TextMeshPro
    private int score = 0;

    private void Start()
    {
        // Assurez-vous que le composant TextMeshPro est attribué dans l'inspecteur Unity
        if (scoreText == null)
        {
            Debug.LogError("Assign the TMP_Text component in the Unity Inspector.");
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void IncrementScore()
    {
        // Incrémente le score
        score++;
        UpdateScoreText();
    }
}