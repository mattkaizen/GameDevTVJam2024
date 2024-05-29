using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMoneyHandler : MonoBehaviour
    {
        public UnityEvent MoneyAdded;
        
        public int CurrentMoney => currentMoney;
        
        [SerializeField] private int currentMoney;

        private void AddMoney(int newMoney)
        {
            currentMoney += newMoney;
            MoneyAdded?.Invoke();
        }
        //TODO: It has to listen to a Scriptable object event, which will be triggered on the death of the enemy unit
    }
}