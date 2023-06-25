using UnityEngine;
using System;

namespace Gameplay
{
    public class Item2DCounter : MonoBehaviour, IFailedLevel
    {
        private const int Triple = 3;
        private const int LimitCount = 7;

        private int _counter;

        public int Counter => _counter;
        
        public event Action TaskFailed; 
        
        public void AddToCounter()
        {
            _counter++;
        }

        public void SubtractFromCounter()
        {
            _counter -= Triple;
        }

        public void CheckTaskFailed(bool isRepeatsOnce)
        {
            if (!isRepeatsOnce)
            {
                if (_counter == LimitCount)
                {
                    TaskFailed?.Invoke();
                }
            }
        }
    }
}