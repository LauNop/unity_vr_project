using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateCanon : MonoBehaviour
{
    public Transform Rotater; // Assurez-vous d'attribuer le transform de l'objet Rotater dans l'inspecteur Unity.

    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        print("Select");
        rotate(args.interactor); // Passez l'interactor à la fonction rotate.
    }

    void rotate(XRBaseInteractor interactor)
    {
        // Assurez-vous que l'interactor n'est pas null
        if (interactor != null)
        {
            // Obtenez la direction du contrôleur (vecteur avant)
            Vector3 controllerForward = interactor.transform.forward;

            // Utilisez la direction pour faire tourner l'objet Rotater
            Rotater.transform.LookAt(Rotater.transform.position + controllerForward);

            // Vous pouvez également effectuer d'autres actions en fonction de la direction
            // par exemple, affichez la direction dans la console
            Debug.Log("Direction du contrôleur : " + controllerForward);
        }
    }
}
