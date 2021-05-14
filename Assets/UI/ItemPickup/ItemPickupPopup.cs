using UnityEngine;

namespace UI.ItemPickup
{
    public class ItemPickupPopup : ScriptableObject
    {
        public ItemPickupUI itemPickupUI;

        public void Display(string text)
        {
            if (itemPickupUI)
                itemPickupUI.Display(text);
        }
    }
}