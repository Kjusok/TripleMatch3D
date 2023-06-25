using System;
using Gameplay.Services;
using TMPro;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTimer;
        [SerializeField] private float _timer = 180;
        [SerializeField] private CompleteMenu _completeMenu;
        
        private IPause _pauseManager;

        public float CurrentTime => _timer;
        

        [Inject]
        public void Construct(IPause pause)
        {
            _pauseManager = pause;
        }
        
        private void Update()
        {
            if (_pauseManager.Paused)
            {
               return; 
            }
            
            _timer -= Time.deltaTime;
            
            UpdateTimeText(_textTimer, _timer);
        }

        private void UpdateTimeText(TMP_Text text, float time)
        {
            var timeSpan = TimeSpan.FromSeconds(time);
            var minutes = timeSpan.Minutes;
            var seconds = timeSpan.Seconds;

            text.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            
            _completeMenu.SafeTime(text.text);
        }
    }
}