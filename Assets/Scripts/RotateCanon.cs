using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateCanon : MonoBehaviour
{
    public Transform Rotater; // Assurez-vous d'attribuer le transform de l'objet Rotater dans l'inspecteur Unity.
    private XRSimpleInteractable interactable;
    private bool isRotating = false;
    private float onClickedAngle = 0f;

    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnter);
        interactable.selectExited.AddListener(OnSelectQuit);
    }

    void Update()
    {
        if (isRotating)
        {
            rotate(interactable.selectingInteractor);
            onClickedAngle = interactable.selectingInteractor.transform.eulerAngles.y;
        }
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        isRotating = true;
        onClickedAngle = args.interactor.transform.eulerAngles.y;
    }

    void OnSelectQuit(SelectExitEventArgs args)
    {
        isRotating = false;
    }

    void rotate(XRBaseInteractor interactor)
    {
        // Get the angle of the interactor
        float angle = interactor.transform.eulerAngles.y;

        // Calculate the rotation difference between the interactor and the Rotater
        float rotationDifference = angle - onClickedAngle;

        // Rotate the Rotater horizontally based on the movement of the interactor
        Rotater.Rotate(0, - rotationDifference, 0);
    }
}