using UnityEngine;

public class Observer : MonoBehaviour {
    public Transform player;
    public GameEnding gameEnding;
    private bool m_IsPLayerInRange;

    private void OnTriggerEnter(Collider other) {
        if (other.transform == player) {
            //m_IsPLayerInRange = true;
            gameEnding.CaughtPlayer();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform == player) {
            // m_IsPLayerInRange = false;
        }
    }

    private void Update() {
        if (m_IsPLayerInRange) {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if (Physics.Raycast(ray, out raycastHit)) {
                if (raycastHit.collider.transform == player) {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}