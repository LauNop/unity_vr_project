using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireCannon : MonoBehaviour
{
    public Rigidbody cannonBallPrefab;
    public Transform cannonBallSpawnPoint;

    public float fireSpeed =3.0f;
    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    void OnSelectEnter(SelectEnterEventArgs ags)
    {
        print("Select");
        Fire();
    }

    void Fire()
    {
        Rigidbody newBall = Instantiate(cannonBallPrefab, null);
        // Placer une boule à l'avant du canon
        // newBall.transform
        newBall.transform.position = cannonBallSpawnPoint.position;
        // Déplacer la boule
        newBall.velocity = transform.forward * fireSpeed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(cannonBallSpawnPoint.position, 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
