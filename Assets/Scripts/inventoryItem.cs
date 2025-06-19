using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using System;

public class inventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;


    public void InitializeItem(item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        refreshCount();

    }

    public void refreshCount()
    {
        countText.text = count.ToString();
        if (count > 1)
        {
            countText.gameObject.SetActive(true);
        }
        else
        {
            countText.gameObject.SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
