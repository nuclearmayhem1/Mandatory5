using UnityEngine;
using Cinemachine;

public class Brazier : MonoBehaviour
{
    [Header("References")]
    public GameObject energyBall;
    public CinemachineVirtualCamera brazierCam;

    private Renderer energyBallRenderer;
    private PuzzleManager manager;
    private Animator brazierAnim;

    void Start()
    {
        energyBallRenderer = energyBall.GetComponent<Renderer>();
        manager = FindObjectOfType<PuzzleManager>();
        brazierAnim = GetComponent<Animator>();
    }

    public void BrazierHit()
    {
        brazierCam.m_Priority = 12;
        energyBallRenderer.material.EnableKeyword("_EMISSION");
        brazierAnim.SetTrigger("LightBrazier");
    }
    private void AnimationDone()
    {
        brazierCam.m_Priority = 9;
    }
}
