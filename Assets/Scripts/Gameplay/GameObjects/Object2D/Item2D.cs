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
        private Vector3 _targetWorldPosition;
        private Vector3 _currentPosition;

        private bool _isMovingDone;

        private Holder2DItems _holder2DItems;
        private PoolIcons _poolIcons;
        private CheckerDuplicate2dItems _checkerDuplicate2dItems;


        [Inject]
        public void Construct(Holder2DItems holder2DItems, PoolIcons poolIcons, CheckerDuplicate2dItems checkerDuplicate2dItems)
        {
            _holder2DItems = holder2DItems;
            _poolIcons = poolIcons;
            _checkerDuplicate2dItems = checkerDuplicate2dItems;

            _targetLocalPosition = _holder2DItems.TargetPosition();
        }

        private void Start()
        {
            
            _targetWorldPosition = transform.parent.TransformPoint(_targetLocalPosition);

            _checkerDuplicate2dItems.CheckContainsValue(_id, this);
        }

        private void Update()
        {
            if (transform.position != _targetLocalPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    _targetWorldPosition,
                    Speed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, _targetWorldPosition) < MinValue && !_isMovingDone)
            {
                _isMovingDone = true;
                _poolIcons.CollectElementsInLists(_id, this);
            }
        }

        public void ChangePosition(Vector3 position)
        {
            _targetLocalPosition = position;
            _targetWorldPosition = transform.parent.TransformPoint(_targetLocalPosition);
        }

        public void DestroyIcon()
        {
            Destroy(gameObject);
        }
    }
}
