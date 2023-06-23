using Gameplay;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_holder2DItems")] [SerializeField] private CounterPositionCalculator _counterPositionCalculator;
        [SerializeField] private Canvas _canvas;
        [FormerlySerializedAs("_poolIcons")] [SerializeField] private ListsManipulator _listsManipulator;
        [SerializeField] private CheckerDuplicate2dItems _checkerDuplicate2dItems;
    
        public override void InstallBindings()
        {
            BindGameElementConfigurations();
        }
    
        private void BindGameElementConfigurations()
        {
            Container.Bind<CounterPositionCalculator>()
                .FromInstance(_counterPositionCalculator)
                .AsSingle()
                .NonLazy();
        
            Container.Bind<ListsManipulator>()
                .FromInstance(_listsManipulator)
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
