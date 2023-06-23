using UnityEngine;

namespace Gameplay
{
    public class Mover2DItems : MonoBehaviour
    {
        private PoolIcons _poolIcons;
    
        private int _indexFoundObject;

        private void Start()
        {
            _poolIcons = GetComponent<PoolIcons>();
        }

        public void MoveIconRight(string id, Item2D item2D, int step)
        {
            string valueToCheck = id;

            _indexFoundObject = _poolIcons.ItemsIDList.FindIndex(obj => obj == valueToCheck);

            item2D.ChangePosition(_poolIcons.PositionsList[_indexFoundObject + step]);

            for (int i = _poolIcons.ItemsList.Count - 1; i >= _indexFoundObject + step; i--)
            {
                _poolIcons.ItemsList[i].ChangePosition(_poolIcons.PositionsList[i + 1]);
            }
        }
    
        public void MoveRemainingObjects()
        {
            for (int i = 0; i < _poolIcons.ItemsList.Count; i++)
            {
                _poolIcons.ItemsList[i].ChangePosition(_poolIcons.PositionsList[i]);
            }
        }
    }
}
