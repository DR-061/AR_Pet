using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HungryFileManager : MonoBehaviour
{
    [SerializeField] string JsonFile;
    [SerializeField] Slider hungrySlider;
    private string path;
    private float timer;
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] TextMeshProUGUI sandwichAmountText;

    private SandwichBehaviour sandwich;

    private struct SliderValues
    {
        public float value;
        public int sandwichAmount;
    }

    private void Start()
    {
        path = Application.persistentDataPath + JsonFile;
        GameObject sandwichObject = GameObject.FindWithTag("Sandwich");
        sandwich = sandwichObject.GetComponent<SandwichBehaviour>();
        Load();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            save();
            timer = 0;
        }
    }

    private void save()
    {
        SliderValues s = new SliderValues();
        s.value = hungrySlider.value;
        s.sandwichAmount = sandwich.GetSandwichesAmount();

        string jsonText = JsonUtility.ToJson(s);

        StreamWriter streamWriter = new StreamWriter(path);
        streamWriter.Write(jsonText);
        streamWriter.Close();
    }

    private void Load()
    {
        if (File.Exists(path))
        {
            StreamReader streamReader = new StreamReader(path);
            string jsonText = streamReader.ReadToEnd();
            SliderValues s = JsonUtility.FromJson<SliderValues>(jsonText);
            hungrySlider.value = s.value;

            sandwich.SetSandwichesAmount(s.sandwichAmount);

            sandwichAmountText.SetText($"x {s.sandwichAmount}");
            streamReader.Close();
        }
    }
}
