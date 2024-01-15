using System;
using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public TextMeshProUGUI dialogueTextBox;
    public TextMeshProUGUI characterTextBox;
    public GameObject buttonLayer;
    private float textSpeed = 0.05f;
    public GameObject dialoguePanel;
    private bool _messageEnds;
    private readonly string interactionButtonName = "Interact";
    
    [SerializeField]
    private Transform keysParent;

    public static UIManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }

    private void Start()
    {
        HideButtonInteractionInCanvas();
        HideDialoguePanel();
    }

    private void Update() {
        if (Input.GetButtonDown(interactionButtonName) && _messageEnds) {
            HideDialoguePanel();
            CleanTextBox();
        }
    }

    private void CleanTextBox() {
        StopAllCoroutines();
        dialogueTextBox.text = String.Empty;
        _messageEnds = false;
    }

    public void AddKeyItem(GameObject keyPrefab) {
        Instantiate(keyPrefab, keysParent);
    }

    public void SetMessage([CanBeNull] string character, string message) {
        if (!dialoguePanel.activeSelf) {
            ShowDialoguePanel();
            SetUpCharacterTextBox(character);
            
            StartCoroutine(WriteLine(message));
        }
    }
    
    public void SetMessage([CanBeNull] string character, string[] messages) {
        if (!dialoguePanel.activeSelf) {
            ShowDialoguePanel();
            SetUpCharacterTextBox(character);
            foreach (var message in messages) {
                StartCoroutine(WriteLine(message));               
            }
        }
    }

    private void SetUpCharacterTextBox([CanBeNull] string character) {
        if (character != null) {
            characterTextBox.gameObject.SetActive(true);
            characterTextBox.text = character;
        } else {
            characterTextBox.gameObject.SetActive(false);
            characterTextBox.text = String.Empty;
        }
    }

    IEnumerator WriteLine(string message) {
        foreach (char letter in message) {
            dialogueTextBox.text += letter;
            _messageEnds = dialogueTextBox.text.Length.Equals(message.Length);
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void HideButtonInteractionInCanvas() {
        buttonLayer.SetActive(false);
    }

    public void ShowButtonInteractionInCanvas() {
        buttonLayer.SetActive(true);
    }

    public void ShowDialoguePanel() {
        dialoguePanel.SetActive(true);
    }
    
    public void HideDialoguePanel() {
        dialoguePanel.SetActive(false);
        CleanTextBox();
    }
}
