using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private IconsHolder _iconsHolder;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private PoolIcons _poolIcons;
    
    public override void InstallBindings()
    {
        BindElementsGames();
    }
    
    private void BindElementsGames()
    {
        Container.Bind<IconsHolder>()
            .FromInstance(_iconsHolder)
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
    }
}