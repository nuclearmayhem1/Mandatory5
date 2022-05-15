using UnityEngine;
using Cinemachine;

public class Brazier : MonoBehaviour
{
    [Header("References")]
    public GameObject energyBall;
    public CinemachineVirtualCamera brazierCam;
    public GameObject heatEffect;

    private Renderer energyBallRenderer;
    private PuzzleManager manager;
    private Animator brazierAnim;
    private bool brazierHit;

    void Start()
    {
        energyBallRenderer = energyBall.GetComponent<Renderer>();
        manager = FindObjectOfType<PuzzleManager>();
        brazierAnim = GetComponent<Animator>();
    }

    public void BrazierHit()
    {
        if (!brazierHit)
        {
            manager.PuzzleDone(true);
            heatEffect.SetActive(true);
            brazierCam.m_Priority = 12;
            energyBallRenderer.material.EnableKeyword("_EMISSION");
            brazierAnim.SetTrigger("LightBrazier");
            brazierHit = true;
        }
        
    }
    private void AnimationDone()
    {
        brazierCam.m_Priority = 9;
    }
}
