using UnityEngine;
using System.Collections;

public class RocketMotion : MonoBehaviour
{
    public Shaker position;

    void Update ()
    {
        position.Update (Scroller.instance.delta);
        transform.localPosition = position.Position;
    }
}
