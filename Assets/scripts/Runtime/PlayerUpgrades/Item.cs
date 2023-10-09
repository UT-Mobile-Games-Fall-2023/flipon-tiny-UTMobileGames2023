using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public int price;
    public Sprite icon;
    public bool isPurchased = false;
    public bool isEnabled = false;
}

[CreateAssetMenu(menuName = "Shop/Upgrade")]
public class Upgrade : Item { }

[CreateAssetMenu(menuName = "Shop/Power")]
public class Power : Item { }

[CreateAssetMenu(menuName = "Shop/Incremental")]
public class Incremental : Item { }
