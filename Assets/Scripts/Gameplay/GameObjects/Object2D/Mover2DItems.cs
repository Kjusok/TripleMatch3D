using UnityEngine;

namespace Gameplay
{
    public class Mover2DItems : MonoBehaviour
    {
        private ListsManipulator _listsManipulator;
    
        public int IndexFoundObject
        {
            get; private set;
        }

        private void Awake()
        {
            _listsManipulator = GetComponent<ListsManipulator>();
        }

        public void MoveIconRight(string id, Item2D item2D, int step)
        {
            string valueToCheck = id;

            IndexFoundObject = _listsManipulator.ItemsIDList.FindIndex(obj => obj == valueToCheck);

            item2D.ChangePosition(_listsManipulator.PositionsList[IndexFoundObject + step].position);

            for (int i = _listsManipulator.ItemsList.Count - 1; i >= IndexFoundObject + step; i--)
            {
                _listsManipulator.ItemsList[i].ChangePosition(_listsManipulator.PositionsList[i + 1].position);
            }
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
