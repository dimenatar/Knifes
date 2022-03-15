using System;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public event Action OnAppleHitted;

    private void Awake()
    {
        OnAppleHitted += AddFadeEffect;
    }

    private void AddFadeEffect()
    {
        gameObject.AddComponent<Fader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Knife>())
        {
            OnAppleHitted?.Invoke();
            Destroy(this);
        }
    }
}
