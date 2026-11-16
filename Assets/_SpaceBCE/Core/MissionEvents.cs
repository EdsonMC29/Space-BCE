using System;

namespace SpaceBCE.Core
{
    public static class MissionEvents
    {
        public static Action OnHelmetEquipped;
        
        // NUEVO: Evento que se dispara al salir de la atmósfera y presionar el botón de staging
        public static Action OnStagingCompleted; 
    }
}