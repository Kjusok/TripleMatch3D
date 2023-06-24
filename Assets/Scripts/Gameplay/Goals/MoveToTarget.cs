using UnityEngine;

namespace Gameplay.Goals
{
    public class MoveToTarget : MonoBehaviour
    {
        [SerializeField] private  float _speed = 1800;
        
        private Vector3 _targetPosition;


        private void Start()
        {
            _targetPosition = transform.position;
        }

        private void Update()
        {
            MovingToTarget();
        }

        private void MovingToTarget()
        {
            if (transform.position != _targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    _targetPosition,
                    _speed * Time.deltaTime);
            }
        }
        
        public void ChangePosition(Vector3 position)
        {
            _targetPosition = position;
        }
    }
}