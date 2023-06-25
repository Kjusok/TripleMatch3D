using System.Collections.Generic;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Spawner3DItems : MonoBehaviour
    {
        private const float StartPoint = -3.5f;
        private const float EndPoint = 3.5f;
        private const float StartPositionY = 2.5f;
        
        [SerializeField] private List<ItemCountPair> _itemCountPairs;
        
        private List<Item3D> _itemsClickList;
        private PositionCalculator _positionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;
        private CollectItems3D _collectItems3D;
        private Item2DCounter _item2DCounter;
        private IPause _pauseManager;

        
        [Inject]
        public void Construct(PositionCalculator positionCalculator,
            ListsManipulator listsManipulator,
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal,
            Item2DCounter item2DCounter,
            IPause pause)
        {
            _positionCalculator = positionCalculator;
            _listsManipulator = listsManipulator;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
            _item2DCounter = item2DCounter;
            _pauseManager = pause;
        }

        private void Awake()
        {
            _collectItems3D = GetComponent<CollectItems3D>();
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
                        new Vector3(Random.Range(StartPoint, EndPoint),
                            StartPositionY,
                            Random.Range(StartPoint, EndPoint)),
                        Quaternion.identity);
                    
                    item.GetComponent<ClickOn3DItem>().Construct(_pauseManager);
                    item.GetComponent<GravitySwitch>().Construct(_pauseManager);
                    
                    item.Initialize(_positionCalculator,
                        _listsManipulator,
                        _checkerDuplicate2dItems,
                        _compareItem2DAndGoal,
                        _item2DCounter);
                    item.transform.parent = gameObject.transform;
                    
                    _collectItems3D.AddToList(item);
                }
            }
        }
    }
}