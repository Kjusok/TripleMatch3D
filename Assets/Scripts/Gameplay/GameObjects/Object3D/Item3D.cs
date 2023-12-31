using Audio;
using Gameplay.Services;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(ClickOn3DItem))]
    [RequireComponent(typeof(GravitySwitch))]
    public class Item3D : MonoBehaviour
    {
        [SerializeField] private Item2D _item2DPrefab;
        [SerializeField] private string _id;

        private PositionCalculator _positionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;
        private Item2DCounter _item2DCounter;
        private SoundsList _soundsList;
        
        private Transform _magnetPosition;
        
        public string ID => _id;
        
        public void Initialize(PositionCalculator positionCalculator,
            ListsManipulator listsManipulator, 
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal,
            Item2DCounter item2DCounter,
            IPause pauseManager,
            Transform magnetPosition,
            SoundsList soundsList)
        {
            _positionCalculator = positionCalculator;
            _listsManipulator = listsManipulator;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
            _item2DCounter = item2DCounter;
            _magnetPosition = magnetPosition;
            
            gameObject.GetComponent<ClickOn3DItem>().Construct(pauseManager, soundsList);
            gameObject.GetComponent<GravitySwitch>().Construct(pauseManager);
        }

        public void SpawnIcon(bool isMagnetActive)
        {
            var item2D = Instantiate(_item2DPrefab,_listsManipulator.transform, false);

            if (!isMagnetActive)
            {
                _item2DCounter.AddToCounter();

            }

            item2D.Construct(_positionCalculator,
                _listsManipulator,
                _checkerDuplicate2dItems,
                _compareItem2DAndGoal,
                isMagnetActive,
                _magnetPosition);

            Vector3 worldPosition = transform.position;
            Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_listsManipulator.GetComponent<RectTransform>(),
                screenPosition,
                null,
                out Vector2 localPosition);

            item2D.GetComponent<RectTransform>().anchoredPosition = localPosition;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    } 
}