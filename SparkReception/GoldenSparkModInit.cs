using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GoldenSparkMod.Passive_Effects;
using HarmonyLib;
using LOR_DiceSystem;
using LOR_XML;
using Mod;
using TMPro;
using UI;
using UnityEngine;
using Workshop;
using System.Xml.Serialization;



namespace GoldenSparkMod
{
    class GoldenSparkModInit : ModInitializer
    {
		public override void OnInitializeMod()
		{
			Harmony harmony = new Harmony("LOR.GoldenSparkReception_MOD");
			MethodInfo method = typeof(GoldenSparkModInit).GetMethod("BookModel_SetXmlInfo");
			harmony.Patch(typeof(BookModel).GetMethod("SetXmlInfo", AccessTools.all), null, new HarmonyMethod(method), null, null, null);
			GoldenSparkModInit.path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
			GoldenSparkModInit.GetArtWorks(new DirectoryInfo(GoldenSparkModInit.path + "/ArtWork"));
			GoldenSparkModInit.RemoveError();
			method = typeof(GoldenSparkModInit).GetMethod("UISpriteDataManager_GetStoryIcon");
			harmony.Patch(typeof(UISpriteDataManager).GetMethod("GetStoryIcon", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
			method = typeof(GoldenSparkModInit).GetMethod("BattleUnitView_ChangeSkin");
			harmony.Patch(typeof(BattleUnitView).GetMethod("ChangeSkin", AccessTools.all), null, new HarmonyMethod(method), null, null, null);
			method = typeof(GoldenSparkModInit).GetMethod("BookModel_CanSuccessionPassive");
			harmony.Patch(typeof(BookModel).GetMethod("CanSuccessionPassive"), null, new HarmonyMethod(method), null, null, null);
			//Patch for Buff names.
			var dict = typeof(BattleEffectTextsXmlList).GetField("_dictionary", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(BattleEffectTextsXmlList.Instance) as Dictionary<string, BattleEffectText>;
			dict["Electrified"] = new BattleEffectText()
			{
				ID = "Electrified",
				Name = "Electrify",
				Desc = "For the Scene, up to {0} dice have their maximum roll value increased by 3 when using pages."
			};
			var dict1 = typeof(BattleEffectTextsXmlList).GetField("_dictionary", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(BattleEffectTextsXmlList.Instance) as Dictionary<string, BattleEffectText>;
			dict1["Golden_Spark"] = new BattleEffectText()
			{
				ID = "Golden_Spark",
				Name = "Speed of Light",
				Desc = "Immobilize half of the enemies (rounded up) every 5 scenes. Increase the maximum roll amount of all dice by {0}. Upon losing 3 or more clashes per scene, take 25 Stagger damage."
			};

			//Localize stuff:
			if (typeof(BattleCardAbilityDescXmlList).GetField("_dictionaryKeywordCache", AccessTools.all)
						?.GetValue(BattleCardAbilityDescXmlList.Instance) is Dictionary<string, List<string>>
					dictionary)
				Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(DiceCardSelfAbilityBase))
											   && x.Name.StartsWith("DiceCardSelfAbility_"))
					.Do(x => dictionary[x.Name.Replace("DiceCardSelfAbility_", "")] =
						new List<string>(((DiceCardSelfAbilityBase)Activator.CreateInstance(x)).Keywords));

			AddLocalize();
		}
		public static void AddLocalize()
		{
			System.IO.FileInfo[] files;
			try
			{
				var dictionary =
					typeof(BattleEffectTextsXmlList).GetField("_dictionary", AccessTools.all)
							?.GetValue(Singleton<BattleEffectTextsXmlList>.Instance) as
						Dictionary<string, BattleEffectText>;
				files = new DirectoryInfo(GoldenSparkModInit.path + "/Localize/" + "en" + "/EffectTexts").GetFiles();
				foreach (var t in files)
					using (var stringReader = new StringReader(File.ReadAllText(t.FullName)))
					{
						var battleEffectTextRoot =
							(BattleEffectTextRoot)new XmlSerializer(typeof(BattleEffectTextRoot))
								.Deserialize(stringReader);
						foreach (var battleEffectText in battleEffectTextRoot.effectTextList)
						{
							dictionary.Remove(battleEffectText.ID);
							dictionary?.Add(battleEffectText.ID, battleEffectText);

						}
					}
			}
			catch (Exception e)
			{
				Debug.LogError(e);
			}
		}

		public static void GetArtWorks(DirectoryInfo dir)
		{
			bool flag = dir.GetDirectories().Length != 0;
			if (flag)
			{
				DirectoryInfo[] directories = dir.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					GoldenSparkModInit.GetArtWorks(directories[i]);
				}
			}
			foreach (System.IO.FileInfo fileInfo in dir.GetFiles())
			{
				Texture2D texture2D = new Texture2D(2, 2);
				texture2D.LoadImage(File.ReadAllBytes(fileInfo.FullName));
				Sprite value = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0f, 0f));
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
				GoldenSparkModInit.ArtWorks[fileNameWithoutExtension] = value;
			}
		}

