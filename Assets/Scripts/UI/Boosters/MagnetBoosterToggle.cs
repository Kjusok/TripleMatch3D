using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MagnetBoosterToggle : MonoBehaviour
    {
        [SerializeField] private MagnetBoosterButton _magnetBoosterButton;

        private Toggle _toggle;

        private void Start()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn)
        {
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