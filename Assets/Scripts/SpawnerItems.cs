using UnityEngine;
using Zenject;

public class SpawnerItems : MonoBehaviour
{
    [SerializeField] private Item[] _items;
    [SerializeField] private Canvas _canvas;

    private IconsHolder _iconsHolder;
    private PoolIcons _poolIcons;

    [Inject]
    public void Construct(IconsHolder iconsHolder, PoolIcons poolIcons, Canvas canvas)
    {
        _iconsHolder = iconsHolder;
        _poolIcons = poolIcons;
        _canvas = canvas;
    }

    private void Start()
    {
        for (int i = 0; i < 90; i++)
        {
            var item = Instantiate(_items[Random.Range(0, 10)],
                new Vector3(Random.Range(-3.5f, 3.5f), 4, Random.Range(-3.5f, 3.5f)),
                Quaternion.identity);

            item.Initialize(_canvas, _iconsHolder, _poolIcons);

            item.transform.parent = gameObject.transform;
        }
    }
}