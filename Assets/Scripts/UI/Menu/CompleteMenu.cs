using Audio;
using Gameplay.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CompleteMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        
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
            _soundsList.WinLevel();
            gameObject.SetActive(true);
            _pauseManager.Paused = true;
        }

        public void SaveTime(string time)
        {
            _timerText.text = time;
        }
    }
}