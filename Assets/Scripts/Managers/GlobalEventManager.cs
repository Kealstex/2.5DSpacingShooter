using System;

namespace Managers
{
    public class GlobalEventManager
    {
        public static event Action OnEnemyKilled;

        public static void SendEnemyKilled(){
            OnEnemyKilled?.Invoke();
        }
    }
}