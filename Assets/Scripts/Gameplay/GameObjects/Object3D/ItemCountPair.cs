using UnityEngine;

namespace Gameplay
{
    [System.Serializable]
    public class ItemCountPair
    {
        [SerializeField] private Item3D _item;
        [SerializeField] private int _count;

        public Item3D Item => _item;
        public int Count => _count;
    }
}