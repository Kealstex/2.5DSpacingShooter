using UnityEngine.Events;

namespace Managers
{
    public static class GlobalEventManager
    {
        public static UnityEvent OnEnemyKilled = new UnityEvent();

        public static UnityEvent OnPlayerKilled = new UnityEvent();

        public static void SendEnemyKilled(){
            OnEnemyKilled.Invoke();
        }

        public static void SendPlayerKilled(){
            OnPlayerKilled.Invoke();
        }
    }
}