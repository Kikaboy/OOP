using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQHW
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public Tuple<string, int>[] GetMostFrequentWords(string text, int count)
        {
            text = ("Разнообразный и богатый опыт рамки и место обучения кадров требует определения и уточнения соответствующих условий активизации! Не следует, однако, забывать о том, что выбранный нами инновационный путь позволяет выполнить важнейшие задания по разработке экономической целесообразности принимаемых решений.");
            return text.ToLower().Split(' ', ',', '.','!','?')
                .GroupBy(g => g)
                .Select(s => new Tuple<string, int>(s.Key, s.Count()))
                .OrderByDescending(b => b.Item2)
                .ThenBy(t => t.Item1)
                .Take(count)
                .ToArray();

        }
        public struct Record
        {
            public int ClientID;
            public int Year;
            public int Month;
            public int Duration;
        }
        static void PrintNumberTimeSpentPerYear(int duration, List<Record> db)
        { 
            var lines = db.Where(r => r.Duration == duration)
                .GroupBy(r => r.Duration)
                .Select(g => (g.Key, g.GroupBy(r => r.Year).Count()))
                .OrderBy(x => x.Key);
            if (lines.Count() > 0) 
            { 
                foreach (var line in lines) Console.Write($"В{line.Key}году. Времени проведено:  {line.Item2}");
            } 
            else Console.Write($"Нет данных."); 
        }
    }
}
