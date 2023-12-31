﻿using System;
using Gameplay.Services;
using TMPro;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Timer : MonoBehaviour, IFailedLevel
    {
        [SerializeField] private TMP_Text _textTimer;
        [SerializeField] private float _timer = 180;
        [SerializeField] private CompleteMenu _completeMenu;
        
        private IPause _pauseManager;

        public float CurrentTime => _timer;
        public event Action TaskFailed;


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

            UpdateTimerAndCheckFailed();
            
            UpdateTimeText(_textTimer, _timer);
        }

        private void UpdateTimerAndCheckFailed()
        {
            if (_timer <= 0)
            {
                TaskFailed?.Invoke();
            }
            
            _timer -= Time.deltaTime;
        }

        private void UpdateTimeText(TMP_Text text, float time)
        {
            var timeSpan = TimeSpan.FromSeconds(time);
            var minutes = timeSpan.Minutes;
            var seconds = timeSpan.Seconds;

            text.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            
            _completeMenu.SaveTime(text.text);
        }
    }
}