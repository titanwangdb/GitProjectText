namespace GrapeCity.DataVisualization.Console
{
    using GrapeCity.DataVisualization.Options;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class TestDataSource
    {
        public static readonly TestDataSource Builder = new TestDataSource();

        public List<IDataOption> GetData()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("Country", "US");
            dict1.Add("Company", "IBM");
            dict1.Add("Sales", 3545.711769757831);
            dict1.Add("Date", "2011-02-05T11:23:15.000Z");
            dict1.Add("Downloads", 5834);
            dict1.Add("NewCustomer", true);

            var dict2 = new Dictionary<string, object>();
            dict2.Add("Country", "US");
            dict2.Add("Company", "MS");
            dict2.Add("Sales", 6545.711769757831);
            dict2.Add("Date", "2011-03-05T12:20:15.000Z");
            dict2.Add("Downloads", 3834);
            dict2.Add("NewCustomer", false);

            var dict3 = new Dictionary<string, object>();
            dict3.Add("Country", "CHINA");
            dict3.Add("Company", "Alibaba");
            dict3.Add("Sales", 4663.452628406266);
            dict3.Add("Date", "2013-04-05T12:20:15.000Z");
            dict3.Add("Downloads", 18470);
            dict3.Add("NewCustomer", true);

            var dict4 = new Dictionary<string, object>();
            dict4.Add("Country", "CHINA");
            dict4.Add("Company", "HuaWei");
            dict4.Add("Sales", 6663.452628406266);
            dict4.Add("Date", "2012-06-05T12:20:15.000Z");
            dict4.Add("Downloads", 12470);
            dict4.Add("NewCustomer", false);

            var dict5 = new Dictionary<string, object>();
            dict5.Add("Country", "RUSSIA");
            dict5.Add("Company", "ABBYY");
            dict5.Add("Sales", 5828.891491163088);
            dict5.Add("Date", "2013-05-05T12:20:15.000Z");
            dict5.Add("Downloads", 3356);
            dict5.Add("NewCustomer", true);

            var dict6 = new Dictionary<string, object>();
            dict6.Add("Country", "JAPAN");
            dict6.Add("Company", "SONY");
            dict6.Add("Sales", 3863.452628406266);
            dict6.Add("Date", "2014-07-05T12:20:15.000Z");
            dict6.Add("Downloads", 27470);
            dict6.Add("NewCustomer", true);

            var dict7 = new Dictionary<string, object>();
            dict7.Add("Country", "JAPAN");
            dict7.Add("Company", "SOFTBANK");
            dict7.Add("Sales", 2863.452628406266);
            dict7.Add("Date", "2012-07-05T12:20:15.000Z");
            dict7.Add("Downloads", 17470);
            dict7.Add("NewCustomer", false);

            var data = new List<IDataOption>() {
                new _DataOption {
                    //name = "",
                    //dateFormats = new List<string> { "true" },
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7 }
                }
            };

            return data;
        }

        public List<IDataOption> GetCalculateTransform()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("Country", "US");
            dict1.Add("Sales", 7327.682638109698);

            var dict2 = new Dictionary<string, object>();
            dict2.Add("Country", "Germany");
            dict2.Add("Sales", 2327.682638109698);

            var dict3 = new Dictionary<string, object>();
            dict3.Add("Country", "UK");
            dict3.Add("Sales", 9627.725374596032);

            var dict4 = new Dictionary<string, object>();
            dict4.Add("Country", "Japan"); ;
            dict4.Add("Sales", 7327.682638109698);

            var dict5 = new Dictionary<string, object>();
            dict5.Add("Country", null);
            dict5.Add("Sales", 3587);

            var data = new List<IDataOption>() {
                new _DataOption {
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5 }
                }
            };

            return data;
        }

        public List<IDataOption> NaNTest()
        {
            var caseData = new List<IDataOption>()
            {new _DataOption()
            {name = "sample", values = new List<System.Object>()
            {new Dictionary<string, object>()
            {{"Country", "US"}, {"Company", "IBM"}, {"Date", "2011-02-05T11:23:15.000Z"}, {"Sales", 3545.711769757831}, {"Downloads", 5834}, {"NewCustomer", true}}, new Dictionary<string, object>()
            {{"Country", "US"}, {"Company", "MS"}, {"Date", "2011-03-05T12:20:15.000Z"}, {"Sales", double.NaN}, {"Downloads", 12470}, {"NewCustomer", false}}, new Dictionary<string, object>()
            {{"Country", "CHINA"}, {"Company", "MAC"}, {"Date", "2011-04-05T11:23:45.000Z"}, {"Sales", 1545.111761757831}, {"Downloads", double.NaN}, {"NewCustomer", true}}, new Dictionary<string, object>()
            {{"Country", "CHINA"}, {"Company", "GrapeCity"}, {"Date", "2011-05-15T12:22:15.000Z"}, {"Sales", 6545.711769757831}, {"Downloads", double.NaN}, {"NewCustomer", false}}, new Dictionary<string, object>()
            {{"Country", "RUSSIA"}, {"Company", "Alibaba"}, {"Date", "2013-04-05T12:20:15.000Z"}, {"Sales", double.NaN}, {"Downloads", 27470}, {"NewCustomer", true}}, new Dictionary<string, object>()
            {{"Country", "RUSSIA"}, {"Company", "HuaWei"}, {"Date", "2012-06-05T12:20:15.000Z"}, {"Sales", 6663.452628406266}, {"Downloads", 17470}, {"NewCustomer", false}}, new Dictionary<string, object>()
            {{"Country", "JAPAN"}, {"Company", "SONY"}, {"Date", "2014-07-05T12:20:15.000Z"}, {"Downloads", 27470}, {"Sales", 3863.452628406266}, {"NewCustomer", true}}, new Dictionary<string, object>()
            {{"Country", "JAPAN"}, {"Company", "SOFTBANK"}, {"Date", "2012-07-05T12:20:15.000Z"}, {"Downloads", 17470}, {"Sales", 2863.452628406266}, {"NewCustomer", false}}}}};
            return caseData;
        }

        public List<IDataOption> DAT_2747()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("Done", 9);
            dict1.Add("Score", 90);
            dict1.Add("Name", "A");
            var dict2 = new Dictionary<string, object>();
            dict2.Add("Done", 7);
            dict2.Add("Score", 70);
            dict2.Add("Name", "B");
            var dict3 = new Dictionary<string, object>();
            dict3.Add("Done", 6);
            dict3.Add("Score", 60);
            dict3.Add("Name", "C");
            var dict4 = new Dictionary<string, object>();
            dict4.Add("Done", 6);
            dict4.Add("Score", 60);
            dict4.Add("Name", "D");
            var dict5 = new Dictionary<string, object>();
            dict5.Add("Done", 6);
            dict5.Add("Score", 60);
            dict5.Add("Name", "E");
            var dict6 = new Dictionary<string, object>();
            dict6.Add("Done", 5);
            dict6.Add("Score", 50);
            dict6.Add("Name", "F");
            var dict7 = new Dictionary<string, object>();
            dict7.Add("Done", 5);
            dict7.Add("Score", 50);
            dict7.Add("Name", "G");
            var dict8 = new Dictionary<string, object>();
            dict8.Add("Done", 4);
            dict8.Add("Score", 40);
            dict8.Add("Name", "H");
            var dict9 = new Dictionary<string, object>();
            dict9.Add("Done", 3);
            dict9.Add("Score", 30);
            dict9.Add("Name", "I");
            var dict10 = new Dictionary<string, object>();
            dict10.Add("Done", 2);
            dict10.Add("Score", 20);
            dict10.Add("Name", "J");
            var dict11 = new Dictionary<string, object>();
            dict11.Add("Done", 2);
            dict11.Add("Score", 20);
            dict11.Add("Name", "K");
            var dict12 = new Dictionary<string, object>();
            dict12.Add("Done", 1);
            dict12.Add("Score", 10);
            dict12.Add("Name", "L");

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "sample",
                    dateFormats = new List<string> {},
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7, dict8, dict9, dict10, dict11, dict12 }
                }
            };

            return data;
        }

        public List<IDataOption> HLOC()
        {
            var caseData = new List<IDataOption>() {
                new _DataOption() {
                    dateFormats = new List<System.String>() {"false"}, 
                    name = "sample", 
                    values = new List<System.Object>()
                    {
                        new Dictionary<string, object>()
                        {
                            {"date", "01/05/15"}, 
                            {"Year", "2000-01-05T11:23:15.000Z"}, 
                            {"Day", "2011-01-05T11:23:15.000Z"}, 
                            {"Day1", "2020-01-01T11:23:15.000Z"}, 
                            {"Month", "2020-01-01T11:23:15.000Z"}, 
                            {"Hour", "2011-01-01T01:23:15.000Z"}, 
                            {"Hour1", "2011-01-01T00:23:15.000Z"}, 
                            {"Minute", "2019-01-01T12:00:00.000Z"}, 
                            {"Second", "2019-01-01T12:00:00.000Z"}, 
                            {"MilliSecond", "2019-01-01T12:00:00.000Z"}, 
                            {"open", 77.98}, 
                            {"high", 79.25}, 
                            {"low", 76.86}, 
                            {"close", 77.19}, 
                            {"negative", -77.19}, 
                            {"volume", 26452191}, 
                            {"openA", 75.71}, 
                            {"highA", 75.98}, 
                            {"lowA", 75.21}, 
                            {"closeA", 75.62}, 
                            {"volumeA", 15062573}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/06/15"}, {"Year", "2001-02-05T11:23:15.000Z"}, {"Day", "2011-01-06T12:13:25.000Z"}, {"Day1", "2020-01-02T11:23:15.000Z"}, {"Month", "2020-02-02T11:23:15.000Z"}, {"Hour", "2011-01-01T02:23:15.000Z"}, {"Hour1", "2011-01-01T03:23:15.000Z"}, {"Minute", "2019-01-01T12:01:00.000Z"}, {"Second", "2019-01-01T12:00:01.000Z"}, {"MilliSecond", "2019-01-01T12:00:00.999Z"}, {"open", 77.23}, {"high", 77.59}, {"low", 75.36}, {"close", 76.15}, {"negative", -76.15}, {"volume", 27399288}, {"openA", 75.68}, {"highA", 75.7}, {"lowA", 74.25}, {"closeA", 74.47}, {"volumeA", 21210994}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/07/15"}, {"Year", "2002-03-05T11:23:15.000Z"}, {"Day", "2011-01-07T11:23:15.000Z"}, {"Day1", "2020-01-15T11:23:15.000Z"}, {"Month", "2020-03-03T11:23:15.000Z"}, {"Hour", "2011-01-01T03:23:15.000Z"}, {"Hour1", "2011-01-01T06:23:15.000Z"}, {"Minute", "2019-01-01T12:02:00.000Z"}, {"Second", "2019-01-01T12:00:02.000Z"}, {"MilliSecond", "2019-01-01T12:00:00.100Z"}, {"open", 76.76}, {"high", 77.36}, {"low", 75.82}, {"close", 76.15}, {"negative", -75.82}, {"volume", 22045333}, {"openA", 74.05}, {"highA", 74.83}, {"lowA", 73.45}, {"closeA", 74.44}, {"volumeA", 16194322}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/08/15"}, {"Year", "2003-04-05T11:23:15.000Z"}, {"Day", "2011-01-08T02:59:25.000Z"}, {"Day1", "2020-01-30T11:23:15.000Z"}, {"Hour", "2011-01-01T04:23:15.000Z"}, {"Hour1", "2011-01-01T09:23:15.000Z"}, {"Minute", "2019-01-01T12:15:00.000Z"}, {"Second", "2019-01-01T12:00:15.000Z"}, {"open", 76.74}, {"high", 78.23}, {"low", 76.08}, {"close", 78.18}, {"negative", -76.74}, {"volume", 23960953}, {"openA", 74.85}, {"highA", 75.34}, {"lowA", 74.5}, {"closeA", 75.19}, {"volumeA", 15811344}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/09/15"}, {"Year", "2004-05-05T11:23:15.000Z"}, {"Day", "2011-01-09T11:23:15.000Z"}, {"Day1", "2020-01-31T11:23:15.000Z"}, {"Hour", "2011-01-01T05:23:15.000Z"}, {"Hour1", "2011-01-01T12:23:15.000Z"}, {"Minute", "2019-01-01T12:30:00.000Z"}, {"Second", "2019-01-01T12:00:30.000Z"}, {"open", 78.2}, {"high", 78.62}, {"low", 77.2}, {"close", 77.74}, {"negative", -77.74}, {"volume", 21157007}, {"openA", 75.09}, {"highA", 76.75}, {"lowA", 75.03}, {"closeA", 76.51}, {"volumeA", 20877427}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/12/15"}, {"Year", "2005-06-05T11:23:15.000Z"}, {"Day", "2011-01-12T13:23:15.000Z"}, {"Hour", "2011-01-01T06:23:15.000Z"}, {"Hour1", "2011-01-01T13:23:15.000Z"}, {"Minute", "2019-01-01T12:45:00.000Z"}, {"Second", "2019-01-01T12:00:45.000Z"}, {"open", 77.84}, {"high", 78}, {"low", 76.21}, {"close", 76.72}, {"negative", -76.19}, {"volume", 19190194}, {"openA", 76.86}, {"highA", 76.87}, {"lowA", 75.89}, {"closeA", 76.23}, {"volumeA", 17234976}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/13/15"}, {"Year", "2006-07-05T11:23:15.000Z"}, {"Day", "2011-01-13T03:00:00.000Z"}, {"Hour", "2011-01-01T07:23:15.000Z"}, {"Hour1", "2011-01-01T18:23:15.000Z"}, {"Month", "2020-07-07T11:23:15.000Z"}, {"Minute", "2019-01-01T12:59:00.000Z"}, {"Second", "2019-01-01T12:00:59.000Z"}, {"open", 77.23}, {"high", 78.08}, {"low", 75.85}, {"close", 76.45}, {"negative", -72.19}, {"volume", 25179561}, {"openA", 76.46}, {"highA", 76.48}, {"lowA", 75.5}, {"closeA", 75.74}, {"volumeA", 18621860}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/14/15"}, {"Year", "2008-08-05T11:23:15.000Z"}, {"Day", "2011-01-14T11:23:15.000Z"}, {"Hour", "2011-01-01T08:23:15.000Z"}, {"Hour1", "2011-01-01T21:23:15.000Z"}, {"Month", "2021-01-07T11:23:15.000Z"}, {"Minute", "2019-01-01T12:58:00.000Z"}, {"open", 76.42}, {"high", 77.2}, {"low", 76.03}, {"close", 76.28}, {"negative", -71.19}, {"volume", 25918564}, {"openA", 75.3}, {"highA", 76.91}, {"lowA", 75.08}, {"closeA", 75.6}, {"volumeA", 25254400}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/15/15"}, {"Year", "2009-09-05T11:23:15.000Z"}, {"Day", "2011-01-15T01:11:15.000Z"}, {"Hour", "2011-01-01T09:23:15.000Z"}, {"Minute1", "2019-01-02T12:00:00.000Z"}, {"open", 76.4}, {"high", 76.57}, {"low", 73.54}, {"close", 74.05}, {"negative", -80.19}, {"volume", 34133974}, {"openA", 75.94}, {"highA", 76.9}, {"lowA", 75.45}, {"closeA", 76.71}, {"volumeA", 22426421}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/16/15"}, {"Year", "2010-10-05T11:23:15.000Z"}, {"Day", "2011-01-16T22:22:22.000Z"}, {"Hour", "2011-01-01T10:23:15.000Z"}, {"Month", "2020-10-10T11:23:15.000Z"}, {"open", 74.04}, {"high", 75.32}, {"low", 73.84}, {"close", 75.18}, {"negative", -75.29}, {"volume", 21791529}, {"openA", 76.99}, {"highA", 79.84}, {"lowA", 76.95}, {"closeA", 79.42}, {"volumeA", 45851177}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/20/15"}, {"Year", "2011-11-05T11:23:15.000Z"}, {"Day", "2011-01-20T11:23:15.000Z"}, {"Hour", "2011-01-01T11:23:15.000Z"}, {"open", 75.72}, {"high", 76.31}, {"low", 74.82}, {"close", 76.24}, {"negative", -70.09}, {"volume", 22821614}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/21/15"}, {"Year", "2012-12-05T11:23:15.000Z"}, {"Day", "2011-01-21T12:02:03.000Z"}, {"Hour", "2011-01-01T12:23:15.000Z"}, {"Month", "2020-12-12T11:23:15.000Z"}, {"open", 76.16}, {"high", 77.3}, {"low", 75.85}, {"close", 76.74}, {"negative", -71.1}, {"volume", 25096737}, {"openA", 79.55}, {"highA", 80.34}, {"lowA", 79.2}, {"closeA", 79.9}, {"volumeA", 36931698}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/22/15"}, {"Year", "2013-01-05T11:23:15.000Z"}, {"Day", "2011-01-22T01:20:15.000Z"}, {"Hour", "2011-01-01T13:23:15.000Z"}, {"Month", "2020-12-13T11:23:15.000Z"}, {"open", 77.17}, {"high", 77.75}, {"low", 76.68}, {"close", 77.65}, {"negative", -72}, {"volume", 19519458}, {"openA", 79.96}, {"highA", 80.19}, {"lowA", 78.38}, {"closeA", 78.84}, {"volumeA", 24139056}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/23/15"}, {"Year", "2014-02-05T11:23:15.000Z"}, {"Day", "2011-01-23T23:23:15.000Z"}, {"Hour", "2011-01-01T14:23:15.000Z"}, {"Month", "2019-07-07T11:23:15.000Z"}, {"open", 77.65}, {"high", 78.19}, {"low", 77.04}, {"close", 77.83}, {"negative", -77}, {"volume", 16746503}, {"openA", 78.5}, {"highA", 79.48}, {"lowA", 78.1}, {"closeA", 78.45}, {"volumeA", 18897133}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/26/15"}, {"Year", "2015-03-05T11:23:15.000Z"}, {"Day", "2011-01-26T19:23:15.000Z"}, {"Hour", "2011-01-01T15:23:15.000Z"}, {"open", 77.98}, {"high", 78.47}, {"low", 77.29}, {"close", 77.5}, {"negative", -73}, {"volume", 19260820}, {"openA", 78.5}, {"highA", 80.2}, {"lowA", 78.5}, {"closeA", 79.56}, {"volumeA", 25593800}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/27/15"}, {"Year", "2016-04-05T11:23:15.000Z"}, {"Day", "2011-01-27T23:23:15.000Z"}, {"Hour", "2011-01-01T16:23:15.000Z"}, {"open", 76.71}, {"high", 76.88}, {"low", 75.63}, {"close", 75.78}, {"negative", -79}, {"volume", 20109977}, {"openA", 79.88}, {"highA", 81.37}, {"lowA", 79.72}, {"closeA", 80.41}, {"volumeA", 31111891}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/28/15"}, {"Year", "2017-05-05T11:23:15.000Z"}, {"Day", "2011-01-28T03:23:15.000Z"}, {"Hour", "2011-01-01T17:23:15.000Z"}, {"open", 76.9}, {"high", 77.64}, {"low", 76}, {"close", 76.24}, {"negative", -79.19}, {"volume", 53306422}, {"openA", 80.68}, {"highA", 81.23}, {"lowA", 78.62}, {"closeA", 78.97}, {"volumeA", 30739197}
                        }, 
                        new Dictionary<string, object>()
                        {
                            {"date", "01/29/15"}, {"Year", "2018-06-05T11:23:15.000Z"}, {"Day", "2011-01-29T13:59:15.000Z"}, {"Hour", "2011-01-01T18:23:15.000Z"}, {"open", 76.85}, {"high", 78.02}, {"low", 74.21}, {"close", 78}, {"negative", -72.59}, {"volume", 61293468}, {"openA", 79.61}, {"highA", 79.7}, {"lowA", 78.52}, {"closeA", 79.6}, {"volumeA", 18634973}
                        }
                    }
                }
            };
            return caseData;
        }

        #region NaN
        // DAT-3286 ues same data
        public List<IDataOption> DAT_3287()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("value2", 10);
            dict1.Add("x", "A");
            dict1.Add("color2", "S1");

            var dict2 = new Dictionary<string, object>();
            dict2.Add("value2", 51);
            dict2.Add("x", "B");
            dict2.Add("color2", "S1");

            var dict3 = new Dictionary<string, object>();
            dict3.Add("value2", double.NaN);
            dict3.Add("x", "C");
            dict3.Add("color2", "S1");

            var dict4 = new Dictionary<string, object>();
            dict4.Add("value2", 37);
            dict4.Add("x", "D");
            dict4.Add("color2", "S1");

            var dict5 = new Dictionary<string, object>();
            dict5.Add("value2", 23);
            dict5.Add("x", "E");
            dict5.Add("color2", "S1");

            var dict6 = new Dictionary<string, object>();
            dict6.Add("value2", 25);
            dict6.Add("x", "A");
            dict6.Add("color2", "S2");

            var dict7 = new Dictionary<string, object>();
            dict7.Add("value2", 36);
            dict7.Add("x", "B");
            dict7.Add("color2", "S2");

            var dict8 = new Dictionary<string, object>();
            dict8.Add("value2", 85);
            dict8.Add("x", "C");
            dict8.Add("color2", "S2");

            var dict9 = new Dictionary<string, object>();
            dict9.Add("value2", 65);
            dict9.Add("x", "D");
            dict9.Add("color2", "S2");

            var dict10 = new Dictionary<string, object>();
            dict10.Add("value2", 69);
            dict10.Add("x", "E");
            dict10.Add("color2", "S2");

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "2",
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7, dict8, dict9, dict10 }
                }
            };

            return data;
        }

        public List<IDataOption> DAT_3323()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("country", "US");
            dict1.Add("sales", double.NaN);
            dict1.Add("active", "false");

            var dict2 = new Dictionary<string, object>();
            dict2.Add("country", "Germany");
            dict2.Add("active", "false");

            var dict3 = new Dictionary<string, object>();
            dict3.Add("country", "UK");
            dict3.Add("sales", 9627.725374596032);
            dict3.Add("active", "false");

            var dict4 = new Dictionary<string, object>();
            dict4.Add("country", "Japan");
            dict4.Add("sales", 4531.63710148669);
            dict4.Add("active", "false");

            var dict5 = new Dictionary<string, object>();
            dict5.Add("country", "Italy");
            dict5.Add("sales", 9927.989879079592);
            dict5.Add("active", "false");

            var dict6 = new Dictionary<string, object>();
            dict6.Add("country", "Greece");
            dict6.Add("sales", 526.8966243795559);
            dict6.Add("active", "false");

            var dict7 = new Dictionary<string, object>();
            dict7.Add("country", "US");
            dict7.Add("sales", 9142.080421541787);
            dict7.Add("active", "false");

            var dict8 = new Dictionary<string, object>();
            dict8.Add("country", "Germany");
            dict8.Add("sales", 9780.104103590214);
            dict8.Add("active", "false");

            var dict9 = new Dictionary<string, object>();
            dict9.Add("country", "UK");
            dict9.Add("sales", 4831.725374596032);
            dict9.Add("active", "false");

            var dict10 = new Dictionary<string, object>();
            dict10.Add("country", "Japan");
            dict10.Add("sales", 6740.63710148669);
            dict10.Add("active", "false");

            var dict11 = new Dictionary<string, object>();
            dict11.Add("country", "Italy");
            dict11.Add("sales", 4287.989879079592);
            dict11.Add("active", "false");

            var dict12 = new Dictionary<string, object>();
            dict12.Add("country", "Greece");
            dict12.Add("sales", 4202.8966243795559);
            dict12.Add("active", "false");
            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "2",
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7, dict8, dict9, dict10, dict11, dict12 }
                }
            };

            return data;
        }

        public List<IDataOption> DAT_3799()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("from", "A1");
            dict1.Add("to", "B2");
            dict1.Add("weight", double.NaN);
            
            var dict2 = new Dictionary<string, object>();
            dict2.Add("from", "A4");
            dict2.Add("to", "B2");
            dict2.Add("weight", double.NaN);

            var dict3 = new Dictionary<string, object>();
            dict3.Add("from", "A1");
            dict3.Add("to", "B1");
            dict3.Add("weight", 10);

            var dict4 = new Dictionary<string, object>();
            dict4.Add("from", "A5");
            dict4.Add("to", "B1");

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "2",
                    values = new List<object> { dict1, dict2, dict3, dict4 }
                }
            };

            return data;
        }
		#endregion

		public List<IDataOption> Aggregate_CountDistinct_NaN ()
		{
			var dict1 = new Dictionary<string, object>();
			dict1.Add("from", "A1");
			dict1.Add("to", "B2");
			dict1.Add("weight", double.NaN);

			var dict2 = new Dictionary<string, object>();
			dict2.Add("from", "A4");
			dict2.Add("to", "B2");
			dict2.Add("weight", double.NaN);

			var dict3 = new Dictionary<string, object>();
			dict3.Add("from", "A1");
			dict3.Add("to", "B1");
			dict3.Add("weight", 10);

			var dict4 = new Dictionary<string, object>();
			dict4.Add("from", "A5");
			dict4.Add("to", "B1");

			var data = new List<IDataOption>() {
                                new _DataOption {
	                                name = "2",
	                                values = new List<object> { dict1, dict2, dict3, dict4 }
                                }
                         };

			return data;
		}

		public List<IDataOption> Aggregate_CountDistinct_Type ()
		{
			var dict1 = new Dictionary<string, object>();
			dict1.Add("category", "A1");
			dict1.Add("value", 10.01);

			var dict2 = new Dictionary<string, object>();
			dict2.Add("category", "A1");
			dict2.Add("value", 10);

			var dict3 = new Dictionary<string, object>();
			dict3.Add("category", "A2");
			dict3.Add("value", 10.0);

			var dict4 = new Dictionary<string, object>();
			dict4.Add("category", "A2");
			dict4.Add("value", 10.0);

			var dict5 = new Dictionary<string, object>();
			dict5.Add("category", "A3");
			dict5.Add("value", 1e10);

			var dict6 = new Dictionary<string, object>();
			dict6.Add("category", "A3");
			dict6.Add("value", 10000000000);

			var dict7 = new Dictionary<string, object>();
			dict7.Add("category", "A4");
			dict7.Add("value", 2e10);

			var dict8 = new Dictionary<string, object>();
			dict8.Add("category", "A4");
			dict8.Add("value", 10000000000);

			var data = new List<IDataOption>() {
				new _DataOption {
					name = "sample",
					values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7, dict8 }
				}
			 };

			return data;
		}

		public List<IDataOption> DAT_3386()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("Fields!quantity.Value\u002B25", 92);
            dict1.Add("Fields!quantity.Value\u002B10", 415);
            dict1.Add("quantity", 59);
            dict1.Add("Fields!quantity.Value-20", 340);

            var dict2 = new Dictionary<string, object>();
            dict2.Add("Fields!quantity.Value\u002B25", 60);
            dict2.Add("Fields!quantity.Value\u002B10", 365);
            dict2.Add("quantity", 30);
            dict2.Add("Fields!quantity.Value-20", 255);

            var dict3 = new Dictionary<string, object>();
            dict3.Add("Fields!quantity.Value\u002B25", 42);
            dict3.Add("Fields!quantity.Value\u002B10", 325);
            dict3.Add("quantity", 38);
            dict3.Add("Fields!quantity.Value-20", 350);

            var dict4 = new Dictionary<string, object>();
            dict4.Add("Fields!quantity.Value\u002B25", 25);
            dict4.Add("Fields!quantity.Value\u002B10", 25);
            dict4.Add("quantity", 7);
            dict4.Add("Fields!quantity.Value-20", 445);

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "2",
                    dateFormats = new List<string> { "u" },
                    values = new List<object> { dict1, dict2, dict3, dict4 }
                }
            };

            return data;
        }

        public List<IDataOption> DAT_3356()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("Country", "US");
            dict1.Add("Company", "IBM");
            dict1.Add("Date", new DateTime(2011, 02, 05, 12, 23, 15));
            dict1.Add("Sales", 3545.711769757831);
            dict1.Add("Negative", -3545);
            dict1.Add("Expenses", 5834);
            dict1.Add("NewCustomer", true);

            var dict2 = new Dictionary<string, object>();
            dict2.Add("Country", "US");
            dict2.Add("Company", "MS");
            dict2.Add("Sales", 6545.711769757831);
            dict2.Add("Negative", 6545);
            dict2.Add("Date", new DateTime(2011, 03, 05, 12, 20, 15));
            dict2.Add("Expenses", 3834);
            dict2.Add("NewCustomer", false);

            var dict3 = new Dictionary<string, object>();
            dict3.Add("Country", "CHINA");
            dict3.Add("Company", "MAC");
            dict3.Add("Sales", 4663.452628406266);
            dict3.Add("Negative", 4663);
            dict3.Add("Date", new DateTime(2013, 05, 05, 12, 23, 15));
            dict3.Add("Expenses", 18470);
            dict3.Add("NewCustomer", true);

            var dict4 = new Dictionary<string, object>();
            dict4.Add("Country", "CHINA");
            dict4.Add("Company", "Alibaba");
            dict4.Add("Sales", 6663.452628406266);
            dict4.Add("Negative", 6663);
            dict4.Add("Date", new DateTime(2012, 06, 05, 12, 20, 15));
            dict4.Add("Expenses", 12470);
            dict4.Add("NewCustomer", false);

            var dict5 = new Dictionary<string, object>();
            dict5.Add("Country", "RUSSIA");
            dict5.Add("Company", "HuaWei");
            dict5.Add("Sales", 5828.891491163088);
            dict5.Add("Negative", -5828);
            dict5.Add("Date", null);
            dict5.Add("Expenses", 3356);
            dict5.Add("NewCustomer", true);

            var dict6 = new Dictionary<string, object>();
            dict6.Add("Country", "JAPAN");
            dict6.Add("Company", "GrapeCity");
            dict6.Add("Sales", 3863.452628406266);
            dict6.Add("Negative", -3863);
            dict6.Add("Date", new DateTime(2014, 07, 05, 03, 23, 15));
            dict6.Add("Expenses", 27470);
            dict6.Add("NewCustomer", true);

            var dict7 = new Dictionary<string, object>();
            dict7.Add("Country", "JAPAN");
            dict7.Add("Company", "ABBYY");
            dict7.Add("Sales", 2863.452628406266);
            dict7.Add("Negative", 2863);
            dict7.Add("Date", new DateTime(2012, 07, 05, 03, 23, 15));
            dict7.Add("Expenses", 17470);
            dict7.Add("NewCustomer", false);

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "sample",
                    dateFormats = new List<string> {},
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7 }
                }
            };

            return data;
        }

        public List<IDataOption> DAT_2746()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("value2", 100);
            dict1.Add("x", "1th");
            dict1.Add("color", "Outlook");

            var dict2 = new Dictionary<string, object>();
            dict2.Add("value2", 125);
            dict2.Add("x", "2th");
            dict2.Add("color", "Outlook");

            var dict3 = new Dictionary<string, object>();
            dict3.Add("value2", 170);
            dict3.Add("x", "3th");
            dict3.Add("color", "Outlook");

            var dict4 = new Dictionary<string, object>();
            dict4.Add("value2", 200);
            dict4.Add("x", "4th");
            dict4.Add("color", "Outlook");

            var dict5 = new Dictionary<string, object>();
            dict5.Add("value2", 275);
            dict5.Add("x", "5th");
            dict5.Add("color", "Outlook");

            var dict6 = new Dictionary<string, object>();
            dict6.Add("value2F", 11300);
            dict6.Add("x2", "1th");
            dict6.Add("color2", "Word");

            var dict7 = new Dictionary<string, object>();
            dict7.Add("value2F", 11350);
            dict7.Add("x2", "2th");
            dict7.Add("color2", "Word");

            var dict8 = new Dictionary<string, object>();
            dict8.Add("value2", 12100);
            dict8.Add("x2", "3th");
            dict8.Add("color2", "Word");

            var dict9 = new Dictionary<string, object>();
            dict9.Add("value2F", 13100);
            dict9.Add("x2", "4th");
            dict9.Add("color2", "Word");

            var dict10 = new Dictionary<string, object>();
            dict10.Add("value2F", 14500);
            dict10.Add("x2", "5th");
            dict10.Add("color2", "Word");

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "sample",
                    dateFormats = new List<string> {},
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7, dict8, dict9, dict10 }
                }
            };

            return data;
        }

        public List<IDataOption> DAT_3991()
        {
            var dict1 = new Dictionary<string, object>();
            dict1.Add("OnTime (Sum)", 13);
            dict1.Add("NotOnTime (Sum)", 21);
            dict1.Add("AwaitingApproval (Sum)", 15);

            var dict2 = new Dictionary<string, object>();
            dict2.Add("OnTime (Sum)", 9);
            dict2.Add("NotOnTime (Sum)", 24);
            dict2.Add("AwaitingApproval (Sum)", 23);

            var dict3 = new Dictionary<string, object>();
            dict3.Add("OnTime (Sum)", 5);
            dict3.Add("NotOnTime (Sum)", 12);
            dict3.Add("AwaitingApproval (Sum)", 23);

            var dict4 = new Dictionary<string, object>();
            dict4.Add("OnTime (Sum)", 7);
            dict4.Add("NotOnTime (Sum)", 23);
            dict4.Add("AwaitingApproval (Sum)", 4);

            var data = new List<IDataOption>() {
                new _DataOption {
                    name = "sample",
                    dateFormats = new List<string> {},
                    values = new List<object> { dict1, dict2, dict3, dict4 }
                }
            };

            return data;
        }

        public void GeneratePerformanceDataSource(string path, string type)
        {
            switch (type)
            {
                case "DAT-3846":
                    // Bar, Line, Pie
                    Performance.Builder.DAT_3846(Path.Combine(path, "1k.json"), 1000);
                    Performance.Builder.DAT_3846(Path.Combine(path, "5k.json"), 5000);
                    Performance.Builder.DAT_3846(Path.Combine(path, "1w.json"), 10000);
                    Performance.Builder.DAT_3846(Path.Combine(path, "2w.json"), 20000);
                    Performance.Builder.DAT_3846(Path.Combine(path, "5w.json"), 50000);
                    // Scatter 
                    Performance.Builder.GenerateRandomNumber(Path.Combine(path, "Random1k.json"), 1000);
                    Performance.Builder.GenerateRandomNumber(Path.Combine(path, "Random5k.json"), 5000);
                    Performance.Builder.GenerateRandomNumber(Path.Combine(path, "Random1w.json"), 10000);
                    Performance.Builder.GenerateRandomNumber(Path.Combine(path, "Random2w.json"), 20000);
                    Performance.Builder.GenerateRandomNumber(Path.Combine(path, "Random5w.json"), 50000);
                    break;
                case "DAT-4035":
                    // Sunburst
                    Performance.Builder.DAT_4035(Path.Combine(path, "50.json"), 50);
                    Performance.Builder.DAT_4035(Path.Combine(path, "100.json"), 100);
                    Performance.Builder.DAT_4035(Path.Combine(path, "500.json"), 500);
                    Performance.Builder.DAT_4035(Path.Combine(path, "1000.json"), 1000);
                    break;
                case "DAT-4036":
                    // barInPolar|stackedBarInPolarChart|radialStackedBarChart
                    Performance.Builder.DAT_4036(Path.Combine(path, "barInPolar50.json"), 50);
                    Performance.Builder.DAT_4036(Path.Combine(path, "barInPolar100.json"), 100);
                    Performance.Builder.DAT_4036(Path.Combine(path, "barInPolar500.json"), 500);
                    Performance.Builder.DAT_4036(Path.Combine(path, "barInPolar1000.json"), 1000);
                    // rose
                    Performance.Builder.DAT_4036Rose(Path.Combine(path, "rose50.json"), 50);
                    Performance.Builder.DAT_4036Rose(Path.Combine(path, "rose100.json"), 100);
                    Performance.Builder.DAT_4036Rose(Path.Combine(path, "rose500.json"), 500);
                    Performance.Builder.DAT_4036Rose(Path.Combine(path, "rose1000.json"), 1000);
                    // bubble
                    Performance.Builder.DAT_4036Bubble(Path.Combine(path, "bubble50.json"), 50);
                    Performance.Builder.DAT_4036Bubble(Path.Combine(path, "bubble100.json"), 100);
                    Performance.Builder.DAT_4036Bubble(Path.Combine(path, "bubble500.json"), 500);
                    Performance.Builder.DAT_4036Bubble(Path.Combine(path, "bubble1000.json"), 1000);
                    break;
                case "scatter":
                case "treeMap":
                case "bubble":
                case "range":
                case "stack":
                case "rose":
                case "sunburst":
                case "default":
                    Performance.Builder.GenerateDataSources(Path.Combine(path, type, "50.json"), 50, type);
                    Performance.Builder.GenerateDataSources(Path.Combine(path, type, "100.json"), 100, type);
                    Performance.Builder.GenerateDataSources(Path.Combine(path, type, "500.json"), 500, type);
                    Performance.Builder.GenerateDataSources(Path.Combine(path, type, "1000.json"), 1000, type);
                    Performance.Builder.GenerateDataSources(Path.Combine(path, type, "5000.json"), 5000, type);
                    break;
                default:
                    break;
            }
        }
    }
}
