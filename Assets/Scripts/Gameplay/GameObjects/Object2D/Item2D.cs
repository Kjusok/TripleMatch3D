using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Item2D : MonoBehaviour
    {
        private const float Speed = 2300;
        private const float MinValue = 0.01f;

        [SerializeField] private string _id;

        private Transform _magnetPosition;
        private Vector3 _targetLocalPosition;
        private Vector3 _currentPosition;

        private bool _isMovingDone;
        private bool _isMagnetActive;

        private PositionCalculator _positionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;
        
        
        [Inject]
        public void Construct(PositionCalculator positionCalculator,
            ListsManipulator listsManipulator,
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal,
            bool isMagnetActive,
            Transform magnetPosition)
        {
            _positionCalculator = positionCalculator;
            _listsManipulator = listsManipulator;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
            _isMagnetActive = isMagnetActive;
            _magnetPosition = magnetPosition;
        }

        private void Start()
        {
            if (!_isMagnetActive)
            {
                _targetLocalPosition = _positionCalculator.TargetPosition();
                _checkerDuplicate2dItems.CheckContainsValue(_id, this);
            }
            
            _compareItem2DAndGoal.CompareID(_id);
        }

        private void Update()
        {
            if (!_isMagnetActive)
            {
                MoveToTargetAndCollect(_targetLocalPosition);
            }
            else
            {
                MoveToTargetAndCollect(_magnetPosition.position);
            }
        }

        private void MoveToTargetAndCollect(Vector3 targetPosition)
        {
            if (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    targetPosition,
                    Speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, targetPosition) < MinValue && !_isMovingDone)
            {
                _isMovingDone = true;
                
                if (!_isMagnetActive)
                {
                    _listsManipulator.CollectElementsInLists(_id, this);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        public void ChangePosition(Vector3 position)
        {
            _targetLocalPosition = position;
        }

        public void DestroyIcon()
        {
            Destroy(gameObject);
        }
    }
}
