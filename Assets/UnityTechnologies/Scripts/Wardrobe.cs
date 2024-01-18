using Unity.VisualScripting;
using UnityEngine;
using UnityTechnologies.Scripts;

public class Wardrobe : MonoBehaviour, IInteractable
{
    private bool _hasKey;
    private UIManager uiManager;
    private Dialogues dialogues = new();
    public GameObject keyObject;
    public AudioSource addItem;
    bool m_HasAudioPlayed;

    void Start() {
        _hasKey = !keyObject.IsUnityNull();
        uiManager = UIManager.Instance;
    }

    public void Interact() {
        string message = _hasKey ? Dialogues.FindObjectKey : Dialogues.EmptyWardrobeKey;
        uiManager.SetMessage(
            Dialogues.JhonCharacter,
            dialogues.GetDialogue(Dialogues.JhonCharacter, message).Split("-"));
        var player = FindObjectOfType<Player>();
        if (_hasKey) {
            if (!m_HasAudioPlayed) {
                addItem.Play();
                m_HasAudioPlayed = true;
            }
            player.AddItemToInventory(keyObject);
            keyObject = null;
            _hasKey = false;
        }
    }
}
