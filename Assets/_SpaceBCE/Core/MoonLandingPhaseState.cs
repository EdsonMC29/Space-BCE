using UnityEngine;
using SpaceBCE.Core.StateMachines;

namespace SpaceBCE.Core
{
    public class MoonLandingPhaseState : IState
    {
        private readonly MissionManager _missionManager;
        private readonly int _sceneIndex = 3; // Índice 3 en Build Settings: 03_Moon_Landing

        public MoonLandingPhaseState(MissionManager missionManager)
        {
            _missionManager = missionManager;
        }

        public void Enter()
        {
            Debug.Log("[MoonLandingPhaseState] Iniciando Fase E. Cargando dataset topográfico lunar...");
            
            // Carga la escena con el módulo lunar y el relieve de la NASA
            _missionManager.LoadPhaseSceneAsync(_sceneIndex);

            // Futuro evento para transicionar a la Fase F (ISS):
            // MissionEvents.OnLunarMissionFinished += GoToISS;
        }

        public void Tick()
        {
            // Aquí procesaremos los joysticks 6DOF en el futuro
        }

        public void FixedTick()
        {
            // Físicas de microgravedad
        }

        public void Exit()
        {
            Debug.Log("[MoonLandingPhaseState] Aterrizaje completado. Saliendo de la Luna...");
            _missionManager.UnloadPhaseSceneAsync(_sceneIndex);
        }
    }
}