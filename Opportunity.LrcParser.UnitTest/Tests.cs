using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Opportunity.LrcParser.UnitTest
{
    [TestClass]
    public class Tests
    {
        public const string TEST_DATA = @"
asdfhf
[ ti :  eternal reality  ]aSAS
ASF[
ar :  
fripside   
   ]  SAF
[al:eternal reality]
[by:ShenzhiV战斗]
[offset: +1.1]
[12234:02.16]  [00:02.16]             
  輝く希望が この街を駆け抜けるから
〖闪耀的希望 在这座城市之中游走奔驰〗
[00:08.71]いつだって 信じ合える仲間と 手を繋ぎながら
〖无论在何时 都与相互信任的伙伴们 紧系著双手〗
[00:15.20]心のまま 信じる明日を探し続けてる
〖随着本心 继续寻找著所坚信的明天〗

[00:00.00][00:21.96]
[00:23.54]立ち尽くす 雑踏のなか 远ざかる君を見つめてた
〖伫立於熙熙攘攘的人群 目睹着你的背影渐行渐远〗
[00:30.19]分かち合う その大切さ 今は理解っているから
〖同甘共苦直到如今才能理解是多麼的弥足珍贵〗
[00:36.68]
[00:36.80]いくつもの笑顔が 今日も彩って〖无数地欢笑喜悦 仍将今日点缀的炫彩斑斓〗
[00:43.09]みんなを包み込む そんな当たり前を守りたい〖只想将这理所当然地快乐日常守护到底〗
[00:51.36]
[00:51.49]動き出す夢を この空に響かせたら〖悸动的梦想 响彻於这片广阔的天空〗
[00:58.24]摇るぎない能力(チカラ) 現実を捉えてゆく〖藉由无法动摇的力量 紧紧把握住现实〗
[01:04.87]弱さ打ち明ける そんな強さを持てたから〖只因有着敢于承认软弱的 这种坚强〗
[01:11.55]いつの日も忘れないよ この絆だけ抱きしめて〖这份羁绊必将牢牢守护 永远铭刻於心〗
[01:18.07]胸を張って 誇れる未來を撃ち贯いていく〖挺起胸膛 击穿这值得夸耀的未来〗
[01:24.86]
[01:26.29]一人きり 心閉ざして いくつかの闇を超えてきた〖独自一人 封闭著内心 跨越过无数的黑夜〗
[01:33.06]いつからか 気づされてだ 一人じゃないその强さを〖是从何时起 才察觉到 自己渴望著与伙伴同在的那种坚强〗
[01:39.53]
[01:39.65]思い出す 初めて君と逢った日を〖回忆起当时 与你相遇的那一天〗
[01:46.42]あれから たくさんの お互いの気持ちを交わした〖从那之后 经历过了无数次的心灵契合〗
[01:54.37]
[01:54.51]手にした煌めき この世界照らしていく〖射出手中的闪耀光辉 照亮整个世界〗
[02:01.05]重なる想いが 私を导いている〖交错重叠的思念 无时无刻不在引导著我〗
[02:07.86]大好きな君の その夢を守りたいから〖最喜欢的你的那份梦想 我都想要守护〗
[02:14.50]いつだって 信じて合える仲間と 心繋いでる〖无论在何时 都与相互信任的伙伴们 连系著心灵〗
[02:21.04]私らしく 真っ直ぐな愿いを贯いていく〖以自我的风格 直情径行地贯穿这份心愿〗
[02:27.68]
[02:27.85]foo...We can accept reality〖foo…我们可以直面真实〗
[02:36.43]I'll link the personal wall for me and you〖我将会与你的心紧密相连〗
[02:41.21]
[02:42.00]「eternal reality」
[02:44.00]作詞∶八木沼悟志／作曲：小室哲哉＆八木沼悟志／編曲：八木沼悟志
[02:48.00]翻訳：奈亚拉托提普／潤色：ShenzhiV战斗／^_^ 动漫音乐歌詞吧／萌愛歌詞組
[02:51.00]歌：fripSide
[02:54.00]「某科学的超电磁炮S」OP2
[02:56.50]
[02:57.58]君の優しいを〖你的那份温柔〗
[03:00.56](The feeling dive into my heart)〖(无比直接地抵达於我的内心之中)〗
[03:04.23]いつも感じてる〖每时每刻都能感觉到〗
[03:07.23](So, I continue eternal reality)〖(所以，我将延续这永恒的真实)〗
[03:10.51]
[03:10.66]動き出す夢を この空に嚮かせたら〖悸动的梦想 响彻於这片广阔的天空〗
[03:17.33]摇るぎない能力(チカラ) 现実を捉えてゆく〖藉由无法动摇的力量 紧紧把握住现实〗
[03:23.94]辉く希望が この街を駆け抜けるから〖闪耀的希望 在这座城市之中游走奔驰〗
[03:30.61]いつだって 信じ合える仲間と 手を繋ぎながら〖无论在何时 都与相互信任的伙伴们 紧系著双手〗
[03:37.10]心のまま 信じる明日を探し続けてる〖随着本心 继续寻找著所坚信的明天〗
[03:43.89]
[03:45.00]★→Lrc By ShenzhiV战斗 ※ 萌愛歌詞組←☆
[03:50.00]終わり
[03:52.00]
";

        [TestMethod]
        public void TestAll()
        {
            var l = Lyrics.Parse(TEST_DATA);
            Assert.AreEqual(53, l.Lines.Count);
            foreach (var item in l.Lines)
            {
                Assert.IsNotNull(item.Content);
            }
            Assert.AreEqual(5, l.MetaData.Count, $"Metadata keys: {string.Join(", ", l.MetaData.Keys)}");
            Assert.AreEqual("eternal reality", l.MetaData.Title, "Wrong Title");
            Assert.AreEqual("fripside", l.MetaData.Artist, "Wrong Artist");
            Assert.AreEqual("eternal reality", l.MetaData.Album, "Wrong Album");
            Assert.AreEqual("ShenzhiV战斗", l.MetaData.Creator, "Wrong Creator");
            Assert.AreEqual(new TimeSpan(11000), l.MetaData.Offset, "Wrong Offset");
        }

        [TestMethod]
        public void Parse10000Times()
        {
            for (var i = 0; i < 10000; i++)
            {
                Lyrics.Parse(TEST_DATA);
            }
        }

        [TestMethod]
        public void Stringify10000Times()
        {
            var l = Lyrics.Parse(TEST_DATA);
            for (var i = 0; i < 10000; i++)
            {
                l.ToString();
            }
        }
    }
}
