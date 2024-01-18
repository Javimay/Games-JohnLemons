using UnityEngine;
using UnityTechnologies.Scripts;

public class GhostInBath : MonoBehaviour, IInteractable {
    private UIManager uiManager;
    private Dialogues dialogues = new();

    void Start() {
        uiManager = UIManager.Instance;
    }

    public void Interact() {
        string ghostCharacter = Dialogues.GhostCharacter;
        string[] message = dialogues.GetDialogue(ghostCharacter, Dialogues.KeyClueKey).Split("-");
        uiManager.SetMessage(ghostCharacter, message);
    }
}
