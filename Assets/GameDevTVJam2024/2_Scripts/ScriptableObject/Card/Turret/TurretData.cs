using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "TurretUnitData", menuName = "Card/Unit/Turret", order = 0)]
    public class TurretData : UnitStatsData
    {
        public int BulletRange => bulletRange;
        public float FireRate => fireRate;
        public int BulletDamage => bulletDamage;
        public int BulletSpeed => bulletSpeed;

        [SerializeField] private float fireRate;
        [SerializeField] private int bulletDamage;
        [SerializeField] private int bulletSpeed;
        [SerializeField] private int bulletRange;

    }
}