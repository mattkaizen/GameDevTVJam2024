using Enemies;
using UnityEngine;

namespace Domain
{
    public interface IUnitContainer
    {
        bool IsAvailable { get; }
        bool CanContainUnit { get; }
        bool Contain(GameObject objectToContain);
        void ShowUnitPreview(Unit unit);
        void HideUnitPreview();
        void ClearContainer();
    }
}