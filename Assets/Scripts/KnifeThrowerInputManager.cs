using UnityEngine;

public class KnifeThrowerInputManager : MonoBehaviour
{
    [SerializeField] private KnifeThrower _knifeThrower;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _knifeThrower.ThrowKnife();
        }
    }
}
