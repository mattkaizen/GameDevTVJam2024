using TMPro;
using UnityEngine;

namespace Object
{
    public class InteractableCardDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI costText;

        public void UpdateCostText(string cost)
        {
            costText.text = cost;
        }
    }
}