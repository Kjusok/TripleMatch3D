using Gameplay;
using Gameplay.Goals;
using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Gameplay Elements")]
        [SerializeField] private PositionCalculator _positionCalculator;
        [SerializeField] private ListsManipulator _listsManipulator;
        [SerializeField] private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        [SerializeField] private CompareItem2DAndGoal _compareItem2DAndGoal;
        [SerializeField] private GoalsHolder _goalsHolder;
        [SerializeField] private Timer _timer;
        [SerializeField] private Item2DCounter _item2DCounter;
    
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
            Container.Bind<PositionCalculator>()
                .FromInstance(_positionCalculator)
                .AsSingle()
                .NonLazy();
        
            Container.Bind<ListsManipulator>()
                .FromInstance(_listsManipulator)
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
            
            Container.Bind<Timer>()
                .FromInstance(_timer)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<Item2DCounter>()
                .FromInstance(_item2DCounter)
                .AsSingle()
                .NonLazy();
        }
    }
}
