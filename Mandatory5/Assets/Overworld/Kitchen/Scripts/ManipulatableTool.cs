using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatableTool : MonoBehaviour
{
    public bool held = false;
    public bool carried = false;

    public virtual void UseTool() { }
    public virtual void UseToolSecondary() { }
    public virtual void UseToolRotation(Vector3 rotation) { }

}
