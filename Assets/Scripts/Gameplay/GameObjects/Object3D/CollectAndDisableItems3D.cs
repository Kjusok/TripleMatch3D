using System.Collections.Generic;
using Gameplay.Goals;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CollectAndDisableItems3D : MonoBehaviour
    {
        private List<Item3D> _itemsClickList;
        private GoalsHolder _goalsHolder;

        
       [Inject]
        public void Construct(GoalsHolder goalsHolder)
        {
            _goalsHolder = goalsHolder;
        }

        private void Awake()
        {
            _itemsClickList = new List<Item3D>();
        }
        
        private void Start()
        {
            _goalsHolder.TaskCompleted += MakeUnavailable;
        }

        private void OnDestroy()
        {
            _goalsHolder.TaskCompleted -= MakeUnavailable;
        }

        public void AddToList(Item3D item3D)
        {
            _itemsClickList.Add(item3D);
        }

        private void MakeUnavailable()
        {
            foreach (var item in _itemsClickList)
            {
                if (item != null)
                {
                    Destroy(item.GetComponent<ClickOn3DItem>());
                }
            }
        }
    }
}