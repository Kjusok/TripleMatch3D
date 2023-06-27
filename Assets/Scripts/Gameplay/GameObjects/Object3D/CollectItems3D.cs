using System.Collections.Generic;
using Gameplay.Goals;
using UnityEngine;

namespace Gameplay
{
    public class CollectItems3D : MonoBehaviour
    {

        [SerializeField] private List<Item3D> _itemsClickList;

        [SerializeField] private List<Item3D> _foundIndices;

        [SerializeField] private GoalsHolder _goalsHolder;


        private void Awake()
        {
            _itemsClickList = new List<Item3D>();
        }

        public void AddToList(Item3D item3D)
        {
            _itemsClickList.Add(item3D);
        }

        private void FindThreeIdentical()
        {
            for (int i = 0; i < _goalsHolder.GoalData.Count; i++)
            {
                var id  = _goalsHolder.GoalData[i].Goal.ID;
                Debug.Log(id);
                for (int j = 0; j < 3; j++)
                {
                    _foundIndices.Add(FindItemById(id)); 

                }

            }
        }
        private Item3D FindItemById(string id)
        {
            return _itemsClickList.Find(item => item.ID == id);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                FindThreeIdentical();
            }
        }
    }
}