using System;

namespace Gameplay
{
    public interface IFailedLevel
    {
        public event Action TaskFailed;
    }
}