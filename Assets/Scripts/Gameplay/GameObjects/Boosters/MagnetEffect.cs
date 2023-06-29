using UnityEngine;

namespace Gameplay
{
    public class MagnetEffect: MonoBehaviour
    {
        private const float Lifetime = 0.5f;

        
        private float _timer;
        
        private void Update()
        {
            Timer();
        }

        private void Timer()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            
            if (_timer <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        public void StartEffect()
        {
            _timer = Lifetime;
            gameObject.SetActive(true);
        }
    }
}