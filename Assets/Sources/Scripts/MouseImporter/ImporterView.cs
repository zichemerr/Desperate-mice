using UnityEngine;
using TMPro;

public class ImporterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    public void ShowValue(int value)
    {
        _text.text = $"{value}/2";
    }
}
