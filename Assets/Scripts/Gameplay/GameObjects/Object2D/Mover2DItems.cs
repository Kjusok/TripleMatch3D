using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(ListsManipulator))]
    public class Mover2DItems : MonoBehaviour
    {
        private ListsManipulator _listsManipulator;
    
        
        private void Awake()
        {
            _listsManipulator = GetComponent<ListsManipulator>();
        }

        public void MoveIconRight(string id, Item2D item2D, int step)
        {
            item2D.ChangePosition(_listsManipulator.PositionsList[IndexFoundedObject(id) + step].position);

            for (int i = _listsManipulator.ItemsList.Count - 1; i >= IndexFoundedObject(id) + step; i--)
            {
                _listsManipulator.ItemsList[i].ChangePosition(_listsManipulator.PositionsList[i + 1].position);
            }
        }
        
        public int IndexFoundedObject(string id)
        {
            return _listsManipulator.ItemsIDList.FindIndex(obj => obj == id);
        }
    
        public void MoveRemainingObjects()
        {
            for (int i = 0; i < _listsManipulator.ItemsList.Count; i++)
            {
                _listsManipulator.ItemsList[i].ChangePosition(_listsManipulator.PositionsList[i].position);
            }
        }
    }
}
