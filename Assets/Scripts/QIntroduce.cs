using UnityEngine;
using UnityEngine.UI;

public class QIntroduce : MonoBehaviour
{
    [SerializeField] private Button NanYan;
    [SerializeField] private Button DanQue;
    [SerializeField] private Button HanShi;
    [SerializeField] private Text IntroduceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NanYan.onClick.AddListener(() => OnButton(NanYan));
        DanQue.onClick.AddListener(() => OnButton(DanQue));
        HanShi.onClick.AddListener(() => OnButton(HanShi));
    }

    private void OnButton(Button button)
    {
        if (button == NanYan)
        {
            IntroduceText.text = "● 南洋叻沙風味：\n非油炸麵餅，0 反式脂肪酸；\n190kcal／每份麵餅 50g，每份麵餅能量約等於 111g 牛油果（鱷梨）＊鱷梨能量為 171kcal／100g（以可食部計）依據《中國食物成分表》標準版 第 6 版第一冊；\n嚴選原料，嚴選江西糙米，大米含量 ≥ 80%；\n採用熱風干燥技術，20 小時製麵，18 道工藝，久泡不爛；\n匠心精製料；\n真實配料，內容濃縮椰漿。";
        }
        else if (button == DanQue)
        {
            IntroduceText.text = "● 當歸雞風味：\n非油炸麵餅，0 反式脂肪酸；\n190kcal／每份麵餅 50g，每份麵餅能量約等於 111g 牛油果（鱷梨）＊鱷梨能量為 171kcal／100g（以可食部計）依據《中國食物成分表》標準版 第 6 版第一冊；\n嚴選原料，嚴選江西糙米，大米含量 ≥ 80%；\n採用熱風干燥技術，20 小時製麵，18 道工藝，久泡不爛；\n香醇濃郁，內容芝麻油包；\n真實配料，寧夏枸杞點睛。";
        }
        else if (button == HanShi)
        {
            IntroduceText.text = "● 韓式泡菜風味：\n膳食纖維 ≥ 50%；\n嚴選珍稀大顆粒芽菇原料，自有工廠深加工；\n麵餅含有膳食纖維，膳食纖維有助於維持正常的腸道功能；\n採用亞瑪熱風干燥技術，一種全自動化生產非油炸索狀食品的方法，12 小時製麵，18 道工藝，久泡不爛；\n精選干制辣白菜，還原地道風味。";
        }
    }
}   