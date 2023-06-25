using Gameplay;
using Gameplay.Goals;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private CompleteMenu _completeMenu;
        [SerializeField] private FailedMenu _failedMenu;

        private GoalsHolder _goalsHolder;
        private Item2DCounter _item2DCounter;

        
        [Inject]
        public void Construct(GoalsHolder goalsHolder, Item2DCounter item2DCounter)
        {
            _goalsHolder = goalsHolder;
            _item2DCounter = item2DCounter;
        }
        
        private void Start()
        {
            _goalsHolder.TaskCompleted += _completeMenu.Open;
            _item2DCounter.TaskFailed += _failedMenu.Open;
        }

        private void OnDestroy()
        {
            _goalsHolder.TaskCompleted -= _completeMenu.Open;
            _item2DCounter.TaskFailed -= _failedMenu.Open;
        }
    }
}