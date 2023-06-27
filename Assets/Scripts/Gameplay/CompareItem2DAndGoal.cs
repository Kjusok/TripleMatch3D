using Gameplay.Goals;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(GoalsHolder))]
    public class CompareItem2DAndGoal : MonoBehaviour
    {
        private GoalsHolder _goalsHolder;

        private void Awake()
        {
            _goalsHolder = GetComponent<GoalsHolder>();
        }

        public void CompareID(string id)
        {
            for (int i = _goalsHolder.CurrentGoal.Count - 1; i >= 0; i--)
            {
                var currentCount = _goalsHolder.GoalData[i].Count;
                var currentId = _goalsHolder.CurrentGoal[i].ID;

                if (id == currentId)
                {
                    _goalsHolder.SubtractCount(i);

                    if (currentCount == 1)
                    {
                        _goalsHolder.RemoveGoalElements(i);
                    }
                }
            }
        }
    }
}