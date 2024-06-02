using UnityEngine;

namespace Enemies
{
    public class TurretUnitAudioController : MonoBehaviour
    {
        [SerializeField] private TurretUnit turretUnit;
        [SerializeField] private AudioSource unitAudioSource;
        [SerializeField] private AudioClip shootAudio;

        private void OnEnable()
        {
            turretUnit.BulletFired += OnBulletFired;
        }

        private void OnDisable()
        {
            turretUnit.BulletFired -= OnBulletFired;
        }

        private void OnBulletFired()
        {
            PlayShootAudio();
        }

        private void PlayShootAudio()
        {
            unitAudioSource.PlayOneShot(shootAudio);
        }
    }
}