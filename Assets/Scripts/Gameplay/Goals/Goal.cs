using UnityEngine;

namespace Gameplay.Goals
{
    public class Goal : MoveToTarget
    {
        [SerializeField] public string _id;
        
        private Vector3 _targetPosition;
        public void Destroy()
        {
           Destroy(gameObject); 
        }
    }
}