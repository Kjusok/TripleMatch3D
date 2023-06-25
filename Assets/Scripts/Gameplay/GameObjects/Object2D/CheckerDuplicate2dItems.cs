using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CheckerDuplicate2dItems : MonoBehaviour
    {
        private const int DoubleStep = 2;
        private const int ValueDestroy = 3;
    
        private int _step = 1;
        public bool _isRepeatedTwice;
    
        private Item2DCounter _item2DCounter;
        private Mover2DItems _mover2DItems;
        private ListsManipulator _listsManipulator;

        public bool IsRepeatsOnce
        {
            get; private set;
        }
        
        [Inject]
        public void Construct(Item2DCounter item2DCounter)
        {
           _item2DCounter = item2DCounter;
        }
    
        private void Awake()
        {
            _mover2DItems = GetComponent<Mover2DItems>();
            _listsManipulator = GetComponent<ListsManipulator>();
        }
    
        public void CheckContainsValue(string id, Item2D item2D)
        {
            IsRepeatsOnce = _listsManipulator.ItemsIDList.Contains(id);
            _isRepeatedTwice = CheckMultipleOccurrences(_listsManipulator.ItemsIDList, id);

            _item2DCounter.CheckTaskFailed(IsRepeatsOnce);

            if (_isRepeatedTwice)
            {
                _step = DoubleStep;
                _mover2DItems.MoveIconRight(id, item2D, _step);
    
                return;
            }
    
            if (IsRepeatsOnce)
            {
                _step = 1;
                _mover2DItems.MoveIconRight(id, item2D, _step);
            }
        }
        
        private bool CheckMultipleOccurrences(List<string> list, string item)
        {
            int count = list.Count(x => x.Equals(item));
            return count > 1;
        }
    
        public void CheckingThreeIdentical(string id)
        {
            int count = 0;
    
            foreach (string icon in _listsManipulator.ItemsIDList)
            {
                if (icon == id)
                {
                    count++;
    
                    if (count >= ValueDestroy)
                    {
                        _listsManipulator.RemoveAndDestroyDuplicateElements(id);
                        _mover2DItems.MoveRemainingObjects();
                        _item2DCounter.SubtractFromCounter();
    
                        break;
                    }
                }
            }
        }
    }
}
