using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTechnologies.Scripts;

public class GameEnding : MonoBehaviour, IInteractable
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    private Dialogues _dialogues = new();
    private UIManager uiManager;
    
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    private void Start() {
        uiManager = UIManager.Instance;
    }

    public void CaughtPlayer() {
        m_IsPlayerCaught = true;
    }

    private void Update() {
        if (m_IsPlayerAtExit) {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        } else if (m_IsPlayerCaught) {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource) {
        if (!m_HasAudioPlayed) {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        
        m_Timer += Time.deltaTime;
        uiManager.HideItemLayour();
        uiManager.HideButtonInteractionInCanvas();
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        if (m_Timer > fadeDuration + displayImageDuration) {
            if (doRestart) {
                SceneManager.LoadScene(0);
            } else {
                Application.Quit();
            }
        }
    }

    public void Interact() {
        var playerInventory = player.GetComponent<Player>();
        string[] message;
        if (playerInventory.HasItems()) {
            if (playerInventory.HasItemInInventory("GoldKey")) {
                m_IsPlayerAtExit = true;
            } else {
                message = _dialogues.GetDialogue(null, Dialogues.Key_RedKey).Split("-");
                UIManager.Instance.SetMessage(null, message);
            }
        } else {
            message = _dialogues.GetDialogue(null, Dialogues.Key_NoKey).Split("-");
            UIManager.Instance.SetMessage(null, message);
        }
    }
}