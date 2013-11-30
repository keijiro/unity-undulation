using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour
{
    public float positionFrequency = 0.5f;
    public float positionAmount = 2.0f;
    public float rotationFrequency = 0.5f;
    public float rotationAmount = 10.0f;

    void Update ()
    {
        var tp = Time.time * positionFrequency;
        var tr = Time.time * rotationFrequency;

        transform.localPosition =
            new Vector3 (
                Perlin.Fbm (new Vector2 (tp, 0.331f), 3),
                Perlin.Fbm (new Vector2 (tp, 5.431f), 3),
                Perlin.Fbm (new Vector2 (tp, 1.931f), 3)) * positionAmount;

        transform.localRotation =
            Quaternion.AngleAxis (Perlin.Fbm (new Vector2 (tr, 9.331f), 3) * rotationAmount, Vector3.up) *
            Quaternion.AngleAxis (Perlin.Fbm (new Vector2 (tr, 3.331f), 3) * rotationAmount, Vector3.right);
    }
}
