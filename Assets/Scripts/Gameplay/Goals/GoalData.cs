using UnityEngine;

namespace Gameplay.Goals
{
    [System.Serializable]
    public class GoalData
    {
        [SerializeField] private Goal _goal;
        [SerializeField] private int _count;
        [SerializeField] private Transform _position;

        public Goal Goal => _goal;
        public int Count => _count;
        public Transform Position => _position;
    }
}