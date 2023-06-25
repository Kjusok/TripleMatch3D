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

        private IFailedLevel _failedLevel;

        
        [Inject]
        public void Construct(GoalsHolder goalsHolder, IFailedLevel failedLevel)
        {
            _goalsHolder = goalsHolder;
            _failedLevel = failedLevel;
        }
        
        private void Start()
        {
            _goalsHolder.TaskCompleted += _completeMenu.Open;
            _failedLevel.TaskFailed += _failedMenu.Open;
        }

        private void OnDestroy()
        {
            _goalsHolder.TaskCompleted -= _completeMenu.Open;
            _failedLevel.TaskFailed -= _failedMenu.Open;
        }
    }
}