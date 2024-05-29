﻿using Data;
using Enemies;
using UnityEngine;

namespace Domain
{
    public interface ICardInteractable
    {
        CardData Data { get; set;}

        Unit GetUnit();
        void InitializeCardUnit();
        void DragCardUnit();
        void DropCardUnitOn(GameObject objectToDropOn);
    }
}