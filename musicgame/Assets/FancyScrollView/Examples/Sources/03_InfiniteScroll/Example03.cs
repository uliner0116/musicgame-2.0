using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace FancyScrollView.Example03
{
    public class Example03 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;
        [SerializeField] Button Swich = default;
        [SerializeField] Button Swich_Ch = default;
        [SerializeField] Button Swich_En = default;
        [SerializeField] Button Swich_Jp = default;
        [SerializeField] Button Swich_Kr = default;
        [SerializeField] Button Swich_ALL = default;
        [SerializeField] Text Language = default;
        public GameObject page;
        string[] name = { "butterfly" ,"Don't say lazy" ,"Im sorry" ,"LATATA" ,"LOVE" ,"Mirotic" ,"Oh!" ,"One Night In 北京" ,"PON PON PON" ,"Roly Poly" ,"SORRY SORRY" ,"Trouble Maker" ,"Tunak Tunak Tun" ,
        "YES or YES" ,"三國戀" ,"千年之戀" ,"不得不愛" ,"月牙灣" ,"回レ! 雪月花" ,"我不配" ,"我還年輕 我還年輕" ,"牡丹江" ,"東區東區" ,"直感" ,"星空" ,"夏祭り" ,"恋","恋は渾沌の隷也" ,
        "恋愛サーキュレーション" ,"夠愛" ,"將軍令" ,"華陽炎" ,"極楽浄土" ,"憂愁" ,"憨人" ,"樹枝孤鳥" ,"Burn It Down","Counting Stars","Good Time","I Really Like You","Maps","One More Night",
        "Poker Face","Thunder","What Ive Done","What Makes You Beautiful"
        };
        string[] Chinese = { "One Night In 北京", "三國戀", "千年之戀", "不得不愛", "月牙灣", "我不配", "我還年輕 我還年輕", "牡丹江", "東區東區", "星空", "夠愛", "將軍令", "憂愁", "憨人", "樹枝孤鳥" };
        string[] English = { "Burn It Down","Counting Stars","Good Time","I Really Like You","Maps","One More Night","Poker Face","Thunder","What Ive Done","What Makes You Beautiful", "Tunak Tunak Tun" };
        string[] Janpan = { "butterfly", "Don't say lazy", "PON PON PON", "回レ! 雪月花", "夏祭り", "恋", "恋は渾沌の隷也", "恋愛サーキュレーション", "華陽炎", "極楽浄土" };
        string[] Korean = { "Im sorry" ,"LATATA" ,"LOVE" ,"Mirotic" ,"Oh!" , "Roly Poly", "SORRY SORRY", "Trouble Maker", "YES or YES", "直感" };
        void Start()
        {
            Swich.onClick.AddListener(Active_Text);
            Swich_Ch.onClick.AddListener(SW_Ch);
            Swich_En.onClick.AddListener(SW_En);
            Swich_Jp.onClick.AddListener(SW_Jp);
            Swich_Kr.onClick.AddListener(SW_Kr);
            Swich_ALL.onClick.AddListener(SW_ALL);
            scrollView.OnSelectionChanged(OnSelectionChanged);
            
            var items = Enumerable.Range(0,46)
                .Select(i => new ItemData(name[i], name[i]))
                .ToArray();
            
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
        }
        void OnSelectionChanged(int index)
        {
            
        }
        public void Active_Text()
        {
            if (!page.activeInHierarchy)
            { page.SetActive(true); }
            else
            { page.SetActive(false); }
        }
        public void SW_Ch()
        {
            var items = Enumerable.Range(0, 15)
                .Select(i => new ItemData(Chinese[i], Chinese[i]))
                .ToArray();
            Language.text = Swich_Ch.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
        }
        public void SW_En()
        {
            var items = Enumerable.Range(0, 11)
                .Select(i => new ItemData(English[i], English[i]))
                .ToArray();
            Language.text = Swich_En.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
        }
        public void SW_Jp()
        {
            var items = Enumerable.Range(0, 10)
                .Select(i => new ItemData(Janpan[i], Janpan[i]))
                .ToArray();
            Language.text = Swich_Jp.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
        }
        public void SW_Kr()
        {
            var items = Enumerable.Range(0, 10)
                .Select(i => new ItemData(Korean[i], Korean[i]))
                .ToArray();
            Language.text = Swich_Kr.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
        }
        public void SW_ALL()
        {
            var items = Enumerable.Range(0, 46)
                .Select(i => new ItemData(name[i], name[i]))
                .ToArray();
            Language.text = Swich_ALL.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
        }
    }
}
