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
        [SerializeField] private Canvas _canvas;
        private List<Item3D> _itemsClickList;

        private CounterPositionCalculator _counterPositionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;
        private CollectAndDisableItems3D _collectAndDisableItems3D;

        
        [Inject]
        public void Construct(CounterPositionCalculator counterPositionCalculator,
            ListsManipulator listsManipulator,
            Canvas canvas,
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal)
        {
            _counterPositionCalculator = counterPositionCalculator;
            _listsManipulator = listsManipulator;
            _canvas = canvas;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
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
                    
                    item.Initialize(_canvas, _counterPositionCalculator, _listsManipulator, _checkerDuplicate2dItems, _compareItem2DAndGoal);
                    item.transform.parent = gameObject.transform;
                    
                    _collectAndDisableItems3D.AddToList(item);
                }
            }
        }
    }
}