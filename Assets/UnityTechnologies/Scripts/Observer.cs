using UnityEngine;

public class Observer : MonoBehaviour {
    public Transform player;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other) {
        if (other.transform == player) {
            gameEnding.CaughtPlayer();
        }
    }
}
