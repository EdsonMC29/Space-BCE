using UnityEngine;
using SpaceBCE.Core; // Para acceder a MissionEvents

public class HelmetTest : MonoBehaviour
{
    // Este método avisará a la Máquina de Estados que ya podemos despegar
    public void ActivateHelmet()
    {
        Debug.Log("Casco agarrado. Avisando al MissionManager...");
        MissionEvents.OnHelmetEquipped?.Invoke(); 
    }
}