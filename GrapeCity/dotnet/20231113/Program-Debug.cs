extern alias DVChart;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DVChart.GrapeCity.DataVisualization.Chart;
using DVChart.GrapeCity.DataVisualization.Options;
using GrapeCity.DataVisualization.Plugins.ExcelCalculationEngine;
using GrapeCity.DataVisualization.Plugins.SvgRenderEngine;
using GrapeCity.DataVisualization.Plugins.SvgRenderEngine.Image;
using System.Reflection;

namespace GrapeCity.DataVisualization.Debug
{
	class Program
	{
		static void Main (string[] args)
		{
			string casePath = @"D:\temp\thread\thread";
			int count = 3;

			ThreadDemo(casePath, count);

			Console.WriteLine("End");

			//string jsonOption = File.ReadAllText(@"general.json");
			//JsonElement dvJson = JsonDocument.Parse(jsonOption).RootElement.Clone();
			//_DvOption dvOption = new _DvOption(dvJson);

			//PluginCollection.defaultPluginCollection.register(new ExcelCalculationEngineBuilder());

			//Size size = new Size(1090, 450);

			//if (args.Length == 2 && args[0] == "--thread")
			//{
			//    try
			//    {
			//        int numThreads = Int32.Parse(args[1]);

			//        Thread[] threads = new Thread[numThreads];
			//        for (int i = 0; i < numThreads; i++)
			//        {
			//            var index = i;
			//            Thread thread = new Thread(() =>
			//            {
			//                IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			//                IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();
			//                FlexDV dv = new FlexDV(dvOption, size, renderEngine, null, imageInfoBuilder);

			//                dv.Paint();

			//                if (dv.RenderEngine is ISvgRenderEngineApi)
			//                {
			//                    var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
			//                    File.WriteAllText($"general-{index}.svg", svgRenderEngine.Svg.ToString());
			//                }
			//            });
			//            threads[i] = thread;
			//        }
			//        for (int i = 0; i < numThreads; i++)
			//        {
			//            threads[i].Start();
			//            // Thread.Sleep(100);
			//        }
			//        foreach (var thread in threads)
			//        {
			//            thread.Join();
			//        }
			//    }
			//    catch (Exception e)
			//    {
			//        Console.WriteLine($"Exception'{e}'");
			//    }
			//}
			//else
			//{
			//    IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			//    IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();
			//    FlexDV dv = new FlexDV(dvOption, size, renderEngine, null, imageInfoBuilder);

			//    dv.Paint();

			//    if (dv.RenderEngine is ISvgRenderEngineApi)
			//    {
			//        var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
			//        File.WriteAllText("general.svg", svgRenderEngine.Svg.ToString());
			//    }
			//}

		}

		public static void ThreadDemo (string testCase, int count)
		{
			string jsonOption = File.ReadAllText(testCase + ".json");
			JsonElement dvJson = JsonDocument.Parse(jsonOption).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			PluginCollection.defaultPluginCollection.register(new ExcelCalculationEngineBuilder());

			Size size = new Size(1090, 450);

			try
			{
				//int numThreads = Int32.Parse(args[1]);
				int numThreads = count;

				Thread[] threads = new Thread[numThreads];
				for (int i = 0; i < numThreads; i++)
				{
					var index = i;
					Console.WriteLine("index: " + index);
					Thread thread = new Thread(() =>
					{
						IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
						IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();
						FlexDV dv = new FlexDV(dvOption, size, renderEngine, null, imageInfoBuilder);

						dv.Paint();

						if (dv.RenderEngine is ISvgRenderEngineApi)
						{
							var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
							File.WriteAllText(testCase + index + ".svg", svgRenderEngine.Svg.ToString());
						}
					});
					threads[i] = thread;
				}
				for (int i = 0; i < numThreads; i++)
				{
					Console.WriteLine("threads Start: " + i);
					threads[i].Start();
					// Thread.Sleep(100);
				}
				foreach (var thread in threads)
				{
					thread.Join();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception'{e}'");
			}
		}

	}

}
