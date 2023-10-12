using System.Collections.Generic;
using System;

namespace GSG
{
    public static class i18n
    {
        public enum i18nLanguage
        {
            EN,     // (English): English
            ES,     // (Spanish): Español
            FR,     // (French): Français
            JP,     // (Japanese): 日本語(Nihongo)
            KO,     // (Korean) : 한국어(Hangugeo)
            RU,     // (Russian) : Русский(Russkiy)
            TR,     // (Turkish) : Türkçe
            ZH,     // (Chinese) : 中文, (Zhōngwén)
        }

        public Dictionary<string, string> menu = new Dictionary<string, string>();
    }
}