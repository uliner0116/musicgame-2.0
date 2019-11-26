using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

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
        [SerializeField] Button Mask = default;
        [SerializeField] Text Language = default;
        public GameObject page;

        public AudioSource audioBgm;
        string songName;
        int listNumber = 0;
        bool Chdown = false;
        bool Endown = false;
        bool Jpdown = false;
        bool Krdown = false;
        bool ALLdown = true;
        float playTime = 0;
        float endTime = 0;

        string[] name = { "butterfly" ,"Don't say lazy" ,"Im sorry" ,"LATATA" ,"LOVE" ,"Mirotic" ,"Oh!" ,"One Night In 北京" ,"PON PON PON" ,"Roly Poly" ,"SORRY SORRY" ,"Trouble Maker" ,"Tunak Tunak Tun" ,
        "YES or YES" ,"三國戀" ,"千年之戀" ,"不得不愛" ,"月牙灣" ,"回レ! 雪月花" ,"我不配" ,"我還年輕 我還年輕" ,"牡丹江" ,"東區東區" ,"直感" ,"星空" ,"夏祭り" ,"恋は渾沌の隷也" ,
        "恋愛サーキュレーション" ,"夠愛" ,"將軍令" ,"華陽炎" ,"極楽浄土" ,"憂愁" ,"憨人" ,"樹枝孤鳥" ,"恋" ,"Burn It Down","Counting Stars","Good Time","I Really Like You","Maps","One More Night",
        "Poker Face","Thunder","What Ive Done","What Makes You Beautiful"
        };
        float[] chorusTime = { 55, 75, 35, 41, 39, 34, 42, 44, 75.8F, 59, 59, 22, 46, 56, 69, 40, 84, 56, 58, 70, 121, 54, 56, 43, 59, 58, 67, 57, 81, 64, 47, 60, 64, 51, 98, 49, 50, 53, 48, 33, 38, 46, 43, 33, 43, 30 };
        float[] chorusEndTime = { 80,96,80,71,78,63,76,90,105,76,88,56,74,88,96,75,107,107,82,111,154,85,77,78,83,77,87,72,111,85,70,74,95,84,110,75,71,88,68,65,72,66,60,51,62,66};
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
            Mask.onClick.AddListener(mask);
            scrollView.OnSelectionChanged(OnSelectionChanged);
            
            var items = Enumerable.Range(0,46)
                .Select(i => new ItemData(name[i], name[i]))
                .ToArray();
            
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
           // audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/song001");
           // audioBgm.Play(30);
          //  audioBgm.volume = 0.5f;
        }
        void OnSelectionChanged(int index)
        {
            
            if(Chdown == true)
            {
                songName = Chinese[index];
            }
            else if (Endown == true)
            {
                songName = English[index];
            }
            else if (Jpdown == true)
            {
                songName = Janpan[index];
            }
            else if (Krdown == true)
            {
                songName = Korean[index];
            }
            else if (ALLdown == true)
            {
                songName = name[index];
            }
            

            for (int i = 1; i <= name.Length; i++)
            {
                if (string.Compare(name[i - 1], songName) == 0)
                {
                    listNumber = i;
                    playTime = chorusTime[listNumber-1];
                    endTime = chorusEndTime[listNumber - 1];
                    songName = "song" + listNumber.ToString("D3");
                    Debug.Log("songName: " + songName);
                    Debug.Log("playTime: " + playTime);
                    break;
                }
            }
            audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/" + songName);
            audioBgm.time = 0F;
            audioBgm.PlayDelayed(1F);
            audioBgm.time = playTime;
        }
        private void Update()
        {
            if(audioBgm.time >= endTime || audioBgm.time >= audioBgm.clip.length)
            {
                audioBgm.PlayDelayed(1.5F);
                audioBgm.time = playTime;
            }
        }
        public void Active_Text()
        {
            if (!page.activeInHierarchy)
            { page.SetActive(true); }
            else
            { page.SetActive(false); }
        }
        public void mask()
        {
            page.SetActive(false);
        }
        public void SW_Ch()
        {
            Thread.Sleep(500);
            var items = Enumerable.Range(0, 15)
                .Select(i => new ItemData(Chinese[i], Chinese[i]))
                .ToArray();
            Language.text = Swich_Ch.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
            Chdown = true;
            Endown = false;
            Jpdown = false;
            Krdown = false;
            ALLdown =false;
            audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/song008" );
            audioBgm.time = 0F;
            audioBgm.PlayDelayed(1.5F);
            playTime = 44;
            endTime = 90;
            audioBgm.time = playTime;
            audioBgm.volume = 0.5f;
        }
        public void SW_En()
        {
            Thread.Sleep(500);
            var items = Enumerable.Range(0, 11)
                .Select(i => new ItemData(English[i], English[i]))
                .ToArray();
            Language.text = Swich_En.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
            Endown = true;
            Chdown = false;
            Jpdown = false;
            Krdown = false;
            ALLdown =false;
            audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/song037" );
            audioBgm.time = 0F;
            audioBgm.PlayDelayed(1F);
            playTime = 50;
            endTime = 71;
            audioBgm.time = playTime;
            audioBgm.volume = 0.5f;
        }
        public void SW_Jp()
        {
            Thread.Sleep(500);
            var items = Enumerable.Range(0, 10)
                .Select(i => new ItemData(Janpan[i], Janpan[i]))
                .ToArray();
            Language.text = Swich_Jp.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
            Jpdown = true;
            Endown = false;
            Chdown = false;
            Krdown = false;
            ALLdown = false;
            audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/song001");
            audioBgm.time = 0F;
            audioBgm.PlayDelayed(1F);
            playTime = 55;
            endTime = 80;
            audioBgm.time = playTime;
            audioBgm.volume = 0.5f;
        }
        public void SW_Kr()
        {
            Thread.Sleep(500);

            var items = Enumerable.Range(0, 10)
                .Select(i => new ItemData(Korean[i], Korean[i]))
                .ToArray();
            Language.text = Swich_Kr.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
            Krdown = true;
            Endown = false;
            Chdown = false;
            Jpdown = false;
            ALLdown = false;
            audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/song003");
            audioBgm.time = 0F;
            audioBgm.PlayDelayed(1F);
            playTime = 35;
            endTime = 80;
            audioBgm.time = playTime;
            audioBgm.volume = 0.5f;
        }
        public void SW_ALL()
        {
            Thread.Sleep(500);
            var items = Enumerable.Range(0, 46)
                .Select(i => new ItemData(name[i], name[i]))
                .ToArray();
            Language.text = Swich_ALL.name;
            scrollView.UpdateData(items);
            scrollView.SelectCell(0);
            page.SetActive(false);
            ALLdown = true;
            Endown = false;
            Chdown = false;
            Jpdown = false;
            Krdown = false;
            audioBgm.clip = Resources.Load<AudioClip>("Audios/cAudio/song001");
            audioBgm.time = 0F;
            audioBgm.PlayDelayed(1F);
            playTime = 55;
            endTime = 80;
            audioBgm.time = playTime;
            audioBgm.volume = 0.5f;
        }
    }
}
