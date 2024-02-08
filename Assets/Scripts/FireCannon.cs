using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FireCannon : MonoBehaviour
{
    public Rigidbody cannonBallPrefab;
    public Transform cannonBallSpawnPoint;
    public PowderPotCollision powderPotCollision;

    [SerializeField] private InputActionProperty triggerAction;

    public float fireSpeed =1f;
    // Start is called before the first frame update
    void Update()
    {
        // shoot once when trigger is pressed
        if (triggerAction.action.triggered)
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
        if (cannonBallPrefab != null && powderPotCollision.GetPowderAmount() > 0f)
        {
            Rigidbody newBall = Instantiate(cannonBallPrefab, null);
            newBall.transform.position = cannonBallSpawnPoint.position;
            /* // Placer une boule à l'avant du canon
            // newBall.transform

            // Déplacer la boule
            newBall.velocity = transform.forward * fireSpeed; */

            // adjust fire speed
            float adjustedFireSpeed = fireSpeed * (1+ 2*powderPotCollision.GetPowderAmount());
            newBall.velocity = transform.forward * adjustedFireSpeed;

            powderPotCollision.ResetPowderAmount();
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(cannonBallSpawnPoint.position, 0.1f);
    }
    // Update is called once per frame

}
