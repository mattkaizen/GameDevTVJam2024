using Data;
using UnityEngine;

namespace Enemies
{
    public abstract class Unit : MonoBehaviour
    {
        public UnitDisplay Display => display;
        
        [SerializeField] private UnitStatsData statsData;
        [SerializeField] private UnitDisplay display;
        public abstract void EnableUnitBehaviour();
    }
}