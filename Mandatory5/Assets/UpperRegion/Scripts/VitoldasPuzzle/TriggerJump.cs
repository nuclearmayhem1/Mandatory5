using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool move = false;

    private void Update()
    {
        if (move)
        {
            //transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpTrigger"))
        {
            animator.SetTrigger("Jump");

            move = true;
        }
    }

    public void BeanSunk()
    {
        Destroy(gameObject);
    }
}
