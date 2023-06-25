using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Item2D : MonoBehaviour
    {
        private const float Speed = 2300;
        private const float MinValue = 0.01f;

        [SerializeField] private string _id;

        private Vector3 _targetLocalPosition;
        private Vector3 _currentPosition;

        private bool _isMovingDone;

        private PositionCalculator _positionCalculator;
        private ListsManipulator _listsManipulator;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        private CompareItem2DAndGoal _compareItem2DAndGoal;



        [Inject]
        public void Construct(PositionCalculator positionCalculator,
            ListsManipulator listsManipulator,
            CheckerDuplicate2dItems checkerDuplicate2dItems,
            CompareItem2DAndGoal compareItem2DAndGoal)
        {
            _positionCalculator = positionCalculator;
            _listsManipulator = listsManipulator;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;
            _compareItem2DAndGoal = compareItem2DAndGoal;
        }

        private void Start()
        {           
            _targetLocalPosition = _positionCalculator.TargetPosition();

            _checkerDuplicate2dItems.CheckContainsValue(_id, this);
            _compareItem2DAndGoal.CompareID(_id);
        }

        private void Update()
        {
            MoveToTargetAndCollect();
        }

        private void MoveToTargetAndCollect()
        {
            if (transform.position != _targetLocalPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    _targetLocalPosition,
                    Speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, _targetLocalPosition) < MinValue && !_isMovingDone)
            {
                _isMovingDone = true;
                _listsManipulator.CollectElementsInLists(_id, this);
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
