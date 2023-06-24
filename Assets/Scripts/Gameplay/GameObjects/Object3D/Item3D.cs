using UnityEngine;

namespace Gameplay
{
    public class Item3D : MonoBehaviour
    {
        [SerializeField] private Item2D _item2DPrefab;
        [SerializeField] private Canvas _canvas;

        private CounterPositionCalculator _counterPositionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;
        
        
        public void Initialize(Canvas canvas,
            CounterPositionCalculator counterPositionCalculator,
            ListsManipulator listsManipulator, 
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal)
        {
            _canvas = canvas;
            _counterPositionCalculator = counterPositionCalculator;
            _listsManipulator = listsManipulator;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
        }

        public void SpawnIcon()
        {
            var item2D = Instantiate(_item2DPrefab);

            _counterPositionCalculator.AddToCounter();

            item2D.Construct(_counterPositionCalculator , _listsManipulator, _checkerDuplicate2dItems, _compareItem2DAndGoal);
            item2D.transform.SetParent(_canvas.transform, false);

            Vector3 worldPosition = transform.position;
            Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.GetComponent<RectTransform>(),
                screenPosition,
                null,
                out Vector2 localPosition);

            item2D.GetComponent<RectTransform>().anchoredPosition = localPosition;
        }
    } 
}