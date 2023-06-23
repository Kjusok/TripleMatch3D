using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Goals
{
    public class GoalsHolder : MonoBehaviour
    {
        [SerializeField] private GoalData[] _goalData;
        [SerializeField] private TMP_Text[] _goalTexts;
        
        
        private void Start()
        {
            for (int i = 0; i < _goalData.Length && i < _goalTexts.Length; i++)
            {
                _goalTexts[i].text = _goalData[i].Count.ToString();
                SpawnPrefab(i);
            }
        }
        
        private void SpawnPrefab(int i)
        {
            var goal = Instantiate(_goalData[i].Goal, _goalData[i].Position);
            goal.transform.SetAsFirstSibling();
        }
    }
}