using TMPro;
using UnityEngine;

namespace Gameplay.Goals
{
    [System.Serializable]
    public class GoalData
    {
        [SerializeField] private Goal _goal;
        [SerializeField] private int _count;
        [SerializeField] private TMP_Text _text;

        public Goal Goal => _goal;
        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public TMP_Text Text => _text;
    }
}