using Gameplay.Goals;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private CompleteMenu _completeMenu;

        private GoalsHolder _goalsHolder;

        
        [Inject]
        public void Construct(GoalsHolder goalsHolder)
        {
            _goalsHolder = goalsHolder;
        }
        
        private void Start()
        {
            _goalsHolder.TaskCompleted += _completeMenu.Open;
        }

        private void OnDestroy()
        {
            _goalsHolder.TaskCompleted -= _completeMenu.Open;
        }
    }
}