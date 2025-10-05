using UnityEngine;


public enum ItemTag {Trinket, Tool, Artifact}

[CreateAssetMenu(fileName = "Item", menuName = "Collectibles/Item")]
public class Item : ScriptableObject
{
    public string id;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public ItemTag tag;
}
