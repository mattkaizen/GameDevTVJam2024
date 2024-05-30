using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "TurretUnitData", fileName = "Card/Unit/Turret", order = 0)]
    public class TurretData : UnitStatsData
    {
        public int BulletRange => bulletRange;
        public float FireRate => fireRate;
        public int BulletDamage => bulletDamage;

        [SerializeField] private int bulletDamage;
        [SerializeField] private float fireRate;
        [SerializeField] private int bulletRange;

    }
}