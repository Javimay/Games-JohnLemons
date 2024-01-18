using System.Collections.Generic;
using UnityEngine;
using UnityTechnologies.Scripts;

public class InteractionDetector : MonoBehaviour
{
    private List<IInteractable> _interactablesInRange = new();
    private UIManager uiManager;

    private void Start() {
        uiManager = UIManager.Instance;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && _interactablesInRange.Count > 0
            && !uiManager.showingMessage) {
            var interactable = _interactablesInRange[0];
            interactable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other) {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null) {
            _interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerStay(Collider other) {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null) {
            uiManager.ShowButtonInteractionInCanvas();
        }
    }

    private void OnTriggerExit(Collider other) {
        var interactable = other.GetComponent<IInteractable>();
        uiManager.HideButtonInteractionInCanvas();
        uiManager.HideDialoguePanel();
        if (_interactablesInRange.Contains(interactable)) {
            _interactablesInRange.Remove(interactable);
        }
    }
}
