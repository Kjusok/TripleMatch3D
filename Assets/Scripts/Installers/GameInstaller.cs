using Gameplay;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Holder2DItems _holder2DItems;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private PoolIcons _poolIcons;
        [SerializeField] private CheckerDuplicate2dItems _checkerDuplicate2dItems;
    
        public override void InstallBindings()
        {
            BindGameElementConfigurations();
        }
    
        private void BindGameElementConfigurations()
        {
            Container.Bind<Holder2DItems>()
                .FromInstance(_holder2DItems)
                .AsSingle()
                .NonLazy();
        
            Container.Bind<PoolIcons>()
                .FromInstance(_poolIcons)
                .AsSingle()
                .NonLazy();
        
            Container.Bind<Canvas>()
                .FromInstance(_canvas)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<CheckerDuplicate2dItems>()
                .FromInstance(_checkerDuplicate2dItems)
                .AsSingle()
                .NonLazy();
        }
    }
}
