using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SerializableSprite 
{
    [NonSerialized]
    public Sprite Sprite;

    SerializeTexture exportObj = new SerializeTexture();
    SerializeTexture importObj = new SerializeTexture();

    public void Serialize(string path)
    {
        Texture2D tex = Sprite.texture;
        exportObj.x = tex.width;
        exportObj.y = tex.height;
        exportObj.bytes = ImageConversion.EncodeToPNG(tex);
        string text = JsonConvert.SerializeObject(exportObj);
        File.WriteAllText(@"d:\test.json", text);
    }

    public void Serialize(string path, Sprite sprite)
    {
        Texture2D tex = sprite.texture;
        exportObj.x = tex.width;
        exportObj.y = tex.height;
        exportObj.bytes = ImageConversion.EncodeToPNG(tex);
        string text = JsonConvert.SerializeObject(exportObj);
        File.WriteAllText(@"d:\test.json", text);
    }

    public Sprite DeSerialize(string path)
    {
        string text = File.ReadAllText(path);
        importObj = JsonConvert.DeserializeObject<SerializeTexture>(text);
        Texture2D tex = new Texture2D(importObj.x, importObj.y);
        ImageConversion.LoadImage(tex, importObj.bytes);
        return Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);
    }

    [Serializable]
    public class SerializeTexture
    {
        [SerializeField]
        public int x;
        [SerializeField]
        public int y;
        [SerializeField]
        public byte[] bytes;
    }
}
