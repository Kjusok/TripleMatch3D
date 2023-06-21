using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Icon : MonoBehaviour
{
    [SerializeField] private string _id;

    private Vector3 _targetLocalPosition;
    private float _speed = 2300;
    private Vector3 _targetWorldPosition;
    private Vector3 _currentPosition;
    private bool _IsMovingDone;

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
                _speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, _targetWorldPosition) < 0.01f && !_IsMovingDone)
        {
            _IsMovingDone = true;
           _poolIcons.AddIDToList(_id, this);
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