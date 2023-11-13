namespace GrapeCity.DataVisualization.Console
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.Json;
	using System.Threading;
	using GrapeCity.DataVisualization.Chart;
	using GrapeCity.DataVisualization.Console.Plugins;
	using GrapeCity.DataVisualization.Options;
	using GrapeCity.DataVisualization.Plugins.SvgRenderEngine;
	using GrapeCity.DataVisualization.Plugins.SvgRenderEngine.Image;
	using GrapeCity.DataVisualization.TypeScript;
	using Newtonsoft.Json;
	using GrapeCity.Documents.Imaging;
	using GrapeCity.DataVisualization.Plugins.GcImageRenderEngine.Imaging;
	using System.Diagnostics;

	internal class TestCase
	{
		public static readonly TestCase Builder = new TestCase();

		#region HitTest
		public void DAT_3351 (Size size)
		{
			//https://grapecity.atlassian.net/wiki/spaces/DAT/pages/2960359821/Specification+QueryInterface#19%E3%80%81ILegendTitleModel

			string casePath = @"D:\temp\DAT\3351\case02";

			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);
			//
			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());


			FlexDV dv = new FlexDV(dvOption, size, renderEngine, null);
			dv.Paint();

			var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
			string svgResult = svgRenderEngine.Svg.ToString();

			File.WriteAllText(casePath + ".svg", svgResult);

			// LegendItemLabel
			Point point = new Point(737, 174);
			// LegendItemSymbol
			//Point point = new Point(730, 174);      
			// LegendTitle
			//Point point = new Point(747, 151);      
			HitTestResult hittestResult = dv.HitTest(point);
			IViewModel dvModel = hittestResult.model;
			if (dvModel != null)
			{
				System.Console.WriteLine(dvModel.type);
				var shapeModel = dvModel.queryInterface("IShapeModel") as IShapeModel;
				if (shapeModel != null)
				{
					foreach (var shape in shapeModel.shapes)
					{
						System.Console.WriteLine(shape.type);
						System.Console.WriteLine("----------------------");
						if (shape.type == "Line")
						{
							var lineShape = shape as IPolygonalLineShape;
							System.Console.WriteLine(lineShape.center);
							System.Console.WriteLine(lineShape.width);
							System.Console.WriteLine(lineShape.strokeWidth);
						}
						else if (shape.type == "Rectangle")
						{
							var rectangleShape = shape as IRectangleShape;
							var aa = rectangleShape.center.x;
							System.Console.WriteLine(rectangleShape.center.x + "," + rectangleShape.center.y);
							System.Console.WriteLine(rectangleShape.size.width + "," + rectangleShape.size.height);
							System.Console.WriteLine(rectangleShape.angle);
						}
						else if (shape.type == "Donut")
						{
							var dountShape = shape as IDonutShape;
							System.Console.WriteLine(dountShape.center);
							System.Console.WriteLine(dountShape.radius);
							System.Console.WriteLine(dountShape.innerRadius);
							System.Console.WriteLine(dountShape.startAngle);
							System.Console.WriteLine(dountShape.sweepAngle);
						}
						else if (shape.type == "Polygon")
						{
							var polygonShape = shape as IPolygonShape;
							System.Console.WriteLine(polygonShape.points);
						}
						else if (shape.type == "PolygonalLine")
						{
							var polygonalLineShape = shape as IPolygonalLineShape;
							System.Console.WriteLine(polygonalLineShape.center);
							System.Console.WriteLine(polygonalLineShape.radius);
							System.Console.WriteLine(polygonalLineShape.angles);
							System.Console.WriteLine(polygonalLineShape.width);
							System.Console.WriteLine(polygonalLineShape.strokeWidth);
						}
						else if (shape.type == "Arc")
						{
							var arcShape = shape as IArcShape;
							System.Console.WriteLine(arcShape.center);
							System.Console.WriteLine(arcShape.radius);
							System.Console.WriteLine(arcShape.width);
							System.Console.WriteLine(arcShape.strokeWidth);
							System.Console.WriteLine(arcShape.startAngle);
							System.Console.WriteLine(arcShape.sweepAngle);
						}
					}
				}
			}
		}

		public void DAT_3361 (Size size)
		{
			//https://grapecity.atlassian.net/wiki/spaces/DAT/pages/2960359821/Specification+QueryInterface#19%E3%80%81ILegendTitleModel

			string casePath = @"D:\temp\DAT\3361\case01";

			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);
			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			FlexDV dv = new FlexDV(dvOption, size, renderEngine, null);
			dv.Paint();
			var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
			string svgResult = svgRenderEngine.Svg.ToString();
			File.WriteAllText(casePath + ".svg", svgResult);

			// Axis
			Point point = new Point(80, 204);
			HitTestResult hittestResult = dv.HitTest(point);
			if (hittestResult != null)
			{
				var dvModel = hittestResult.model;
				if (dvModel != null)
				{
					System.Console.WriteLine(dvModel.type);
					var axisModel = dvModel.queryInterface("IAxisModel") as IAxisModel;
					if (axisModel != null)
					{
						System.Console.WriteLine(axisModel.type);
					}
					else
					{
						System.Console.WriteLine("axisModel is Null");
					}
				}
				else
				{
					System.Console.WriteLine("dvModel is Null");
				}
			}
			else
			{
				System.Console.WriteLine("HitTest is Null");
			}
		}
		#endregion

		#region Encoding
		public void DAT_3386 (Size size)
		{
			string casePath = @"D:\temp\DAT\3386\after";

			_DvOption dvOption = new _DvOption();
			_PlotOption plotOption = new _PlotOption();
			plotOption.name = "Plot1";
			plotOption.type = "Bar";
			plotOption.encodings.values = new List<IValueEncodingOption>() {
		new _FieldsValueEncodingOption {
		    field = "Fields!quantity.Value\u002B25",
		    aggregate = Aggregate.Sum
		},
		new _FieldsValueEncodingOption {
		    field = "Fields!quantity.Value\u002B10",
		    aggregate = Aggregate.Sum
		},
		new _FieldsValueEncodingOption {
		    field = "quantity",
		    aggregate = Aggregate.Sum
		},
		new _FieldsValueEncodingOption {
		    field = "Fields!quantity.Value-20",
		    aggregate = Aggregate.Sum
		}
	    };
			plotOption.config.axisMode = AxisMode.Radial;
			plotOption.config.showNulls = ShowNulls.Gaps;
			plotOption.config.showNaNs = ShowNulls.Connected;
			plotOption.config.innerRadius = 0.80000000000000004;
			plotOption.config.sweep = 270;
			plotOption.config.startAngle = -135;
			plotOption.config.bar = new _PlotBarOption()
			{
				overlap = 1
			};
			dvOption.plots.Add(plotOption);

			_NeedleOverlayOption needleOverlayOption = new _NeedleOverlayOption();
			needleOverlayOption.type = "Needle";
			needleOverlayOption.start = "center";
			needleOverlayOption.endOffset = 10;
			needleOverlayOption.width = 0;
			needleOverlayOption.end = "0,0";
			needleOverlayOption.placement = Placement.Auto;
			needleOverlayOption.position = AnnotationPosition.Outside;
			needleOverlayOption.style = new _OverlayStyleOption()
			{
				fill = new _CssColorOption()
				{
					type = ColorOptionType.CssColor,
					color = "DarkSlateGray"
				},
				stroke = new _CssColorOption()
				{
					type = ColorOptionType.CssColor,
					color = "DarkSlateGray"
				}
			};
			plotOption.config.overlays.Add(needleOverlayOption);

			_TextOverlayOption textOverlayOption = new _TextOverlayOption();
			textOverlayOption.type = "Text";
			textOverlayOption.text = "Text";
			textOverlayOption.display = OverlayDisplay.Front;
			textOverlayOption.placement = Placement.Auto;
			textOverlayOption.position = AnnotationPosition.Center;
			textOverlayOption.pointPath = "center";
			textOverlayOption.offset = "0,12";
			textOverlayOption.textStyle = new _TextStyleOption()
			{
				color = "Black",
				fontSize = "22pt",
				fontFamily = "Arial",
				fontStyle = FontStyle.Normal,
				fontWeight = "700",
				writingMode = TextWritingMode.Horizontal
			};
			plotOption.config.overlays.Add(textOverlayOption);

			_ConfigOption configOption = new _ConfigOption();
			configOption.palette = new List<IPaletteItemOption> {
		new _PaletteItemOption() {
		    color = new _CssColorOption() { type = ColorOptionType.CssColor, color = "rgba(255,0,0,255)" },
		    type = PaletteItemType.Index
		}
	    };
			dvOption.config = configOption;

			_PlotAreaOption plotArea = new _PlotAreaOption();

			_AxisOption xAxis = new _AxisOption();
			xAxis.type = AxisType.X;
			xAxis.plots.Add("Plot1");
			xAxis.position = AxisPosition.None;

			_AxisOption yAxis = new _AxisOption();
			yAxis.type = AxisType.Y;
			yAxis.plots.Add("Plot1");
			yAxis.position = AxisPosition.Far;
			yAxis.title = "value";
			yAxis.max = new _ValueOption()
			{
				type = ValueOptionType.Number,
				value = 500
			};
			plotArea.axes.Add(xAxis);
			plotArea.axes.Add(yAxis);

			var plotAreas = new List<IPlotAreaOption>();
			plotAreas.Add(plotArea);
			dvOption.config.plotAreas = plotAreas;

			dvOption.data = TestDataSource.Builder.DAT_3386();

			// result is svg
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
		}

		// overlays
		public void DAT_2742 (Size size)
		{
			string casePath = @"D:\temp\DAT\2742\case00";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    },
			    category = new _CategoryEncodingOption() { field = "Country" }
			},
			config = new _PlotConfigOption() {
			    overlays = new List<IOverlayOption>() {
				new _ImageOverlayOption() {
				    type = "Image",
				    source = "https://findicons.com/files/icons/2777/sound_and_audio_for_android/96/5_favorite_star.png",
				    pointPath = "$[2]"
				},
				new _TextOverlayOption() {
				    type = "Text",
				    pointPath = "$[0]",
				    text = "Text"
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.GetData()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
		}

		// 
		public void DAT_2746 (Size size)
		{
			string casePath = @"D:\temp\DAT\2746\excludeNulls";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "x, value2" }
			    },
			    details = new List<IDetailEncodingOption> {
				new _DetailEncodingOption() {
				    field = "color",
				    group = Group.Cluster,
				    excludeNulls = true
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.DAT_2746()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// plots(plugins)
		public void DAT_2747 (Size size)
		{
			string casePath = @"D:\temp\DAT\2747\case01";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			name = "p1",
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Score", aggregate = Aggregate.List }
			    },
			    category = new _CategoryEncodingOption() { field = "Name" },
			    text = new List<IContentEncodingOption> {
				new _ContentEncodingOption() { field = "Done" }
			    },
			    color = new _ColorEncodingOption() { field = "Name" }
			},
			config = new _PlotConfigOption() {
			    plugins = new List<IConfigPluginOption>() {
				new _ConfigPluginOption() {
				    type = "DataLabelPlugin",
				    name = "GCESSwappedBarFloatingLabels"
				}
			    },
			    swapAxes = true,
			    bar = new _PlotBarOption() { width = 0.3 },
			    text = new List<IPlotConfigTextOption> {
				new _PlotConfigTextOption() {
				    template = "错误个数：{Done.value}  正确率：{valueField.value:n2}%",
				    style = new _StyleOption() {
					stroke = new _CssColorOption() { color = "green" },
					strokeWidth = 1,
					backgroundColor = new _CssColorOption() { color = "lightblue" }
				    },
				    textStyle = new _TextStyleOption() {
					color = "red",
					fontSize = "16",
					fontFamily = "HelveticaNeueW02-45Ligh,Arial,'Hiragino Kaku Gothic ProN',Meiryo,sans-serif"
				    }
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.DAT_2747()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// overlays(PolynomialTrendline)
		public void DAT_2726 (Size size)
		{
			string casePath = @"D:\temp\DAT\2726\case01";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Scatter",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    },
			    category = new _CategoryEncodingOption() { field = "Country" },
			    details = new List<IDetailEncodingOption> {
				new _DetailEncodingOption() { field = "NewCustomer" }
			    }
			},
			config = new _PlotConfigOption() {
			    overlays = new List<IOverlayOption>() {
				new _PolynomialTrendlineOverlayOption() {
				    type = "PolynomialTrendline",
				    display = OverlayDisplay.Front,
				    order = 4,
				    detailLevel = DetailLevel.Group,
				    detailKey = new List<DataValueType>() { "true" },
				    label = "label"
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.GetData()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// plots(style)
		public void DAT_2745 (Size size)
		{
			string casePath = @"D:\temp\DAT\2745\case01";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    },
			    category = new _CategoryEncodingOption() { field = "Country" }
			},
			config = new _PlotConfigOption() {
			    style = new _DataPointStyleOption() {
				backgroundColor = new _PatternOption() {
				    type = ColorOptionType.Pattern,
				    pattern = new List<IPathWithStyleOption>() {
					new _PathWithStyleOption {
					    style = new _StyleOption() {
						fill = new _CssColorOption() { color = "blue" }
					    },
					    content = "Weave"
					}
				    }
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.GetData()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// transform(Bin)
		public void DAT_2722 (Size size)
		{
			string casePath = @"D:\temp\DAT\2722\case01";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    },
			    category = new _CategoryEncodingOption() { field = "Country" },
			    color = new _ColorEncodingOption() { field = "SalesBin" }
			}
		    }
		},
				transform = new List<ITransformOption> {
		    new _BinTransformOption() {
			bin = new _BinOption() {
			    steps = new List<Double>() { 3000, 6000, 9000, 12000 }
			},
			field = "Sales",
			outputAs = "SalesBin",
			type = TransformType.Bin
		    }
		},
				data = TestDataSource.Builder.GetData()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// overlays
		public void DAT_3575 (Size size)
		{
			string casePath = @"D:\temp\DAT\3575\case05";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    },
			    category = new _CategoryEncodingOption() { field = "Country" },
			    details = new List<IDetailEncodingOption> {
				new _DetailEncodingOption() { field = "NewCustomer" }
			    }
			},
			config = new _PlotConfigOption() {
			    overlays = new List<IOverlayOption>() {
				new _ReferenceLineOverlayOption() {
				    axis = AxisType.Y,
				    display = OverlayDisplay.Front,
				    aggregate = ReferenceLineAggregate.Average,
				    detailLevel = DetailLevel.Group
				},
				new _ReferenceBandOverlayOption() {
				    axis = AxisType.X,
				    display = OverlayDisplay.Back,
				    start = 1,
				    end = 2,
				    style = new _DataPointStyleOption() {
					opacity = 0.5
				    }
				},
				new _TextGroupOverlayOption() {
				    display = OverlayDisplay.Front,
				    pointPath = "$[0]",
				    text = "Text",
				    width = 10
				},
                                //new _TextOverlayOption() {
                                //    display = OverlayDisplay.Front,
                                //    pointPath = "$[0]",
                                //    text = "Text",
                                //    width = 10
                                //},
                                new _ImageOverlayOption() {
				    source = "https://findicons.com/files/icons/2777/sound_and_audio_for_android/96/5_favorite_star.png",
				    pointPath = "$[3]"
				},
				new _LineOverlayOption() {
				    start = "1, 100",
				    end = "4, 6000"
				},
				new _NeedleOverlayOption() {
				    start = "4, 100",
				    end = "1, 6000"
				},
				new _EllipseOverlayOption() {
				    display = OverlayDisplay.Front,
				    height = 30,
				    width = 30,
				    pointPath = "$[1]"
				},
				new _RectangleOverlayOption() {
				    display = OverlayDisplay.Front,
				    height = 30,
				    width = 30,
				    pointPath = "$[2]"
				},
				new _PathAnnotationOption() {
				    pointPath = "center",
				    display = OverlayDisplay.Front,
				    height = 30,
				    width = 30,
                                    //path = new List<String>() {"M 250,75 L 323,301 131,161 369,161 177,301 z"}
                                    path = new List<string>() {"M 250,75 L 323,301 131,161 369,161 177,301 z"}
				},
				new _ErrorBarOption() {
				    direction = ErrorBarDirection.Both
				},
				new _BarLineOverlayOption() {
				    style = new _LineStyleOption {
					stroke = new _CssColorOption() { color = "lightblue" },
					strokeWidth = 2
				    }
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.GetData()
			};
			TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		public void DAT_3575B (Size size)
		{
			string casePath = @"D:\temp\DAT\3575\case02";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    },
			    category = new _CategoryEncodingOption() { field = "Company" }
			},
			config = new _PlotConfigOption() {
			    overlays = new List<IOverlayOption>() {
				new _LinearTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _PolynomialTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _ExponentialTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _PowerTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _LogarithmicTrendlineOverlayOption(){
				    display = OverlayDisplay.Front
				},
				new _FourierTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _SimpleMovingAverageTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _CumulativeMovingAverageTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _WeightedMovingAverageTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _MovingAnnualTotalTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				},
				new _ExponentialTrendlineOverlayOption() {
				    display = OverlayDisplay.Front
				}
			    }
			}
		    }
		},
				data = TestDataSource.Builder.GetData()
			};
			TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// transform(unpivot)
		public void DAT_3991 (Size size)
		{
			string casePath = @"D:\temp\DAT\3991\case01";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption> {
		    new _PlotOption() {
			type = "Bar",
			data = "unpivotData",
			encodings = new _PlotEncodingsOption() {
			    values = new List<IValueEncodingOption>() {
				new _FieldsValueEncodingOption() { field = "value" }
			    },
			    category = new _CategoryEncodingOption() { field = "category" },
			    color = new _ColorEncodingOption() { field = "category" },
			    backgroundColor = new _BackgroundColorEncodingOption() { field = "category" },
			    shape = new _ShapeEncodingOption() { field = "category" },
			    size = new _SizeEncodingOption() { field = "value" }
			}
		    }
		},
				config = new _ConfigOption()
				{
					legend = new _GlobalLegendOption()
					{
						position = LegendPosition.None
					}
				},
				transform = new List<ITransformOption> {
		    new _UnpivotTransformOption() {
			type = TransformType.Unpivot,
			outputAs = "unpivotData",
			valueFieldAs = "value",
			category = new _UnpivotCategoryOption() {
			    fieldAs = "category",
			    from = new List<string> {
				"OnTime (Sum)",
				"NotOnTime (Sum)",
				"AwaitingApproval (Sum)"
			    }
			}
		    }
		},
				data = TestDataSource.Builder.DAT_3991()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			//var jsonContents = dvOption.ToJson();
			//File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}

		// SjsLegendViewManagerPlugin
		public void DAT_4281 (Size size)
		{
			string casePath = @"D:\temp\DAT\4281\case01";

			_DvOption dvOption = new _DvOption();

			_PlotOption plotOption = new _PlotOption();
			plotOption.type = "Bar";
			plotOption.encodings.values = new List<IValueEncodingOption>() { new _FieldsValueEncodingOption { field = "Sales" } };
			plotOption.encodings.category = new _CategoryEncodingOption() { field = "Country" };
			plotOption.encodings.color = new _ColorEncodingOption() { field = "Country" };
			dvOption.plots.Add(plotOption);

			_ConfigOption configOption = new _ConfigOption();
			dvOption.config = configOption;

			_PlotAreaOption plotArea = new _PlotAreaOption();
			var plotAreas = new List<IPlotAreaOption>();
			plotAreas.Add(plotArea);

			var plugins = new List<IConfigPluginOption>();
			var sjsplugin = new _ConfigPluginOption();
			sjsplugin.name = "SjsLegendViewManagerPlugin";
			sjsplugin.type = "LegendViewManagerModel";
			plugins.Add(sjsplugin);

			plotArea.plugins = plugins;

			_SjsLegendViewManagerOption legendPluginOption = new _SjsLegendViewManagerOption();
			legendPluginOption.excelPosition = SjsLegendPosition.Bottom;
			plotArea.plugins[0].arguments = legendPluginOption;

			dvOption.config.plotAreas = plotAreas;

			dvOption.data = TestDataSource.Builder.GetData();

			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			//var jsoncontents = dvoption.tojson();
			//file.writealltext(casepath + "_tojson.json", jsoncontents);
		}
		#endregion

		#region ToJson
		public void DAT_3592 (Size size)
		{
			string casePath = @"D:\temp\DAT\3592\Candlestick_HLOC_HLO";
			//Candlestick_HLOC_HL Candlestick_HLOC_HLC Candlestick_HLOC_HLO 
			// Load Json
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			// before
			var jsonBefore = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson_Before.json", jsonBefore);

			// result is png
			TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

			// result is svg
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));

			// after
			var jsonAfter = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson_After.json", jsonAfter);
		}

		public void DAT_3807 (Size size)
		{
			string casePath = @"D:\temp\DAT\3807\Node_Flow";
			// Load Json
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			//
			var toJson = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", toJson);

			// before
			var jsonBefore = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson_Before.json", jsonBefore);

			// result is png
			TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

			// result is svg
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));

			// after
			var jsonAfter = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson_After.json", jsonAfter);
		}
		#endregion

		// culture
		public void DAT_3609 (Size size)
		{
			double numberDecimalSeparator = 1.2;
			System.Console.WriteLine("Current: " + numberDecimalSeparator.ToString());

			var savedCulture = Thread.CurrentThread.CurrentCulture;
			//System.Console.WriteLine(savedCulture);     // en-US

			var culture = new CultureInfo("en-US");
			culture.NumberFormat.NumberDecimalSeparator = ",";
			Thread.CurrentThread.CurrentCulture = culture;

			System.Console.WriteLine("Modify: " + numberDecimalSeparator.ToString());

			string casePath = @"D:\temp\DAT\3609\model";
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			// result is png
			TestRenderEngine.Builder.DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));

			Thread.CurrentThread.CurrentCulture = savedCulture;
			System.Console.WriteLine("Restore： " + numberDecimalSeparator.ToString());
		}

		#region Runtime
		public void DAT_3359 (Size size)
		{
			string casePath = @"D:\temp\DAT\3359\case01";
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);
			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			FlexDV dv = new FlexDV(dvOption, size, renderEngine, null);
			dv.Paint();
			var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
			string svgResult = svgRenderEngine.Svg.ToString();
			File.WriteAllText(casePath + ".svg", svgResult);

			var dvModel = dv.Model;
			if (dvModel != null)
			{
				System.Console.WriteLine(dvModel.type);
				var flexDvModel = dvModel.queryInterface("IFlexDvModel") as IFlexDvModel;
				if (flexDvModel != null)
				{
					System.Console.WriteLine(flexDvModel.type);
				}
			}
		}

		/*
		* legend kind
		* var kind = dv.Model.plotAreas[0].legends[0].kind;
		* color 1  shape 2  size 4  overlay 8   backgrounColor 16
		*/
		public void DAT_3655 (Size size)
		{
			string casePath = @"D:\temp\DAT\3655\Color_String";
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			GcBitmap bmp = new GcBitmap((int)size.width, (int)size.height, false);
			bmp.ApplyLicenseKey("GrapeCity Internal Use Only,215564869134247#A0iymiOiQWSisnOiQkIsISP3EkYCdGW6d4a6VUUHVjYI3yMsB7R4QXdNBFR8NFa6tmUXBnSLtUTxMDaGRnbQNEallWTxdTYJVnc4xmbl3EcydVMupXZphGRD9mavwkQBRkeG36cRlVZiojITJCL7gTO7QzNyITN0IicfJye&Qf35VfikDVLZkI0IyQiwiIzYHI4VmTuAyZul6Zh5WSgI7bmBCduVWb5N6bEByQHJiOi8kI1tlOiQmcQJCLicTM5IDNwACOwATM9EDMyIiOiQncDJCLiU6cVByZulGdzVGVgI7bGJiOiEmTDJCLicDNyQzMxkjN8Qju3nT");
			using (GcBitmapGraphics g = bmp.CreateGraphics(System.Drawing.Color.Transparent))
			{
				CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
				PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

				PluginCollection customPluginCollection = new PluginCollection();
				CustomStringFormattingPlugin customStringFormattingPlugin = new CustomStringFormattingPlugin();
				customPluginCollection.register(customStringFormattingPlugin);

				GcImageRenderEngine renderEngine = new GcImageRenderEngine(g, new GcImageTextMetrics(g));
				using (FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, new GcImageInfoBuilder()))
				{
					dv.Paint();
					var kind = dv.Model.plotAreas[0].legends[0].kind;
					Console.WriteLine("legend kind: " + kind);
				}
			}
		}

		public void DAT_3969 (Size size)
		{
			Dictionary<string, object> pointsDict = new Dictionary<string, object>();
			string casePath = @"D:\temp\DAT\3969\DAT-3949-Index-Next";
			casePath = @"D:\temp\DAT\3969\DAT-3949-Previous";
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			GcBitmap bmp = new GcBitmap((int)size.width, (int)size.height, false);
			bmp.ApplyLicenseKey("GrapeCity Internal Use Only,215564869134247#A0iymiOiQWSisnOiQkIsISP3EkYCdGW6d4a6VUUHVjYI3yMsB7R4QXdNBFR8NFa6tmUXBnSLtUTxMDaGRnbQNEallWTxdTYJVnc4xmbl3EcydVMupXZphGRD9mavwkQBRkeG36cRlVZiojITJCL7gTO7QzNyITN0IicfJye&Qf35VfikDVLZkI0IyQiwiIzYHI4VmTuAyZul6Zh5WSgI7bmBCduVWb5N6bEByQHJiOi8kI1tlOiQmcQJCLicTM5IDNwACOwATM9EDMyIiOiQncDJCLiU6cVByZulGdzVGVgI7bGJiOiEmTDJCLicDNyQzMxkjN8Qju3nT");
			using (GcBitmapGraphics g = bmp.CreateGraphics(System.Drawing.Color.Transparent))
			{
				CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
				PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

				PluginCollection customPluginCollection = new PluginCollection();
				CustomStringFormattingPlugin customStringFormattingPlugin = new CustomStringFormattingPlugin();
				customPluginCollection.register(customStringFormattingPlugin);

				GcImageRenderEngine renderEngine = new GcImageRenderEngine(g, new GcImageTextMetrics(g));
				using (FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, new GcImageInfoBuilder()))
				{
					dv.Paint();

					// Index-Next
					//var points = dv.Model.plotAreas[0].plotsPanes[0].plots[0].points[0];
					//var getPoints = points.GetType().GetProperties();
					//foreach (var point in getPoints)
					//{
					//    if (!point.Name.StartsWith("_"))
					//    {
					//        if (point.Name.Equals("index") || point.Name.Equals("next"))
					//        {
					//            var propertyValue = point.GetValue(points, null);
					//            pointsDict.Add(point.Name, propertyValue);
					//        }
					//    }
					//}

					// Previous
					var parent = dv.Model.plotAreas[0].plotsPanes[0].plots[0].points[0].parent;
					var getParent = parent.GetType().GetProperties();
					foreach (var item in getParent)
					{
						if (!item.Name.StartsWith("_") && item.Name.Equals("points"))
						{
							Console.WriteLine(item.Name);
							if (item.PropertyType.Name.Equals("List`1"))
							{
								var propertys = getParent as System.Collections.IEnumerable;
								foreach (var property in propertys)
								{
									Console.WriteLine(property);
								}
							}
						}
					}
				}
			}

			WriteFile(casePath, pointsDict);
		}

		public void DAT_0000 (Size size)
		{
			string casePath = @"D:\temp\DAT\0000\case02";
			_DvOption dvOption = new()
			{
				plots = new List<IPlotOption>() {
		    new _PlotOption() {
			encodings = new _PlotEncodingsOption() {
			    category = new _CategoryEncodingOption() { field = "Country" },
			    color = new _ColorEncodingOption() { field = "Country" },
			    values = new List < IValueEncodingOption > () {
				new _FieldsValueEncodingOption() { field = "Sales" }
			    }
			},
			type = "Bar"
		    }
		},
				config = new _ConfigOption()
				{
					plotAreas = new List<IPlotAreaOption>() {
			new _PlotAreaOption() {
			    plugins = new List < IConfigPluginOption > () {
				new _ConfigPluginOption() {
				    name = "SjsLegendViewManagerPlugin",
				    type = "LegendViewManagerModel",
				    arguments = new _SjsLegendViewManagerOption() {
					excelPosition = SjsLegendPosition.Bottom,
					showLegendWithoutOverlappingChart = true
				    }
				}
			    }
			}
		    }
				},
				data = TestDataSource.Builder.GetData()
			};
			File.WriteAllText(casePath + ".svg", TestRenderEngine.Builder.DrawSvg(dvOption, size));
			var jsonContents = dvOption.ToJson();
			File.WriteAllText(casePath + "_ToJson.json", jsonContents);
		}
		#endregion

		#region Inject
		public void DAT_4447 (Size size, string casePath, List<int> index)
		{
			Dictionary<string, object> pointsDict = new Dictionary<string, object>();
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
			PluginCollection.defaultPluginCollection.register(new CustomCalculateEnginePlugin());
			PluginCollection customPluginCollection = new PluginCollection();

			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();
			FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, imageInfoBuilder);

			dv.Paint();

			//  
			var pts = dv.Model.plotAreas[0].plotsPanes[0].plots[0].points;
			void SetTotal (IPointModel point)
			{
				var waterfallPoint = point as IWaterfallPointModel;
				if (waterfallPoint != null)
				{
					waterfallPoint.waterfallType = "Total";
				}
			}

			for (int i = 0; i < index.Count; i++)
			{
				SetTotal(pts[index[i]]);
			}

			dv.Paint();

			if (dv.RenderEngine is ISvgRenderEngineApi)
			{
				var svgRenderEngine = dv.RenderEngine as ISvgRenderEngineApi;
				string result = svgRenderEngine.Svg.ToString();
				File.WriteAllText(casePath + "_CSharp.svg", result);
			}
		}
		#endregion

		public void RunTimeModel (Size size, string casePath)
		{
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			_DvOption dvOption = new _DvOption(dvJson);

			PluginCollection.defaultPluginCollection.register(new CustomCalculateEnginePlugin());
			PluginCollection customPluginCollection = new PluginCollection();
			IRenderEngine renderEngine = new _SvgRenderEngine(new SvgTextMetrics());
			IImageInfoBuilder imageInfoBuilder = new SvgImageInfoBuilder();

			FlexDV dv = new FlexDV(dvOption, size, renderEngine, customPluginCollection, imageInfoBuilder);

			List<object> visitedTypes = new List<object>();
			var result = GenerateRunTimeModel(dv.Model, visitedTypes);
			//var dictionaryFilter = TraversalDictionary(result);
			WriteFile(casePath, result);
		}

		private Dictionary<string, object> GenerateRunTimeModel (object models, List<object> visitedTypes)
		{
			Dictionary<string, object> dictionaryRoot = new Dictionary<string, object>();

			if (visitedTypes.Contains(models))
			{
				return dictionaryRoot;
			}
			visitedTypes.Add(models);

			foreach (var item in models.GetType().GetProperties())
			{
				if (!item.Name.StartsWith("_") && !item.ReflectedType.Name.Equals("Dictionary`2"))
				{
					var propertyValue = item.GetValue(models, null);
					if (item.PropertyType.Name.Equals("List`1"))
					{
						var propertys = propertyValue as System.Collections.IEnumerable;
						foreach (var property in propertys)
						{
							List<object> child = new List<object>();
							Dictionary<string, object> dictionaryChild = GenerateRunTimeModel(property, visitedTypes);
							child.Add(dictionaryChild);
							if (!dictionaryRoot.ContainsKey(item.Name))
							{
								dictionaryRoot.Add(item.Name, child);
							}
						}
					}
					else if (item.Name.Equals("parent"))
					{
					}
					else if (item.Name.Equals("Module"))
					{
					}
					else if (item.Name.Equals("GetMethod"))
					{
					}
					//else if (item.PropertyType.Equals("Dictionary`2"))
					//{
					//}
					else if (propertyValue is FlexDV)
					{
					}
					else if (propertyValue is Enum)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is Int32)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is double)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is string)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is Boolean)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue == null)
					{
						dictionaryRoot.Add(item.Name, null);
					}
					else if (propertyValue is Point)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is Size)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is IConfigOption)
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
					else if (propertyValue is IHeaderFooterModel || propertyValue is ISelectionStyleOption || propertyValue is ICssColor
					    || propertyValue is ILegendItemLabelView || propertyValue is ILegendItemSymbolModel || propertyValue is ILineAxisView
					    //|| propertyValue is IDataPointStyleOption || propertyValue is IBarCartesianSeriesView || propertyValue is IXyBarCartesianPointView
					    || propertyValue is IPlotConfigTextOption || propertyValue is IPlotConfigTooltipOption || propertyValue is IBarCartesianPlotView
					    || propertyValue is IPlotAreaView || propertyValue is IPlotOption)
					{
						var itemTypes = item.GetType().GetProperties();
						foreach (var itemType in itemTypes)
						{
							List<object> child = new List<object>();
							Dictionary<string, object> dictionaryChild = GenerateRunTimeModel(itemType, visitedTypes);
							child.Add(dictionaryChild);
							if (!dictionaryRoot.ContainsKey(item.Name))
							{
								dictionaryRoot.Add(item.Name, child);
							}
						}
					}
					else
					{
						dictionaryRoot.Add(item.Name, propertyValue);
					}
				}
			}
			return dictionaryRoot;
		}

		private void WriteFile (string path, Dictionary<string, object> contents)
		{
			//System.Console.WriteLine("---------------------------------WriteFile--------------------------------------------");
			string content = JsonConvert.SerializeObject(contents);
			File.WriteAllText(path + "_.json", content);
		}

		private Dictionary<string, object> TraversalDictionary (Dictionary<string, object> dictionarys)
		{
			foreach (var item in dictionarys)
			{
				if (item.Key == "type")
				{
					System.Console.WriteLine("--------------" + item.Value);
				}
				if (item.Value is List<object>)
				{
					System.Console.WriteLine(item.Key + "\t" + item.Value);
					var itemDict = dictionarys[item.Key];
					var itemList = itemDict as System.Collections.IEnumerable;
					foreach (var list in itemList)
					{
						var dicts = list as Dictionary<string, object>;
						TraversalDictionary(dicts);
					}
				}
				else
				{
					System.Console.WriteLine(item.Key + "\t" + item.Value);
				}
			}
			return dictionarys;
		}

		#region Performance
		public void DAT_3846 (Size size, string path, string type)
		{
			string plot = string.Empty;
			if (path.Contains("Bar"))
			{
				plot = "Bar";
			}
			else if (path.Contains("Line"))
			{
				plot = "Line";
			}
			else if (path.Contains("Scatter"))
			{
				plot = "Scatter";
			}
			else if (path.Contains("Pie"))
			{
				plot = "Pie";
			}

			switch (type)
			{
				case "1k":
					Console.WriteLine("The " + plot + " chart data points 1k: ");
					this.PerformanceCase(size, Path.Combine(path, type));
					break;
				case "5k":
					Console.WriteLine("The " + plot + " chart data points 5k: ");
					this.PerformanceCase(size, Path.Combine(path, type));
					break;
				case "1w":
					Console.WriteLine("The " + plot + " chart data points 1w: ");
					this.PerformanceCase(size, Path.Combine(path, type));
					break;
				case "2w":
					Console.WriteLine("The " + plot + " chart data points 2w: ");
					this.PerformanceCase(size, Path.Combine(path, type));
					break;
				case "5w":
					Console.WriteLine("The " + plot + " chart data points 5w: ");
					this.PerformanceCase(size, Path.Combine(path, type));
					break;
				default:
					break;
			}
		}

		internal void PerformanceCase (Size size, string casePath)
		{
			Stopwatch readFile = new Stopwatch();
			readFile.Start();
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			readFile.Stop();
			Console.WriteLine("Read Json Spend: " + readFile.ElapsedMilliseconds + " ms");

			Stopwatch drawSvg = new Stopwatch();
			drawSvg.Start();
			_DvOption dvOption = new _DvOption(dvJson);
			string contents = TestRenderEngine.Builder.DrawSvg_Performance(dvOption, size);
			drawSvg.Stop();
			Console.WriteLine("SVG Paint Spend: " + drawSvg.ElapsedMilliseconds + " ms");

			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", contents);
		}

		internal void PerformanceCase (Size size, string casePath, int numbner)
		{
			Console.WriteLine("The data points " + numbner + ": ");

			Stopwatch readFile = new Stopwatch();
			readFile.Start();
			string sourceJson = File.ReadAllText(casePath + ".json");
			JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
			readFile.Stop();
			Console.WriteLine("Read Json Spend: " + readFile.ElapsedMilliseconds + " ms");

			Stopwatch drawSvg = new Stopwatch();
			drawSvg.Start();
			_DvOption dvOption = new _DvOption(dvJson);
			string contents = TestRenderEngine.Builder.DrawSvg_Performance(dvOption, size);
			drawSvg.Stop();
			Console.WriteLine("SVG Paint Spend: " + drawSvg.ElapsedMilliseconds + " ms");

			// result is svg
			File.WriteAllText(casePath + "_CSharp.svg", contents);
		}

		//public void DAT_4035(Size size, string path, int numbner)
		//{
		//    Console.WriteLine("The data points "+ numbner + ": ");
		//    this.PerformanceCase(size, path);
		//}
		#endregion


		public void DAT_4483 ()
		{
			var builder = _PathCommandBuilder._defaultPathCommandBuilder;

			var commands = new List<IPathCommand>();

			commands.push(builder._buildMoveToPathCommand(350, 200));
			commands.push(builder._buildCanvasArcToPathCommand(175, 200, 0, 175, 200, 0, 2 * System.Math.PI - 0.001, 0));
			commands.push(builder._buildClosePathCommand());

			var path = _PathBuilder._defaultPathBuilder._buildPath(commands);

			// M 350 200 A 175 200 0 1 1 349.9999125000073 199.80000003333322Z
			Console.WriteLine(path.expression);
		}

	}
}
