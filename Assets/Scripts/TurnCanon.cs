using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnCanon : MonoBehaviour
{
    public GameObject canon;
    public GameObject handle;
    
    private XRSimpleInteractable interactable;
    private float previousAngle = 0;
    private bool isRotating = false;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectQuit);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        // set isRotating to true when the rotation of the interactor changes
        isRotating = true;
    }

    void OnSelectQuit(SelectExitEventArgs args)
    {
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 currentControllerAngle = interactable.selectingInteractor.transform.rotation.eulerAngles;
        Debug.Log(currentControllerAngle);
        if (currentControllerAngle.y != previousAngle && isRotating)
        {
            rotate(interactable.selectingInteractor);
        }
        previousAngle = currentControllerAngle.y;
    }

    void rotate(XRBaseInteractor interactor)
    {
        // Get the center of the handle in world space
        Vector3 handleCenter = handle.transform.position;

        // Get the direction from the handle to the interactor's position
        Vector3 interactorPos = interactor.transform.position;
        Vector3 handleProj = handle.transform.InverseTransformPoint(interactorPos);
        handleProj.z = 0;
        interactorPos = handle.transform.TransformPoint(handleProj);
        
        Vector3 direction = interactorPos - handleCenter;
        
        // Rotate the crank to the specified direction
        
        
        // Calculate the angle from the handle to the interactor's position
        float currentAngle = Vector3.SignedAngle(handle.transform.up, direction, handle.transform.forward);
        float angle = currentAngle - previousAngle;

        // Rotate the handle around its center based on the calculated angle
        handle.transform.RotateAround(handleCenter, handle.transform.forward, angle);
        canon.transform.RotateAround(handleCenter, handle.transform.forward, angle);
        previousAngle = currentAngle;
    }


}
