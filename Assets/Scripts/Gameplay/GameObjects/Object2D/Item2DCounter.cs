using UnityEngine;
using System;
using Audio;
using Gameplay.Services;
using Zenject;

namespace Gameplay
{
    public class Item2DCounter : MonoBehaviour, IFailedLevel
    {
        private const int Triple = 3;
        private const int LimitCount = 7;

        private int _counter;
        private SoundsList _soundsList;

        public int Counter => _counter;
        
        public event Action TaskFailed; 
        

        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }
        
        public void AddToCounter()
        {
            _counter++;
        }

        public void ApplyMatchThree()
        {
            _soundsList.VanishingTriple();
            _counter -= Triple;
        }

        public void CheckTaskFailed(bool isRepeatsTwice)
        {
            if (_counter == LimitCount && !isRepeatsTwice)
            {
                TaskFailed?.Invoke();
            }
        }
    }
}