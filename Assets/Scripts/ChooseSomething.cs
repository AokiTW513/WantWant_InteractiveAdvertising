using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseSomething : MonoBehaviour
{
    [Header("場景1")]
    [Header("Good Food")]
    [SerializeField] private Button _noodleButton;
    [SerializeField] private Button _soupButton;
    [SerializeField] private Button _sandwichButton;
    [Header("Bad Food")]
    [SerializeField] private Button _FriedChickenButton;

    [Header("場景2")]
    [Header("Good Food")]
    [SerializeField] private Button _idk1Button;
    [SerializeField] private Button _idk2Button;
    [SerializeField] private Button _idk3Button;
    [Header("Bad Food")]
    [SerializeField] private Button _idk4Button;

    [Header("場景3")]
    [Header("Good Food")]
    [SerializeField] private Button _idk5Button;
    [SerializeField] private Button _idk6Button;
    [SerializeField] private Button _idk7Button;
    [Header("Bad Food")]
    [SerializeField] private Button _idk8Button;

    [Header("UI")]
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _goodBadText;

    private int _chooseFoodIndex = 0;
    private float _health = 100f;

    private void Awake()
    {
        _chooseFoodIndex = 0;
        _healthText.text = "Health:" + _health;
        _goodBadText.text = "";
        Debug.Log("現在場景名稱:" + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            ButtonAddListener(_noodleButton);
            ButtonAddListener(_soupButton);
            ButtonAddListener(_sandwichButton);
            ButtonAddListener(_FriedChickenButton);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            ButtonAddListener(_idk1Button);
            ButtonAddListener(_idk2Button);
            ButtonAddListener(_idk3Button);
            ButtonAddListener(_idk4Button);
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            ButtonAddListener(_idk5Button);
            ButtonAddListener(_idk6Button);
            ButtonAddListener(_idk7Button);
            ButtonAddListener(_idk8Button);
        }
        else
        {
            Debug.Log("你不是在Level1/2/3，那你在哪?WTF?");
        }
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
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (button.gameObject.tag == "Good")
            {
                Debug.Log("Good :D");
                switch (_chooseFoodIndex)
                {
                    case 0:
                        if (button == _noodleButton)
                        {
                            _chooseFoodIndex++;
                            _noodleButton.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇麵";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    case 1:
                        if (button == _soupButton)
                        {
                            _chooseFoodIndex++;
                            _soupButton.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇湯";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    case 2:
                        if (button == _sandwichButton)
                        {
                            _chooseFoodIndex++;
                            _sandwichButton.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇三明治";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    default:
                        Debug.Log("Wait What?");
                        break;
                }
            }
            else if (button.gameObject.tag == "Bad")
            {
                Debug.Log("Bad :(");
                _goodBadText.text = "老兄你選這什麼垃圾食物";
                _health -= 10f;
                _healthText.text = "Health:" + _health;
            }
            else
            {
                Debug.LogError("Error");
                _goodBadText.text = "好像不該看到這個，出Error了:(";
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (button.gameObject.tag == "Good")
            {
                Debug.Log("Good :D");
                switch (_chooseFoodIndex)
                {
                    case 0:
                        if (button == _idk1Button)
                        {
                            _chooseFoodIndex++;
                            _idk1Button.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇麵";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    case 1:
                        if (button == _idk2Button)
                        {
                            _chooseFoodIndex++;
                            _idk2Button.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇湯";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    case 2:
                        if (button == _idk3Button)
                        {
                            _chooseFoodIndex++;
                            _idk3Button.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇三明治";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    default:
                        Debug.Log("Wait What?");
                        break;
                }
            }
            else if (button.gameObject.tag == "Bad")
            {
                Debug.Log("Bad :(");
                _goodBadText.text = "老兄你選這什麼垃圾食物";
                _health -= 10f;
                _healthText.text = "Health:" + _health;
            }
            else
            {
                Debug.LogError("Error");
                _goodBadText.text = "好像不該看到這個，出Error了:(";
            }    
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (button.gameObject.tag == "Good")
            {
                Debug.Log("Good :D");
                switch (_chooseFoodIndex)
                {
                    case 0:
                        if (button == _idk5Button)
                        {
                            _chooseFoodIndex++;
                            _idk5Button.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇麵";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    case 1:
                        if (button == _idk6Button)
                        {
                            _chooseFoodIndex++;
                            _idk6Button.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇湯";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    case 2:
                        if (button == _idk7Button)
                        {
                            _chooseFoodIndex++;
                            _idk7Button.gameObject.SetActive(false);
                            Debug.Log("Nice OwO");
                            _goodBadText.text = "已選擇三明治";
                        }
                        else
                        {
                            Debug.Log("You Choose Wrong One");
                            _goodBadText.text = "老兄你選錯摟";
                        }
                        break;
                    default:
                        Debug.Log("Wait What?");
                        break;
                }
            }
            else if (button.gameObject.tag == "Bad")
            {
                Debug.Log("Bad :(");
                _goodBadText.text = "老兄你選這什麼垃圾食物";
                _health -= 10f;
                _healthText.text = "Health:" + _health;
            }
            else
            {
                Debug.LogError("Error");
                _goodBadText.text = "好像不該看到這個，出Error了:(";
            }
        }
        else
        {
            Debug.LogError("等等，你在哪個場景?");
        }
    }
}