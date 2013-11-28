using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour
{
    #region Public properties

    public GameObject panelPrefab;
    public int column = 10;
    public int row = 20;

    #endregion

    #region Private members

    GameObject[] panels;

    #endregion

    void Start ()
    {
        panels = new GameObject[row * column];

        for (var r = 0; r < row; r++)
        {
            for (var c = 0; c < column; c++)
            {
                var go = Instantiate (panelPrefab) as GameObject;
                go.transform.parent = transform;
                go.transform.localPosition = new Vector3(c - 0.5f * column, 0, r - 0.5f * row);
                go.transform.localRotation = Quaternion.AngleAxis (15.0f, Vector3.right);
                panels[r * column + c] = go;
            }
        }
    }
    
    void Update ()
    {
		var offset = Vector3.up * Time.time * 0.43f + Vector3.forward * Time.time * 0.79f;
        for (var i = 0; i < panels.Length; i++)
        {
			var angle = -60.0f * (Perlin.Noise(panels[i].transform.position * 0.19f + offset));
            panels[i].transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
        }
    }
}
