using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMover : MonoBehaviour
{
    private float _speed;

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, _speed, 0);
    }

    private void OnDestroy()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
