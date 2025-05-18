using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSomething : MonoBehaviour
{
    [Header("場景")]
    [Header("Good Food")]
    [SerializeField] private List<Button> _goodThings;
    [Header("Bad Food")]
    [SerializeField] private List<Button> _badThings;

    [Header("UI")]
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _goodBadText;

    private int _chooseSomethingIndex = 0;
    private float _health = 100f;
    public bool _isPlaying = false;
    public bool _isWin = false;
    public bool _isLose = false;

    private void Awake()
    {
        _chooseSomethingIndex = 0;
        _healthText.text = "Health:" + _health;
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
            if (button == _goodThings[_chooseSomethingIndex])
            {
                _goodBadText.text = "選對了";
                button.gameObject.SetActive(false);
                if (_chooseSomethingIndex == (_goodThings.Count - 1))
                {
                    _goodBadText.text = "關卡完成";
                    _isPlaying = false;
                    _isWin = true;
                }
                else
                {
                    _chooseSomethingIndex++;
                }
            }
            else
            {
                _goodBadText.text = "選錯了";
                TakeDamage();
            }
        }
    }

    private void TakeDamage()
    {
        _health -= 10f;
        _healthText.text = $"Health:{_health}";
        if (_health <= 0)
        {
            _goodBadText.text = "關卡失敗";
            _isPlaying = false;
            _isLose = true;
        }
    }
}