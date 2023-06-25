using UnityEngine;

namespace Gameplay.GameObjects
{
    public class TurnOffCollider : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        
        
        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void OffCollider()
        {
            _boxCollider.enabled = false;
        }
    }
}