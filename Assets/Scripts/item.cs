using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class item : ScriptableObject
{
    [Header("Gameplay")]
    public TileBase tile; //Can highlight a block when placing basically, ot if an item on the ground is pickable yknow
    public ItemType itemType;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Both")]
    public bool stackable = true;

    [Header("UI")]
    public Sprite image; //Sprite type shown in the inventory
    
}

public enum ItemType
{
    Tool,
    Fish,
    Flower,
    Block,
    Unique //Like keys, character specific books, quest rewards etc.
}

public enum ActionType
{
    Place,
    castRod, //???
    Use,
    Pick,
    Dig
}
