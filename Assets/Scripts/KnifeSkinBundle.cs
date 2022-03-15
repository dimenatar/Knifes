using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Knife Skins", menuName = "Knife Skins", order = 43)]
public class KnifeSkinBundle : ScriptableObject
{
    [SerializeField] private List<KnifeSkinData> _skins;

    public List<KnifeSkinData> Skins => _skins;
}
