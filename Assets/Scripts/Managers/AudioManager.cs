using System;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource background;
        [SerializeField] private AudioSource laser;
        [SerializeField] private AudioSource explosion;
        [SerializeField] private AudioSource powerUp;


        private void Start(){
            GlobalEventManager.OnPlayerKilled.AddListener(ExplosionPlay);
            GlobalEventManager.OnEnemyKilled.AddListener(ExplosionPlay);
        }

        public void LaserPlay(){
            laser.Play();
        }

        private void ExplosionPlay(){
            explosion.Play();
        }

        public void PowerUpPlay(){
            powerUp.Play();
        }
    }
}