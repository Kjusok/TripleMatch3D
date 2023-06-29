using Audio;
using Gameplay;
using Gameplay.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MagnetBoosterButton : MonoBehaviour
    {
        private const int StartAmount = 3;
        
        [SerializeField] private Image _blockImage;
        [SerializeField] private Button _booster;
        [SerializeField] private GameObject _quantityPanel;
        [SerializeField] private MagnetBooster _magnetBooster;
        [SerializeField] private TMP_Text _numberOfChargesText;

        private int _numberOfCharges;
        private SoundsList _soundsList;

        
        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }

        private void Start()
        {
            _numberOfCharges = StartAmount;
        }

        public void ActivateButton()
        {
            _blockImage.enabled = false;
            _booster.enabled = true;
            _quantityPanel.SetActive(true);
        }
        
        public void DeactivateButton()
        {
            _blockImage.enabled = true;
            _booster.enabled = false;
            _quantityPanel.SetActive(false);
        }

        public void ActivateBooster()
        {
            _soundsList.Magnet();
            
            if (_numberOfCharges >= 1)
            {
                _numberOfCharges--;
                _numberOfChargesText.text = _numberOfCharges.ToString();
                _magnetBooster.ActivateMagnetBooster();
            }

            if (_numberOfCharges == 0)
            {
                _booster.enabled = false;
            }
        }
    }
}