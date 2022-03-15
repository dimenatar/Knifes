using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private KnifeSkinBundle _skinBundle;
    [SerializeField] private GameObject _backGroundPrefab;
    [SerializeField] private GameObject _scrollContent;
    [SerializeField] private Image _usersKnife;

    private void Start()
    {
        LoadSkins();
    }

    private void SetUsersKnifeSprite(string resourcePath)
    {
        _usersKnife.sprite = Resources.Load<Sprite>(resourcePath);
    }

    private void LoadSkins()
    {
        UserData userData = UserSaveManager.LoadUserData(UserSaveManager.Path);
        if (userData == null)
        {
            userData = new UserData();
            userData.UnlockSkin(_skinBundle.Skins[0]);
            userData.SetUsersKnife(_skinBundle.Skins[0].SkinIndex);
            UserSaveManager.SaveUserData(UserSaveManager.Path, userData);
        }
        _usersKnife.sprite = Resources.Load<Sprite>(userData.CurrentKnife.SkinResourcesPath);
        for (int i = 0; i < _skinBundle.Skins.Count; i++)
        {
            GameObject background = Instantiate(_backGroundPrefab, _scrollContent.transform);
            var skin = userData.UnlockedSkins.Where(skin => skin.SkinIndex == _skinBundle.Skins[i].SkinIndex).ToList();
            background.AddComponent<KnifeMenuItem>();
            if (skin.Count == 0)
            {
                background.GetComponent<Image>().color = Color.gray;
                background.GetComponent<KnifeMenuItem>().SetSkinData(_skinBundle.Skins[i], false);
            }
            else
            {
                background.GetComponent<KnifeMenuItem>().SetSkinData(_skinBundle.Skins[i], true);
            }
            background.GetComponent<KnifeMenuItem>().OnSkinSet += SetUsersKnifeSprite;
            background.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(_skinBundle.Skins[i].SkinResourcesPath);
        }
    }
}
