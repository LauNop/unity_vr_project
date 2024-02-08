using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    public GameObject targetBrokenPrefab; // Assign your TargetBroken prefab or object in the Inspector
    public GameObject target;
    public bool isHit= false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Ensure your CannonBall prefab has the tag "Ball"
        {
            if(!isHit)
            {
                isHit = true;
                Debug.Log("Ball through");
                target.SetActive(false); // Deactivate the current target
                targetBrokenPrefab.SetActive(true); // Activate the broken target
                ApplyForceToBrokenParts(targetBrokenPrefab);
                FindObjectOfType<SpawnManager>().Spawn();
            }
        }
    }

    private void ApplyForceToBrokenParts(GameObject brokenTarget)
    {
        foreach (Rigidbody rb in brokenTarget.GetComponentsInChildren<Rigidbody>())
        {
            // Applique une force aléatoire pour disperser les morceaux
            Debug.Log("Applying force");
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f));
            rb.AddForce(randomDirection.normalized * Random.Range(5f, 10f), ForceMode.Impulse);
        }
    }
}