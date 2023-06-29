using Gameplay;
using Gameplay.Goals;
using Gameplay.Services;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("3D Items")]
        [SerializeField] private Spawner3DItems _spawner3DItems;
        
        [Header("2D Items")]
        [SerializeField] private PositionCalculator _positionCalculator;
        [SerializeField] private ListsManipulator _listsManipulator;
        [SerializeField] private CheckerDuplicate2dItems _checkerDuplicate2dItems;
        [SerializeField] private Item2DCounter _item2DCounter;
       
        [Header("Goals")]
        [SerializeField] private CompareItem2DAndGoal _compareItem2DAndGoal;
        [SerializeField] private GoalsHolder _goalsHolder;
        
        [Header("Timer")]
        [SerializeField] private Timer _timer;


        public override void InstallBindings()
        {
            BindGameElementConfigurations();
            BindPauseManager();
            BindFailedObserver();
        }
        
        private void BindPauseManager()
        {
            Container.Bind<IPause>()
                .To<PauseManager>()
                .AsSingle()
                .Lazy();
        }

        private void BindFailedObserver()
        {
            Container.Bind<IFailedLevel>()
                .To<FailedObserver>()
                .FromNew()
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
            
            Container.Bind<Spawner3DItems>()
                .FromInstance(_spawner3DItems)
                .AsSingle()
                .NonLazy();
        }
    }
}
