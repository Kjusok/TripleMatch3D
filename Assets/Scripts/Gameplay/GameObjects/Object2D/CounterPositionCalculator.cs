using UnityEngine;

namespace Gameplay
{
    public class CounterPositionCalculator : MonoBehaviour
    {
        private const int PositionY = -588;
        private const int StartPositionX = -390;
        private const int StepPositionX = 130;
        private const int Triple = 3;
        
        private int _positionX;
        private int _counter;

        public void AddToCounter()
        {
            _counter++;
        }

        public void SubtractFromCounter()
        {
            _counter -= Triple;
        }
    
        public Vector2 TargetPosition()
        {
            _positionX = StartPositionX;
        
            for (int i = 1; i < _counter; i++)
            {
                _positionX += StepPositionX;
            }
        
            return new Vector2(_positionX, PositionY);
        }
    } 
}
