using UnityEngine;
using Zenject;

public class Icon : MonoBehaviour
{
    private const float Speed = 2300;
    private const float MinValue = 0.01f;

    [SerializeField] private string _id;

    private Vector3 _targetLocalPosition;
    private Vector3 _targetWorldPosition;
    private Vector3 _currentPosition;
    
    private bool _isMovingDone;

    private IconsHolder _iconsHolder;
    private PoolIcons _poolIcons;
    

    [Inject]
    public void Construct(IconsHolder iconsHolder, PoolIcons poolIcons)
    {
        _iconsHolder = iconsHolder;
        _poolIcons = poolIcons;
        _targetLocalPosition = _iconsHolder.TargetPosition();
    }

    private void Start()
    {
        _targetWorldPosition = transform.parent.TransformPoint(_targetLocalPosition);

        _poolIcons.CheckContainsValue(_id, this);
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