using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HungryFileManager : MonoBehaviour
{

    [SerializeField] Slider hungrySlider;
    private string path;
    private float timer;
    [SerializeField] private float cooldown;

    struct SliderValues
    {
        public float value;
        public int sandwichAmount;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        path = Application.persistentDataPath + "/savedata.json";
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown) 
        {
            save();
            timer = 0;
        }

    }

    void save()
    {
        SliderValues s = new SliderValues();
        s.value = hungrySlider.value;
        s.sandwichAmount = SandwichBehaviour.sandwichesAmount;

        string jsonText = JsonUtility.ToJson(s);

        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.Write(jsonText);
        streamWriter.Close();
    }


    void Load()
    {
        if (File.Exists(path))
        {
            StreamReader streamReader = new StreamReader(path);
            string jsonText = streamReader.ReadToEnd();
            SliderValues s = JsonUtility.FromJson<SliderValues>(jsonText);
            hungrySlider.value = s.value;
            SandwichBehaviour.sandwichesAmount = s.sandwichAmount;
            streamReader.Close();
        }
    }
}
