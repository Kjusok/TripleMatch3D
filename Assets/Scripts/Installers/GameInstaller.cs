using Gameplay;
using Gameplay.Goals;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("UI Elements")]
        [SerializeField] private Canvas _canvas;
        
        [Header("Gameplay Elements")]
        [SerializeField] private CounterPositionCalculator _counterPositionCalculator;
        [SerializeField] private ListsManipulator _listsManipulator;
        [SerializeField] private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        [SerializeField] private CompareItem2DAndGoal _compareItem2DAndGoal;
        [SerializeField] private GoalsHolder _goalsHolder;
    
        public override void InstallBindings()
        {
            BindGameElementConfigurations();
            BindPauseManager();
        }
        
        private void BindPauseManager()
        {
            Container.Bind<IPause>()
                .To<PauseManager>()
                .AsSingle()
                .Lazy();
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
            
            Container.Bind<CompareItem2DAndGoal>()
                .FromInstance(_compareItem2DAndGoal)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<GoalsHolder>()
                .FromInstance(_goalsHolder)
                .AsSingle()
                .NonLazy();
        }
    }
}
