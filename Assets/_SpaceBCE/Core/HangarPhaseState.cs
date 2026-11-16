using UnityEngine;
using SpaceBCE.Core.StateMachines;

namespace SpaceBCE.Core
{
    public class HangarPhaseState : IState
    {
        private readonly MissionManager _missionManager;
        private readonly int _sceneIndex = 1;

        public HangarPhaseState(MissionManager missionManager)
        {
            _missionManager = missionManager;
        }

        public void Enter()
        {
            Debug.Log("[HangarPhaseState] Fase C iniciada. Suscribiendo evento...");
            
            // ¡ESTA ES LA LÍNEA VITAL! Aquí el estado se pone los "auriculares" para escuchar
            MissionEvents.OnHelmetEquipped += FinishPreparation; 
            
            _missionManager.LoadPhaseSceneAsync(_sceneIndex);
        }

        public void Tick() { }
        public void FixedTick() { }

        public void Exit()
        {
            // Siempre quitarse los auriculares al salir
            MissionEvents.OnHelmetEquipped -= FinishPreparation; 
            _missionManager.UnloadPhaseSceneAsync(_sceneIndex);
        }

        // Este método se ejecutará en el instante que agarres el cubo
        private void FinishPreparation()
        {
            Debug.Log("[HangarPhaseState] ¡Evento escuchado! Cambiando a Fase D...");
            
            // ¡ESTA LÍNEA HACE EL CAMBIO!
            _missionManager.ChangeState(new AscentPhaseState(_missionManager));
        }
    }
}