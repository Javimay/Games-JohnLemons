using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private String horizontalAxis = "Horizontal";
    private String verticalAxis = "Vertical";
    private String isWalkingNameVariable = "IsWalking";
    float turnSpeed = 20f;
    
    public Vector3 m_Movement;
    public Quaternion m_Rotation = Quaternion.identity;
    public Animator m_Animator;
    public Rigidbody m_Rigidbody;
    private AudioSource m_AudioSource;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis(horizontalAxis);
        float vertical = Input.GetAxis(verticalAxis);
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool(isWalkingNameVariable, isWalking);

        if (isWalking) {
            if (!m_AudioSource.isPlaying) {
                m_AudioSource.Play();
            }
        } else {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(
            transform.forward,
            m_Movement,
            turnSpeed * Time.deltaTime,
            0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
