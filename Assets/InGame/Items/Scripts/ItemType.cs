using UnityEngine;
using UnityEngine.UI;

namespace InGame.Items.Scripts
{
    public class ItemType : ScriptableObject
    {
        public string displayName;
        public string description;
        public Sprite image;
        public Color color = Color.white;
    }
}