using UnityEngine;

namespace Enemies
{
    public class TurretEnemyAI : EnemyAI
    {
        public override void OnEnable()
        {
            Debug.Log("A");
            base.OnEnable();
        }

        public override void EnableCharacterBehaviour()
        {
            throw new System.NotImplementedException();
        }

        public override void DisableCharacterBehaviour()
        {
            throw new System.NotImplementedException();
        }
    }
}