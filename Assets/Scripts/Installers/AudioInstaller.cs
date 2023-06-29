using Audio;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class AudioInstaller:  MonoInstaller
    {
        [Header("Sounds")]
        [SerializeField] private SoundsList _soundsList;
        
        
        public override void InstallBindings()
        {
            BindSoundsList();
        }
        
        private void BindSoundsList()
        {
            Container.Bind<SoundsList>()
                .FromInstance(_soundsList)
                .AsSingle()
                .NonLazy();
        }
    }
}