using Audio;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace UI
{
    public class FailedMenu : MonoBehaviour
    {
        private IPause _pauseManager;
        private SoundsList _soundsList;

        
        [Inject]
        public void Construct(IPause pause, SoundsList soundsList)
        {
            _pauseManager = pause;
            _soundsList = soundsList;
        }

        public void Open()
        {
            _soundsList.FailedLevel();
            gameObject.SetActive(true);
            _pauseManager.Paused = true;
        }
    }
}