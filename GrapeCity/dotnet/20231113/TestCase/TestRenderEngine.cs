namespace GrapeCity.DataVisualization.Console
{
	using GrapeCity.DataVisualization.Chart;
	using GrapeCity.DataVisualization.Console.Plugins;
	using GrapeCity.DataVisualization.Options;
	using GrapeCity.DataVisualization.Plugins.GcImageRenderEngine.Imaging;
	using GrapeCity.DataVisualization.Plugins.SvgRenderEngine;
	using GrapeCity.DataVisualization.Plugins.SvgRenderEngine.Image;
	using GrapeCity.Documents.Imaging;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	internal class TestRenderEngine
	{
		public static readonly TestRenderEngine Builder = new TestRenderEngine();

		public GcBitmap DrawImage (IDvOption dvOption, Size size)
		{
			GcBitmap bmp = new GcBitmap((int)size.width, (int)size.height, false);
			bmp.ApplyLicenseKey("GrapeCity Internal Use Only,215564869134247#A0iymiOiQWSisnOiQkIsISP3EkYCdGW6d4a6VUUHVjYI3yMsB7R4QXdNBFR8NFa6tmUXBnSLtUTxMDaGRnbQNEallWTxdTYJVnc4xmbl3EcydVMupXZphGRD9mavwkQBRkeG36cRlVZiojITJCL7gTO7QzNyITN0IicfJye&Qf35VfikDVLZkI0IyQiwiIzYHI4VmTuAyZul6Zh5WSgI7bmBCduVWb5N6bEByQHJiOi8kI1tlOiQmcQJCLicTM5IDNwACOwATM9EDMyIiOiQncDJCLiU6cVByZulGdzVGVgI7bGJiOiEmTDJCLicDNyQzMxkjN8Qju3nT");
			using (GcBitmapGraphics g = bmp.CreateGraphics(System.Drawing.Color.Transparent))
			{
				// Testing the Calculation Engine.
				CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
				PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

				// Instance plugin sample.
				PluginCollection customPluginCollection = new PluginCollection();
				CustomStringFormattingPlugin customStringFormattingPlugin = new CustomStringFormattingPlugin();
				customPluginCollection.register(customStringFormattingPlugin);
				// DAT-3290
				//customPluginCollection.register(new TrendlineExpressionPlugin());
				// DAT-2777
				//customPluginCollection.register(new CompatibleOverlayDetailKeyPlugin(), true);
				//
				//customPluginCollection.register(new GcesTrendlineExpressionTextStylePolicyPlugin(), true);
				// 
				//customPluginCollection.register(new GcesReferenceLineLabelTextStylePolicyPlugin(), true);
				// DAT-3876
				//customPluginCollection.register(new _RadialCartesianCoordinateSystemLayoutPlugin(), true);

				GcImageRenderEngine renderEngine = new GcImageRenderEngine(g, new GcImageTextMetrics(g));
				using (FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, new GcImageInfoBuilder()))
				{
					dv.Paint();

					// DAT-3655
					// var kind = dv.Model.plotAreas[0].legends[0].kind;
				}

				//try
				//{
				//    // Testing the Calculation Engine.
				//    CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
				//    PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

				//    // Instance plugin sample.
				//    PluginCollection customPluginCollection = new PluginCollection();
				//    CustomStringFormattingPlugin customStringFormattingPlugin = new CustomStringFormattingPlugin();
				//    customPluginCollection.register(customStringFormattingPlugin);

				//    GcImageRenderEngine renderEngine = new GcImageRenderEngine(g, new GcImageTextMetrics(g));
				//    using (FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, new GcImageInfoBuilder()))
				//    {
				//        dv.Paint();
				//    }
				//}
				//finally
				//{
				//}
			}
			return bmp;
		}

		public string DrawSvg (IDvOption dvOption, Size size)
		{
			// Testing the Calculation Engine.
			CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
			PluginCollection.defaultPluginCollection.register(new CustomCalculateEnginePlugin());

			// Instance plugin sample.
			PluginCollection customPluginCollection = new PluginCollection();
			//CustomStringFormattingPlugin customStringFormattingPlugin = new CustomStringFormattingPlugin();
			//customPluginCollection.register(customStringFormattingPlugin);

			// DAT-2577
			//NullValueTextInfoPolicyPlugin nullValueTextInfoPolicyPlugin = new NullValueTextInfoPolicyPlugin();
			//customPluginCollection.register(nullValueTextInfoPolicyPlugin);
			// DAT-3185
			//ExcelLinearAxisScalePolicyPlugin excelLinearAxisScalePolicyPlugin = new ExcelLinearAxisScalePolicyPlugin();
			//customPluginCollection.register(excelLinearAxisScalePolicyPlugin);
			// DAT-3149|3404
			//customPluginCollection.register(new SjsStackBarOverlapPolicyPlugin());
			//customPluginCollection.register(new SjsStackBarOverlapPolicyPlugin(),false);
			// DAT-3420
			//customPluginCollection.register(new SjsGridLineDisplayPolicyPlugin());
			//customPluginCollection.register(new SjsGridLineDisplayPolicyPlugin(), false);
			// DAT-3290
			//customPluginCollection.register(new TrendlineExpressionPlugin());
			// DAT-2777
			//customPluginCollection.register(new CompatibleOverlayDetailKeyPlugin(), true);
			//
			//customPluginCollection.register(new GcesTrendlineExpressionTextStylePolicyPlugin(), true);
			// 
			//customPluginCollection.register(new GcesReferenceLineLabelTextStylePolicyPlugin(), true);
			// DAT-3876
			//customPluginCollection.register(_RadialCartesianCoordinateSystemLayoutPlugin._defaultPlugin);
			// DAT-3933
			//customPluginCollection.register(new ScatterCartesianTrapezoidLegendViewPlugin(), true);
			// DAT-3945
			//customPluginCollection.register(new ScatterCartesianLightnessLegendPlugin(), true);
			//customPluginCollection.register(new LightnessLegendViewPlugin(), true);

			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();
			//FlexDV dv = new FlexDV(dvOption, size, renderEngine, null, imageInfoBuilder);
			FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, imageInfoBuilder);

			dv.Paint();

			// DAT-3655
			// var kind = dv.Model.plotAreas[0].legends[0].kind;

			if (dv.RenderEngine is ISvgRenderEngineApi)
			{
				var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
				return svgRenderEngine.Svg.ToString();
			}
			return "";
		}

		public string DrawSvg_Plugin (IDvOption dvOption, Size size, string type, bool flag)
		{
			// Testing the Calculation Engine.
			CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
			PluginCollection.defaultPluginCollection.register(new CustomCalculateEnginePlugin());

			// Instance plugin sample.
			PluginCollection customPluginCollection = new PluginCollection();

			PluginRegister(customPluginCollection, type, flag);

			//PluginCollection.defaultPluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, true);
			//PluginCollection.defaultPluginCollection.register(_SwingLineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, true);

			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();

			FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, imageInfoBuilder);

			dv.Paint();

			if (dv.RenderEngine is ISvgRenderEngineApi)
			{
				var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
				return svgRenderEngine.Svg.ToString();
			}
			return "";
		}

		internal void PluginRegister (PluginCollection customPluginCollection, string type, bool flag)
		{
			switch (type)
			{
				case "CommonScale":
					customPluginCollection.register(new CartesianAxesCommonScalePlugin(), flag);
					break;
				//case "GCESMeasureMultiLineString":
				//    customPluginCollection.register(new GCESMeasureMultiLineStringRenderApiPlugin(), flag);
				//    break;
				case "LegendDataPoint":
					customPluginCollection.register(new CompatibleLegendDataPointsPolicyPlugin(), flag);
					break;
				case "CustomStringFormattingPlugin":                    // 
											//CustomStringFormattingPlugin customStringFormattingPlugin = new CustomStringFormattingPlugin();
											//customPluginCollection.register(customStringFormattingPlugin);
					customPluginCollection.register(new CustomStringFormattingPlugin(), flag);
					break;
				case "NullValueTextInfoPolicyPlugin":                   // DAT-2577
											//NullValueTextInfoPolicyPlugin nullValueTextInfoPolicyPlugin = new NullValueTextInfoPolicyPlugin();
											//customPluginCollection.register(nullValueTextInfoPolicyPlugin);
					customPluginCollection.register(new NullValueTextInfoPolicyPlugin(), flag);
					break;
				case "ExcelLinearAxisScalePolicyPlugin":                // DAT-3185
											//ExcelLinearAxisScalePolicyPlugin excelLinearAxisScalePolicyPlugin = new ExcelLinearAxisScalePolicyPlugin();
											//customPluginCollection.register(excelLinearAxisScalePolicyPlugin);
					customPluginCollection.register(new ExcelLinearAxisScalePolicyPlugin(), flag);
					break;
				case "SjsStackBarOverlapPolicyPlugin":                  // DAT-3149|3404
					customPluginCollection.register(new SjsStackBarOverlapPolicyPlugin(), flag);
					break;
				case "SjsGridLineDisplayPolicyPlugin":                  // DAT-3420
					customPluginCollection.register(new SjsGridLineDisplayPolicyPlugin(), flag);
					break;
				case "TrendlineExpressionPlugin":                       // DAT-3290
					customPluginCollection.register(new TrendlineExpressionPlugin(), flag);
					break;
				case "CompatibleOverlayDetailKeyPlugin":                // DAT-2777
					customPluginCollection.register(new CompatibleOverlayDetailKeyPlugin(), flag);
					break;
				case "GcesTrendlineExpressionTextStylePolicyPlugin":    // 
					customPluginCollection.register(new GcesTrendlineExpressionTextStylePolicyPlugin(), flag);
					break;
				case "GcesReferenceLineLabelTextStylePolicyPlugin":     //
					customPluginCollection.register(new GcesReferenceLineLabelTextStylePolicyPlugin(), flag);
					break;
				case "RadialCartesianCoordinateSystemLayoutPlugin":     // DAT-3876  DAT-4098
					customPluginCollection.register(_RadialCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
					break;
				case "ScatterCartesianTrapezoidLegendViewPlugin":       // DAT-3933
					customPluginCollection.register(new ScatterCartesianTrapezoidLegendViewPlugin(), flag);
					break;
				case "ScatterCartesianLightnessLegendPlugin":           // DAT-3945
					customPluginCollection.register(new ScatterCartesianLightnessLegendPlugin(), flag);
					customPluginCollection.register(new LightnessLegendViewPlugin(), flag);
					break;
				case "GcesRadialPlotSmartDataLabelPlugin":              // DAT-4024
											//customPluginCollection.register(new GcesRadialPlotSmartDataLabelPlugin(), flag);
					customPluginCollection.register(GcesRadialPlotSmartDataLabelPlugin.defaultPlugin, flag);
					break;
				case "SjsLegendViewManagerPlugin":
					customPluginCollection.register(new SjsLegendViewManagerPlugin(), flag);
					break;
				case "SunburstPlotViewLayoutPlugin":                    // DAT-4029 DAT-4099
					customPluginCollection.register(_SunburstPlotViewLayoutPlugin._defaultPlugin, flag);
					break;
				case "SwingCoordinateSystem":                           // DAT-4063
					customPluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, flag);
					break;
				case "LineCartesian":
					customPluginCollection.register(_LineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
					break;
				case "MirrorLineCartesian":
					customPluginCollection.register(_MirrorLineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
					break;
				case "SwingLineCartesian":
					customPluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, flag);
					customPluginCollection.register(_SwingLineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
					break;
				//case "Gauge":
				//    customPluginCollection.register(new TrellisRadialCartesianCoordinateSystemLayoutPlugin(), flag);
				//    break;
				case "PictorialBarCartesianPointViewRender":
					customPluginCollection.register(new PictorialBarCartesianPointViewRenderPlugin(), flag);
					break;
				//case "DefaultOrdinalDimensionMergePolicy":
				//    customPluginCollection.register(new _DefaultOrdinalDimensionMergePolicy(), flag);
				//    break;
				case "MultiRowTickLabelLayout":			// DAT-4502
					customPluginCollection.register(new MultiRowTickLabelLayoutPlugin(), flag);
					break;
				case "ExcelWaterfall":
					customPluginCollection.register(new ExcelWaterfallOverlayPlugin(), flag);
					break;
				case "GcesLineCartesian":
					customPluginCollection.register(new GcesLineCartesianCoordinateSystemLayoutPlugin(), flag);
					break;
				default:
					break;
			}
		}

		public string DrawSvg_Performance (IDvOption dvOption, Size size)
		{
			// Testing the Calculation Engine.
			PluginCollection.defaultPluginCollection.register(new CustomCalculateEnginePlugin());
			// Instance plugin sample.
			PluginCollection customPluginCollection = new PluginCollection();

			// DAT-3876
			//customPluginCollection.register(_RadialCartesianCoordinateSystemLayoutPlugin._defaultPlugin, true);
			// DAT-3950
			//customPluginCollection.register(AutoOrdinalAxisScalePolicyPlugin.defaultPlugin, true);
			// DAT-4035
			//customPluginCollection.register(_SunburstPlotViewLayoutPlugin._defaultPlugin, true);

			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();
			FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, imageInfoBuilder);

			dv.Paint();

			if (dv.RenderEngine is ISvgRenderEngineApi)
			{
				var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
				return svgRenderEngine.Svg.ToString();
			}
			return "";
		}
	}
}
