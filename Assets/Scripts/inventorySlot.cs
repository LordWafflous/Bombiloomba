using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler, IPointerClickHandler
{
    public static List<inventorySlot> allSlots = new List<inventorySlot>();
    [Header("UI")]
    [HideInInspector] public Image slot;
    [HideInInspector] public Image frame;
    public enum SlotType { Inventory, Hotbar, Chest, Store }
    public SlotType slotType;

    private Color ogColorSlot;
    private Color ogColorFrame;
    private bool clickSlot = false;

    public GameObject inventoryItemPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        slot = GetComponent<Image>();
        frame = GetComponentInParent<Image>();
    }
    void Start()
    {
        
        ogColorSlot = slot.color;
        ogColorFrame = frame.color;

        if (slotType != SlotType.Hotbar)
        {
            slotType = SlotType.Inventory;
        }

        allSlots.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        slot.color = (clickSlot) ? new Color(0.6f, 1f, 0.6f, 1f) : new Color(0.6f, 0.6f, 0.6f, 1f); //first one is iverted weird colors
        frame.color = (clickSlot) ? new Color(1f, 1f, 0.6f, 1f) : new Color(0.6f, 0.6f, 0.6f, 1f); //first one is iverted weird colors
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slot.color = (clickSlot) ? new Color(0.6f, 1f, 1f, 1f) : ogColorSlot; //first one is iverted weird colors
        frame.color = (clickSlot) ? new Color(1f, 1f, 1f, 1f) : ogColorFrame; //first one is iverted weird colors
    }

    public void OnDrop(PointerEventData eventData)
    {
        foreach (inventorySlot item in allSlots)
        {
            item.slot.color = ogColorSlot;
            item.frame.color = ogColorFrame;
            item.clickSlot = false;
        }
        clickSlot = true;
        frame.color = new Color(1f, 1f, 1f, 1f);
        slot.color = new Color(0.6f, 1f, 1f, 1f);

        inventoryItem inventoryItem = eventData.pointerDrag.GetComponent<inventoryItem>();
        if (transform.childCount == 0)
        {
            inventoryItem.parentAfterDrag = transform;
            
        }
        else //swap items
        {
            inventoryItem item2 = GetComponentInChildren<inventoryItem>();
            Transform draggedItemSlot = inventoryItem.parentAfterDrag;
            item2.transform.SetParent(draggedItemSlot);
            inventoryItem.parentAfterDrag = transform;

            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //do this for hotbar and inventory slots with iffs twice basically



        foreach (inventorySlot item in allSlots)
        {
            if (item.slotType != this.slotType)
            {
                continue;
            }

            item.slot.color = ogColorSlot;
            item.frame.color = ogColorFrame;
            item.clickSlot = false;
        }
        if (slotType == SlotType.Hotbar)
        {
            clickSlot = clickSlot ? false : true;
            frame.color = new Color(1f, 1f, 1f, 1f);
            slot.color = new Color(0.6f, 1f, 1f, 1f);
        }
        
    }  
}