		public static void RemoveError()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			list.Add("0Harmony");
			list.Add("NAudio");
			using (List<string>.Enumerator enumerator = Singleton<ModContentManager>.Instance.GetErrorLogs().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string errorLog = enumerator.Current;
					bool flag = list.Exists((string x) => errorLog.Contains(x));
					if (flag)
					{
						list2.Add(errorLog);
					}
				}
			}
			foreach (string item in list2)
			{
				Singleton<ModContentManager>.Instance.GetErrorLogs().Remove(item);
			}
		}

		public static void BookModel_SetXmlInfo(BookModel __instance, BookXmlInfo ____classInfo, ref List<DiceCardXmlInfo> ____onlyCards)
		{
			bool flag = __instance.BookId.packageId == GoldenSparkModInit.packageId;
			if (flag)
			{
				____onlyCards.AddRange(from id in ____classInfo.EquipEffect.OnlyCard
									   select ItemXmlDataList.instance.GetCardItem(new LorId(GoldenSparkModInit.packageId, id), false));
			}
		}

		public static void BattleAbDialog(MonoBehaviour instance, List<AbnormalityCardDialog> dialogs)
		{
			CanvasGroup component = instance.GetComponent<CanvasGroup>();
			string dialog = dialogs[UnityEngine.Random.Range(0, dialogs.Count)].dialog;
			FieldInfo field = typeof(BattleDialogUI).GetField("_txtAbnormalityDlg", AccessTools.all);
			TextMeshProUGUI textMeshProUGUI = (TextMeshProUGUI)((field != null) ? field.GetValue(instance) : null);
			textMeshProUGUI.text = dialog;
			textMeshProUGUI.fontMaterial.SetColor("_GlowColor", SingletonBehavior<BattleManagerUI>.Instance.negativeCoinColor);
			textMeshProUGUI.color = SingletonBehavior<BattleManagerUI>.Instance.negativeTextColor;
			FieldInfo field2 = typeof(BattleDialogUI).GetField("_canvas", AccessTools.all);
			((Canvas)((field2 != null) ? field2.GetValue(instance) : null)).enabled = true;
			component.interactable = true;
			component.blocksRaycasts = true;
			textMeshProUGUI.GetComponent<AbnormalityDlgEffect>().Init();
			FieldInfo field3 = typeof(BattleDialogUI).GetField("_routine", AccessTools.all);
			Coroutine coroutine = (Coroutine)((field3 != null) ? field3.GetValue(instance) : null);
			MethodInfo method = typeof(BattleDialogUI).GetMethod("AbnormalityDlgRoutine", AccessTools.all);
			instance.StartCoroutine(method.Invoke(instance, new object[0]) as IEnumerator);
		}

		public static bool UISpriteDataManager_GetStoryIcon(UISpriteDataManager __instance, ref UIIconManager.IconSet __result, string story)
		{
			bool flag = !GoldenSparkModInit.ArtWorks.ContainsKey(story);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				__result = new UIIconManager.IconSet
				{
					type = story,
					icon = GoldenSparkModInit.ArtWorks[story],
					iconGlow = GoldenSparkModInit.ArtWorks[story]
				};
				result = false;
			}
			return result;
		}

		public static void BattleUnitView_ChangeSkin(BattleUnitView __instance, string charName)
		{
			WorkshopSkinData workshopBookSkinData = Singleton<CustomizingBookSkinLoader>.Instance.GetWorkshopBookSkinData("GoldenSparkReception", charName);
			bool flag = workshopBookSkinData != null;
			if (flag)
			{
				Dictionary<ActionDetail, ClothCustomizeData> dic = __instance.charAppearance.gameObject.GetComponent<WorkshopSkinDataSetter>().dic;
				bool flag2 = dic == null || dic.Count == 0;
				if (flag2)
				{
					__instance.charAppearance.gameObject.GetComponent<WorkshopSkinDataSetter>().SetData(workshopBookSkinData);
				}
			}
		}

		// Passive Attribution Exclusivity
		public static void BookModel_CanSuccessionPassive(BookModel __instance, PassiveModel targetpassive, ref GivePassiveState haspassiveState, ref bool __result)
        {
			Debug.Log("PASSIVE SCRIPT IS " + targetpassive.originpassive.script);
			if (_armors.Contains(targetpassive.originpassive.script) && __instance.BookId != new LorId("GoldenSparkReception", 10000001))
            {
				haspassiveState = GivePassiveState.Lock;
				__result = false;
            }
        }

		public static string path;

		public static string packageId = "GoldenSparkReception";

		public static Dictionary<string, Sprite> ArtWorks = new Dictionary<string, Sprite>();

		//public static Dictionary<string, AudioClip> CustomSound;

		private static List<string> _armors = new List<string> { "Kingmaker" };
	}
}
