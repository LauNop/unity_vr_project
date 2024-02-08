using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    SpawnTarget[] spawnTargets;
    // Start is called before the first frame update
    void Start()
    {
        spawnTargets = gameObject.GetComponentsInChildren<SpawnTarget>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        spawnTargets[0].Spawn();
        print("Coroutine exit");

    }
}
