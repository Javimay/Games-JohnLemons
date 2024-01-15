using System.Collections.Generic;
using UnityEngine;
using UnityTechnologies.Scripts;

public class InteractionDetector : MonoBehaviour
{
    private string interactionButtonName = "Interact";
    private List<IInteractable> _interactablesInRange = new();
    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }

    void Update()
    {
        if (Input.GetButtonDown(interactionButtonName) && _interactablesInRange.Count > 0)
        {
            var interactable = _interactablesInRange[0];
            interactable.Interact();
            uiManager.HideButtonInteractionInCanvas();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null) {
            uiManager.ShowButtonInteractionInCanvas();
            _interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();
        uiManager.HideButtonInteractionInCanvas();
        uiManager.HideDialoguePanel();
        if (_interactablesInRange.Contains(interactable)) {
            _interactablesInRange.Remove(interactable);
        }
    }
}
