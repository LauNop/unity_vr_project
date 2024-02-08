using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    SpawnTarget[] spawnTargets;
    public TMP_Text scoreText; // Utilisez TMP_Text pour TextMeshPro
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        spawnTargets = gameObject.GetComponentsInChildren<SpawnTarget>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Spawn(){
        gameObject.SetActive(true);
        StartCoroutine(SleepCoroutine());
        Debug.Log("SpawnPoints:");
        Debug.Log(spawnTargets.Length);
    }

    IEnumerator SleepCoroutine()
    {
        print("Coroutine enter");
        yield return new WaitForSeconds(2f);
        spawnTargets = gameObject.GetComponentsInChildren<SpawnTarget>();
        if (spawnTargets.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnTargets.Length);
            spawnTargets[randomIndex].Spawn();
        }
        else
        {
            Debug.LogWarning("Aucun SpawnTarget trouvé dans les enfants de ce gameObject.");
        }
        print("Coroutine exit");

    }
}
