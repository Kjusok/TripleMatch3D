using UnityEngine;

namespace Gameplay.Goals
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] public string _id;


        public void Destroy()
        {
           Destroy(gameObject); 
        }
    }
}