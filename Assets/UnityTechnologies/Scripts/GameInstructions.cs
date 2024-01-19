using UnityTechnologies.Scripts;
using UnityEngine;

public class GameInstructions : MonoBehaviour
{
    private Dialogues _dialogues = new();
    private UIManager _uiManager;
    private string _dataShowInstructions = "KEY_SHOW_INSTRUCTIONS";

    private void Start() {
        _uiManager = UIManager.Instance;
        _uiManager.HideButtonInteractionInCanvas();
        if (!PlayerPrefs.HasKey(_dataShowInstructions)) {
            SetInstructionsMessage();
            PlayerPrefs.SetInt(_dataShowInstructions, 0);
        }
    }

    private void SetInstructionsMessage() {
        string message = _dialogues.GetDialogue(Dialogues.Key_GameInstructions, Dialogues.Key_GameInstructions);
        string[] messages = message.Split('-');
        _uiManager.SetMessage(null, messages);
    }
}
