using UnityEngine.Events;

namespace Managers
{
    public class GlobalEventManager
    {
        public static UnityEvent OnEnemyKilled = new UnityEvent();

        public static void SendEnemyKilled(){
            OnEnemyKilled.Invoke();
        }
    }
}