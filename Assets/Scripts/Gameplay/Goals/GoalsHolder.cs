using System;
using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.Goals
{
    public class GoalsHolder : MonoBehaviour
    {
        [SerializeField] private List<GoalData> _goalData;
        [SerializeField] private List<Goal> _currentGoal;
        [SerializeField] private List<TMP_Text> _currentText;
        
        [SerializeField] private List<Transform> _positionGoal;
        [SerializeField] private List<Transform>  _positionCount;

        private SoundsList _soundsList;

        public List<GoalData> GoalData => _goalData;
        public List<Goal> CurrentGoal => _currentGoal;

        public event Action TaskCompleted;

        
        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }

        private void Start()
        {
            BuildGoalsPanel();
        }

        private void BuildGoalsPanel()
        {
            for (int i = 0; i < _goalData.Count; i++)
            {
                _goalData[i].Text.text = _goalData[i].Count.ToString();
                SpawnPrefab(i);
            }
        }
        
        private void SpawnPrefab(int i)
        {
            var goal = Instantiate(_goalData[i].Goal, _positionGoal[i]);
            goal.transform.SetAsFirstSibling();
            
            _currentGoal.Add(goal);
        }
        
        public void SubtractCount(int goalIndex)
        {
            if (goalIndex >= 0 && goalIndex < _currentGoal.Count)
            {
                _goalData[goalIndex].Count -= 1;
                _goalData[goalIndex].Text.text = _goalData[goalIndex].Count.ToString();
            }
        }

        public void RemoveGoalElements(int i)
        {
            _soundsList.VanishingGoal();
            
            _goalData.RemoveAt(i);
            
            _currentGoal[i].Destroy();
            Destroy(_currentText[i]);

            _currentGoal.RemoveAt(i);
            _currentText.RemoveAt(i);

            MoveGoals(i);
            LevelFinished();
        }

        private void LevelFinished()
        {
            if (_goalData.Count == 0)
            {
                TaskCompleted?.Invoke();
            }
        }
        
        private void MoveGoals(int index)
        {
            for (int i = _currentGoal.Count - 1; i >= index; i--)
            {
                _currentGoal[i].ChangePosition(_positionGoal[i].position);
            }
            
            for (int i = _currentText.Count - 1; i >= index; i--)
            {
               _currentText[i].GetComponent<MoveToTarget>().ChangePosition(_positionCount[i].position);
            }
        }
    }
}