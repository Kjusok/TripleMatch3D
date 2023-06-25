using Gameplay.GameObjects;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartLevelMenu : MonoBehaviour
    {
        [SerializeField] private TurnOffCollider _turnOffCollider;
        
        private IPause _pauseManager;
        
        
        [Inject]
        public void Construct(IPause pause)
        {
            _pauseManager = pause;
        }

        private void Start()
        {
            _pauseManager.Paused = true;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _pauseManager.Paused = false;
            
            _turnOffCollider.OffCollider();
        }
    }
}