using UnityEngine;

namespace Gameplay.GameObjects
{
    [RequireComponent(typeof(BoxCollider))]
    public class TurnOffCollider : MonoBehaviour
    {
        private BoxCollider _boxCollider;
        
        
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void OffCollider()
        {
            _boxCollider.enabled = false;
        }
    }
}