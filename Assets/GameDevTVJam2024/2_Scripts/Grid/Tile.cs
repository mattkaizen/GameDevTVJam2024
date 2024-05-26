using UnityEngine;
using UnityEngine.EventSystems;

namespace Grid
{
    public class Tile : MonoBehaviour, IPointerEnterHandler
    {
        //TODO: An unit could have a list of tiles,
        //TODO: ItemSetter o ItemPlacer
        //TODO: It has to have TileType?
        private bool isAvailable;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
        }
    }
}