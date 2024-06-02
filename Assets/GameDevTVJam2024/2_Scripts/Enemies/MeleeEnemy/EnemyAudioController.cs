using UnityEngine;

namespace Enemies
{
    public class EnemyAudioController : MonoBehaviour
    {
        [SerializeField] private EnemyAI AI;
        [SerializeField] private AudioSource enemyAudioSource;
        [SerializeField] private AudioClip enemyDiedClip;

        private void OnEnable()
        {
            AI.Died.AddListener(OnEnemyDied);
        }

        private void OnDisable()
        {
            AI.Died.RemoveListener(OnEnemyDied);
        }

        private void OnEnemyDied()
        {
            enemyAudioSource.PlayOneShot(enemyDiedClip);
        }
    }
}