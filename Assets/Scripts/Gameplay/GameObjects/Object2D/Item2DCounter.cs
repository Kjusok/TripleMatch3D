using UnityEngine;
using System;

namespace Gameplay
{
    public class Item2DCounter : MonoBehaviour
    {
        private const int Triple = 3;

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
                if (_counter == 7)
                {
                    TaskFailed?.Invoke();
                }
            }
        }
    }
}