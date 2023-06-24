using System;

namespace Gameplay.Services
{
    public interface IPause
    {
        bool Paused { get; set; }

        event Action<IPause> PauseChanged;
    }
}