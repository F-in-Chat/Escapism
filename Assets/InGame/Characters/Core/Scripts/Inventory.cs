using System.Collections.Generic;
using System.Linq;
using Extensions;
using InGame.Items.Scripts;
using Parents;
using UI.InventoryUI;
using UnityEngine;

namespace InGame.Characters.Core.Scripts
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerInventory inventory;
        public List<Item> items = new List<Item>();

        private Collector collector;

        private void Awake()
        {
            collector = Parent.GetComponent<Collector>(this);
        }

        private void OnEnable()
        {
            if (collector) collector.onCollect.Add(Add);
            if (inventory) inventory.value = this;
        }

        private void OnDisable()
        {
            if (collector) collector.onCollect.Remove(Add);
            if (inventory && inventory.value == this)
                inventory.value = null;
        }

        private void Add(Collectible collectible)
        {
            var itemType = collectible.ItemType;
            var quantity = collectible.Quantity;
            var item = items.FirstOrDefault(x => x.itemType == itemType);
            if (item != null)
                item.quantity += quantity;
            else
            {
                item = new Item {itemType = itemType, quantity = quantity};
                items.Add(item);
            }
        }
    }
}
