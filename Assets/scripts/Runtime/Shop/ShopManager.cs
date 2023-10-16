using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopDatabase shopDatabase;
    public static ShopManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public bool PurchaseItem(Item item)
    {
        if(item == null)
        {
            Debug.Log("item is null");
        }
        
        if (CurrencyManager.Instance.CanAfford(item.price) && !item.isPurchased)
        {
            CurrencyManager.Instance.RemoveCurrency(item.price);
            item.isPurchased = true;
            // Here, you could also add the item to the player's inventory
            InventoryManager.Instance.AddItemFromShop(item);
            return true;  // Successful purchase
        }
        return false;  // Failed to purchase
    }
}
