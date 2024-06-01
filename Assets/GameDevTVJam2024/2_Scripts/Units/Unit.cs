using UnityEngine;

namespace Enemies
{
    public abstract class Unit : Character
    {
        public UnitDisplay Display => display;

        [SerializeField] protected UnitDisplay display;

    }
}