using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetPrefab;
    public Transform spawnPoint;
    public ArrayList targetList = new ArrayList();

    void Start()
    {
        PrintTargetCount();
    }

    public void Spawn(){
        GameObject newTarget = Instantiate(targetPrefab, null);
        newTarget.transform.position = spawnPoint.position;
        targetList.Add(newTarget);
        PrintTargetCount();
    }
    
    void PrintTargetCount()
    {
        Debug.Log("Targets:");
        Debug.Log(targetList.Count);
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
