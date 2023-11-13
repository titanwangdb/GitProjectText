namespace GrapeCity.DataVisualization.Console
{
	//extern alias DVChart;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text.Json;
	using System.Threading;
	//using DVChart.GrapeCity.DataVisualization.Chart;
	//using DVChart.GrapeCity.DataVisualization.Options;
	using GrapeCity.DataVisualization.Chart;
	using GrapeCity.DataVisualization.Options;
	using GrapeCity.DataVisualization.Console.Plugins;
	using GrapeCity.DataVisualization.Console.Testings.Engines;
	//using GrapeCity.DataVisualization.Plugins.ExcelCalculationEngine;
	using GrapeCity.DataVisualization.Plugins.GcImageRenderEngine.Imaging;
	using GrapeCity.DataVisualization.Plugins.SvgRenderEngine;
	using GrapeCity.DataVisualization.Plugins.SvgRenderEngine.Image;
	using GrapeCity.Documents.Imaging;
	using Newtonsoft.Json;
	using Microsoft.VisualBasic.FileIO;

	class Program
	{
		static void Main (string[] args)
		{
			//var engine = new ToJsonTestEngine();
			//engine.Test(@"D:\temp\DAT\2700\source.json");

			Size size = new Size(800, 400);

			//size = new Size(900, 300);
			string casePath = @"D:\temp\DAT\4654\DAT-4500-EmpetArea07";
			//casePath = @"D:\temp\DailyCheck\DataBinding_Category";

			// JsonLoad
			//JsonLoad(size, casePath);

			// EncodingFormat(size);
			//TestCase.Builder.DAT_2742(size);
			//TestCase.Builder.DAT_3386(size);
			//TestCase.Builder.DAT_2746(size);
			//TestCase.Builder.DAT_2747(size);
			//TestCase.Builder.DAT_2726(size);
			//TestCase.Builder.DAT_2745(size);
			//TestCase.Builder.DAT_2722(size);
			//TestCase.Builder.DAT_3575(size);
			//TestCase.Builder.DAT_3575B(size);
			//TestCase.Builder.DAT_3991(size);
			//TestCase.Builder.DAT_4281(size);
			//TestCase.Builder.DAT_0000(size);

			// ToJson
			//ToJson(size, casePath);
			//TestCase.Builder.DAT_3592(size);
			//TestCase.Builder.DAT_3807(size);

			/* Plugin
			    CustomStringFormattingPlugin
			    NullValueTextInfoPolicyPlugin                       // DAT-2577
			    ExcelLinearAxisScalePolicyPlugin                    // DAT-3185
			    SjsStackBarOverlapPolicyPlugin                      // DAT-3149|3404
			    SjsGridLineDisplayPolicyPlugin                      // DAT-3420
			    TrendlineExpressionPlugin                           // DAT-3290
			    CompatibleOverlayDetailKeyPlugin                    // DAT-2777
			    GcesTrendlineExpressionTextStylePolicyPlugin
			    GcesReferenceLineLabelTextStylePolicyPlugin
			    RadialCartesianCoordinateSystemLayoutPlugin         // DAT-3876 DAT-4098
			    ScatterCartesianTrapezoidLegendViewPlugin           // DAT-3933
			    ScatterCartesianLightnessLegendPlugin               // DAT-3945 
			    GcesRadialPlotSmartDataLabelPlugin                  // DAT-4024
			    SjsLegendViewManagerPlugin
			    SunburstPlotViewLayoutPlugin                        // DAT-4029 DAT-4099
			    SwingCoordinateSystem                               // DAT-4063
			    LineCartesian|MirrorLineCartesian|SwingLineCartesian
			    PictorialBarCartesianPointViewRender
			    DefaultOrdinalDimensionMergePolicy                  // DAT-4396
			    MultiRowTickLabelLayout				// 	
			    ExcelWaterfall
			   GcesLineCartesian				// DAT-4443
			 */
			//Plugin(size, casePath, "GcesLineCartesian", true);

			// Exception
			//JsonLoadException(size, casePath);

			// HitTest
			//TestCase.Builder.DAT_3351(size);
			//TestCase.Builder.DAT_3361(size);

			// culture
			//TestCase.Builder.DAT_3609(size);

			// Runtime
			//var dvModel = dv.Model.type;
			//TestCase.Builder.DAT_3359(size);
			//TestCase.Builder.DAT_3655(size);
			//TestCase.Builder.DAT_3969(size);

			// inject
			//List<int> index = new List<int> { 1, 2, 3, 4 };
			//TestCase.Builder.DAT_4447(size, casePath, index);

			// RunTimeModel
			//casePath = @"D:\temp\DailyCheck\RunTimeModel\BorderStyle";
			//TestCase.Builder.RunTimeModel(size, casePath);

			// NaN
			//JsonLoadNaN(size, casePath);

			//  load data
			//var data = TestDataSource.Builder.Aggregate_CountDistinct_Type();
			//JsonLoadData(size, casePath, data);

			// performance
			//Stopwatch drawSvg = new Stopwatch();
			//drawSvg.Start();
			//JsonLoad(size, casePath);
			//drawSvg.Stop();
			//System.Console.WriteLine("Spend: " + drawSvg.ElapsedMilliseconds);

			// 
			//TestCase.Builder.DAT_4483();

			/*
			    performance(DAT-3846)
			    1k|5k|1w|2w|5w|Random1k|Random5k|Random1w|Random2w|Random5w
			    Bar1k|Bar5k|Bar1w|Bar2w|Bar5w
			    Line1k|Line5k|Line1w|Line2w|Line5w
			    Scatter1k|Scatter5k|Scatter1w|Scatter2w|Scatter5w
			    Pie1k|Pie5k|Pie1w|Pie2w|Pie5w
			*/
			//string path = @"D:\temp\DAT\performance\TestCase\DAT-3846\Pie";
			//TestCase.Builder.DAT_3846(size, path, "1k");
			//TestCase.Builder.DAT_3846(size, path, "5k");
			//TestCase.Builder.DAT_3846(size, path, "1w");
			//TestCase.Builder.DAT_3846(size, path, "2w");
			//TestCase.Builder.DAT_3846(size, path, "5w");

			// Generate performance data source(DAT-4029) 
			//string path = @"D:\temp\Performance\Data\DAT-4036";
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "DAT-4035");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "DAT-4036");

			/*
			    performance(DAT-4035)
			    barInPolar|stackedBarInPolar/radialStackedBar/rose|Bbubble
			    50|100|500|1000
			    dv.plugins.PluginCollection.defaultPluginCollection.register(dv.plugins._SunburstPlotViewLayoutPlugin._defaultPlugin, true);
			 */
			//string path = @"D:\temp\Performance\TestCase\DAT-4035";
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "50"), 50);
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "100"), 100);
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "500"), 500);
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "1000"), 1000);

			/*
			    performance(DAT-4036)
			    barInPolarChart50|barInPolarChart100|barInPolarChart500|barInPolarChart1000
			    stackedBarInPolarChart50|stackedBarInPolarChart100|stackedBarInPolarChart500|stackedBarInPolarChart1000
			    radialStackedBarChart50|radialStackedBarChart100|radialStackedBarChart500|radialStackedBarChart1000
			    roseChart50|roseChart100|roseChart500|roseChart1000
			    bubbleChart50|bubbleChart100|bubbleChart500|bubbleChart1000
			 */
			//string path = @"D:\temp\Performance\TestCase\DAT-4036";
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "bubbleChart1000"), 1000);

			/*
			    performance(DAT-4097)
			    funnelChart50|funnelChart100|funnelChart500|funnelChart1000
			*/
			//string path = @"D:\temp\Performance\TestCase\DAT-4097";
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "funnelChart1000"), 1000);

			/*
			    performance(DAT-4101)
			    roseChart50|roseChart100|roseChart500|roseChart1000|roseChart5000
			*/
			//string path = @"D:\temp\Performance\TestCase\DAT-4101";
			//TestCase.Builder.PerformanceCase(size, Path.Combine(path, "roseChart5000"), 5000);

			// DAT-3806
			//string path = @"D:\temp\Performance\Data\DAT-3806\DAT-3806";
			//TestCase.Builder.PerformanceCase(size, path);

			// Generate performance data source(DAT-3846)
			// string path = @"D:\temp\performance\Data\DAT-3846";
			// TestDataSource.Builder.GeneratePerformanceDataSource(path, "DAT-3846");

			// Generate performance data source
			//string path = @"D:\temp\Performance\Data";
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "scatter");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "treeMap");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "bubble");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "range");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "stack");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "rose");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "sunburst");
			//TestDataSource.Builder.GeneratePerformanceDataSource(path, "default");

			// System.Console.WriteLine("Start");

			// // string stringParameters = "abc";
			// // int intParameters = 111;

			//string sourceJson = File.ReadAllText(casePath + ".json");
			//JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			//_DvOption dvOption = new _DvOption(dvJson);

			//var arrayTemp = new List<object>() { "aa", "bb", "cc"};

			//object[] arrayObject = new object[] { dvOption, size };

			//CallNodeJs(@"D:\practise\b.js", arrayObject);

			//CallNodeJs(@"D:\practise\b.js", dvOption, size);


			System.Console.WriteLine("End");

			//string soruce = @"D:\dv-chart-1\tests\source2\Loadjson";
			//string target = @"D:\temp\123\333.txt";
			////AcceptDirectory(path);
			//List<string> contents = new List<string>();
			////TraverseDirectories(soruce, target);
			//TraverseDirectories(soruce, contents);
			//using (TextWriter tw = new StreamWriter(target))
			//{
			//    foreach (String content in contents)
			//    {
			//        tw.WriteLine(content);
			//    }  
			//}
		}

		internal static void CallNodeJs (string filePath, object[] arguments)
		{
			var argumentsString = string.Join(" ", arguments);

			var startInfo = new ProcessStartInfo
			{
				FileName = "node",
				Arguments = $"{filePath} {argumentsString}",
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			};

			using var process = new Process { StartInfo = startInfo };
			process.Start();

			while (!process.StandardOutput.EndOfStream)
			{
				string line = process.StandardOutput.ReadLine();
				System.Console.WriteLine(line);
			}
		}

		internal static void CallNodeJs (string filePath, object argumentsA, object argumentsB)
		{
			var startInfo = new ProcessStartInfo
			{
				FileName = "node",
				Arguments = $"{filePath} {argumentsA} {argumentsB}",
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true,
			};

			using var process = new Process { StartInfo = startInfo };
			process.Start();

			while (!process.StandardOutput.EndOfStream)
			{
				string line = process.StandardOutput.ReadLine();
				System.Console.WriteLine(line);
			}
		}

		internal static void JsonLoad (Size size, string casePath)
		{
			//Stopwatch drawSvg = new Stopwatch();
			//drawSvg.Start();
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			//drawSvg.Stop();
			//System.Console.WriteLine("JsonDocument: " + drawSvg.ElapsedMilliseconds);

			_DvOption dvOption = new _DvOption(dvJson);
			//var dd = dvOption.option().Value;
			//dvOption.data = DAT_3287();
			//dvOption.data = DAT_3323();
			//dvOption.data = DAT_3356();

			// result is png
			//TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");

			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
		}

		internal static void JsonLoadException (Size size, string casePath)
		{
			try
			{
				string sourceJson = File.ReadAllText(casePath + ".json");
				JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
				_DvOption dvOption = new _DvOption(dvJson);

				// result is png
				//TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");

				// result is svg
				File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			}
			catch (Exception e)
			{
				e = FilterTargetInvocationException(e);
				string exceptionType = e.GetType().ToString();
				string exceptionMessage = e.Message;
				File.WriteAllText(casePath + "_Exception.txt", exceptionType + ":\n" + exceptionMessage);
			}
		}

		internal static Exception FilterTargetInvocationException (Exception exception)
		{
			if (exception is TargetInvocationException targetInvocationException)
			{
				return FilterTargetInvocationException(targetInvocationException.InnerException);
			}
			else
			{
				return exception;
			}
		}

		internal static void EncodingFormat (Size size)
		{
			string casePath = @"D:\temp\DAT\EncodingFormat";

			_DvOption dvOption = new _DvOption();
			var plotOption = new _PlotOption();
			plotOption.type = "Candlestick";
			plotOption.encodings.values.Add(new _FieldsValueEncodingOption() { field = "date, high, low, open, close" });
			dvOption.plots.Add(plotOption);
			//dvOption.data = HLOC();

			//_DvOption dvOption = new _DvOption()
			//{
			//    plots = new List<IPlotOption>
			//    {
			//        new _PlotOption {
			//            type = "Line",
			//            encodings = new _PlotEncodingsOption()
			//            {
			//                values = new List<IValueEncodingOption>() {
			//                    new _FieldsValueEncodingOption() { field = "Sales" }
			//                },
			//                category = new _CategoryEncodingOption() { field = "Country" }
			//            }
			//        }
			//    }
			//};
			//dvOption.data = GetData();

			//var jsonContents = dvOption3.ToJson();
			//File.WriteAllText(casePath + ".json", jsonContents);

			// result is png
			//DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

			// result is svg
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
		}

		internal static void ToJson (Size size, string casePath)
		{
			// Load Json
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			// Waterfall
			//_DvOption dvOption = new()
			//{
			//    plots = new List<IPlotOption> {
			//        new _PlotOption() {
			//            type = "Bar",
			//            encodings = new _PlotEncodingsOption() {
			//                values = new List<IValueEncodingOption>() {
			//                    new _FieldsValueEncodingOption() { field = "Sales" }
			//                },
			//                category = new _CategoryEncodingOption() { field = "Country" }
			//            },
			//            config = new _PlotConfigOption() {
			//                bar = new _PlotBarOption() {
			//                    waterfall = new _WaterfallOption() { }
			//                }
			//            }
			//        }
			//    },
			//    data = GetData()
			//};

			//_DvOption dvOption = new _DvOption();
			//var plotOption = new _PlotOption();
			//plotOption.type = "Bar";
			//plotOption.encodings.values.Add(new _FieldsValueEncodingOption() { field = "Country, Sales" });
			//dvOption.plots.Add(plotOption);
			//dvOption.data = GetData();

			//_DvOption dvOption = new _DvOption()
			//{
			//    config = new _ConfigOption()
			//    {
			//        plotAreas = new List<IPlotAreaOption>()
			//    {new _PlotAreaOption()
			//    {axes = new List<IAxisOption>()
			//    {new _AxisOption()
			//    {dateMode = DateMode.Day, labelAngle = new List<System.Double?>()
			//    {-90}, majorUnit = new _AxisUnitOption()
			//    {dateMode = DateMode.Day, value = 1}, plots = new List<System.String>()
			//    {"p1"}, type = AxisType.X}, new _AxisOption()
			//    {plots = new List<System.String>()
			//    {"p1"}, type = AxisType.Y}}}}
			//    },
			//    plots = new List<IPlotOption>()
			//    {new _PlotOption()
			//    {encodings = new _PlotEncodingsOption()
			//    {values = new List<IValueEncodingOption>()
			//    {new _FieldsValueEncodingOption()
			//    {field = "date, high, low, open, close"}}}, name = "p1", type = "Candlestick"}}
			//};
			//dvOption.data = HLOC();

			// DAT_3592
			//_DvOption dvOption = new _DvOption() {
			//    plots = new List<IPlotOption> {
			//        new _PlotOption() {
			//            type = "Candlestick",
			//            encodings = new _PlotEncodingsOption() {
			//                values = new List<IValueEncodingOption>() {
			//                    new _StockFieldValueEncodingOption {
			//                        field = new _StockFieldOption {
			//                            close = "close",
			//                            high = "high",
			//                            low = "low",
			//                            x = "date"
			//                        }
			//                    }
			//                }
			//            }
			//        }
			//    },
			//    data = HLOC()
			//};

			// 
			var toJson = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", toJson);

			//// before
			//var jsonBefore = dvOption.ToJson();
			//File.WriteAllText(casePath + "_ToJson_Before.json", jsonBefore);

			// result is png
			TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

			// result is svg
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));

			//// after
			//var jsonAfter = dvOption.ToJson();
			//File.WriteAllText(casePath + "_ToJson_After.json", jsonAfter);
		}

		internal static void JsonLoadNaN (Size size, string casePath)
		{
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();

			_DvOption dvOption = new _DvOption(dvJson);

			// 3287|3323|3356|3799
			dvOption.data = TestDataSource.Builder.DAT_3799();

			// result is png
			//TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");

			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));

		}

		internal static void JsonLoadData (Size size, string casePath, List<IDataOption> data)
		{
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();

			_DvOption dvOption = new _DvOption(dvJson);

			// 
			dvOption.data = data;

			// result is png
			//TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");

			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));

		}

		internal static void Plugin (Size size, string casePath, string type, bool flag = true)
		{
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			// result is png
			//TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");

			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg_Plugin(dvOption, size, type, flag));
		}

		internal static void AcceptDirectory (string directoryPath)
		{
			foreach (var childPath in Directory.GetFiles(directoryPath))
			{
				System.Console.WriteLine(directoryPath);
				break;
			}

			foreach (var childPath in Directory.GetDirectories(directoryPath))
			{
				AcceptDirectory(childPath);
			}
		}

		internal static void TraverseDirectories (string directoryPath, string outputFilePath)
		{
			StreamWriter output = new StreamWriter(outputFilePath, true);
			string[] subDirectories = Directory.GetDirectories(directoryPath);
			foreach (string subDirectory in subDirectories)
			{
				if (Directory.GetFiles(subDirectory).Length > 0)
				{
					output.WriteLine(subDirectory);
				}
				TraverseDirectories(subDirectory, outputFilePath);
			}
			output.Close();
		}

		internal static void TraverseDirectories (string directoryPath, List<string> contents)
		{
			string[] subDirectories = Directory.GetDirectories(directoryPath);
			foreach (string subDirectory in subDirectories)
			{
				if (Directory.GetFiles(subDirectory).Length > 0 && !contents.Contains(subDirectory))
				{
					contents.Add(subDirectory);
				}
				TraverseDirectories(subDirectory, contents);
			}
		}

		internal static void RunCount (int count, Size size, string path, int number)
		{
			for (int x = 0; x < count; x++)
			{
				TestCase.Builder.PerformanceCase(size, Path.Combine(path, "funnelChart100"), 100);
			}
		}

	}
}
