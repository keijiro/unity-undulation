using UnityEngine;
using System.Collections;

public class Twister : MonoBehaviour
{
    public Shaker twist;

    void Update ()
    {
        twist.Update (Scroller.instance.delta);
        transform.localRotation = Quaternion.AngleAxis (twist.Scalar, Vector3.forward);
    }
}
