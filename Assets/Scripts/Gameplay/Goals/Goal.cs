using UnityEngine;

namespace Gameplay.Goals
{
    public class Goal : MoveToTarget
    {
        [SerializeField] private string _id;

        public string ID => _id;
        

        public void Destroy()
        {
           Destroy(gameObject); 
        }
    }
}