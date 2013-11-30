using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{
    #region Public properties

    public float zLimit = -20.0f;

    #endregion

    #region Private variables

    Quaternion initialRotation;

    #endregion

    #region Monobehaviour functions

    void Start ()
    {
        initialRotation = transform.rotation;
    }

    void Update ()
    {
        var slide = RoadMaker.instance.speed * Time.deltaTime;
        transform.position -= Vector3.forward * slide;

        if (transform.position.z < zLimit)
            Destroy(gameObject);

        var offset = Vector3.up * Time.time * 0.83f - Vector3.forward * Time.time * 0.79f;
        var angle = 110.0f * (Perlin.Noise(transform.position * 0.19f + offset));
        transform.rotation = initialRotation * Quaternion.AngleAxis(angle, Vector3.right);
    }

    #endregion
}
