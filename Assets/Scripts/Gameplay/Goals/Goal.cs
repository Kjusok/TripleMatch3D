using UnityEngine;

namespace Gameplay.Goals
{
    public class Goal : MoveToTarget
    {
        [SerializeField] public string _id;
        

        public void Destroy()
        {
           Destroy(gameObject); 
        }
    }
}