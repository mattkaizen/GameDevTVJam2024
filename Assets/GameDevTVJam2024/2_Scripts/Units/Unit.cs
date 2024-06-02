using UnityEngine;

namespace Enemies
{
    public abstract class Unit : Character
    {
        public UnitDisplay Display => display;

        [SerializeField] protected UnitDisplay display;

        public void RotateUnit(Vector3 directionToRotate)
        {
            gameObject.transform.up = directionToRotate;
        }

    }
}