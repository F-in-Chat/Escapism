using UnityEngine;

namespace Parents
{
    public class Parent : MonoBehaviour
    {
        public static T GetComponent<T>(Component component) where T : Component
        {
            return GetParent(component).GetComponentInChildren<T>();
        }
        
        public static T[] GetComponents<T>(Component component) where T : Component
        {
            return GetParent(component).GetComponentsInChildren<T>();
        }

        private static Transform GetParent(Component component)
        {
            var parent = component.GetComponentInParent<Parent>();
            if (parent) return parent.transform;
            var myTransform = component.transform;
            var myParent = myTransform.parent;
            return myParent ? myParent : myTransform;
        }
    }
}