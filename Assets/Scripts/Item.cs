using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Icon _iconPrefab;
    [SerializeField] private Canvas _canvas;

    private IconsHolder _iconsHolder;
    private PoolIcons _poolIcons;
    
    public void Initialize(Canvas canvas, IconsHolder iconsHolder, PoolIcons poolIcons)
    {
        _canvas = canvas;
        _iconsHolder = iconsHolder;
        _poolIcons = poolIcons;
        
    }

    public void SpawnIcon()
    {
        var icon = Instantiate(_iconPrefab);
        _iconsHolder.AddToCounter();

        icon.Construct(_iconsHolder , _poolIcons);
        
        icon.transform.SetParent(_canvas.transform, false);

        Vector3 worldPosition = transform.position;

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(), screenPosition, null, out Vector2 localPosition);

        icon.GetComponent<RectTransform>().anchoredPosition = localPosition;
    }
}