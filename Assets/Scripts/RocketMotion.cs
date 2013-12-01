using UnityEngine;
using System.Collections;

public class RocketMotion : MonoBehaviour
{
    public float positionFrequency = 0.5f;
    public float positionAmount = 2.0f;

    float randomSeed;

    void Start ()
    {
        randomSeed = Random.value;
    }

    void Update ()
    {
        var tp = Time.time * positionFrequency;

        transform.localPosition =
            new Vector3 (
                Perlin.Fbm (new Vector3 (tp, 9.3310f, randomSeed), 3),
                Perlin.Fbm (new Vector3 (tp, 15.431f, randomSeed), 3),
                Perlin.Fbm (new Vector3 (tp, 43.931f, randomSeed), 3)) * positionAmount;
    }
}
