using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour
{
    #region Static attribute

    static public Scroller instance;

    #endregion

    #region Public properties

    public float speed = 20.0f;

    #endregion

    #region Public variables

    [HideInInspector]
    public float position;

    [HideInInspector]
    public float delta;

    #endregion

    #region Monobehaviour functions

    void Awake ()
    {
        instance = this;
    }

    void Update ()
    {
        delta = speed * Time.deltaTime;
        position += delta;
    }

    #endregion
}
