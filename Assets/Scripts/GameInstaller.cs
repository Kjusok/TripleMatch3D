using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private IconsHolder _iconsHolder;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private PoolIcons _poolIcons;
    
    public override void InstallBindings()
    {
        BindIconHolder();
        BindCanvas();
        BindPoolIcons();
    }
    
    private void BindIconHolder()
    {
        Container.Bind<IconsHolder>()
            .FromInstance(_iconsHolder)
            .AsSingle()
            .NonLazy();
        
    }
    
    private void BindPoolIcons()
    {
        Container.Bind<PoolIcons>()
            .FromInstance(_poolIcons)
            .AsSingle()
            .NonLazy();
    }
    
    private void BindCanvas()
    {
        Container.Bind<Canvas>()
            .FromInstance(_canvas)
            .AsSingle()
            .NonLazy();
    }
}