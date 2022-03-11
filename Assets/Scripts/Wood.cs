using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KnifeMover>())
        {
            Destroy(other.GetComponent<KnifeMover>());
            Destroy(other.GetComponent<Rigidbody>());
            Debug.Log(Vector3.Distance(transform.position, other.transform.position));
            other.transform.SetParent(this.transform);
        }
    }
}
