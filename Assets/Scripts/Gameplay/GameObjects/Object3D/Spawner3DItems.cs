using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Spawner3DItems : MonoBehaviour
    {
        private const float StartPoint = -3.5f;
        private const float EndPoint = 3.5f;
        private const float StartPositionY = 4f;
        
        [SerializeField] private List<ItemCountPair> _itemCountPairs;
        private List<Item3D> _itemsClickList;

        private PositionCalculator _positionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;
        private CollectAndDisableItems3D _collectAndDisableItems3D;
        private Item2DCounter _item2DCounter;

        
        [Inject]
        public void Construct(PositionCalculator positionCalculator,
            ListsManipulator listsManipulator,
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal,
            Item2DCounter item2DCounter)
        {
            _positionCalculator = positionCalculator;
            _listsManipulator = listsManipulator;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
            _item2DCounter = item2DCounter;
        }

        private void Awake()
        {
            _collectAndDisableItems3D = GetComponent<CollectAndDisableItems3D>();
        }

        private void Start()
        {
            SpawnItems();
        }

        private void SpawnItems()
        {
            foreach (var pair in _itemCountPairs)
            {
                for (int j = 0; j < pair.Count; j++)
                {
                    var item = Instantiate(pair.Item,
                        new Vector3(Random.Range(StartPoint, EndPoint), StartPositionY, Random.Range(StartPoint, EndPoint)),
                        Quaternion.identity);
                    
                    item.Initialize(_positionCalculator, _listsManipulator, _checkerDuplicate2dItems, _compareItem2DAndGoal, _item2DCounter);
                    item.transform.parent = gameObject.transform;
                    
                    _collectAndDisableItems3D.AddToList(item);
                }
            }
        }
    }
}