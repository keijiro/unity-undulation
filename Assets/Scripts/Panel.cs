using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour
{
    Quaternion initialRotation;

    void Start ()
    {
        initialRotation = transform.rotation;
    }

    void Update ()
    {
        transform.position -= Vector3.forward * Scroller.instance.delta;

        if (transform.position.z < PanelController.instance.zLimit)
            Destroy (gameObject);

        transform.rotation = initialRotation * PanelController.instance.Rotation (transform.position);
    }
}
