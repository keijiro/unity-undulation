using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour
{
    #region Public properties

    public GameObject panelPrefab;
    public int column = 10;
    public int row = 20;
	public float speed = 5.0f;

    #endregion

    #region Private members

    GameObject[] panels;
	float scroll;
	int toWrap;

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

		toWrap = column * (row - 1);
    }
    
    void Update ()
    {
		speed = Time.time;

		var slide = Vector3.forward * speed * Time.deltaTime;
		scroll += speed * Time.deltaTime;

		var offset = Vector3.up * Time.time * 0.83f + Vector3.forward * Time.time * 0.79f;

        for (var i = 0; i < panels.Length; i++)
        {
			var angle = -80.0f * (Perlin.Noise(panels[i].transform.position * 0.19f + offset));
            panels[i].transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
			panels[i].transform.localPosition += slide;
		}

		while (scroll > 1.0f)
		{
			for (var i = 0; i < column; i++)
			{
				panels[toWrap + i].transform.localPosition -= Vector3.forward * row;
			}

			toWrap -= column;
			if (toWrap < 0) toWrap += row * column;

			scroll -= 1.0f;
		}
	}
}
