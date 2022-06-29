using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LangResolver : MonoBehaviour
{
    private const char Separator = '=';

    private static readonly Dictionary<SystemLanguage, LangData> _langData = new Dictionary<SystemLanguage, LangData>();
    private static readonly List<SystemLanguage> _supportedLanguages = new List<SystemLanguage>();

    public static SystemLanguage _language;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        ReadProperties();
        ResolveTexts();

    }

    private void ReadProperties()
    {
        foreach (var file in Resources.LoadAll<TextAsset>("LangFiles"))
        {
            Enum.TryParse(file.name, out SystemLanguage language);
            var lang = new Dictionary<string, string>();
            foreach (var line in file.text.Split('\n'))
            {
                var prop = line.Split(Separator);
                lang[prop[0]] = prop[1];
            }

            _langData[language] = new LangData(lang);
            _supportedLanguages.Add(language);
        }

        ResolveLanguage();
    }

    private void ResolveLanguage()
    {
        _language = PrefsHolder.GetLang();
        if (!_supportedLanguages.Contains(_language))
        {
            _language = SystemLanguage.English;
        }
    }

    public static void ResolveTexts()
    {
        var lang = _langData[_language].Lang;
        foreach (var langText in Resources.FindObjectsOfTypeAll<LangText>())
        {
            langText.ChangeText(lang[langText.Identifier]);
        }
    }

    public static void ChangeToEnglish()
    {
        var currentLanguageIndex = _supportedLanguages.IndexOf(_language);
        _language = SystemLanguage.English;

        ResolveTexts();
        PrefsHolder.SaveLang(_language);
    }

    public static void ChangeToPortuguese()
    {
        var currentLanguageIndex = _supportedLanguages.IndexOf(_language);
        _language = SystemLanguage.Portuguese;

        ResolveTexts();
        PrefsHolder.SaveLang(_language);
    }

    private class LangData
    {
        public readonly Dictionary<string, string> Lang;

        public LangData(Dictionary<string, string> lang)
        {
            Lang = lang;
        }
    }

    public static string loadText(string chave)
    {
        var lang = _langData[_language].Lang;
        return lang[chave];
        
    }


}