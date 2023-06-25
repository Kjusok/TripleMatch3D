using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GravitySwitch: MonoBehaviour
    {
        private IPause _pauseManager;
        private Rigidbody _rigidbody;
        
        [Inject]
        public void Construct(IPause pause)
        {
            _pauseManager = pause;
        }
        
        private void Start()
        {
            TurnOffGravity();
        }

        private void TurnOffGravity()
        {
            _rigidbody = GetComponent<Rigidbody>();

            if (_rigidbody != null)
            {
                _rigidbody.useGravity = false;
            }
        }

        private void Update()
        {
            if (_pauseManager.Paused)
            {
                return;
            }

            _rigidbody.useGravity = true;
        }
    }
}