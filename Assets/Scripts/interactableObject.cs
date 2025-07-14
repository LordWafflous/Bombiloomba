using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro.EditorUtilities;
using UnityEngine;

public enum InteractionType {Bed, Furnace, CraftingTable, Chest, Window}
public class interactableObject : MonoBehaviour
{
    public InteractionType type;
  // Start is called before the first frame update
  public void Interact()
  {
    if (Input.GetKeyDown(KeyCode.Mouse1))//right click
    {
            switch (type)
            {
                case InteractionType.Bed:
                    Debug.Log("Clicked on bed");
                    break;

                case InteractionType.Furnace:
                    Debug.Log("Clicked on furnace");
                    break;

                case InteractionType.CraftingTable:
                    Debug.Log("Clicked on crafting table");
                    break;

                case InteractionType.Chest:
                    Debug.Log("Clicked on chest");
                    break;

                case InteractionType.Window:
                    Debug.Log("Clicked on window");
                    break;

            default:
                Debug.Log("Error in accesing interactable object.");
                break;
        }
    }
  }
}
