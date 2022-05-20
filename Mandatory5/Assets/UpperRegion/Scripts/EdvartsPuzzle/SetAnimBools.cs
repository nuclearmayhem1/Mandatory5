using UnityEngine;

public class SetAnimBools : MonoBehaviour
{
    public Animator animator;
    public string[] nameOfBool;
    
    public void SetAnimBoolTrue()
    {
        for (int i = 0; i < nameOfBool.Length; i++)
        {
            animator.SetBool(nameOfBool[i], true);
        }
    }
    public void SetAnimBoolFalse()
    {
        for (int i = 0; i < nameOfBool.Length; i++)
        {
            animator.SetBool(nameOfBool[i], false);
        }
    }
}
