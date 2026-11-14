namespace SpaceBCE.Core.StateMachines
{
    public interface IState
    {
        /// <summary>
        /// Se ejecuta una sola vez al entrar al estado. Útil para inicializar variables o UI.
        /// </summary>
        void Enter();

        /// <summary>
        /// Lógica por frame (Update). Útil para leer inputs de los mandos Quest o mover UI.
        /// </summary>
        void Tick();

        /// <summary>
        /// Lógica de físicas (FixedUpdate). Vital en VR para aplicar fuerzas a la nave o mandos.
        /// </summary>
        void FixedTick();

        /// <summary>
        /// Se ejecuta justo antes de cambiar a otro estado. Útil para limpiar eventos o apagar luces.
        /// </summary>
        void Exit();
    }
}