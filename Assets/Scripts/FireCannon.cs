using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FireCannon : MonoBehaviour
{
    public Rigidbody cannonBallPrefab;
    public Transform cannonBallSpawnPoint;

    [SerializeField] private InputActionProperty triggerAction;

    public float fireSpeed =3.0f;
    // Start is called before the first frame update
    void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();
        if (triggerValue > 0.5f)
        {
            Fire();
        }
    }

    void OnSelectEnter(SelectEnterEventArgs ags)
    {
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

}
