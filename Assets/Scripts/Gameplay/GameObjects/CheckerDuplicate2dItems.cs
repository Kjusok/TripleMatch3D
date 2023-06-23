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
    
        private int _indexFoundObject;
        private int _step = 1;
    
        private bool _isRepeatsOnce;
        private bool _isRepeatedTwice;
    
        private Holder2DItems _holder2DItems;
        private Mover2DItems _mover2DItems;
        private PoolIcons _poolIcons;

    
        [Inject]
        public void Construct(Holder2DItems holder2DItems)
        {
            _holder2DItems = holder2DItems;
        }
    
        private void Awake()
        {
            _mover2DItems = GetComponent<Mover2DItems>();
            _poolIcons = GetComponent<PoolIcons>();
        }
    
        public void CheckContainsValue(string id, Item2D item2D)
        {
            _isRepeatsOnce = _poolIcons.ItemsIDList.Contains(id);
    
            _isRepeatedTwice = CheckMultipleOccurrences(_poolIcons.ItemsIDList, id);
    
            if (_isRepeatedTwice)
            {
                _step = DoubleStep;
                _mover2DItems.MoveIconRight(id, item2D, _step);
    
                return;
            }
    
            if (_isRepeatsOnce)
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
    
            foreach (string icon in _poolIcons.ItemsIDList)
            {
                if (icon == id)
                {
                    count++;
    
                    if (count >= ValueDestroy)
                    {
                        _poolIcons.DestroyDuplicateElements(id);
                        _mover2DItems.MoveRemainingObjects();
                        _holder2DItems.SubtractFromCounter();
    
                        break;
                    }
                }
            }
        }
    }
}
