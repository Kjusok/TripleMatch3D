using UnityEngine;

namespace Gameplay
{
    public class Item3D : MonoBehaviour
    {
        [SerializeField] private Item2D _item2DPrefab;
        [SerializeField] private Canvas _canvas;

        private Holder2DItems _holder2DItems;
        private PoolIcons _poolIcons;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
    
        public void Initialize(Canvas canvas, Holder2DItems holder2DItems, PoolIcons poolIcons, CheckerDuplicate2dItems checkerDuplicate2dItems)
        {
            _canvas = canvas;
            _holder2DItems = holder2DItems;
            _poolIcons = poolIcons;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
        }

        public void SpawnIcon()
        {
            var item2D = Instantiate(_item2DPrefab);

            _holder2DItems.AddToCounter();

            item2D.Construct(_holder2DItems , _poolIcons, _checkerDuplicate2dItems);
            item2D.transform.SetParent(_canvas.transform, false);

            Vector3 worldPosition = transform.position;
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(),
                screenPosition,
                null,
                out Vector2 localPosition);

            item2D.GetComponent<RectTransform>().anchoredPosition = localPosition;
        }
    } 
}