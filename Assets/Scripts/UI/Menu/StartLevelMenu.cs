using Audio;
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
        private SoundsList _soundsList;

        
        [Inject]
        public void Construct(IPause pause, SoundsList soundsList)
        {
            _pauseManager = pause;
            _soundsList = soundsList;
        }

        private void Start()
        {
            _pauseManager.Paused = true;
        }

        public void Close()
        {
            _soundsList.FallingItems();
            
            gameObject.SetActive(false);
            _pauseManager.Paused = false;
            
            _turnOffCollider.OffCollider();
        }
    }
}