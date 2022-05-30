using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource background;
        [SerializeField] private AudioSource laser;
        [SerializeField] private AudioSource explosion;
        [SerializeField] private AudioSource powerUp;
        
        public void LaserPlay(){
            laser.Play();
        }

        public void ExplosionPlay(){
            explosion.Play();
        }

        public void PowerUpPlay(){
            powerUp.Play();
        }
    }
}