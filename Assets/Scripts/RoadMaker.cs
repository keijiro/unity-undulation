using UnityEngine;
using System.Collections;

public class RoadMaker : MonoBehaviour
{
    #region Static attribute

    static public RoadMaker instance;

    #endregion

    #region Public properties

    public GameObject panelPrefab;
    public int columnCount = 15;
    public float speed = 5.0f;

    #endregion

    #region Private members

    float scroll;

    #endregion

    #region Private method

    void CreateRow (float offset)
    {
        for (var column = 0; column < columnCount; column++)
        {
            var position = transform.position +
                transform.right * (column - 0.5f * columnCount) -
                transform.forward * offset;
            Instantiate (panelPrefab, position, transform.rotation);
        }
    }

    #endregion

    #region Monobehaviour functions

    void Awake ()
    {
        instance = this;
    }

    void Update ()
    {
        transform.localRotation = Quaternion.AngleAxis(Perlin.Noise (Time.time * 0.3f) * 90.0f + 20.0f, Vector3.forward);

        scroll += speed * Time.deltaTime;

        while (scroll > 1.0f)
        {
            CreateRow (scroll);
            scroll -= 1.0f;
        }
    }

    #endregion
}
