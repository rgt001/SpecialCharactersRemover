using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    public static class SpecialCharacters
    {
        private static HashSet<int> specialCharacters;
        private static Regex pattern;

        static SpecialCharacters()
        {
            specialCharacters = new HashSet<int>();

            // Adiciona os códigos decimais dos caracteres especiais à HashSet
            int i;
            for (i = 0; i <= 31; i++)
            {
                specialCharacters.Add(i);
            }
            i++;
            for (; i <= 47; i++)
            {
                specialCharacters.Add(i);
            }
            for (i = 58; i <= 64; i++)
            {
                specialCharacters.Add(i);
            }

            // Caracteres especiais adicionais
            specialCharacters.Add(91); // [
            specialCharacters.Add(92); // \
            specialCharacters.Add(93); // ]
            specialCharacters.Add(94); // ^
            specialCharacters.Add(95); // _
            specialCharacters.Add(96); // `
            specialCharacters.Add(123); // {
            specialCharacters.Add(124); // {
            specialCharacters.Add(125); // {
            specialCharacters.Add(126); // {
            specialCharacters.Add(127); // Del
            specialCharacters.Add(128); // Ç
            specialCharacters.Add(129); // ü
            specialCharacters.Add(130); // é
            specialCharacters.Add(131); // â
            specialCharacters.Add(132); // ä
            specialCharacters.Add(133); // à
            specialCharacters.Add(134); // å
            specialCharacters.Add(135); // ç
            specialCharacters.Add(136); // ê
            specialCharacters.Add(137); // ë
            specialCharacters.Add(138); // è
            specialCharacters.Add(139); // ï
            specialCharacters.Add(140); // î
            specialCharacters.Add(141); // ì
            specialCharacters.Add(142); // Ä
            specialCharacters.Add(143); // Å
            specialCharacters.Add(144); // É
            specialCharacters.Add(145); // æ
            specialCharacters.Add(146); // Æ
            specialCharacters.Add(147); // ô
            specialCharacters.Add(148); // ö
            specialCharacters.Add(149); // ò
            specialCharacters.Add(150); // û
            specialCharacters.Add(151); // ù
            specialCharacters.Add(152); // ÿ
            specialCharacters.Add(153); // Ö
            specialCharacters.Add(154); // Ü
            specialCharacters.Add(155); // ø
            specialCharacters.Add(156); // £
            specialCharacters.Add(157); // Ø
            specialCharacters.Add(158); // ×
            specialCharacters.Add(159); // ƒ
            specialCharacters.Add(160); // á
            specialCharacters.Add(161); // í
            specialCharacters.Add(162); // ó
            specialCharacters.Add(163); // ú
            specialCharacters.Add(164); // ñ
            specialCharacters.Add(165); // Ñ
            specialCharacters.Add(166); // ª
            specialCharacters.Add(167); // º
            specialCharacters.Add(168); // ¿
            specialCharacters.Add(169); // ®
            specialCharacters.Add(170); // ¬
            specialCharacters.Add(171); // ½
            specialCharacters.Add(172); // ¼
            specialCharacters.Add(173); // ¡
            specialCharacters.Add(174); // «
            specialCharacters.Add(175); // »
            specialCharacters.Add(176); // ░
            specialCharacters.Add(177); // ▒
            specialCharacters.Add(178); // ▓
            specialCharacters.Add(179); // │
            specialCharacters.Add(180); // ┤
            specialCharacters.Add(181); // Á
            specialCharacters.Add(182); // Â
            specialCharacters.Add(183); // À
            specialCharacters.Add(184); // ©
            specialCharacters.Add(185); // ╣
            specialCharacters.Add(186); // ║
            specialCharacters.Add(187); // ╗
            specialCharacters.Add(188); // ╝
            specialCharacters.Add(189); // ¢
            specialCharacters.Add(190); // ¥
            specialCharacters.Add(191); // ┐
            specialCharacters.Add(192); // └
            specialCharacters.Add(193); // ┴
            specialCharacters.Add(194); // ┬
            specialCharacters.Add(195); // ├
            specialCharacters.Add(196); // ─
            specialCharacters.Add(197); // ┼
            specialCharacters.Add(198); // ã
            specialCharacters.Add(199); // Ã
            specialCharacters.Add(200); // ╚
            specialCharacters.Add(201); // ╔
            specialCharacters.Add(202); // ╩
            specialCharacters.Add(203); // ╦
            specialCharacters.Add(204); // ╠
            specialCharacters.Add(205); // ═
            specialCharacters.Add(206); // ╬
            specialCharacters.Add(207); // €
            specialCharacters.Add(208); // æ
            specialCharacters.Add(209); // Æ
            specialCharacters.Add(210); // ô
            specialCharacters.Add(211); // ö
            specialCharacters.Add(212); // ò
            specialCharacters.Add(213); // û
            specialCharacters.Add(214); // ù
            specialCharacters.Add(215); // ÿ
            specialCharacters.Add(216); // Ö
            specialCharacters.Add(217); // Ü
            specialCharacters.Add(218); // ¢
            specialCharacters.Add(219); // £
            specialCharacters.Add(220); // ¥
            specialCharacters.Add(221); // ₧
            specialCharacters.Add(222); // ƒ
            specialCharacters.Add(223); // á
            specialCharacters.Add(224); // í
            specialCharacters.Add(225); // ó
            specialCharacters.Add(226); // ú
            specialCharacters.Add(227); // ñ
            specialCharacters.Add(228); // Ñ
            specialCharacters.Add(229); // ª
            specialCharacters.Add(230); // º
            specialCharacters.Add(231); // ¿
            specialCharacters.Add(232); // ¬
            specialCharacters.Add(233); // ½
            specialCharacters.Add(234); // ¼
            specialCharacters.Add(235); // ¡
            specialCharacters.Add(236); // «
            specialCharacters.Add(237); // »
            specialCharacters.Add(238); // ░
            specialCharacters.Add(239); // ▒
            specialCharacters.Add(240); // ▓
            specialCharacters.Add(241); // │
            specialCharacters.Add(242); // ┤
            specialCharacters.Add(243); // Á
            specialCharacters.Add(244); // Â
            specialCharacters.Add(245); // À
            specialCharacters.Add(246); // ©
            specialCharacters.Add(247); // ╣
            specialCharacters.Add(248); // ║
            specialCharacters.Add(249); // ╗
            specialCharacters.Add(250); // ╝
            specialCharacters.Add(251); // ¢
            specialCharacters.Add(252); // ¥
            specialCharacters.Add(253); // ┐
            specialCharacters.Add(254); // └
            specialCharacters.Add(255); // ┴

            string regex = "[^a-z0-9\\u0600-\\u06ff\\s]";
            pattern = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        public static string RemoveSpecialCharacters3(string input)
        {
            char[] resultCharacters = new char[input.Length];
            int currentChar = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!specialCharacters.Contains((int)input[i]))
                {
                    resultCharacters[currentChar++] = input[i];
                }
            }

            return new string(resultCharacters);
        }

        public static string RemoveSpecialCharacters2(string input)
        {
            return pattern.Replace(input, string.Empty);
        }

        /// <summary>
        /// This method was created by Mehdi Golzari(https://www.linkedin.com/in/mehdigolzariofficial/)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string input)
        {
            string pattern = @"[^a-zA-Z0-9\u0600-\u06ff\s]";

            string cleanedString = Regex.Replace(input, pattern, string.Empty);

            return cleanedString;
        }
    }
}
