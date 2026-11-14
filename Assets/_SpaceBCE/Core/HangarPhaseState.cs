using UnityEngine;
using SpaceBCE.Core.StateMachines;

namespace SpaceBCE.Core
{
    public class HangarPhaseState : IState
    {
        private readonly MissionManager _missionManager;
        private readonly int _sceneIndex = 1; // Índice de 01_Hangar_Preparation en el Build Settings

        // Inyección de dependencias a través del constructor
        public HangarPhaseState(MissionManager missionManager)
        {
            _missionManager = missionManager;
        }

        public void Enter()
        {
            Debug.Log("[HangarPhaseState] Iniciando Fase C. Cargando Hangar en background...");
            
            // Carga la escena del Hangar aditivamente
            _missionManager.LoadPhaseSceneAsync(_sceneIndex);
            
            // Aquí te suscribirás a eventos futuros. Ejemplo:
            // EventBroker.OnHelmetEquipped += FinishPreparation;
        }

        public void Tick()
        {
            // Lógica por frame exclusiva del hangar (si fuera necesaria)
        }

        public void FixedTick()
        {
            // Físicas específicas de esta fase
        }

        public void Exit()
        {
            Debug.Log("[HangarPhaseState] Secuencia completada. Descargando Hangar...");
            
            // Libera la memoria borrando el hangar
            _missionManager.UnloadPhaseSceneAsync(_sceneIndex);
            
            // Limpieza de eventos
            // EventBroker.OnHelmetEquipped -= FinishPreparation;
        }

        // Método simulado para probar la transición a la siguiente fase
        private void FinishPreparation()
        {
            // _missionManager.ChangeState(new AscentPhaseState(_missionManager));
        }
    }
}