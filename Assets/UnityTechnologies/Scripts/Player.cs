using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTechnologies.Scripts;

public class Player : MonoBehaviour
{
    private List<string> inventory = new();
    private bool _isInstructionsEnabled = true;
    private Dialogues _dialogues = new();
    private UIManager _uiManager;

    private void Start() {
        _uiManager = UIManager.Instance;
        if (_isInstructionsEnabled) {
            setInstructionsMessage();
        }
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void setInstructionsMessage() {
        string message = _dialogues.GetDialogue(Dialogues.Key_GameInstructions, Dialogues.Key_GameInstructions);
        string[] messages = message.Split('-');
        _uiManager.ShowButtonInteractionInCanvas();
        _uiManager.SetMessage(null, messages);
        _isInstructionsEnabled = false;
        /*_uiManager.HideButtonInteractionInCanvas();
        _uiManager.HideDialoguePanel();*/
    }

    public void AddItemToInventory(GameObject keyObject) {
        inventory.Add(keyObject.name);
        UIManager.Instance.AddKeyItem(keyObject);
        Debug.Log("Added new item: " + keyObject.name);
    }

    public bool HasItemInInventory(string item) {
        return inventory.Contains(item);
    }

    public bool HasItems() {
        return inventory.Count > 0;
    }
}
