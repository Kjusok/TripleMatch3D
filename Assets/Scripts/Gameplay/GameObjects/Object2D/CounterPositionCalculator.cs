using UnityEngine;

namespace Gameplay
{
    public class CounterPositionCalculator : MonoBehaviour
    {
        private const int Triple = 3;
        
        private int _positionX;
        private int _counter;

        private ListsManipulator _listsManipulator;

        private void Awake()
        {
            _listsManipulator = GetComponent<ListsManipulator>();
        }

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
            var position = _listsManipulator.PositionsList[_counter-1];
            
            return position.position;
        }
    } 
}
