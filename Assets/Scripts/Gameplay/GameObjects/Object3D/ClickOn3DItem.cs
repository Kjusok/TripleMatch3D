using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ClickOn3DItem : MonoBehaviour
    {
        private const float Coefficient = 1.1f;
        private const float Speed = 2f;
    
        private Vector3 _startScale;
        
        private IPause _pauseManager;
        
        
        [Inject]
        public void Construct(IPause pause)
        {
            _pauseManager = pause;
        }

        public void OnMouseUp()
        {
            if (!_pauseManager.Paused)
            {
                GetComponent<Item3D>().SpawnIcon(false);

                Destroy(gameObject);
            }
        }

        public void OnMouseDown()
        {
            if (!_pauseManager.Paused)
            {
                GetComponent<Outline>().enabled = true;

                _startScale = transform.localScale;
            }
        }

        private void Update()
        {
            if (_pauseManager.Paused)
            {
                return;
            }
            
            ChangeScale();
        }

        private void ChangeScale()
        {
            if (transform.localScale.x < _startScale.x * Coefficient)
            {
                transform.localScale += _startScale * Time.deltaTime * Speed;
            }
        }
    }
}
