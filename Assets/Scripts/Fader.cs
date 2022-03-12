using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fader : MonoBehaviour
{
    private float _rotater;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up*100, ForceMode.Impulse);
        _rotater = Random.Range(4, 6) + Random.Range(0.1f, 0.9f);
        GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(-_rotater, _rotater)*50, ForceMode.Impulse);
        Invoke(nameof(DestroyCurrentObject), 4);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(_rotater, _rotater/2, 0));
    }

    private void DestroyCurrentObject()
    {
        Destroy(gameObject);
    }
}
