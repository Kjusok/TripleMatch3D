using UnityEngine;

namespace Gameplay
{
    public class ClickOn3DItem : MonoBehaviour
    {
        private const float Coefficient = 1.1f;
        private const float Speed = 2f;
    
        private Vector3 _startScale;
        private float _posY;
    
        public void OnMouseUp()
        {
            GetComponent<Item3D>().SpawnIcon();

            Destroy(gameObject);
        }

        public void OnMouseDown()
        {
            GetComponent<Outline>().enabled = true;

            _startScale = transform.localScale;
        }

        private void Update()
        {
            ChangeScale();
        }

        private void ChangeScale()
        {
            if (transform.localScale.x < _startScale.x * Coefficient)
            {
                transform.localScale += _startScale * Time.deltaTime * Speed;
            }
        }
    }
}
