using Data;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMoneyHandler : MonoBehaviour
    {
        public UnityEvent MoneyAdded;
        public UnityEvent MoneyRemoved;
        
        public int CurrentMoney => currentMoney;
        
        [SerializeField] private int currentMoney;
        [SerializeField] private IntEventChannelData moneyPicked;
        [SerializeField] private PlayerMoneyDisplay moneyDisplay;

        private void OnEnable()
        {
            moneyPicked.EventRaised += OnMoneyPicked;
            moneyDisplay.UpdateMoneyDisplay(currentMoney.ToString());

        }

        private void OnDisable()
        {
            moneyPicked.EventRaised -= OnMoneyPicked;
        }

        private void OnMoneyPicked(int money)
        {
            AddMoney(money);
        }

        private void AddMoney(int newMoney)
        {
            currentMoney += newMoney;
            moneyDisplay.UpdateMoneyDisplay(currentMoney.ToString());
            MoneyAdded?.Invoke();
        }

        public void DeductMoney(int newMoney)
        {
            currentMoney -= newMoney;
            moneyDisplay.UpdateMoneyDisplay(currentMoney.ToString());
            MoneyRemoved?.Invoke();
        }
    }
}