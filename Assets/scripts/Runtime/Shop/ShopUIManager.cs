using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopUIManager : MonoBehaviour
{
    public ShopDatabase shopDatabase;
    public GameObject shopItemPrefab;  // This prefab will represent each item in the shop UI
    public Transform shopContainer;    // The parent object where all items will be displayed
    public ItemModal itemModal;
    public Transform PurchaseConfirmation;
    public Transform upgradesRowTransform;
    public Transform powersRowTransform;
    public Transform incrementalsRowTransform;
    public GameObject purchaseConfirmationPopup;

    public static ShopUIManager Instance { get; private set; }

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

    private void Start()
    {
        PopulateShop();
    }

    public void PopulateShop()
    {
        foreach (var item in shopDatabase.shopItems)
        {
            GameObject itemUI;

            if (item is Upgrade)
            {
                itemUI = Instantiate(shopItemPrefab, upgradesRowTransform);
            }
            else if (item is Power)
            {
                itemUI = Instantiate(shopItemPrefab, powersRowTransform);
            }
            else // Assumes item is Incremental or any other type
            {
                itemUI = Instantiate(shopItemPrefab, incrementalsRowTransform);
            }

            itemUI.transform.Find("TextContainer/PriceText").GetComponent<TextMeshProUGUI>().text = item.price.ToString();
            itemUI.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;

            Button openModalButton = itemUI.transform.Find("OpenModalTap").GetComponent<Button>();
            openModalButton.onClick.AddListener(() => OpenModal(item));

            Button purchaseButton = itemUI.transform.Find("PurchaseTap").GetComponent<Button>();
            purchaseButton.onClick.AddListener(() => Purchase(item, itemUI));

            GameObject soldScrim = itemUI.transform.Find("SoldScrim").gameObject;
            if (item.isPurchased)
            {
                soldScrim.SetActive(true);
                purchaseButton.interactable = false;
            }
            else
            {
                soldScrim.SetActive(false);
            }

            void OpenModal(Item item)
            {
                itemModal.Populate(item, itemUI);
                itemModal.ShowModal();
            }


        }
    }

    public void Purchase(Item item, GameObject itemUI)
    {
        if (ShopManager.Instance.PurchaseItem(item)) // Check if purchase is successful
        {
            // If the purchase was successful, set the SoldScrim to active and disable the purchase button
            GameObject soldScrim = itemUI.transform.Find("SoldScrim").gameObject;
            soldScrim.SetActive(true);

            Button purchaseButton = itemUI.transform.Find("PurchaseTap").GetComponent<Button>();
            purchaseConfirmationPopup.SetActive(true);  // Show the confirmation popup
            purchaseButton.interactable = false;

            Button openModalButton = itemUI.transform.Find("OpenModalTap").GetComponent<Button>();
            openModalButton.interactable = false;
        }
    }
}
