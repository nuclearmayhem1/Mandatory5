using UnityEngine;
using UnityEngine.UI;

public class WinMessage : MonoBehaviour
{
    public Text message;
    public Animator messageAnim;

    public void Message(string text)
    {
        message.text = text;
        messageAnim.SetBool("IsActive", true);
        Invoke("MessageDone", 2f);
    }
    private void MessageDone()
    {
        messageAnim.SetBool("IsActive", false);
    }
}
