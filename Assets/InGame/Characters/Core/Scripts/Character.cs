using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character GetCharacter(Component component)
    {
        return component ? component.GetComponentInParent<Character>() : null;
    }

    public static T GetComponent<T>(Component component) where T : Component
    {
        var character = GetCharacter(component);
        return character ? character.GetComponentInChildren<T>() : null;
    }
}