using Audio;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace UI
{
    public class PauseMenu: MonoBehaviour
    {
        private IPause _pauseManager;

        
        [Inject]
        public void Construct(IPause pause)
        {
            _pauseManager = pause;
        }
        
        public void Open()
        {
            gameObject.SetActive(true);
            _pauseManager.Paused = true;
        }
        
        public void Close()
        {
            gameObject.SetActive(false);
            _pauseManager.Paused = false;
        }
    }
}