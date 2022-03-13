using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private StageController _stageController;
    [SerializeField] private List<SpriteRenderer> _woodPartsSprites;
    [SerializeField] private SpriteRenderer _woodSprite;
    [SerializeField] private List<Transform> _woodPartsPositions;

    private List<Vector3> _woodPartsBasePositions = new List<Vector3>();
    private List<GameObject> _receivedKnifes = new List<GameObject>();
    private int _requiredKnifeAmount;
    private int _receivedKnifeAmount;

    private void Awake()
    {
        _stageController.OnStageChanged += SetRequiredKnifes;
        _stageController.OnStageChanged += SetWoodSprites;
    }

    private void Start()
    {
        SetPartsBasePositions();
        SetRequiredKnifes(1);
        SetWoodSprites(1);
    }

    private void SetPartsBasePositions()
    {
        _woodPartsBasePositions = new List<Vector3>();
        for (int i = 0; i < _woodPartsPositions.Count; i++)
        {
            _woodPartsBasePositions.Add(_woodPartsPositions[i].position);
        }
    }

    private void ReturnPartsToBasePositions()
    {
        for (int i = 0; i < _woodPartsPositions.Count; i++)
        {
            _woodPartsSprites[i].GetComponent<Rigidbody>().useGravity = false;
            _woodPartsPositions[i].position = _woodPartsBasePositions[i];
        }
    }

    private void SetWoodSprites(int stage)
    {
        _receivedKnifes.Clear();
        ReturnPartsToBasePositions();
        StageData data = _stageController.GetCurrentStage();
        if (data != null)
        {
            _woodSprite.sprite = data.WoodSprite;
            _woodSprite.enabled = true;
            List<Sprite> woodParts = data.WoodParts;
            for (int i = 0; i < woodParts.Count; i++)
            {
                _woodPartsSprites[i].sprite = woodParts[i];
            }
        }
    }

    private void SetRequiredKnifes(int stage)
    {
        StageData data = _stageController.GetCurrentStage();
        if (data != null)
        {
            _requiredKnifeAmount = data.KnifeData.KnifeAmount;
        }
    }

    private void DestroyWood()
    {
        DestroyApple();
        DestroyKnifes();
        transform.rotation = Quaternion.identity;
        _woodSprite.enabled = false;
        for (int i = 0; i < _woodPartsSprites.Count; i++)
        {
            Debug.Log("cmplete");
            GameObject part = Instantiate(_woodPartsSprites[i].gameObject);
            part.transform.parent = null;
            part.AddComponent<Fader>();
            part.GetComponent<SpriteRenderer>().enabled = true;
            part.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void DestroyKnifes()
    {
        Debug.Log("start destroing");
        List<GameObject> knifes = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "Knife")
            {
                knifes.Add(transform.GetChild(i).gameObject);
            }
        }
        foreach (var item in knifes)
        {
            item.transform.parent = null;
            item.AddComponent<Fader>();
        }
        Debug.Log("destroed knifes");
        //foreach (var item in _receivedKnifes)
        //{
        //    item.transform.parent = null;

        //    Destroy(item.GetComponent<BoxCollider>());
        //    item.AddComponent<Fader>();
        //}
    }

    private void DestroyApple()
    {
        var apple = transform.Find("Apple");
        if (apple)
        {
            apple.transform.parent = null;
            Destroy(apple.gameObject.GetComponent<Apple>());
            apple.gameObject.AddComponent<Fader>();
        }
    }

    private void CompleteStage()
    {
        
        DestroyWood();
        _stageController.IncrementStage();
    }

    private void ReceiveKnife(GameObject knife)
    {
        Destroy(knife.GetComponent<KnifeMover>());
        Destroy(knife.GetComponent<Rigidbody>());
        //Destroy(knife.GetComponent<Knife>());
        Debug.Log(Vector3.Distance(transform.position, knife.transform.position));
        knife.transform.SetParent(this.transform);
        _receivedKnifes.Add(knife);
        _receivedKnifeAmount++;
        if (_receivedKnifeAmount == _requiredKnifeAmount && _requiredKnifeAmount != 0)
        {
            _receivedKnifeAmount = 0;
            CompleteStage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KnifeMover>())
        {
            ReceiveKnife(other.gameObject);
        }
    }
}
