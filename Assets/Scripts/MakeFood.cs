using UnityEngine;
using UnityEngine.UI;

public class MakeFood : MonoBehaviour
{
    /// <summary>
    /// Good Food
    /// </summary>
    [Header("Good Food")]
    [SerializeField] private Button _nooodleButton;
    [SerializeField] private Button _soupButton;
    [SerializeField] private Button _sandwichButton;

    /// <summary>
    /// Bad Food
    /// </summary>
    [Header("Bad Food")]
    [SerializeField] private Button _FriedChickenButton;

    /// <summary>
    /// Variable
    /// </summary>
    private float _health = 100f;

    /// <summary>
    /// UI
    /// </summary>
    [Header("UI")]
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _goodBadText;

    private int _chooseFoodIndex = 0;

    private void Awake()
    {
        _nooodleButton.onClick.AddListener(() => OnButtonClick(_nooodleButton));
        _soupButton.onClick.AddListener(() => OnButtonClick(_soupButton));
        _sandwichButton.onClick.AddListener(() => OnButtonClick(_sandwichButton));
        _FriedChickenButton.onClick.AddListener(() => OnButtonClick(_FriedChickenButton));
        _chooseFoodIndex = 0;
        _healthText.text = "Health:" + _health;
        _goodBadText.text = "";
    }

    private void OnButtonClick(Button button)
    {
        if(button.gameObject.tag == "Good")
        {
            Debug.Log("Good :D");
            switch(_chooseFoodIndex)
            {
                case 0:
                    if(button == _nooodleButton)
                    {
                        _chooseFoodIndex++;
                        _nooodleButton.gameObject.SetActive(false);
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
                    if(button == _soupButton)
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
                    if(button == _sandwichButton)
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
        else if(button.gameObject.tag == "Bad")
        {
            Debug.Log("Bad :(");
            _goodBadText.text = "老兄你選這什麼垃圾食物";
            _health -= 10f;
            _healthText.text = "Health:" + _health;
        }
        else
        {
            Debug.Log("Error");
            _goodBadText.text = "好像不該看到這個，出Error了:(";
        }
    }
}