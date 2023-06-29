using Audio;
using Gameplay.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Toggle))]
    public class MagnetBoosterToggle : MonoBehaviour
    {
        [SerializeField] private MagnetBoosterButton _magnetBoosterButton;

        private Toggle _toggle;
        private SoundsList _soundsList;

        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }
        
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            _soundsList.TapToggle();
            
            if (isOn)
            {
                _magnetBoosterButton.ActivateButton();
            }
            else
            {
                _magnetBoosterButton.DeactivateButton();
            }
        }
    }
}