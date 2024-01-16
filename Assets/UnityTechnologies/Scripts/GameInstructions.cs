using UnityTechnologies.Scripts;
using UnityEngine;

public class GameInstructions : MonoBehaviour
{
    private Dialogues _dialogues = new();
    private UIManager _uiManager;
    private string _dataShowInstructions = "KEY_SHOW_INSTRUCTIONS";
    public bool deleteData;

    private void Start() {
        _uiManager = UIManager.Instance;
        _uiManager.HideButtonInteractionInCanvas();
        if (!PlayerPrefs.HasKey(_dataShowInstructions)) {
            PlayerPrefs.SetInt(_dataShowInstructions, 1);
            PlayerPrefs.Save();
            SetInstructionsMessage();
        }
    }

    private void SetInstructionsMessage() {
        string message = _dialogues.GetDialogue(Dialogues.Key_GameInstructions, Dialogues.Key_GameInstructions);
        string[] messages = message.Split('-');
        _uiManager.SetMessage(null, messages);
    }

    private void OnValidate() {
        if (deleteData) {
            PlayerPrefs.DeleteKey(_dataShowInstructions);
        }
    }
}
