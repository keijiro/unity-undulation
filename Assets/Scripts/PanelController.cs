using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour
{
    public static PanelController instance;
    public float zLimit = -20.0f;
    public float swing = 110.0f;
    public float noiseFrequency = 0.19f;
    public Vector3 noiseVelocity;
    Vector3 offset;

    public Quaternion Rotation (Vector3 position)
    {
        var angle = swing * (Perlin.Noise ((position + offset) * noiseFrequency));
        return Quaternion.AngleAxis (angle, Vector3.right);
    }

    void Awake ()
    {
        instance = this;
    }

    void Update ()
    {
        offset = noiseVelocity * Time.time;
    }
}
