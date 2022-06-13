using UnityEngine;
using Cinemachine;

public class Brazier : MonoBehaviour
{
    [Header("References")]
    public GameObject energyBall;
    public CinemachineVirtualCamera brazierCam;
    public ParticleSystem heatEffect;
    public AudioSource brazierAudioSource;

    private Renderer energyBallRenderer;
    private PuzzleManagerEdvart manager;
    private Animator brazierAnim;
    private bool brazierHit;

    void Start()
    {
        energyBallRenderer = energyBall.GetComponent<Renderer>();
        manager = FindObjectOfType<PuzzleManagerEdvart>();
        brazierAnim = GetComponent<Animator>();
    }

    public void BrazierHit()
    {
        if (!brazierHit)
        {
            brazierAudioSource.PlayDelayed(2.5f);
            manager.PuzzleDone(true);
            heatEffect.Play();
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
