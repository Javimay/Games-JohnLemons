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
    private int index;
    private string[] lines;
    public bool showingMessage;
    //private readonly string interactionButtonName = "Interact";

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

    private void Update() {
        showingMessage = dialoguePanel.activeSelf;
        if (Input.GetKeyDown(KeyCode.Space) && dialoguePanel.activeSelf) {
            if (dialogueTextBox.text == lines[index]) {
                NextLine();
            } else if (dialogueTextBox.text.Length > 5) {
                dialogueTextBox.text = lines[index];
                StopAllCoroutines();
            }
        }
    }

    private void CleanTextBox() {
        StopAllCoroutines();
        index = 0;
        dialogueTextBox.text = String.Empty;
    }

    public void AddKeyItem(GameObject keyPrefab) {
        Instantiate(keyPrefab, keysParent);
    }

        
    public void SetMessage([CanBeNull] string character, string[] messages) {
        lines = messages;
        ShowButtonInteractionInCanvas();
        if (!dialoguePanel.activeInHierarchy) {
            ShowDialoguePanel();
            SetUpCharacterTextBox(character);
            StartCoroutine(WriteLine(messages));
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

    IEnumerator WriteLine(string[] messages) {
        foreach (char letter in messages[index].ToCharArray()) {
            dialogueTextBox.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        //yield return new WaitForSeconds(1f);
    }

    public void NextLine() {
        if (index < lines.Length - 1) {
            index++;
            dialogueTextBox.text = String.Empty;
            StartCoroutine(WriteLine(lines));
        } else {
            HideDialoguePanel();
            CleanTextBox();
            if (!characterTextBox.IsActive()) {
                HideButtonInteractionInCanvas();
            }
        }
    } 

    public void HideButtonInteractionInCanvas() {
        buttonLayer.SetActive(false);
    }

    public void HideItemLayout() {
        keysParent.gameObject.SetActive(false);
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
