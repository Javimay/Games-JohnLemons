using Unity.VisualScripting;
using UnityEngine;
using UnityTechnologies.Scripts;

public class Wardrobe : MonoBehaviour, IInteractable
{
    private bool _hasKey;
    private UIManager uiManager;
    private GameObject _characterPrefab;
    private Dialogues dialogues = new();
    public GameObject keyObject;
    void Start() {
        _hasKey = !keyObject.IsUnityNull();
        uiManager = UIManager.Instance;
    }

    public void Interact() {
        string message = _hasKey ? Dialogues.FindObjectKey : Dialogues.EmptyWardrobeKey;
        uiManager.SetMessage(
            Dialogues.JhonCharacter,
            dialogues.GetDialogue(Dialogues.JhonCharacter, message));
        var player = FindObjectOfType<Player>();
        if (_hasKey) {
            player.AddItemToInventory(keyObject);
            keyObject = null;
            _hasKey = false;
        }
    }
}
