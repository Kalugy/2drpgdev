using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FLoatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
        {
            txt.UpdateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floationText = GetFloatingText();

        floationText.txt.text = msg;
        floationText.txt.fontSize = fontSize;
        floationText.txt.color = color;
        floationText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floationText.motion = motion;
        floationText.duration = duration;

        floationText.Show();


    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }
        return txt;
    }
}
