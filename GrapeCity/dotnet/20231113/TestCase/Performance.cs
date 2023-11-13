namespace GrapeCity.DataVisualization.Console
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.Json;

    internal class Performance
    {
        public static readonly Performance Builder = new Performance();

        internal void DAT_3846(string path, int count)
        {
            JObject jsonObj = new JObject();

            jsonObj.Add("name", "sample");
            jsonObj.Add("dateFormats", false);

            JArray valuesArray = new JArray();
            for (int i = 1; i <= count; i++)
            {
                JObject valueObj = new JObject();
                valueObj.Add("Y", "C" + i);
                valueObj.Add("X", i);

                valuesArray.Add(valueObj);
            }
            jsonObj.Add("values", valuesArray);

            //Console.WriteLine(JsonConvert.SerializeObject(jsonObj, Formatting.Indented));

            File.WriteAllText(path, JsonConvert.SerializeObject(jsonObj, Formatting.None));
        }

        internal void GenerateRandomNumber(string path, int count)
        {
            Random randomMin = new Random();
            Random randomMax = new Random();

            JObject jsonObj = new JObject();

            jsonObj.Add("name", "sample");
            jsonObj.Add("dateFormats", false);

            JArray valuesArray = new JArray();
            for (int i = 1; i <= count; i++)
            {
                JObject valueObj = new JObject();
                valueObj.Add("X", this.RandomDouble(randomMin, 1.00, 50.00, 2));
                valueObj.Add("Y", this.RandomDouble(randomMax, 1.00, 100.00, 2));

                valuesArray.Add(valueObj);
            }
            jsonObj.Add("values", valuesArray);

            //Console.WriteLine(JsonConvert.SerializeObject(jsonObj, Formatting.Indented));

            File.WriteAllText(path, JsonConvert.SerializeObject(jsonObj, Formatting.None));
        }

        public double RandomDouble(Random ran, double minValue, double maxValue, int decimalPlace)
        {
            double randNum = ran.NextDouble() * (maxValue - minValue) + minValue;
            return Convert.ToDouble(randNum.ToString("f" + decimalPlace));
        }

        internal void DAT_4035(string path, int count)
        {
            var json = new
            {
                name = "sample",
                dateFormats = false,
                values = GenerateValues_4035(count)
            };

            File.WriteAllText(path, System.Text.Json.JsonSerializer.Serialize(json));
        }

        static List<object> GenerateValues_4035(int count)
        {
            var values = new List<object>();

            for (int i = 0; i < count; i++)
            {
                var detail1 = $"C{i}";
                var detail2 = $"S100";
                var value = i;
                var obj = new
                {
                    detail1,
                    detail2,
                    value
                };
                values.Add(obj);

                detail1 = $"C{i}";
                detail2 = $"S101";
                value = i + 1;
                obj = new
                {
                    detail1,
                    detail2,
                    value
                };
                values.Add(obj);

                detail1 = $"C{i}";
                detail2 = $"S102";
                value = i + 2;
                obj = new
                {
                    detail1,
                    detail2,
                    value
                };
                values.Add(obj);
            }

            return values;
        }

        internal void DAT_4036(string path, int count)
        {
            var json = new
            {
                name = "sample",
                dateFormats = false,
                values = GenerateValues_4036(count)
            };

            File.WriteAllText(path, System.Text.Json.JsonSerializer.Serialize(json));
        }

        static List<object> GenerateValues_4036(int count)
        {
            var values = new List<object>();

            for (int i = 0; i < count; i++)
            {
                var category = $"C{i}";
                var series = $"S12";
                var value = i;
                var obj = new
                {
                    category,
                    series,
                    value
                };
                values.Add(obj);

                category = $"C{i}";
                series = $"S13";
                value = i + 1;
                obj = new
                {
                    category,
                    series,
                    value
                };
                values.Add(obj);

                category = $"C{i}";
                series = $"S14";
                value = i + 2;
                obj = new
                {
                    category,
                    series,
                    value
                };
                values.Add(obj);
            }

            return values;
        }

        internal void DAT_4036Rose(string path, int count)
        {
            var json = new
            {
                name = "sample",
                dateFormats = false,
                values = GenerateValues_4036Rose(count)
            };

            File.WriteAllText(path, System.Text.Json.JsonSerializer.Serialize(json));
        }

        static List<object> GenerateValues_4036Rose(int count)
        {
            var values = new List<object>();

            for (int i = 0; i < count; i++)
            {
                var series = $"C{i}";
                var value = i;
                var obj = new
                {
                    series,
                    value
                };
                values.Add(obj);
            }

            return values;
        }

        internal void DAT_4036Bubble(string path, int count)
        {
            var json = new
            {
                name = "sample",
                dateFormats = false,
                values = GenerateValues_4036Bubble(count)
            };

            File.WriteAllText(path, System.Text.Json.JsonSerializer.Serialize(json));
        }

        static List<object> GenerateValues_4036Bubble(int count)
        {
            var values = new List<object>();
            var xCount = Math.Ceiling(Math.Sqrt(count));
            var yCount = Math.Ceiling(count / xCount);
            for (int i = 0; i < xCount; i++)
            {
                for (int j = 0; j < yCount; j++)
                {
                    var x = i;
                    var y = j;
                    var z = Math.Ceiling(i / 3 + (double)1);
                    var obj = new
                    {
                        x,
                        y,
                        z
                    };
                    values.Add(obj);
                }
            }

            return values;
        }

        internal void GenerateDataSources(string path, int count, string type = "Other")
        {
            List<object> value = new List<object>();

            switch (type) {
                case "scatter":
                    value = GenerateScatter(count);
                    break;
                case "treeMap":
                    value = GenerateTreeMap(count);
                    break;
                case "bubble":
                    value = GenerateBubble(count);
                    break;
                case "range":
                    value = GenerateRange(count);
                    break;
                case "stack":
                    value = GenerateStack(count);
                    break;
                case "rose":
                    value = GenerateRose(count);
                    break;
                case "sunburst":
                    value = GenerateSunburst(count);
                    break;
                default:
                    value = GenerateOther(count);
                    break;
            }
            
            var json = new
            {
                name = "sample",
                dateFormats = false,
                values = value
            };

            File.WriteAllText(path, System.Text.Json.JsonSerializer.Serialize(json));
        }

        // columnChart|lineChart|pieChart|radarChart|filledRadar|barChart|areaChart
        static List<object> GenerateOther(int count)
        {
            var values = new List<object>();
            for (int i = 0; i < count; i++)
            {
                var Category = $"C{i}";
                var Value = i;
                var obj = new
                {
                    Category,
                    Value
                };
                values.Add(obj);
            }

            return values;
        }

        // scatterChart
        static List<object> GenerateScatter(int count)
        {
            var values = new List<object>();
            var xCount = Math.Ceiling(Math.Sqrt(count));
            var yCount = Math.Ceiling(count / xCount);
            for (int i = 0; i < xCount; i++)
            {
                for (int j = 0; j < yCount; j++)
                {
                    var x = i;
                    var y = j;
                    var obj = new
                    {
                        x,
                        y
                    };
                    values.Add(obj);
                }
            }

            return values;
        }

        // treeMapChart
        static List<object> GenerateTreeMap(int count)
        {
            var values = new List<object>();
            for (int i = 0; i < count; i++)
            {
                var x = i;
                var y = i + 1;
                var obj = new
                {
                    x,
                    y
                };
                values.Add(obj);
            }

            return values;
        }

        // bubbleChart
        static List<object> GenerateBubble(int count)
        {
            var values = new List<object>();
            var xCount = Math.Ceiling(Math.Sqrt(count));
            var yCount = Math.Ceiling(count / xCount);
            for (int i = 0; i < xCount; i++)
            {
                for (int j = 0; j < yCount; j++)
                {
                    var x = i;
                    var y = j;
                    var z = Math.Ceiling(i / 3 + (double)1);
                    var obj = new
                    {
                        x,
                        y,
                        z
                    };
                    values.Add(obj);
                }
            }

            return values;
        }

        // rangeColumnChart|rangeBarChart|rangeAreaChart
        static List<object> GenerateRange(int count)
        {
            var values = new List<object>();
            for (int i = 0; i < count; i++)
            {
                var category = $"C{i}";
                var lower = i;
                var upper = i + 3;
                var obj = new
                {
                    category,
                    lower,
                    upper
                };
                values.Add(obj);
            }

            return values;
        }

        // stackedColumnChart|percentStackedColumnChart|stackedBarChart|percentStackedBarChart|stackedAreaChart|percentStackedAreaChart|radialStackedBarChart|barInPolarChart|stackedBarInPolarChart
        static List<object> GenerateStack(int count)
        {
            var values = new List<object>();
            for (int i = 0; i < count; i++)
            {
                var category = $"C{i}";
                var series = $"C12";
                var value = i;
                var obj = new
                {
                    category,
                    series,
                    value
                };
                values.Add(obj);

                category = $"C{i}";
                series = $"C13";
                value = i + 1;
                obj = new
                {
                    category,
                    series,
                    value
                };
                values.Add(obj);

                category = $"C{i}";
                series = $"C14";
                value = i + 2;
                obj = new
                {
                    category,
                    series,
                    value
                };
                values.Add(obj);
            }

            return values;
        }

        // donutChart|roseChart|funnelChart
        static List<object> GenerateRose(int count)
        {
            var values = new List<object>();
            for (int i = 0; i < count; i++)
            {
                var series = $"C{i}";
                var value = i;
                var obj = new
                {
                    series,
                    value
                };
                values.Add(obj);
            }

            return values;
        }

        // sunburstChart
        static List<object> GenerateSunburst(int count)
        {
            var values = new List<object>();
            for (int i = 0; i < count; i++)
            {
                var detail1 = $"C{i}";
                var detail2 = $"C12";
                var value = i;
                var obj = new
                {
                    detail1,
                    detail2,
                    value
                };
                values.Add(obj);

                detail1 = $"C{i}";
                detail2 = $"C13";
                value = i + 2;
                obj = new
                {
                    detail1,
                    detail2,
                    value
                };
                values.Add(obj);

                detail1 = $"C{i}";
                detail2 = $"C14";
                value = i + 4;
                obj = new
                {
                    detail1,
                    detail2,
                    value
                };
                values.Add(obj);
            }

            return values;
        }
    }
}
