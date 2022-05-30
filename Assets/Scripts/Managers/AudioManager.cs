using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource background;
        [SerializeField] private AudioSource laser;
        
        public void LaserPlay(){
            laser.Play();
        } 
    }
}