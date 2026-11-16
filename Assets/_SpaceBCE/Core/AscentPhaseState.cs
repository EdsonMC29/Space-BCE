using UnityEngine;
using SpaceBCE.Core.StateMachines;

namespace SpaceBCE.Core
{
    public class AscentPhaseState : IState
    {
        private readonly MissionManager _missionManager;
        private readonly int _sceneIndex = 2; // 02_Cockpit_Ascent

        public AscentPhaseState(MissionManager missionManager)
        {
            _missionManager = missionManager;
        }

        public void Enter()
        {
            Debug.Log("[AscentPhaseState] Iniciando Fase D (Despegue). Cargando cabina...");
            
            // 1. Nos suscribimos al evento del botón de la nave
            MissionEvents.OnStagingCompleted += FinishAscent;
            
            // 2. Cargamos la escena
            _missionManager.LoadPhaseSceneAsync(_sceneIndex);
        }

        public void Tick() { }
        public void FixedTick() { }

        public void Exit()
        {
            // Desuscribirse siempre en el Exit para evitar fugas de memoria
            MissionEvents.OnStagingCompleted -= FinishAscent;
            
            _missionManager.UnloadPhaseSceneAsync(_sceneIndex);
        }

        private void FinishAscent()
        {
            Debug.Log("[AscentPhaseState] Staging completado. Rumbo a la Luna.");
            // Transición a la siguiente fase
            _missionManager.ChangeState(new MoonLandingPhaseState(_missionManager));
        }
    }
}