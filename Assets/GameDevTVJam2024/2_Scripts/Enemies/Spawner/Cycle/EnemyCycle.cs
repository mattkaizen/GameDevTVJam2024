using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Cycle
{
    [CreateAssetMenu(fileName = "EnemyCycle", menuName = "Enemy/Cycle", order = 0)]
    public class EnemyCycle : ScriptableObject
    {
        public List<EnemyAI> EnemiesToAdd => enemiesToAdd;
        
        [SerializeField] private List<EnemyAI> enemiesToAdd;
    }
}