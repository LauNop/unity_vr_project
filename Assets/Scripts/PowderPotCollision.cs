using UnityEngine;
using UnityEngine.UI; // Importez ce namespace pour travailler avec l'UI

public class PowderPotCollision : MonoBehaviour
{
    public GameObject exhaust;
    public Slider powderGauge; // Référence au Slider UI
    private float powderAmount = 0f; // Quantité actuelle de poudre, initialement 0
    public float fillRate = 0.3f; // Taux de remplissage de la jauge par contact

    private bool isTouchingExhaust = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == exhaust)
        {
            isTouchingExhaust = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == exhaust)
        {
            isTouchingExhaust = false;
        }
    }

    private void Update()
    {
        if (isTouchingExhaust && powderAmount < 1f) // Si touchant et la jauge n'est pas encore pleine
        {
            FillMeter(fillRate * Time.deltaTime);
        }
    }

    private void FillMeter(float amount)
    {
        powderAmount += amount;
        powderAmount = Mathf.Clamp(powderAmount, 0f, 1f); // S'assurer que la quantité de poudre reste entre 0 et 1
        powderGauge.value = powderAmount; // Mettre à jour la valeur du Slider UI

        if (powderAmount >= 1f)
        {
            Debug.Log("Canon est complètement chargé !");
            // Ici, vous pouvez ajouter d'autres logiques spécifiques une fois la jauge pleine
        }
    }
    public void ResetPowderAmount()
    {
        powderAmount = 0f;
        powderGauge.value = powderAmount;
    }

    public float GetPowderAmount()
    {
        return powderAmount;
    }
}
