using Enemies;
using UnityEngine;

namespace Domain
{
    public interface IUnitContainer
    {
        bool IsAvailable { get; }
        bool CanContainUnit { get; }
        bool Contain(Unit objectToContain);
        void ShowUnitPreview(Unit unit);
        void HideUnitPreview(Unit unit);
        void ClearContainer();
        GameObject GetContainer();

    }
}