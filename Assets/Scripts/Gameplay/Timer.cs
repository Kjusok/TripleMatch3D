using System;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textTimer;
        [SerializeField] private float _timer = 180;
        
        private void Update()
        {
            _timer -= Time.deltaTime;
            
            UpdateTimeText(_textTimer, _timer);
        }

        private void UpdateTimeText(TMP_Text text, float time)
        {
            var timeSpan = TimeSpan.FromSeconds(time);
            var minutes = timeSpan.Minutes;
            var seconds = timeSpan.Seconds;

            text.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
        }
    }
}