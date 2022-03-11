using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrowerInputManager : MonoBehaviour
{
    [SerializeField] private KnifeThrower _knifeThrower;

    void Update()
    {
        //if (Input.touchCount == 1)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Began)
        //    {
        //        _knifeThrower.ThrowKnife();
        //    }
        //}
        if (Input.GetMouseButtonDown(0))
        {
            _knifeThrower.ThrowKnife();
        }
    }
}
