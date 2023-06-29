using System.Collections.Generic;
using Gameplay.Goals;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class MagnetBooster : MonoBehaviour
    {
        [SerializeField] private MagnetEffect _magnetEffect;        
        
        private List<Item3D> _itemsOnScene;
        private List<Item3D> _currentGoals;
        private List<int> _indexesItemsToRemoved;
        private List<int> _indexesIdenticalItems;
        
        private GoalsHolder _goalsHolder;
        

        [Inject]
        public void Construct(GoalsHolder goalsHolder)
        {
            _goalsHolder = goalsHolder;
        }
        
        private void Awake()
        {
            _itemsOnScene = new List<Item3D>();
        }

        public void AddToList(Item3D item3D)
        {
            _itemsOnScene.Add(item3D);
        }

        private void FindCurrentGoals()
        {
            for (int i = 0; i < _goalsHolder.GoalData.Count; i++)
            {
                var id  = _goalsHolder.GoalData[i].Goal.ID;
               
               _currentGoals.Add(FindItemById(id));
            }
        }
        
        private Item3D FindItemById(string id)
        {
            return _itemsOnScene.Find(item => item.ID == id);
        }
        
        public void ActivateMagnetBooster()
        {
            _indexesIdenticalItems = new List<int>();
            _indexesItemsToRemoved = new List<int>();

            _magnetEffect.StartEffect();
            
            ClearListOfEmpties();
            FindIdenticalItems();
            DestroyIdenticalTargetsOnScene();
        }

        private void ClearListOfEmpties()
        {
            for (int i = _itemsOnScene.Count - 1; i >= 0; i--)
            {
                if (_itemsOnScene[i] == null)
                {
                    _itemsOnScene.RemoveAt(i);
                }
            }
        }
        
        private void FindIdenticalItems()
        {
            _currentGoals = new List<Item3D>();
            
            FindCurrentGoals();
            
            var indexGoal = Random.Range(0, _currentGoals.Count - 1);
            
            for (int i = 0; i < _itemsOnScene.Count; i++)
            {
                if (_currentGoals[indexGoal].ID == _itemsOnScene[i].ID)
                {
                    _indexesIdenticalItems.Add(i);
                }
            }
        }
        
        private void DestroyIdenticalTargetsOnScene()
        {
            int itemCount = Mathf.Min(3, _indexesIdenticalItems.Count);

            for (int i = 0; i < itemCount; i++)
            {
                int randomIndex = Random.Range(0, _indexesIdenticalItems.Count); 
                var randomItem = _indexesIdenticalItems[randomIndex]; 

                _indexesItemsToRemoved.Add(randomItem);
                _indexesIdenticalItems.RemoveAt(randomIndex); 
            }
            
            for (int i = _indexesItemsToRemoved.Count - 1; i >= 0; i--)
            {
                int index = _indexesItemsToRemoved[i];
                
                _itemsOnScene[index].SpawnIcon(true);
                _itemsOnScene[index].Destroy();
            }
        }
    }
}