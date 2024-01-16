using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<string> inventory = new();
    private UIManager _uiManager;

    private void Start() {
        _uiManager = UIManager.Instance;
    }

    public void AddItemToInventory(GameObject keyObject) {
        inventory.Add(keyObject.name);
        _uiManager.AddKeyItem(keyObject);
    }

    public bool HasItemInInventory(string item) {
        return inventory.Contains(item);
    }

    public bool HasItems() {
        return inventory.Count > 0;
    }
}
