using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose : MonoBehaviour
{
    [SerializeField] private List<Button> _goodThings;
    [SerializeField] private List<Button> _badThings;

    [Header("UI")]
    [SerializeField] private Text _goodBadText;

    private int _correctCount = 0;
    public bool _isPlaying = false;
    public bool _isWin = false;
    public bool _isLose = false;
    private void Awake()
    {
        _correctCount = 0;
        _goodBadText.text = "";
        foreach (Button _goodButton in _goodThings)
        {
            ButtonAddListener(_goodButton);
        }
        foreach (Button _badButton in _badThings)
        {
            ButtonAddListener(_badButton);
        }
        _isPlaying = true;
        _isWin = false;
        _isLose = false;
    }

    private void ButtonAddListener(Button button)
    {
        try
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"發生錯誤:{ex.Message}");
        }
    }

    private void OnButtonClick(Button button)
    {
        if (_isPlaying)
        {
            if (_goodThings.Contains(button))
            {
                _goodBadText.text = "選對了!";
                button.gameObject.SetActive(false);
                    _correctCount++;
                if(_correctCount >= _goodThings.Count)
                {
                    StartCoroutine(Finsh());
                }
            }
            else
            {
                _goodBadText.text = "選錯了!";
            }
        }
    }
    private IEnumerator Finsh()
    {
        _goodBadText.text = "通關!";
        yield return new WaitForSeconds(1f);
        _isPlaying = false;
        _isWin = true;
    }
}
