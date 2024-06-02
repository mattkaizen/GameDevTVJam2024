using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerMoneyDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;
        
        public void UpdateMoneyDisplay(string newText)
        {
            moneyText.text = newText;
        }
    }
}