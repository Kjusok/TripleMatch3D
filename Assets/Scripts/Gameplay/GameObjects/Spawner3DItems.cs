using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Spawner3DItems : MonoBehaviour
    {
        [SerializeField] private Item3D[] _items;
        [SerializeField] private Canvas _canvas;

        private CounterPositionCalculator _counterPositionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;

        [Inject]
        public void Construct(CounterPositionCalculator counterPositionCalculator, ListsManipulator listsManipulator, Canvas canvas, CheckerDuplicate2dItems checkerDuplicate2dItems)
        {
            _counterPositionCalculator = counterPositionCalculator;
            _listsManipulator = listsManipulator;
            _canvas = canvas;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
        }

        private void Start()
        {
            SpawnItems();
        }

        private void SpawnItems()
        {
            for (int i = 0; i < 90; i++)
            {
                var item = Instantiate(_items[Random.Range(0, 10)],
                    new Vector3(Random.Range(-3.5f, 3.5f), 4, Random.Range(-3.5f, 3.5f)),
                    Quaternion.identity);

                item.Initialize(_canvas, _counterPositionCalculator, _listsManipulator, _checkerDuplicate2dItems);

                item.transform.parent = gameObject.transform;
            }
        }
    }
}
