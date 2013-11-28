using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public GameObject prefab;
    public float radius;
    public float rate;
	public float velocity;
    float timer;

    void GenerateInstance()
    {
        var position = Random.insideUnitCircle * radius;
        var go = Instantiate (prefab, transform.position + new Vector3 (position.x, 0, position.y), Random.rotation) as GameObject;
		go.rigidbody.velocity = transform.forward * velocity * Random.Range (0.9f, 1.1f);
    }

    void Update ()
    {
        timer += Time.deltaTime * rate;

        while (timer > 1.0f)
        {
            GenerateInstance();
            timer -= 1.0f;
        }
    }
}
