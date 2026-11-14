using UnityEngine;
using UnityEngine.SceneManagement;
using SpaceBCE.Core.StateMachines;

namespace SpaceBCE.Core
{
    public class MissionManager : StateMachine
    {
        // Singleton puro para asegurar que solo exista un cerebro de misión
        public static MissionManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            // Evita que este GameObject se destruya si alguna vez cargas una escena de forma no aditiva
            DontDestroyOnLoad(gameObject); 
        }

        private void Start()
        {
            // Arranca la simulación inicializando la Fase C (Hangar)
            ChangeState(new HangarPhaseState(this));
        }

        /// <summary>
        /// Carga una escena de forma asíncrona y aditiva (no congela el visor VR)
        /// </summary>
        public void LoadPhaseSceneAsync(int sceneBuildIndex)
        {
            SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);
        }

        /// <summary>
        /// Descarga la escena de la memoria para liberar RAM en el Quest 3S
        /// </summary>
        public void UnloadPhaseSceneAsync(int sceneBuildIndex)
        {
            SceneManager.UnloadSceneAsync(sceneBuildIndex);
        }
    }
}