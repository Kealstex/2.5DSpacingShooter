using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text visualizer;
    private int _value=0;

    public void Increase(){
        _value+=10;
        visualizer.text = "Score: " + _value;
    }

    public int Get(){
        return _value;
    }
}