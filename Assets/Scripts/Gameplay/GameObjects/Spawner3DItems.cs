using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Spawner3DItems : MonoBehaviour
    {
        [SerializeField] private Item3D[] _items;
        [SerializeField] private Canvas _canvas;

        private Holder2DItems _holder2DItems;
        private PoolIcons _poolIcons;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;

        [Inject]
        public void Construct(Holder2DItems holder2DItems, PoolIcons poolIcons, Canvas canvas, CheckerDuplicate2dItems checkerDuplicate2dItems)
        {
            _holder2DItems = holder2DItems;
            _poolIcons = poolIcons;
            _canvas = canvas;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
        }

        private void Start()
        {
            for (int i = 0; i < 90; i++)
            {
                var item = Instantiate(_items[Random.Range(0, 10)],
                    new Vector3(Random.Range(-3.5f, 3.5f), 4, Random.Range(-3.5f, 3.5f)),
                    Quaternion.identity);

                item.Initialize(_canvas, _holder2DItems, _poolIcons, _checkerDuplicate2dItems);

                item.transform.parent = gameObject.transform;
            }
        }
    }
}
