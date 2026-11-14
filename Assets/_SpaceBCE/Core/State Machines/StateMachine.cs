using UnityEngine;

namespace SpaceBCE.Core.StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected IState CurrentState { get; private set; }

        /// <summary>
        /// Transiciona de forma segura apagando el estado anterior e inicializando el nuevo.
        /// </summary>
        public void ChangeState(IState newState)
        {
            if (CurrentState == newState) return;

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
            
            Debug.Log($"[StateMachine] Transición a: {newState.GetType().Name}");
        }

        protected virtual void Update()
        {
            CurrentState?.Tick();
        }

        protected virtual void FixedUpdate()
        {
            CurrentState?.FixedTick();
        }
    }
}