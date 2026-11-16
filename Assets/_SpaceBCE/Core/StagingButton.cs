using UnityEngine;
using SpaceBCE.Core;

namespace SpaceBCE.Features.Cockpit
{
    public class StagingButton : MonoBehaviour
    {
        private bool _isPressed = false;

        /// <summary>
        /// Este método se puede llamar desde el evento "Select Entered" de un XR Simple Interactable
        /// o mediante un trigger físico de los dedos del XR Hands.
        /// </summary>
        public void PressButton()
        {
            if (_isPressed) return;
            
            _isPressed = true;
            Debug.Log("[Cabina] Botón de Staging presionado.");
            
            // Dispara el evento global que la Máquina de Estados está escuchando
            MissionEvents.OnStagingCompleted?.Invoke();
        }
    }
} 