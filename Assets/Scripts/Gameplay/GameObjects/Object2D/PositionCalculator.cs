using UnityEngine;

namespace Gameplay
{
    public class PositionCalculator : MonoBehaviour
    {
        private int _positionX;

        private ListsManipulator _listsManipulator;
        private Item2DCounter _item2DCounter;

        private void Awake()
        {
            _listsManipulator = GetComponent<ListsManipulator>();
            _item2DCounter = GetComponent<Item2DCounter>();
        }

        public Vector2 TargetPosition()
        {
            var position = _listsManipulator.PositionsList[_item2DCounter.Counter - 1];
            
            return position.position;
        }
    } 
}
