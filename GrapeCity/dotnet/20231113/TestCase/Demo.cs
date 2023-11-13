using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using GrapeCity.DataVisualization.Chart;
using GrapeCity.DataVisualization.Console.Plugins;
using GrapeCity.DataVisualization.Console.Testings.Engines;
using GrapeCity.DataVisualization.Options;
//using GrapeCity.DataVisualization.Plugins.ExcelCalculationEngine;
using GrapeCity.DataVisualization.Plugins.GcImageRenderEngine.Imaging;
using GrapeCity.DataVisualization.Plugins.SvgRenderEngine;
using GrapeCity.DataVisualization.Plugins.SvgRenderEngine.Image;
using GrapeCity.Documents.Imaging;
using Newtonsoft.Json;

namespace GrapeCity.DataVisualization.Console
{
    class Demo
    {
        internal static void JsonLoad(Size size, string casePath)
        {
            string sourceJson = File.ReadAllText(casePath + ".json");
            JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
            _DvOption dvOption = new _DvOption(dvJson);

            //dvOption.data = DAT_3287();
            //dvOption.data = DAT_3323();
            //dvOption.data = DAT_3356();

            //Stopwatch drawImage = new Stopwatch();
            //drawImage.Start();
            // result is png
            DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
            //drawImage.Stop();
            //System.Console.WriteLine("Image Render Spend: " + drawImage.ElapsedMilliseconds);

            //Stopwatch drawSvg = new Stopwatch();
            //drawSvg.Start();
            // result is svg
            File.WriteAllText(casePath + "_CSharp.svg", DrawSvg(dvOption, size));
            //drawSvg.Stop();
            //System.Console.WriteLine("Svg Render Spend: " + drawSvg.ElapsedMilliseconds);

            //try
            //{
            //    string sourceJson = File.ReadAllText(casePath + ".json");
            //    JsonElement dvJson = JsonDocument.Parse(sourceJson).RootElement.Clone();
            //    _DvOption dvOption = new _DvOption(dvJson);

            //    //dvOption.data = DAT_3287();
            //    //dvOption.data = DAT_3323();
            //    //dvOption.data = DAT_3356();

            //    // result is png
            //    DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

            //    // result is svg
            //    File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
            //}
            //catch (Exception e)
            //{
            //    e = FilterTargetInvocationException(e);
            //    string exceptionType = e.GetType().ToString();
            //    string exceptionMessage = e.Message;
            //    File.WriteAllText(casePath + "_Exception.txt", exceptionType + ":\n" + exceptionMessage);
            //}
        }

        internal static Exception FilterTargetInvocationException(Exception exception)
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

        internal static void EncodingFormat(Size size)
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
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
        }

        internal static void ToJson(Size size, string casePath)
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
            DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

            // result is svg
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));

            //// after
            //var jsonAfter = dvOption.ToJson();
            //File.WriteAllText(casePath + "_ToJson_After.json", jsonAfter);
        }

        internal static void FullOption()
        {
            _DvOption dvOption = new()
            {
                plots = new List<IPlotOption> {
                    new _PlotOption() {
                        type = "Line",
                        encodings = new _PlotEncodingsOption() {
                            values = new List<IValueEncodingOption>() {
                                new _FieldsValueEncodingOption() {
                                    field = "Sales",
                                    aggregate = Aggregate.List,
                                    label = "",
                                    excludeNulls = true,
                                    sort = new List<ISortEncodingOption> {
                                        new _SortEncodingOption() {
                                            field = "",
                                            order = OrderType.Ascending,
                                            aggregate = Aggregate.PopulationStandardDeviation
                                        }
                                    }
                                },
                                new _FieldsValueEncodingOption { field = "Downloads" },
                                new _RangeFieldValueEncodingOption {
                                    field = new _RangeFieldOption {
                                        lower = "",
                                        upper = "" },
                                    aggregate = Aggregate.Max,
                                    excludeNulls = false,
                                    label = new _RangeFieldOption() {
                                        lower = "",
                                        upper = ""
                                    }
                                },
                                new _StockFieldValueEncodingOption {
                                    field = new _StockFieldOption {
                                        close = "close",
                                        high = "high",
                                        low = "low",
                                        open = "open",
                                        x = "date"
                                    }
                                }
                            },
                            category = new _CategoryEncodingOption() {
                                field = "Country",
                                label = "",
                                excludeNulls = true,
                                sort = new _SortEncodingOption() {
                                    order = OrderType.Descending,
                                    field = "",
                                    aggregate = Aggregate.Average
                                }
                            },
                            details = new List<IDetailEncodingOption> {
                                new _DetailEncodingOption() {
                                    field = "",
                                    group = Group.Cluster,
                                    excludeNulls = true,
                                    label = "",
                                    sort = new _SortEncodingOption() {
                                        order = OrderType.Descending,
                                        field = "",
                                        aggregate = Aggregate.Average
                                    }
                                }
                            },
                            color = new _ColorEncodingOption() {
                                field = "Country",
                                label = "",
                                aggregate = Aggregate.Average,
                                sort = new _SortEncodingOption() {
                                    order = OrderType.Descending,
                                    field = "",
                                    aggregate = Aggregate.Average
                                },
                                items = new List<ILegendItemEncodingOption> {
                                    new _LegendItemEncodingOption() {
                                        title = "",
                                        ruleType = "Increase"
                                    },
                                    new _LegendItemEncodingOption() {
                                        title = "",
                                        ruleType = "Decrease"
                                    }
                                }
                            },
                            size = new _SizeEncodingOption() {
                                field = "Sales",
                                label = "",
                                aggregate = Aggregate.Average,
                                sort = new _SortEncodingOption() {
                                    order = OrderType.Descending,
                                    field = "",
                                    aggregate = Aggregate.Average
                                }
                            },
                            shape = new _ShapeEncodingOption() {
                                field = "NewCustomer",
                                label = "",
                                aggregate = Aggregate.Average,
                                sort = new _SortEncodingOption() {
                                    order = OrderType.Descending,
                                    field = "",
                                    aggregate = Aggregate.Average
                                }
                            },
                            text = new List<IContentEncodingOption> {
                                new _ContentEncodingOption() {
                                    field = "",
                                    label = "",
                                    aggregate = Aggregate.Average
                                },
                                new _ContentEncodingOption() { }
                            },
                            tooltip = new List<IContentEncodingOption>() {
                                new _ContentEncodingOption() {
                                    field = "",
                                    label = "",
                                    aggregate = Aggregate.Average
                                },
                                new _ContentEncodingOption() { }
                            },
                            layout = new _LayoutEncodingOption() {
                                type = "Trellis",
                                field = "",
                                label = "",
                                // columnSort  does not
                                // rowSort
                            },
                            backgroundColor = new _BackgroundColorEncodingOption() {
                                field = "",
                                label = "",
                                sort = new _SortEncodingOption() {
                                    order = OrderType.Descending,
                                    field = "",
                                    aggregate = Aggregate.Average
                                },
                                aggregate = Aggregate.Average
                            }
                        },
                        //config = new _PlotConfigOption() {
                        config = new _SankeyPlotConfigOption() {
                            axisMode = AxisMode.Radial,
                            symbols = true,
                            sweep = 90,
                            startAngle = 90,
                            innerRadius = 0.3,
                            swapAxes = true,
                            lineAspect = LineAspect.StepCenter,
                            offset = new List<IValueOption>() {
                                new _ValueOption() { 
                                    type = ValueOptionType.Percentage,
                                    value = 0.5
                                }
                            },
                            showNulls = ShowNulls.Connected,
                            showNaNs = ShowNulls.Gaps,
                            clippingMode = ClippingMode.Clip,
                            style = new _DataPointStyleOption() {
                                backgroundColor = new _RadialGradientOption() {
                                    //type = ColorOptionType.Radial,    --this is default value
                                    extentKeyword = GradientExtentKeyword.FarthestCorner,
                                    position = new List<IGradientPositionOption>() {
                                        new _GradientPositionOption {
                                            keyword = GradientPositionKeyword.Bottom,
                                            offset = 1
                                        }
                                    },
                                    colorStops = new List<IColorStopOption> {
                                        new _ColorStopOption { color = "red" },
                                        new _ColorStopOption { color = "white" },
                                        new _ColorStopOption { color = "red" }
                                    }
                                },
                                //backgroundColor = new _LinearGradientOption()
                                //{
                                //    angle = 0.5
                                //},
                                //backgroundColor = new _CssColorOption() { color = "lithblue" },
                                opacity = 0.5,
                                //fill = new _CssColorOption() { color = "red" },
                                fill = new _PatternOption() {
                                    //type = ColorOptionType.Pattern,
                                    color = new _CssColorOption() { color = "" },
                                    pattern = new List<IPathWithStyleOption>() {
                                        new _PathWithStyleOption {
                                            style = new _StyleOption() {
                                                stroke = new _CssColorOption() { color = "" },
                                                strokeWidth = 1,
                                                fill = new _CssColorOption() { color = "" }
                                            },
                                            content = "path:Weave"
                                        },
                                        new _PathWithStyleOption { }
                                    }
                                },
                                stroke = new _CssColorOption() { color = "blue" },
                                strokeWidth = new _StrokeWidthOption() { top = 2 },
                                strokeDasharray = "3, 3",
                                strokeOpacity = 0.1,
                                symbolOpacity = 0.1,
                                symbolStrokeOpacity = 0.1,
                                symbolFill = new _LinearGradientOption() {
                                    angle = 0.5,
                                    colorStops = new List<IColorStopOption> {
                                        new _ColorStopOption { color = "red" },
                                        new _ColorStopOption { color = "white" },
                                        new _ColorStopOption { color = "red" }
                                    }
                                },
                                //symbolFill = new _CssColorOption() { color = "" },
                                symbolStroke = new _CssColorOption() { color = "" },
                                symbolStrokeWidth = 2,
                                symbolStrokeDasharray = "1, 1",
                                symbolShape = "",
                                symbolSize = 10,
                                borderRadius = new _BorderRadiusOption() {
                                    verticalRadius = new _BorderRadiusValueOption() {
                                        topLeft = new _ValueOption() {
                                            type = ValueOptionType.Pixel,
                                            value = 20
                                        },
                                        topRight = new _ValueOption() { type = ValueOptionType.Number, value = 20 },
                                        bottomLeft = new _ValueOption() { value = 10 },
                                        bottomRight = new _ValueOption() { value = 10 }
                                    },
                                    horizontalRadius = new _BorderRadiusValueOption() {
                                        topLeft = new _ValueOption() { type = ValueOptionType.Pixel, value = 20 },
                                        topRight = new _ValueOption() { type = ValueOptionType.Number, value = 20 },
                                        bottomLeft = new _ValueOption() { },
                                        bottomRight = new _ValueOption() { }
                                    }
                                }
                            },
                            textStyle = new _TextStyleOption() {
                                color = "",
                                fontSize = "",
                                fontFamily = "",
                                fontStyle = FontStyle.Italic,
                                fontWeight = "",
                                textDecoration = new _TextDecorationOption() {
                                    lineThrough = true,
                                    overline = false,
                                    underline = true
                                },
                                overflow = TextOverflow.Clip,
                                opacity = 0.1,
                                writingMode = TextWritingMode.Horizontal
                            },
                            text = new List<IPlotConfigTextOption> {
                                new _PlotConfigTextOption() {
                                    scope = "",
                                    template = "",
                                    //offset = 0,
                                    //position = TextPosition.Center,
                                    //linePosition = LinePosition.Auto,
                                    //connectingLine = new _LineStyleOption() {
                                    //    opacity = 0.5,
                                    //    stroke = new _CssColorOption() { color = "" },
                                    //    strokeWidth = 2,
                                    //    strokeDasharray = ""
                                    //},
                                    overlappingLabels = OverlappingLabels.Auto,
                                    style = new _StyleOption() {
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 2,
                                        strokeDasharray = "",
                                        backgroundColor = new _CssColorOption() { color = "" }
                                    },
                                    textStyle = new _TextStyleOption() {
                                        color = "",
                                        fontSize = "",
                                        fontFamily = "",
                                        fontStyle = FontStyle.Italic,
                                        fontWeight = "",
                                        textDecoration = new _TextDecorationOption() {
                                            lineThrough = true,
                                            overline = false,
                                            underline = true
                                        },
                                        overflow = TextOverflow.Clip,
                                        opacity = 0.1,
                                        writingMode = TextWritingMode.Vertical
                                    },
                                    format = new _FormatOption() {
                                        type = "Thousands",
                                        value = ""
                                    }
                                },
                                new _PlotConfigTextOption() { }
                            },
                            hoverStyle = new _DataPointStyleOption() {
                                opacity = 0.5,
                                fill = new _PatternOption() {
                                    color = new _CssColorOption() { color = "" },
                                    pattern = new List<IPathWithStyleOption>() {
                                        new _PathWithStyleOption {
                                            style = new _StyleOption() {
                                                stroke = new _CssColorOption() { color = "" },
                                                strokeWidth = 1,
                                                fill = new _CssColorOption() { color = "" }
                                            },
                                            content = "path:Weave"
                                        },
                                        new _PathWithStyleOption { }
                                    }
                                },
                                stroke = new _CssColorOption() { color = "blue" },
                                strokeWidth = new _StrokeWidthOption() { top = 2 },
                                strokeDasharray = "3, 3",
                                strokeOpacity = 0.1,
                                symbolOpacity = 0.1,
                                symbolStrokeOpacity = 0.1,
                                symbolFill = new _CssColorOption() { color = "" },
                                symbolStroke = new _CssColorOption() { color = "" },
                                symbolStrokeWidth = 2,
                                symbolStrokeDasharray = "1, 1"
                            },
                            tooltip = new List<IPlotConfigTooltipOption> {
                                new _PlotConfigTooltipOption() {
                                    scope = "",
                                    template = "",
                                    style = new _StyleOption() {
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 2,
                                        strokeDasharray = "",
                                        backgroundColor = new _CssColorOption() { color = "" }
                                    },
                                    textStyle = new _TextStyleOption() {
                                        color = "",
                                        fontSize = "",
                                        fontFamily = "",
                                        fontStyle = FontStyle.Italic,
                                        fontWeight = "",
                                        textDecoration = new _TextDecorationOption() {
                                            lineThrough = true,
                                            overline = false,
                                            underline = true
                                        },
                                        overflow = TextOverflow.Clip,
                                        opacity = 0.1
                                    }
                                }
                            },
                            rules = new List<IRuleOption>() {
                                new _RuleOption() {
                                    condition = "",
                                    type = "",
                                    actions = new List<IRuleActionOption>() {
                                        new _RuleActionOption {
                                            targetElement = "",
                                            properties = new List<IRuleActionPropertyOption>() {
                                                new _RuleActionPropertyOption {
                                                    name = "",
                                                    value = ""
                                                },
                                                new _RuleActionPropertyOption { }
                                            }
                                        }
                                    }
                                },
                                new _RuleOption() { }
                            },
                            palette = new List<IPaletteItemOption>() {
                                new _PaletteItemOption() {
                                    color = new _CssColorOption() { color = "red" },
                                    data = ""
                                },
                                new _PaletteItemOption() {
                                    color = new _RadialGradientOption() {
                                        extentKeyword = GradientExtentKeyword.FarthestCorner,
                                        position = new List<IGradientPositionOption>() {
                                            new _GradientPositionOption {
                                                keyword = GradientPositionKeyword.Bottom,
                                                offset = 1
                                            }
                                        },
                                        colorStops = new List<IColorStopOption> {
                                            new _ColorStopOption { color = "red" },
                                            new _ColorStopOption { color = "white" },
                                            new _ColorStopOption { color = "red" }
                                        }
                                    }
                                }
                            },
                            seriesStyles = new List<ISeriesStyleOption> {
                                new _SeriesStyleOption() {
                                    key = "c1",
                                    valueField = "value12",
                                    backgroundColor = new _CssColorOption() { color = "" },
                                    borderRadius = new _BorderRadiusOption() { },
                                    fill = new _CssColorOption() { color = "" },
                                    symbols = false,
                                    opacity = 0.5,
                                    stroke = new _CssColorOption() { color = "" },
                                    strokeWidth = new _StrokeWidthOption() { bottom = 2 },
                                    strokeDasharray = "",
                                    strokeOpacity = 0.1,
                                    symbolFill = new _CssColorOption() { color = "" },
                                    symbolStroke = new _CssColorOption() { color = "" },
                                    symbolOpacity = 0.1,
                                    symbolStrokeWidth = 2,
                                    symbolStrokeDasharray = "",
                                    symbolStrokeOpacity = 0.1,
                                    symbolSize = 20,
                                    symbolShape = ""
                                },
                                new _SeriesStyleOption() { }
                            },
                            bar = new _PlotBarOption() {
                                width = 0.5,
                                overlap = 0.5,
                                groups = new List<IBarGroupOption>() {
                                    new _BarGroupOption {
                                        valueField = "",
                                        key = "",
                                        width = 0.5,
                                        cluster = ""
                                    },
                                    new _BarGroupOption { }
                                },
                                bottomWidth = 0.1,
                                neckHeight = 0.1,
                                topWidth = 0.1,
                                waterfall = new _WaterfallOption() { },
                                connectorLines = true,
                                connectorLineStyle = new _LineStyleOption() {
                                    stroke = new _CssColorOption() { color = "red" },
                                    strokeWidth = 2,
                                    strokeDasharray = "",
                                    strokeOpacity = 0.5
                                }
                            },
                            gradientFillDirection = GradientFillDirection.InnerRadius,
                            altStyle = new _DataPointStyleOption() {
                                fill = new _CssColorOption() { color = "" },
                                opacity = 0.1,
                                stroke = new _CssColorOption() { color = "" },
                                strokeWidth = new _StrokeWidthOption() { top = 1 },
                                strokeDasharray = ""
                            },
                            hAlign = HAlign.Center,
                            vAlign = VAlign.Bottom,
                            shapes = new List<ISymbolItemOption>() {
                                new _SymbolItemOption() {
                                    data = "",
                                    shape = new _SymbolShapeOption() {
                                        name = "shape1",
                                        content = "path:M539.32 861.2c30.9 0 29.84 28.36 66.84 36.28 148.4 31.73 229.76-179.02 239.64-322.94 9.07-132-44.57-195.63-161.05-226.46-68.27-18.07-108.23 9.49-145.43 9.49s-77.16-27.56-145.43-9.49C277.4 378.9 231.72 448.58 232.83 574.53c1.27 144.26 91.25 354.67 239.64 322.94 37.01-7.91 35.95-36.27 66.85-36.27z"
                                    }
                                },
                                new _SymbolItemOption() {
                                    data = ""
                                }
                            },
                            // graphJson
                            plugins = new List<IConfigPluginOption>() {
                                new _ConfigPluginOption() {
                                    type = "",
                                    name = "",
                                    arguments = new _ConfigPluginOption()
                                    {

                                    }
                                }
                            },
                            trackers = new List<ITrackerOption> {
                                new _TrackLineOption {
                                    type = TrackerType.CrossX,
                                    stroke = new _CssColorOption() { color = "" },
                                    strokeWidth = 2,
                                    strokeDasharray = ""
                                },
                                new _TrackAreaOption { }
                            },
                            overlays = new List<IOverlayOption>() {
                                new _ReferenceLineOverlayOption() {
                                    type = "ReferenceLine",
                                    axis = AxisType.Y,
                                    display = OverlayDisplay.Front,
                                    aggregate = ReferenceLineAggregate.Average,
                                    detailLevel = DetailLevel.Group,
                                    style = new _DataPointStyleOption() {
                                        stroke = new _CssColorOption() { color = "lightblue" },
                                        strokeWidth = new _StrokeWidthOption() { top = 2 },
                                        strokeDasharray = "",
                                        strokeOpacity = 0.5
                                    },
                                    legendText = "legend.Text",
                                    label = new _ReferenceLineLabelOption() {
                                        display = true,
                                        position = OverlayLabelPosition.BottomLeft,
                                        text = "",
                                        textStyle = new _TextStyleOption() {
                                            color = "",
                                            fontSize = "",
                                            fontFamily = "",
                                            fontStyle = FontStyle.Italic,
                                            fontWeight = "",
                                            textDecoration = new _TextDecorationOption() {
                                                lineThrough = true,
                                                overline = false,
                                                underline = true
                                            },
                                            overflow = TextOverflow.Clip,
                                            opacity = 0.1
                                        },
                                        style = new _StyleOption() {
                                            stroke = new _CssColorOption() { color = "red" },
                                            strokeWidth = 2,
                                            strokeDasharray = "",
                                            backgroundColor = new _CssColorOption() { color = "lightblue" }
                                        }
                                    },
                                    value = 2.5,
                                    field = new List<string>() { "Sales" },
                                    arguments = new _ReferenceLineOverlayArgumentsOption() {
                                        k = 2,
                                        percentileType = PercentileType.Exclusive
                                    }
                                },
                                new _ReferenceBandOverlayOption() {
                                    type = "ReferenceBand",
                                    axis = AxisType.X,
                                    start = 100,
                                    end = 100,
                                    style = new _DataPointStyleOption() {
                                        opacity = 0.1,
                                    }
                                },
                                new _TextGroupOverlayOption() {
                                    type = "Text",
                                    display = OverlayDisplay.Front,
                                    text = "Text",
                                    textStyle = new _TextStyleOption() { },
                                    style = new _OverlayStyleOption() { },
                                    width = 10,
                                    pointPath = "center",
                                    offset = "",
                                    position = AnnotationPosition.Center,
                                    placement = Placement.Bottom,
                                    vAlign = AnnotationAlign.Bottom,
                                    hAlign = AnnotationAlign.Right,
                                    groupName = "",
                                    groupAlign = AnnotationAlign.Right,
                                    angle = 45,
                                    label = "",
                                    symbol = new _TextPlotTextSymbolOption() {
                                        shape = "box",
                                        height = 10,
                                        width = 10,
                                        style = new _OverlayStyleOption() {
                                            fill = new _CssColorOption() { color = "blue" },
                                            stroke = new _CssColorOption() { color = "" },
                                            strokeWidth = 10,
                                            strokeDasharray = "",
                                            strokeOpacity = 0.5
                                        }
                                    },
                                    rules = new List<IRuleOption>() {
                                        new _RuleOption() {
                                            condition = "",
                                            type = "OverlayItem",
                                            actions = new List<IRuleActionOption>() {
                                                new _RuleActionOption {
                                                    properties = new List<IRuleActionPropertyOption>() {
                                                        new _RuleActionPropertyOption {
                                                            name = "text",
                                                            value = ""
                                                        },
                                                        new _RuleActionPropertyOption { }
                                                    }
                                                }
                                            }
                                        },
                                        new _RuleOption() { }
                                    }
                                },
                                new _ImageOverlayOption() {
                                    type = "Image",
                                    source = "",
                                    display = OverlayDisplay.Front,
                                    pointPath = "$[?(@.Sales>4000)]",
                                    width = 50,
                                    height = 50,
                                    position = AnnotationPosition.Center
                                },
                                new _LineOverlayOption() { },
                                new _NeedleOverlayOption() { },
                                new _EllipseOverlayOption() { },
                                new _PathAnnotationOption() { },
                                new _LinearTrendlineOverlayOption() {
                                    style = new _DataPointStyleOption() {
                                        stroke = new _CssColorOption() { color = "rgb(89,89,89)" },
                                        strokeWidth = new _StrokeWidthOption() {
                                            bottom = 2,
                                            left = 2,
                                            right = 2,
                                            top = 2
                                        },
                                        strokeOpacity = 1
                                    },
                                    type = "LinearTrendline",
                                    display = OverlayDisplay.Front,
                                    label = "Linear(s1)"
                                },
                                new _PolynomialTrendlineOverlayOption() { },
                                new _ExponentialTrendlineOverlayOption() { },
                                new _PowerTrendlineOverlayOption() { },
                                new _LogarithmicTrendlineOverlayOption(){ },
                                new _FourierTrendlineOverlayOption() { },
                                new _SimpleMovingAverageTrendlineOverlayOption() { },
                                new _CumulativeMovingAverageTrendlineOverlayOption() { },
                                new _WeightedMovingAverageTrendlineOverlayOption() { },
                                new _MovingAnnualTotalTrendlineOverlayOption() { },
                                new _ExponentialTrendlineOverlayOption() { },
                                new _ErrorBarOption() {
                                    type = "ErrorBar",
                                    style = new _OverlayStyleOption() {
                                        stroke = new _CssColorOption() { color = "rgb(89,89,89)" },
                                        strokeWidth = 2,
                                        strokeOpacity = 1
                                    },
                                    display = OverlayDisplay.FrontOfPlot,
                                    orientation = ErrorBarOrientation.Vertical,
                                    direction = ErrorBarDirection.Both,
                                    errorType = ErrorBarErrorType.StandardError
                                },
                                new _BarLineOverlayOption() {
                                    type = "",
                                    display = OverlayDisplay.FrontOfPlot,
                                    style = new _LineStyleOption {
                                        stroke = new _CssColorOption() { color = "lightblue" },
                                        strokeWidth = 2,
                                        strokeDasharray = "",
                                        strokeOpacity = 0.5
                                    }
                                }
                            },
                            node = new _SankeyNodeOption() {
                                nodeGap = 10,
                                width = 10,
                                borderRadius = new _BorderRadiusOption() {
                                    verticalRadius = new _BorderRadiusValueOption() {
                                        topLeft = new _ValueOption() {
                                            type = ValueOptionType.Pixel,
                                            value = 20
                                        },
                                        topRight = new _ValueOption() { type = ValueOptionType.Number, value = 20 },
                                        bottomLeft = new _ValueOption() { value = 10 },
                                        bottomRight = new _ValueOption() { value = 10 }
                                    },
                                    horizontalRadius = new _BorderRadiusValueOption() {
                                        topLeft = new _ValueOption() { type = ValueOptionType.Pixel, value = 20 },
                                        topRight = new _ValueOption() { type = ValueOptionType.Number, value = 20 },
                                        bottomLeft = new _ValueOption() { },
                                        bottomRight = new _ValueOption() { }
                                    }
                                },
                                style = new _DataPointStyleOption() {
                                    opacity = 0.5,
                                    fill = new _CssColorOption() { color = "blue" },
                                    stroke = new _CssColorOption() { color = "blue" },
                                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                                    strokeDasharray = "3, 3",
                                    strokeOpacity = 0.1
                                },
                                palette = new List<IPaletteItemOption>() {
                                    new _PaletteItemOption() {
                                        color = new _CssColorOption() { color = "red" },
                                        data = ""
                                    },
                                    new _PaletteItemOption() {
                                        color = new _RadialGradientOption() {
                                            extentKeyword = GradientExtentKeyword.FarthestCorner,
                                            position = new List<IGradientPositionOption>() {
                                                new _GradientPositionOption {
                                                    keyword = GradientPositionKeyword.Bottom,
                                                    offset = 1
                                                }
                                            },
                                            colorStops = new List<IColorStopOption> {
                                                new _ColorStopOption { color = "red" },
                                                new _ColorStopOption { color = "white" },
                                                new _ColorStopOption { color = "red" }
                                            }
                                        }
                                    }
                                },
                                hoverStyle = new _DataPointStyleOption() {
                                    opacity = 0.5,
                                    fill = new _PatternOption() {
                                        color = new _CssColorOption() { color = "" },
                                        pattern = new List<IPathWithStyleOption>() {
                                            new _PathWithStyleOption {
                                                style = new _StyleOption() {
                                                    stroke = new _CssColorOption() { color = "" },
                                                    strokeWidth = 1,
                                                    fill = new _CssColorOption() { color = "" }
                                                },
                                                content = "path:Weave"
                                            },
                                            new _PathWithStyleOption { }
                                        }
                                    },
                                    stroke = new _CssColorOption() { color = "blue" },
                                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                                    strokeDasharray = "3, 3",
                                    strokeOpacity = 0.1,
                                    symbolOpacity = 0.1,
                                    symbolStrokeOpacity = 0.1,
                                    symbolFill = new _CssColorOption() { color = "" },
                                    symbolStroke = new _CssColorOption() { color = "" },
                                    symbolStrokeWidth = 2,
                                    symbolStrokeDasharray = "1, 1"
                                },
                                selectedStyle = new _SelectionStyleOption() {
                                    adorners = true,
                                    opacity = 0.5,
                                    fill = new _CssColorOption() { color = "red" },
                                    stroke = new _CssColorOption() { color = "blue" },
                                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                                    strokeDasharray = "3, 3",
                                    strokeOpacity = 0.1,
                                    symbolOpacity = 0.1,
                                    symbolStrokeOpacity = 0.1,
                                    symbolFill = new _CssColorOption() { color = "" },
                                    symbolStroke = new _CssColorOption() { color = "" },
                                    symbolStrokeWidth = 2,
                                    symbolStrokeDasharray = "1, 1",
                                    backgroundColor = new _CssColorOption() { color = "" }
                                },
                                unselectedStyle = new _SelectionStyleOption() {  }
                            },
                            flow = new _SankeyFlowOption() {
                                colorMode = SankeyColorMode.Source,
                                style = new _DataPointStyleOption() {
                                    opacity = 0.5,
                                    fill = new _CssColorOption() { color = "blue" },
                                    stroke = new _CssColorOption() { color = "blue" },
                                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                                    strokeDasharray = "3, 3",
                                    strokeOpacity = 0.1
                                },
                                palette = new List<IPaletteItemOption>() {
                                    new _PaletteItemOption() {
                                        color = new _CssColorOption() { color = "red" },
                                        data = ""
                                    },
                                    new _PaletteItemOption() {
                                        color = new _RadialGradientOption() {
                                            extentKeyword = GradientExtentKeyword.FarthestCorner,
                                            position = new List<IGradientPositionOption>() {
                                                new _GradientPositionOption {
                                                    keyword = GradientPositionKeyword.Bottom,
                                                    offset = 1
                                                }
                                            },
                                            colorStops = new List<IColorStopOption> {
                                                new _ColorStopOption { color = "red" },
                                                new _ColorStopOption { color = "white" },
                                                new _ColorStopOption { color = "red" }
                                            }
                                        }
                                    }
                                },
                                hoverStyle = new _DataPointStyleOption() {
                                    opacity = 0.5,
                                    fill = new _PatternOption() {
                                        color = new _CssColorOption() { color = "" },
                                        pattern = new List<IPathWithStyleOption>() {
                                            new _PathWithStyleOption {
                                                style = new _StyleOption() {
                                                    stroke = new _CssColorOption() { color = "" },
                                                    strokeWidth = 1,
                                                    fill = new _CssColorOption() { color = "" }
                                                },
                                                content = "path:Weave"
                                            },
                                            new _PathWithStyleOption { }
                                        }
                                    },
                                    stroke = new _CssColorOption() { color = "blue" },
                                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                                    strokeDasharray = "3, 3",
                                    strokeOpacity = 0.1,
                                    symbolOpacity = 0.1,
                                    symbolStrokeOpacity = 0.1,
                                    symbolFill = new _CssColorOption() { color = "" },
                                    symbolStroke = new _CssColorOption() { color = "" },
                                    symbolStrokeWidth = 2,
                                    symbolStrokeDasharray = "1, 1"
                                },
                                selectedStyle = new _SelectionStyleOption() {
                                    adorners = true,
                                    opacity = 0.5,
                                    fill = new _CssColorOption() { color = "red" },
                                    stroke = new _CssColorOption() { color = "blue" },
                                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                                    strokeDasharray = "3, 3",
                                    strokeOpacity = 0.1,
                                    symbolOpacity = 0.1,
                                    symbolStrokeOpacity = 0.1,
                                    symbolFill = new _CssColorOption() { color = "" },
                                    symbolStroke = new _CssColorOption() { color = "" },
                                    symbolStrokeWidth = 2,
                                    symbolStrokeDasharray = "1, 1",
                                    backgroundColor = new _CssColorOption() { color = "" }
                                },
                                unselectedStyle = new _SelectionStyleOption() {  }
                            }
                        }
                    }
                },
                config = new _ConfigOption()
                {
                    plotAreaLayout = new _PlotAreaLayoutOption()
                    {
                        rowHeights = new List<IValueOption>() {
                            new _ValueOption {
                                type = ValueOptionType.Pixel,
                                value = 10
                            }
                        },
                        columnWidths = new List<IValueOption>() {
                            new _ValueOption {
                                type = ValueOptionType.Pixel,
                                value = 10
                            }
                        }
                    },
                    header = new _HeaderOption()
                    {
                        title = "",
                        style = new _StyleOption()
                        {
                            backgroundColor = new _CssColorOption() { color = "lithblue" },
                            stroke = new _CssColorOption() { color = "red" },
                            strokeWidth = 2,
                            strokeDasharray = "3, 3"
                        },
                        textStyle = new _TextStyleOption() { },
                        hAlign = HAlign.Center,
                        vAlign = VAlign.Bottom,
                        borderStyle = new _LineStyleOption()
                        {
                            strokeOpacity = 0.5,
                            stroke = new _CssColorOption() { color = "red" },
                            strokeWidth = 2,
                            strokeDasharray = "3, 3"
                        },
                        height = new _ValueOption()
                        {
                            type = ValueOptionType.Percentage,
                            value = 0.25
                        },
                        maxHeight = new _ValueOption() { },
                        width = new _ValueOption() { },
                        padding = new _PaddingOption()
                        {
                            top = new _ValueOption() { 
                                type = ValueOptionType.Percentage,
                                value = 0.1
                            },
                            left = new _ValueOption()
                            {
                                type = ValueOptionType.Pixel,
                                value = 20
                            }
                        }
                    },
                    footer = new _FooterOption() { },
                    palette = new List<IPaletteItemOption>() {
                        new _PaletteItemOption() {
                            data = "",
                            color = new _CssColorOption() { color = "red" }
                        },
                        new _PaletteItemOption() {
                            color = new _CssColorOption() { color = "red" }
                        }
                    },
                    bar = new _BarOption()
                    {
                        width = 0.5,
                        overlap = 0.5,
                        bottomWidth = 0.1,
                        neckHeight = 0.1,
                        topWidth = 0.1,
                        borderRadius = new _BorderRadiusOption()
                        {
                            verticalRadius = new _BorderRadiusValueOption()
                            {
                                topLeft = new _ValueOption()
                                {
                                    type = ValueOptionType.Pixel,
                                    value = 20
                                }
                            },
                            horizontalRadius = new _BorderRadiusValueOption()
                            {
                                topRight = new _ValueOption()
                                {
                                    value = 20
                                }
                            }
                        },
                        funnelType = FunnelType.EqualBar
                    },
                    backgroundColor = new _CssColorOption() { color = "" },
                    borderStyle = new _LineStyleOption()
                    {
                        strokeOpacity = 0.1,
                        stroke = new _CssColorOption() { color = "" },
                        strokeWidth = 1,
                        strokeDasharray = ""
                    },
                    style = new _StyleOption()
                    {
                        backgroundColor = new _CssColorOption() { color = "" },
                        fill = new _CssColorOption() { color = "" },
                        stroke = new _CssColorOption() { color = "" },
                        strokeWidth = 1,
                        strokeDasharray = ""
                    },
                    textStyle = new _TextStyleOption()
                    {
                        color = "",
                        fontSize = "",
                        fontFamily = "",
                        fontStyle = FontStyle.Italic,
                        fontWeight = "",
                        textDecoration = new _TextDecorationOption()
                        {
                            lineThrough = true,
                            overline = false,
                            underline = true
                        },
                        overflow = TextOverflow.Clip,
                        opacity = 0.1,
                        writingMode = TextWritingMode.Horizontal
                    },
                    legend = new _GlobalLegendOption()
                    {
                        style = new _LegendStyleOption()
                        {
                            backgroundColor = new _CssColorOption() { color = "" },
                            stroke = new _CssColorOption() { color = "" },
                            strokeWidth = 1,
                            strokeDasharray = "",
                            iconColor = new _CssColorOption() { color = "" }
                        },
                        textStyle = new _TextStyleOption()
                        {
                            color = "",
                            fontSize = "",
                            fontFamily = "",
                            fontStyle = FontStyle.Italic,
                            fontWeight = "",
                            textDecoration = new _TextDecorationOption()
                            {
                                lineThrough = true,
                                overline = false,
                                underline = true
                            },
                            overflow = TextOverflow.Clip,
                            opacity = 0.1
                        },
                        titleStyle = new _TextStyleOption()
                        {
                            color = "",
                            fontSize = "",
                            fontFamily = "",
                            fontStyle = FontStyle.Italic,
                            fontWeight = "",
                            textDecoration = new _TextDecorationOption()
                            {
                                lineThrough = true,
                                overline = false,
                                underline = true
                            },
                            overflow = TextOverflow.Clip,
                            opacity = 0.1,
                            writingMode = TextWritingMode.Vertical
                        },
                        titlePosition = Position.Left,
                        position = LegendPosition.Bottom,
                        orientation = Orientation.Horizontal,
                        wrapping = false,
                        borderStyle = new _LineStyleOption()
                        {
                            strokeOpacity = 0.1,
                            stroke = new _CssColorOption() { color = "" },
                            strokeWidth = 1,
                            strokeDasharray = ""
                        },
                        //filteredOutStyle = new _TextStyleOption() { color = "" },
                        itemPadding = new _PaddingOption() { 
                            bottom = new _ValueOption()
                            {
                                type = ValueOptionType.Percentage,
                                value = 0.1
                            }, 
                            left = new _ValueOption()
                            {
                                type = ValueOptionType.Pixel,
                                value = 20
                            }
                        },
                        padding = new _PaddingOption() { 
                            top = new _ValueOption()
                            {
                                type = ValueOptionType.Percentage,
                                value = 0.1
                            }
                        },
                        hoverStyle = new _TextStyleOption() { color = "" },
                        groupHAlign = HAlign.Right,
                        groupVAlign = VAlign.Bottom,
                        groupOrientation = Orientation.Vertical,
                        groupPadding = new _PaddingOption() { 
                            left = new _ValueOption()
                            {
                                type = ValueOptionType.Percentage,
                                value = 0.1
                            }
                        },
                        margin = new _MarginOption() { right = 10 },
                        left = 0.5,
                        top = 0.5,
                        itemSpace = new _ValueOption()
                        {
                            type = ValueOptionType.Percentage,
                            value = 0.5
                        }
                    },
                    padding = new _PaddingOption() { 
                        top = new _ValueOption()
                        {
                            type = ValueOptionType.Percentage,
                            value = 0.1
                        }
                    },
                    shapes = new List<ISymbolItemOption>() {
                        new _SymbolItemOption() {
                            data = "",
                            shape = new _SymbolShapeOption() {
                                name = "shape1",
                                content = ""
                            }
                        },
                        new _SymbolItemOption() {
                            data = ""
                        }
                    },
                    selectionMode = SelectionMode.Category,
                    selectedStyle = new _SelectionStyleOption()
                    {
                        adorners = true,
                        opacity = 0.5,
                        fill = new _CssColorOption() { color = "red" },
                        stroke = new _CssColorOption() { color = "blue" },
                        strokeWidth = new _StrokeWidthOption() { top = 2 },
                        strokeDasharray = "3, 3",
                        strokeOpacity = 0.1,
                        symbolOpacity = 0.1,
                        symbolStrokeOpacity = 0.1,
                        symbolFill = new _CssColorOption() { color = "" },
                        symbolStroke = new _CssColorOption() { color = "" },
                        symbolStrokeWidth = 2,
                        symbolStrokeDasharray = "1, 1",
                        backgroundColor = new _CssColorOption() { color = "" }
                    },
                    unselectedStyle = new _SelectionStyleOption() { },
                    selectedTextStyle = new _TextStyleOption()
                    {
                        color = "",
                        fontSize = "",
                        fontFamily = "",
                        fontStyle = FontStyle.Italic,
                        fontWeight = "",
                        textDecoration = new _TextDecorationOption()
                        {
                            lineThrough = true,
                            overline = false,
                            underline = true
                        },
                        overflow = TextOverflow.Clip,
                        opacity = 0.1,
                        writingMode = TextWritingMode.Horizontal
                    },
                    unselectedTextStyle = new _TextStyleOption() { },
                    plotAreas = new List<IPlotAreaOption>() {
                        new _PlotAreaOption() {
                            backgroundColor = new _CssColorOption() { color = "" },
                            borderStyle = new _LineStyleOption() {
                                strokeOpacity = 0.1,
                                stroke = new _CssColorOption() { color = "" },
                                strokeWidth = 1,
                                strokeDasharray = ""
                            },
                            style = new _PlotAreaStyleOption() {
                                backgroundColor = new _CssColorOption() { color = "" },
                                fill = new _CssColorOption() { color = "" },
                                stroke = new _CssColorOption() { color = "" },
                                strokeWidth = 1,
                                strokeDasharray = "",
                                innerStroke = new _CssColorOption() { color = "" },
                                innerStrokeWidth = 1,
                                innerStrokeDasharray = ""
                            },
                            textStyle = new _TextStyleOption() {
                                color = "",
                                fontSize = "",
                                fontFamily = "",
                                fontStyle = FontStyle.Italic,
                                fontWeight = "",
                                textDecoration = new _TextDecorationOption() {
                                    lineThrough = true,
                                    overline = false,
                                    underline = true
                                },
                                overflow = TextOverflow.Clip,
                                opacity = 0.1,
                                writingMode = TextWritingMode.Horizontal
                            },
                            padding = new _PaddingOption() { 
                                top = new _ValueOption() {
                                    type = ValueOptionType.Percentage,
                                    value = 0.1
                                }
                            },
                            legend = new _GlobalLegendOption() {
                                style = new _LegendStyleOption() {
                                    backgroundColor = new _CssColorOption() { color = "lightblue" },
                                    stroke = new _CssColorOption() { color = "red" },
                                    strokeWidth = 4,
                                    strokeDasharray = "5, 5",
                                    iconColor = new _CssColorOption() { color = "lightblue" }
                                },
                                textStyle = new _TextStyleOption() {
                                    color = "red",
                                    fontSize = "18",
                                    fontFamily = "Lucida Console",
                                    fontStyle = FontStyle.Oblique,
                                    fontWeight = "Bold",
                                    textDecoration = new _TextDecorationOption() {
                                        lineThrough = true,
                                        overline = true,
                                        underline = true
                                    },
                                    opacity = 0.5
                                },
                                titleStyle = new _TextStyleOption() {
                                    color = "red",
                                    fontSize = "22",
                                    fontFamily = "MingLiU",
                                    fontStyle = FontStyle.Oblique,
                                    fontWeight = "Bold",
                                    textDecoration = new _TextDecorationOption() {
                                        lineThrough = true,
                                        overline = true,
                                        underline = true
                                    },
                                    opacity = 0.3
                                },
                                position = LegendPosition.Left,
                                orientation = Orientation.Horizontal,
                                borderStyle = new _LineStyleOption() {
                                    stroke = new _CssColorOption() { color = "red" },
                                    strokeWidth = 2,
                                    strokeDasharray = "5, 5",
                                    strokeOpacity = 0.5
                                },
                                itemPadding = new _PaddingOption() { 
                                    top = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 0.1
                                    }, 
                                    left = new _ValueOption() {
                                        type = ValueOptionType.Pixel,
                                        value = 0.1
                                    }, 
                                    right = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 0.1
                                    }, 
                                    bottom = new _ValueOption() {
                                        type = ValueOptionType.Pixel,
                                        value = 0.1
                                    } 
                                },
                                padding = new _PaddingOption() { 
                                    top = new _ValueOption() {
                                        type = ValueOptionType.Pixel,
                                        value = 0.1
                                    }, 
                                    left = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 0.1
                                    }, 
                                    right = new _ValueOption() {
                                        type = ValueOptionType.Pixel,
                                        value = 0.1
                                    }, 
                                    bottom = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 0.1
                                    }
                                },
                                titlePosition = Position.Bottom,
                                wrapping = false,
                                margin = new _MarginOption() { 
                                    top = 40, 
                                    bottom = 50 
                                },
                                groupPadding = new _PaddingOption() { 
                                    top = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 0.1
                                    }
                                }
                            },
                            legends = new List<ILegendOption>() {
                                new _LegendOption() {
                                    type = LegendType.Color,
                                    title = "",
                                    gradient = new _LegendGradientOption() {
                                        enabled = false,
                                        min = 1000,
                                        max = 2000,
                                        unit = 100,
                                        palette = new List<string>() { "red","blue","yellow" }
                                    },
                                    ranges = new List<ILegendRangeOption> {
                                        new _LegendRangeOption {
                                            to = 5000,
                                            title = "0 - 5000"
                                        },
                                        new _LegendRangeOption {
                                            to = 10000,
                                            title = "5000 - 10000"
                                        },
                                        new _LegendRangeOption {
                                            to = 15000,
                                            title = "10000 - 15000"
                                        }
                                    },
                                    height = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 200
                                    },
                                    width = new _ValueOption(){ },
                                    maxHeight = new _ValueOption() {
                                        type = ValueOptionType.Percentage,
                                        value = 0.2
                                    },
                                    maxWidth = new _ValueOption() { },
                                    items = new List<ILegendItemOption>() {
                                        new _LegendItemOption {
                                            text = "Customer"
                                        },
                                        new _LegendItemOption {
                                            textStyle = new _TextStyleOption() {
                                                color = "red",
                                                fontSize = "20",
                                                fontWeight = "Bold",
                                                fontStyle = FontStyle.Italic,
                                                fontFamily = "Lucida Console"
                                            }
                                        }
                                    },
                                    sortOrder = SortOrder.Ascending,
                                    template = "legend.shape",
                                    merge = new List<IMergeLegendTypeOption>() {
                                        new _MergeLegendTypeOption() {
                                            type = LegendType.Color,
                                            plotName = "p1"
                                        },
                                        new _MergeLegendTypeOption() {
                                            type = LegendType.Shape,
                                            plotName = "p1"
                                        }
                                    },
                                    hAlign = HAlign.Center,
                                    vAlign = VAlign.Bottom
                                },
                                new _LegendOption() {
                                    style = new _LegendStyleOption() {
                                        backgroundColor = new _PatternOption() {
                                            color = new _CssColorOption() { color = "lightblue" },
                                            pattern = new List<IPathWithStyleOption>() {
                                                new _PathWithStyleOption {
                                                    style = new _StyleOption() {
                                                        fill = new _CssColorOption() {
                                                            color = "green"
                                                        }
                                                    },
                                                    content = "path:Weave"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            plotsMargin = new _MarginOption() { left = 10 },
                            //zoom
                            column = 0,
                            row = 0,
                            plugins = new List<IConfigPluginOption>
                            {
                                new _ConfigPluginOption() { 
                                    type = "",
                                    name = "",
                                    arguments = new _ConfigPluginOption()
                                    {

                                    }
                                }
                            },
                            axes = new List<IAxisOption>() {
                                new _AxisOption() {
                                    plots = new List<System.String>() {"p1"},
                                    type = AxisType.X,
                                    title = "",
                                    labelAngle = new List<double?>() { 40, 50 },
                                    labels = AxisPosition.None,
                                    axisLine = true,
                                    labelStyle = new _LabelStyleOption() {
                                        color = "",
                                        fontSize = "",
                                        fontFamily = "",
                                        fontStyle = FontStyle.Italic,
                                        fontWeight = "",
                                        textDecoration = new _TextDecorationOption() {
                                            lineThrough = true,
                                            overline = false,
                                            underline = true
                                        },
                                        overflow = TextOverflow.Clip,
                                        opacity = 0.1,
                                        padding = new _PaddingOption() { 
                                            top = new _ValueOption() {
                                                type = ValueOptionType.Percentage,
                                                value = 0.1
                                            }
                                        }
                                    },
                                    titleStyle = new _LabelStyleOption() {
                                        color = "",
                                        fontSize = "",
                                        fontFamily = "",
                                        fontStyle = FontStyle.Italic,
                                        fontWeight = "",
                                        textDecoration = new _TextDecorationOption() {
                                            lineThrough = true,
                                            overline = false,
                                            underline = true
                                        },
                                        overflow = TextOverflow.Clip,
                                        opacity = 0.1,
                                        padding = new _PaddingOption() { 
                                            top = new _ValueOption() {
                                                type = ValueOptionType.Percentage,
                                                value = 0.1
                                            }
                                        }
                                    },
                                    lineStyle = new _LineStyleOption() {
                                        strokeOpacity = 0.5,
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 1,
                                        strokeDasharray = ""
                                    },
                                    overlappingLabels = OverlappingLabels.Hide,
                                    format = new _FormatOption() { type = "", value = "" },
                                    scale = new _ValueScaleOption() { type = ValueScaleType.Linear },
                                    logBase = 10,
                                    origin = 0,
                                    reversed = true,
                                    dateMode = DateMode.Day,
                                    minorUnit = new _AxisUnitOption() { value = 500, dateMode = DateMode.Hour },
                                    minorTicks = TickMark.Cross,
                                    minorTickSize = 10,
                                    minorTickStyle = new _LineStyleOption() {
                                        strokeOpacity = 0.5,
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 1,
                                        strokeDasharray = ""
                                    },
                                    minorGrid = true,
                                    minorGridStyle = new _LineStyleOption() {
                                        strokeOpacity = 0.5,
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 1,
                                        strokeDasharray = ""
                                    },
                                    groupGrid = TickMark.Inside,
                                    groupGridStyle = new _LineStyleOption() {
                                        strokeOpacity = 0.5,
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 1,
                                        strokeDasharray = ""
                                    },
                                    majorUnit = new _AxisUnitOption() { value = 500, dateMode = DateMode.Hour },
                                    majorTicks = TickMark.Cross,
                                    majorTickSize = 10,
                                    majorTickStyle = new _LineStyleOption() {
                                        strokeOpacity = 0.5,
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 1,
                                        strokeDasharray = ""
                                    },
                                    majorGridStyle = new _LineStyleOption() {
                                        strokeOpacity = 0.5,
                                        stroke = new _CssColorOption() { color = "" },
                                        strokeWidth = 1,
                                        strokeDasharray = ""
                                    },
                                    position = AxisPosition.Near,
                                    min = new _ValueOption() { type = ValueOptionType.Percentage, value = 10 },
                                    max = new _ValueOption() { type = ValueOptionType.Number, value = 10 },
                                    useActualMax = true,
                                    useActualMin = true,
                                    height = new _ValueOption() { type = ValueOptionType.Percentage, value = 0.5 },
                                    maxHeight = new _ValueOption() { },
                                    width = new _ValueOption() { type = ValueOptionType.Pixel, value = 1 },
                                    maxWidth = new _ValueOption() { },
                                    viewSize = 0.5,
                                    scrollbarVisible = true,
                                    rules = new List<IRuleOption>() {
                                        new _RuleOption() {
                                            condition = "",
                                            type = "",
                                            actions = new List<IRuleActionOption>() {
                                                new _RuleActionOption {
                                                    targetElement = "",
                                                    properties = new List<IRuleActionPropertyOption>() {
                                                        new _RuleActionPropertyOption {
                                                            name = "",
                                                            value = ""
                                                        },
                                                        new _RuleActionPropertyOption { }
                                                    }
                                                }
                                            }
                                        },
                                        new _RuleOption() { }
                                    },
                                    unitLabel = new _UnitLabelOption() {
                                        text = "",
                                        textStyle = new _LabelStyleOption() {
                                            color = "red",
                                            fontSize = "20",
                                            fontFamily = "YouYuan",
                                            fontStyle = FontStyle.Italic,
                                            fontWeight = "Bold",
                                            textDecoration = new _TextDecorationOption() { underline = true },
                                            padding = new _PaddingOption() { 
                                                bottom = new _ValueOption() {
                                                    type = ValueOptionType.Percentage,
                                                    value = 0.1
                                                }
                                            }
                                        },
                                        style = new _StyleOption() {
                                            backgroundColor = new _CssColorOption() { color = "lightblue" },
                                            stroke = new _CssColorOption() { color = "lightblue" },
                                            strokeWidth = 6,
                                            strokeDasharray = "10, 10"
                                        },
                                        labelAngle = 45
                                    },
                                    trackers = new List<ITrackerOption>() {
                                        new _TrackAreaOption() {
                                            //type = TrackerType.Area,
                                            fill = new _CssColorOption() { color = "" },
                                            opacity = 0.5
                                        }
                                    },
                                    style = new _StyleOption() { },
                                    textStyle = new _TextStyleOption() { }
                                },
                                new _AxisOption() {
                                    plots = new List<System.String>() {"p1"},
                                    type = AxisType.Y
                                }
                            }
                        },
                        new _PlotAreaOption() { }
                    }
                },
                transform = new List<ITransformOption> {
                    new _AggregateTransformOption() {
                        aggregate = new List<IAggregateOption>() {
                            new _AggregateOption() {
                                field = "Downloads",
                                op = Aggregate.Count,
                                outputAs = "DownloadsCount"
                            }
                        },
                        concat = new _ConcatOption() {
                            customArray = new List<System.Int32>() {},
                            type = ConcatType.End
                        },
                        groupby = new List<System.String>() {"Company"},
                        type = TransformType.Aggregate
                    },
                    new _BinTransformOption() {
                        bin = new _BinOption() {
                            steps = new List<System.Double>() {}
                        },
                        field = "Sales",
                        outputAs = "SalesBin",
                        type = TransformType.Bin
                    },
                    new _CalculateTransformOption() {
                        calculate = "=SUM(current.Downloads, 0.00000005)",
                        outputAs = "newField",
                        type = TransformType.Calculate
                    }
                },
                data = GetData()
            };
        }

        static void EncodingAll()
        {
            _DvOption dvOption = new _DvOption();
            // Plots
            _PlotOption plotOption = new _PlotOption();
            plotOption.name = "p1";
            plotOption.type = "Bar";
            plotOption.encodings.values = new List<IValueEncodingOption>() {
                new _FieldsValueEncodingOption {
                    field = "Sales",
                    aggregate = Aggregate.Max,
                    label = "",
                    excludeNulls = false,
                    sort = new List<ISortEncodingOption>() {
                        new _SortEncodingOption {
                            field = "",
                            order = OrderType.Ascending,
                            aggregate = Aggregate.PopulationStandardDeviation
                        }
                    }
                },
                new _FieldsValueEncodingOption { field = "Downloads" },
                new _RangeFieldValueEncodingOption {
                    field = new _RangeFieldOption { lower = "", upper = "" },
                    aggregate = Aggregate.Max,
                    excludeNulls = false,
                    label = new _RangeFieldOption() { lower = "", upper = "" }
                },
                new _StockFieldValueEncodingOption {
                    field = new _StockFieldOption { close = "close", high = "high", low = "low", open = "open", x = "date" }
                }
            };
            plotOption.encodings.category = new _CategoryEncodingOption()
            {
                field = "Country",
                label = "",
                excludeNulls = true,
                sort = new _SortEncodingOption()
                {
                    order = OrderType.Descending,
                    field = "",
                    aggregate = Aggregate.Average
                }
            };
            plotOption.encodings.details = new List<IDetailEncodingOption> {
                new _DetailEncodingOption() {
                    field = "",
                    group = Group.Cluster,
                    excludeNulls = true,
                    label = "",
                    sort = new _SortEncodingOption() {
                        order = OrderType.Descending,
                        field = "",
                        aggregate = Aggregate.Average
                    }
                }
            };
            plotOption.encodings.color = new _ColorEncodingOption()
            {
                field = "Country",
                label = "",
                aggregate = Aggregate.Average,
                sort = new _SortEncodingOption()
                {
                    order = OrderType.Descending,
                    field = "",
                    aggregate = Aggregate.Average
                },
                items = new List<ILegendItemEncodingOption> {
                    new _LegendItemEncodingOption() { title = "", ruleType = "Increase" },
                    new _LegendItemEncodingOption() { title = "", ruleType = "Decrease" }
                }
            };
            plotOption.encodings.shape = new _ShapeEncodingOption()
            {
                field = "NewCustomer",
                label = "",
                aggregate = Aggregate.Average,
                sort = new _SortEncodingOption()
                {
                    order = OrderType.Descending,
                    field = "",
                    aggregate = Aggregate.Average
                }
            };
            plotOption.encodings.size = new _SizeEncodingOption()
            {
                field = "Sales",
                label = "",
                aggregate = Aggregate.Average,
                sort = new _SortEncodingOption()
                {
                    order = OrderType.Descending,
                    field = "",
                    aggregate = Aggregate.Average
                }
            };
            plotOption.encodings.text = new List<IContentEncodingOption> {
                new _ContentEncodingOption() {
                    field = "",
                    label = "",
                    aggregate = Aggregate.Average
                },
                new _ContentEncodingOption() { }
            };
            plotOption.encodings.tooltip = new List<IContentEncodingOption>() {
                new _ContentEncodingOption() {
                    field = "",
                    label = "",
                    aggregate = Aggregate.Average
                },
                new _ContentEncodingOption() { }
            };
            plotOption.encodings.layout = new _LayoutEncodingOption()
            {
                type = "Trellis",
                field = "",
                label = "",
                // columnSort  does not
                // rowSort
            };
            plotOption.encodings.backgroundColor = new _BackgroundColorEncodingOption()
            {
                field = "",
                label = "",
                sort = new _SortEncodingOption()
                {
                    order = OrderType.Descending,
                    field = "",
                    aggregate = Aggregate.Average
                },
                aggregate = Aggregate.Average
            };
            plotOption.config.axisMode = AxisMode.Radial;
            plotOption.config.symbols = true;
            plotOption.config.sweep = 90;
            plotOption.config.startAngle = 90;
            plotOption.config.innerRadius = 0.3;
            plotOption.config.swapAxes = true;
            plotOption.config.lineAspect = LineAspect.StepCenter;
            plotOption.config.offset = new List<IValueOption>() {
                new _ValueOption() {
                    type = ValueOptionType.Percentage,
                    value = 0.5
                }
            };
            plotOption.config.showNulls = ShowNulls.Connected;
            plotOption.config.showNaNs = ShowNulls.Gaps;
            plotOption.config.clippingMode = ClippingMode.Clip;
            plotOption.config.style = new _DataPointStyleOption()
            {
                backgroundColor = new _RadialGradientOption()
                {
                    //type = ColorOptionType.Radial,    --this is default value
                    extentKeyword = GradientExtentKeyword.FarthestCorner,
                    position = new List<IGradientPositionOption>() {
                        new _GradientPositionOption {
                            keyword = GradientPositionKeyword.Bottom,
                            offset = 1
                        }
                    },
                    colorStops = new List<IColorStopOption> {
                        new _ColorStopOption { color = "red" },
                        new _ColorStopOption { color = "white" },
                        new _ColorStopOption { color = "red" }
                    }
                },
                //backgroundColor = new _LinearGradientOption()
                //{
                //    angle = 0.5
                //},
                //backgroundColor = new _CssColorOption() { color = "lithblue" },
                opacity = 0.5,
                //fill = new _CssColorOption() { color = "red" },
                fill = new _PatternOption()
                {
                    //type = ColorOptionType.Pattern,
                    color = new _CssColorOption() { color = "" },
                    pattern = new List<IPathWithStyleOption>() {
                        new _PathWithStyleOption {
                            style = new _StyleOption() {
                                stroke = new _CssColorOption() { color = "" },
                                strokeWidth = 1,
                                fill = new _CssColorOption() { color = "" }
                            },
                            content = "path:Weave"
                        },
                        new _PathWithStyleOption { }
                    }
                },
                stroke = new _CssColorOption() { color = "blue" },
                strokeWidth = new _StrokeWidthOption() { top = 2 },
                strokeDasharray = "3, 3",
                strokeOpacity = 0.1,
                symbolOpacity = 0.1,
                symbolStrokeOpacity = 0.1,
                symbolFill = new _LinearGradientOption()
                {
                    angle = 0.5,
                    colorStops = new List<IColorStopOption> {
                        new _ColorStopOption { color = "red" },
                        new _ColorStopOption { color = "white" },
                        new _ColorStopOption { color = "red" }
                    }
                },
                //symbolFill = new _CssColorOption() { color = "" },
                symbolStroke = new _CssColorOption() { color = "" },
                symbolStrokeWidth = 2,
                symbolStrokeDasharray = "1, 1",
                symbolShape = "",
                symbolSize = 10,
                borderRadius = new _BorderRadiusOption()
                {
                    verticalRadius = new _BorderRadiusValueOption()
                    {
                        topLeft = new _ValueOption()
                        {
                            type = ValueOptionType.Pixel,
                            value = 20
                        },
                        topRight = new _ValueOption() { type = ValueOptionType.Number, value = 20 },
                        bottomLeft = new _ValueOption() { value = 10 },
                        bottomRight = new _ValueOption() { value = 10 }
                    },
                    horizontalRadius = new _BorderRadiusValueOption()
                    {
                        topLeft = new _ValueOption() { type = ValueOptionType.Pixel, value = 20 },
                        topRight = new _ValueOption() { type = ValueOptionType.Number, value = 20 },
                        bottomLeft = new _ValueOption() { },
                        bottomRight = new _ValueOption() { }
                    }
                }
            };
            plotOption.config.textStyle = new _TextStyleOption()
            {
                color = "",
                fontSize = "",
                fontFamily = "",
                fontStyle = FontStyle.Italic,
                fontWeight = "",
                textDecoration = new _TextDecorationOption()
                {
                    lineThrough = true,
                    overline = false,
                    underline = true
                },
                overflow = TextOverflow.Clip,
                opacity = 0.1,
                writingMode = TextWritingMode.Horizontal
            };
            plotOption.config.text = new List<IPlotConfigTextOption> {
                new _PlotConfigTextOption() {
                    scope = "",
                    template = "",
                    //offset = 0,
                    //position = TextPosition.Center,
                    //linePosition = LinePosition.Auto,
                    //connectingLine = new _LineStyleOption() {
                    //    opacity = 0.5,
                    //    stroke = new _CssColorOption() { color = "" },
                    //    strokeWidth = 2,
                    //    strokeDasharray = ""
                    //},
                    overlappingLabels = OverlappingLabels.Auto,
                    style = new _StyleOption() {
                        stroke = new _CssColorOption() { color = "" },
                        strokeWidth = 2,
                        strokeDasharray = "",
                        backgroundColor = new _CssColorOption() { color = "" }
                    },
                    textStyle = new _TextStyleOption() {
                        color = "",
                        fontSize = "",
                        fontFamily = "",
                        fontStyle = FontStyle.Italic,
                        fontWeight = "",
                        textDecoration = new _TextDecorationOption() {
                            lineThrough = true,
                            overline = false,
                            underline = true
                        },
                        overflow = TextOverflow.Clip,
                        opacity = 0.1,
                        writingMode = TextWritingMode.Vertical
                    },
                    format = new _FormatOption() {
                        type = "Thousands",
                        value = ""
                    }
                },
                new _PlotConfigTextOption() { }
            };
            plotOption.config.hoverStyle = new _DataPointStyleOption()
            {
                opacity = 0.5,
                fill = new _PatternOption()
                {
                    color = new _CssColorOption() { color = "" },
                    pattern = new List<IPathWithStyleOption>() {
                        new _PathWithStyleOption {
                            style = new _StyleOption() {
                                stroke = new _CssColorOption() { color = "" },
                                strokeWidth = 1,
                                fill = new _CssColorOption() { color = "" }
                            },
                            content = "path:Weave"
                        },
                        new _PathWithStyleOption { }
                    }
                },
                stroke = new _CssColorOption() { color = "blue" },
                strokeWidth = new _StrokeWidthOption() { top = 2 },
                strokeDasharray = "3, 3",
                strokeOpacity = 0.1,
                symbolOpacity = 0.1,
                symbolStrokeOpacity = 0.1,
                symbolFill = new _CssColorOption() { color = "" },
                symbolStroke = new _CssColorOption() { color = "" },
                symbolStrokeWidth = 2,
                symbolStrokeDasharray = "1, 1"
            };
            plotOption.config.tooltip = new List<IPlotConfigTooltipOption>
            {
                new _PlotConfigTooltipOption()
                {
                    scope = "",
                    template = "",
                    style = new _StyleOption()
                    {
                        stroke = new _CssColorOption() { color = "" },
                        strokeWidth = 2,
                        strokeDasharray = "",
                        backgroundColor = new _CssColorOption() { color = "" }
                    },
                    textStyle = new _TextStyleOption()
                    {
                        color = "",
                        fontSize = "",
                        fontFamily = "",
                        fontStyle = FontStyle.Italic,
                        fontWeight = "",
                        textDecoration = new _TextDecorationOption()
                        {
                            lineThrough = true,
                            overline = false,
                            underline = true
                        },
                        overflow = TextOverflow.Clip,
                        opacity = 0.1
                    }
                }
            };
            plotOption.config.rules = new List<IRuleOption>() {
                new _RuleOption() {
                    condition = "",
                    type = "",
                    actions = new List<IRuleActionOption>() {
                        new _RuleActionOption {
                            targetElement = "",
                            properties = new List<IRuleActionPropertyOption>() {
                                new _RuleActionPropertyOption {
                                    name = "",
                                    value = ""
                                },
                                new _RuleActionPropertyOption { }
                            }
                        }
                    }
                },
                new _RuleOption() { }
            };
            plotOption.config.palette = new List<IPaletteItemOption>() {
                new _PaletteItemOption() {
                    color = new _CssColorOption() { color = "lithblue" },
                    type = PaletteItemType.Index,
                    data = ""
                }
            };
            plotOption.config.palette = new List<IPaletteItemOption>() {
                new _PaletteItemOption() {
                    color = new _CssColorOption() { color = "red" },
                    data = ""
                },
                new _PaletteItemOption() {
                    color = new _RadialGradientOption() {
                        extentKeyword = GradientExtentKeyword.FarthestCorner,
                        position = new List<IGradientPositionOption>() {
                            new _GradientPositionOption {
                                keyword = GradientPositionKeyword.Bottom,
                                offset = 1
                            }
                        },
                        colorStops = new List<IColorStopOption> {
                            new _ColorStopOption { color = "red" },
                            new _ColorStopOption { color = "white" },
                            new _ColorStopOption { color = "red" }
                        }
                    }
                }
            };
            plotOption.config.seriesStyles = new List<ISeriesStyleOption> {
                new _SeriesStyleOption() {
                    key = "c1",
                    valueField = "value12",
                    backgroundColor = new _CssColorOption() { color = "" },
                    borderRadius = new _BorderRadiusOption() { },
                    fill = new _CssColorOption() { color = "" },
                    symbols = false,
                    opacity = 0.5,
                    stroke = new _CssColorOption() { color = "" },
                    strokeWidth = new _StrokeWidthOption() { bottom = 2 },
                    strokeDasharray = "",
                    strokeOpacity = 0.1,
                    symbolFill = new _CssColorOption() { color = "" },
                    symbolStroke = new _CssColorOption() { color = "" },
                    symbolOpacity = 0.1,
                    symbolStrokeWidth = 2,
                    symbolStrokeDasharray = "",
                    symbolStrokeOpacity = 0.1,
                    symbolSize = 20,
                    symbolShape = ""
                },
                new _SeriesStyleOption() { }
            };
            plotOption.config.bar = new _PlotBarOption()
            {
                width = 0.5,
                overlap = 0.5,
                groups = new List<IBarGroupOption>() {
                    new _BarGroupOption {
                        valueField = "",
                        key = "",
                        width = 0.5,
                        cluster = ""
                    },
                    new _BarGroupOption { }
                },
                bottomWidth = 0.1,
                neckHeight = 0.1,
                topWidth = 0.1,
                waterfall = new _WaterfallOption() { },
                connectorLines = true,
                connectorLineStyle = new _LineStyleOption()
                {
                    stroke = new _CssColorOption() { color = "red" },
                    strokeWidth = 2,
                    strokeDasharray = "",
                    strokeOpacity = 0.5
                }
            };
            plotOption.config.gradientFillDirection = GradientFillDirection.InnerRadius;
            plotOption.config.altStyle = new _DataPointStyleOption()
            {
                fill = new _CssColorOption() { color = "" },
                opacity = 0.1,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = new _StrokeWidthOption() { top = 1 },
                strokeDasharray = ""
            };
            plotOption.config.hAlign = HAlign.Center;
            plotOption.config.vAlign = VAlign.Bottom;
            plotOption.config.shapes = new List<ISymbolItemOption>() {
                new _SymbolItemOption() {
                    data = "",
                    shape = new _SymbolShapeOption() {
                        name = "shape1",
                        content = "path:M539.32 861.2c30.9 0 29.84 28.36 66.84 36.28 148.4 31.73 229.76-179.02 239.64-322.94 9.07-132-44.57-195.63-161.05-226.46-68.27-18.07-108.23 9.49-145.43 9.49s-77.16-27.56-145.43-9.49C277.4 378.9 231.72 448.58 232.83 574.53c1.27 144.26 91.25 354.67 239.64 322.94 37.01-7.91 35.95-36.27 66.85-36.27z"
                    }
                },
                new _SymbolItemOption() {
                    data = ""
                }
            };
            // graphJson
            plotOption.config.plugins = new List<IConfigPluginOption>() {
                new _ConfigPluginOption() {
                    type = "",
                    name = ""
                }
            };
            plotOption.config.trackers = new List<ITrackerOption> {
                new _TrackLineOption {
                    type = TrackerType.CrossX,
                    stroke = new _CssColorOption() { color = "" },
                    strokeWidth = 2,
                    strokeDasharray = ""
                },
                new _TrackAreaOption { }
            };
            dvOption.plots.Add(plotOption);

            _ReferenceLineOverlayOption referenceLineOpation = new()
            {
                type = "ReferenceLine",
                axis = AxisType.Y,
                display = OverlayDisplay.Back,
                aggregate = ReferenceLineAggregate.Average,
                detailLevel = DetailLevel.Group,
                style = new _DataPointStyleOption()
                {
                    stroke = new _CssColorOption() { color = "lightblue" },
                    strokeWidth = new _StrokeWidthOption() { top = 2 },
                    strokeDasharray = "",
                    strokeOpacity = 0.5
                },
                legendText = "legend.Text",
                label = new _ReferenceLineLabelOption()
                {
                    display = true,
                    position = OverlayLabelPosition.BottomLeft,
                    text = "",
                    textStyle = new _TextStyleOption()
                    {
                        color = "",
                        fontSize = "",
                        fontFamily = "",
                        fontStyle = FontStyle.Italic,
                        fontWeight = "",
                        textDecoration = new _TextDecorationOption()
                        {
                            lineThrough = true,
                            overline = false,
                            underline = true
                        },
                        overflow = TextOverflow.Clip,
                        opacity = 0.1
                    },
                    style = new _StyleOption()
                    {
                        stroke = new _CssColorOption() { color = "red" },
                        strokeWidth = 2,
                        strokeDasharray = "",
                        backgroundColor = new _CssColorOption() { color = "lightblue" }
                    }
                },
                value = 2.5,
                arguments = new _ReferenceLineOverlayArgumentsOption()
                {
                    k = 2,
                    percentileType = PercentileType.Exclusive
                },
                //referenceLineOpation.field.Add("");
                field = new List<string>() { "Sales" }
            };
            plotOption.config.overlays.Add(referenceLineOpation);

            //_ReferenceBandOverlayOption referenceBandOpation = new _ReferenceBandOverlayOption();
            //referenceBandOpation.type = "ReferenceBand";
            //referenceBandOpation.axis = AxisType.X;
            //referenceBandOpation.start = 100;
            //referenceBandOpation.end = 100;
            //referenceBandOpation.style = new _DataPointStyleOption()
            //{
            //    opacity = 0.1,
            //};

            _ReferenceBandOverlayOption referenceBandOpation = new()
            {
                type = "ReferenceBand",
                axis = AxisType.X,
                start = 100,
                end = 100,
                style = new _DataPointStyleOption()
                {
                    opacity = 0.1,
                }
            };
            plotOption.config.overlays.Add(referenceBandOpation);

            _TextOverlayOption textOverlayOption = new()
            {
                type = "Text",
                display = OverlayDisplay.Front,
                pointPath = "center",
                text = "Text",
                width = 10,
                offset = "",
                position = AnnotationPosition.Center,
                placement = Placement.Bottom,
                angle = 45,
                label = "",
                rules = new List<IRuleOption>() {
                    new _RuleOption() {
                        condition = "",
                        type = "OverlayItem",
                        actions = new List<IRuleActionOption>() {
                            new _RuleActionOption {
                                properties = new List<IRuleActionPropertyOption>() {
                                    new _RuleActionPropertyOption {
                                        name = "text",
                                        value = ""
                                    },
                                    new _RuleActionPropertyOption { }
                                }
                            }
                        }
                    },
                    new _RuleOption() { }
                },
                style = new _OverlayStyleOption() { },
                textStyle = new _TextStyleOption() { }
            };
            plotOption.config.overlays.Add(textOverlayOption);

            _ImageOverlayOption ImageOverlayOption = new()
            {
                type = "Image",
                source = "https://www.easyicon.net/api/resizeApi.php?id=1152326&size=128",
                display = OverlayDisplay.Front,
                pointPath = "$[?(@.Sales>4000)]",
                width = 50,
                height = 50,
                position = AnnotationPosition.Center
            };
            plotOption.config.overlays.Add(ImageOverlayOption);

            _RectangleOverlayOption rectangleOverlayOption = new _RectangleOverlayOption();
            rectangleOverlayOption.type = "Rectangle";
            plotOption.config.overlays.Add(rectangleOverlayOption);

            _LineOverlayOption lineOverlayOption = new _LineOverlayOption();
            lineOverlayOption.type = "Line";
            plotOption.config.overlays.Add(lineOverlayOption);

            // Needle|Ellipse|Path|

            _LinearTrendlineOverlayOption trendline = new()
            {
                style = new _DataPointStyleOption()
                {
                    stroke = new _CssColorOption() { color = "rgb(89,89,89)" },
                    strokeWidth = new _StrokeWidthOption() { bottom = 2, left = 2, right = 2, top = 2 },
                    strokeOpacity = 1
                },
                type = "LinearTrendline",
                display = OverlayDisplay.Front,
                label = "Linear(s1)",
                detailKey = new List<DataValueType>() { }
            };
            plotOption.config.overlays.Add(trendline);

            _ErrorBarOption error = new()
            {
                type = "ErrorBar",
                style = new _OverlayStyleOption()
                {
                    stroke = new _CssColorOption() { color = "rgb(89,89,89)" },
                    strokeWidth = 2,
                    strokeOpacity = 1
                },
                display = OverlayDisplay.FrontOfPlot,
                orientation = ErrorBarOrientation.Vertical,
                direction = ErrorBarDirection.Both,
                errorType = ErrorBarErrorType.StandardError
            };
            error.detailKey.Add("true");
            plotOption.config.overlays.Add(error);

            // Config
            _ConfigOption configOption = new()
            {
                plotAreaLayout = new _PlotAreaLayoutOption()
                {
                    rowHeights = new List<IValueOption>() {
                        new _ValueOption {
                            type = ValueOptionType.Pixel,
                            value = 10
                        }
                    },
                    columnWidths = new List<IValueOption>() {
                        new _ValueOption {
                            type = ValueOptionType.Pixel,
                            value = 10
                        }
                    }
                },
                header = new _HeaderOption()
                {
                    title = "",
                    style = new _StyleOption()
                    {
                        backgroundColor = new _CssColorOption() { color = "lithblue" },
                        stroke = new _CssColorOption() { color = "red" },
                        strokeWidth = 2,
                        strokeDasharray = "3, 3"
                    },
                    textStyle = new _TextStyleOption() { },
                    hAlign = HAlign.Center,
                    vAlign = VAlign.Bottom,
                    borderStyle = new _LineStyleOption()
                    {
                        strokeOpacity = 0.5,
                        stroke = new _CssColorOption() { color = "red" },
                        strokeWidth = 2,
                        strokeDasharray = "3, 3"
                    },
                    height = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.25
                    },
                    maxHeight = new _ValueOption() { },
                    width = new _ValueOption() { },
                    padding = new _PaddingOption()
                    {
                        top = new _ValueOption()
                        {
                            type = ValueOptionType.Percentage,
                            value = 0.1
                        },
                        left = new _ValueOption()
                        {
                            type = ValueOptionType.Pixel,
                            value = 0.1
                        }
                    }
                },
                footer = new _FooterOption() { },
                palette = new List<IPaletteItemOption> {
                    new _PaletteItemOption()
                    {
                        color = new _CssColorOption() { color = "lithblue" },
                        type = PaletteItemType.Data,
                        data = ""
                    }
                }
            };
            configOption.palette.Add(new _PaletteItemOption()
            {
                color = new _CssColorOption() { color = "lithblue" },
                type = PaletteItemType.Data,
                data = ""
            });
            configOption.palette = new List<IPaletteItemOption> {
                new _PaletteItemOption() {
                    color = new _CssColorOption() { color = "lithblue" },
                    data = "",
                    type = PaletteItemType.Index
                }
            };
            configOption.palette = new List<IPaletteItemOption>() {
                new _PaletteItemOption() {
                    data = "",
                    color = new _CssColorOption() { color = "red" }
                },
                new _PaletteItemOption() {
                    color = new _CssColorOption() { color = "red" }
                }
            };
            configOption.bar = new _BarOption()
            {
                width = 0.5,
                overlap = 0.5,
                bottomWidth = 0.1,
                neckHeight = 0.1,
                topWidth = 0.1,
                borderRadius = new _BorderRadiusOption()
                {
                    verticalRadius = new _BorderRadiusValueOption()
                    {
                        topLeft = new _ValueOption()
                        {
                            type = ValueOptionType.Pixel,
                            value = 20
                        }
                    },
                    horizontalRadius = new _BorderRadiusValueOption()
                    {
                        topRight = new _ValueOption()
                        {
                            value = 20
                        }
                    }
                },
                funnelType = FunnelType.EqualBar
            };
            configOption.backgroundColor = new _CssColorOption() { color = "" };
            configOption.borderStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.1,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            configOption.style = new _StyleOption()
            {
                backgroundColor = new _CssColorOption() { color = "" },
                fill = new _CssColorOption() { color = "" },
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            configOption.textStyle = new _TextStyleOption()
            {
                color = "",
                fontSize = "",
                fontFamily = "",
                fontStyle = FontStyle.Italic,
                fontWeight = "",
                textDecoration = new _TextDecorationOption()
                {
                    lineThrough = true,
                    overline = false,
                    underline = true
                },
                overflow = TextOverflow.Clip,
                opacity = 0.1,
                writingMode = TextWritingMode.Horizontal
            };
            configOption.legend = new _GlobalLegendOption()
            {
                style = new _LegendStyleOption()
                {
                    backgroundColor = new _CssColorOption() { color = "" },
                    stroke = new _CssColorOption() { color = "" },
                    strokeWidth = 1,
                    strokeDasharray = "",
                    iconColor = new _CssColorOption() { color = "" }
                },
                textStyle = new _TextStyleOption()
                {
                    color = "",
                    fontSize = "",
                    fontFamily = "",
                    fontStyle = FontStyle.Italic,
                    fontWeight = "",
                    textDecoration = new _TextDecorationOption()
                    {
                        lineThrough = true,
                        overline = false,
                        underline = true
                    },
                    overflow = TextOverflow.Clip,
                    opacity = 0.1
                },
                titleStyle = new _TextStyleOption()
                {
                    color = "",
                    fontSize = "",
                    fontFamily = "",
                    fontStyle = FontStyle.Italic,
                    fontWeight = "",
                    textDecoration = new _TextDecorationOption()
                    {
                        lineThrough = true,
                        overline = false,
                        underline = true
                    },
                    overflow = TextOverflow.Clip,
                    opacity = 0.1,
                    writingMode = TextWritingMode.Vertical
                },
                titlePosition = Position.Left,
                position = LegendPosition.Bottom,
                orientation = Orientation.Horizontal,
                wrapping = false,
                borderStyle = new _LineStyleOption()
                {
                    strokeOpacity = 0.1,
                    stroke = new _CssColorOption() { color = "" },
                    strokeWidth = 1,
                    strokeDasharray = ""
                },
                //filteredOutStyle = new _TextStyleOption() { color = "" },
                itemPadding = new _PaddingOption() { 
                    bottom = new _ValueOption() {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    },
                    left = new _ValueOption() {
                        type = ValueOptionType.Pixel,
                        value = 0.1
                    }
                },
                padding = new _PaddingOption() { 
                    top = new _ValueOption() {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }
                },
                hoverStyle = new _TextStyleOption() { color = "" },
                groupHAlign = HAlign.Right,
                groupVAlign = VAlign.Bottom,
                groupOrientation = Orientation.Vertical,
                groupPadding = new _PaddingOption() { 
                    left = new _ValueOption() {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }
                },
                margin = new _MarginOption() { right = 10 },
                left = 0.5,
                top = 0.5,
                itemSpace = new _ValueOption()
                {
                    type = ValueOptionType.Percentage,
                    value = 0.5
                }
            };
            configOption.padding = new _PaddingOption() { 
                top = new _ValueOption()
                {
                    type = ValueOptionType.Percentage,
                    value = 0.1
                }
            };
            configOption.shapes = new List<ISymbolItemOption>() {
                new _SymbolItemOption() {
                    data = "",
                    shape = new _SymbolShapeOption() {
                        name = "shape1",
                        content = "path:M539.32 861.2c30.9 0 29.84 28.36 66.84 36.28 148.4 31.73 229.76-179.02 239.64-322.94 9.07-132-44.57-195.63-161.05-226.46-68.27-18.07-108.23 9.49-145.43 9.49s-77.16-27.56-145.43-9.49C277.4 378.9 231.72 448.58 232.83 574.53c1.27 144.26 91.25 354.67 239.64 322.94 37.01-7.91 35.95-36.27 66.85-36.27z"
                    }
                },
                new _SymbolItemOption() {
                    data = ""
                }
            };
            dvOption.config = configOption;

            // PlotAreas
            _PlotAreaOption plotArea = new _PlotAreaOption();
            plotArea.backgroundColor = new _CssColorOption() { color = "" };
            plotArea.borderStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.1,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            plotArea.style = new _PlotAreaStyleOption()
            {
                backgroundColor = new _CssColorOption() { color = "" },
                fill = new _CssColorOption() { color = "" },
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = "",
                innerStroke = new _CssColorOption() { color = "" },
                innerStrokeWidth = 1,
                innerStrokeDasharray = ""
            };
            plotArea.textStyle = new _TextStyleOption()
            {
                color = "",
                fontSize = "",
                fontFamily = "",
                fontStyle = FontStyle.Italic,
                fontWeight = "",
                textDecoration = new _TextDecorationOption()
                {
                    lineThrough = true,
                    overline = false,
                    underline = true
                },
                overflow = TextOverflow.Clip,
                opacity = 0.1,
                writingMode = TextWritingMode.Horizontal
            };
            plotArea.padding = new _PaddingOption() { 
                top = new _ValueOption()
                {
                    type = ValueOptionType.Percentage,
                    value = 0.1
                }
            };
            plotArea.legend = new _GlobalLegendOption()
            {
                style = new _LegendStyleOption()
                {
                    backgroundColor = new _CssColorOption() { color = "lightblue" },
                    stroke = new _CssColorOption() { color = "red" },
                    strokeWidth = 4,
                    strokeDasharray = "5, 5",
                    iconColor = new _CssColorOption() { color = "lightblue" }
                },
                textStyle = new _TextStyleOption()
                {
                    color = "red",
                    fontSize = "18",
                    fontFamily = "Lucida Console",
                    fontStyle = FontStyle.Oblique,
                    fontWeight = "Bold",
                    textDecoration = new _TextDecorationOption()
                    {
                        lineThrough = true,
                        overline = true,
                        underline = true
                    },
                    opacity = 0.5
                },
                titleStyle = new _TextStyleOption()
                {
                    color = "red",
                    fontSize = "22",
                    fontFamily = "MingLiU",
                    fontStyle = FontStyle.Oblique,
                    fontWeight = "Bold",
                    textDecoration = new _TextDecorationOption()
                    {
                        lineThrough = true,
                        overline = true,
                        underline = true
                    },
                    opacity = 0.3
                },
                position = LegendPosition.Left,
                orientation = Orientation.Horizontal,
                borderStyle = new _LineStyleOption()
                {
                    stroke = new _CssColorOption() { color = "red" },
                    strokeWidth = 2,
                    strokeDasharray = "5, 5",
                    strokeOpacity = 0.5
                },
                itemPadding = new _PaddingOption() { 
                    top = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }, 
                    left = new _ValueOption()
                    {
                        type = ValueOptionType.Pixel,
                        value = 0.1
                    }, 
                    right = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }, 
                    bottom = new _ValueOption()
                    {
                        type = ValueOptionType.Pixel,
                        value = 0.1
                    }
                },
                padding = new _PaddingOption() { 
                    top = new _ValueOption()
                    {
                        type = ValueOptionType.Pixel,
                        value = 0.1
                    }, 
                    left = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }, 
                    right = new _ValueOption()
                    {
                        type = ValueOptionType.Pixel,
                        value = 0.1
                    }, 
                    bottom = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }
                },
                titlePosition = Position.Bottom,
                wrapping = false,
                margin = new _MarginOption() { top = 40, bottom = 50 },
                groupPadding = new _PaddingOption() { 
                    top = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }
                }
            };
            plotArea.legends = new List<ILegendOption>() {
                new _LegendOption() {
                    type = LegendType.Color,
                    title = "",
                    gradient = new _LegendGradientOption() {
                        enabled = false,
                        min = 1000,
                        max = 2000,
                        unit = 100,
                        palette = new List<string>() { "red","blue","yellow" }
                    },
                    ranges = new List<ILegendRangeOption> {
                        new _LegendRangeOption {
                            to = 5000,
                            title = "0 - 5000"
                        },
                        new _LegendRangeOption {
                            to = 10000,
                            title = "5000 - 10000"
                        },
                        new _LegendRangeOption {
                            to = 15000,
                            title = "10000 - 15000"
                        }
                    },
                    height = new _ValueOption() {
                        type = ValueOptionType.Percentage,
                        value = 200
                    },
                    width = new _ValueOption(){ },
                    maxHeight = new _ValueOption() {
                        type = ValueOptionType.Percentage,
                        value = 0.2
                    },
                    maxWidth = new _ValueOption() { },
                    items = new List<ILegendItemOption>() {
                        new _LegendItemOption {
                            text = "Customer"
                        },
                        new _LegendItemOption {
                            textStyle = new _TextStyleOption() {
                                color = "red",
                                fontSize = "20",
                                fontWeight = "Bold",
                                fontStyle = FontStyle.Italic,
                                fontFamily = "Lucida Console"
                            }
                        }
                    },
                    sortOrder = SortOrder.Ascending,
                    template = "legend.shape",

                    merge = new List<IMergeLegendTypeOption>() {
                        new _MergeLegendTypeOption() {
                            type = LegendType.Color,
                            plotName = "p1"
                        },
                        new _MergeLegendTypeOption() {
                            type = LegendType.Shape,
                            plotName = "p1"
                        }
                    },

                    hAlign = HAlign.Center,
                    vAlign = VAlign.Bottom
                },
                new _LegendOption() {
                    style = new _LegendStyleOption() {
                        backgroundColor = new _PatternOption() {
                            color = new _CssColorOption() { color = "lightblue" },
                            pattern = new List<IPathWithStyleOption>() {
                                new _PathWithStyleOption {
                                    style = new _StyleOption() {
                                        fill = new _CssColorOption() {
                                            color = "green"
                                        }
                                    },
                                    content = "path:Weave"
                                }
                            }
                        }
                    }
                }
            };
            plotArea.plotsMargin = new _MarginOption() { left = 10 };
            //plotArea.zoom

            plotArea.column = 0;
            plotArea.row = 0;

            // Axis
            _AxisOption xAxis = new _AxisOption();
            xAxis.plots.Add("p1");
            xAxis.plots = new List<string>() { "p1", "p2" };
            xAxis.type = AxisType.X;
            xAxis.title = "";
            xAxis.labelAngle = new List<double?>() { 40, 50 };
            xAxis.labels = AxisPosition.None;
            xAxis.axisLine = true;
            xAxis.labelStyle = new _LabelStyleOption()
            {
                color = "",
                fontSize = "",
                fontFamily = "",
                fontStyle = FontStyle.Italic,
                fontWeight = "",
                textDecoration = new _TextDecorationOption()
                {
                    lineThrough = true,
                    overline = false,
                    underline = true
                },
                overflow = TextOverflow.Clip,
                opacity = 0.1,
                padding = new _PaddingOption() { 
                    top = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }
                }
            };
            xAxis.titleStyle = new _LabelStyleOption()
            {
                color = "",
                fontSize = "",
                fontFamily = "",
                fontStyle = FontStyle.Italic,
                fontWeight = "",
                textDecoration = new _TextDecorationOption()
                {
                    lineThrough = true,
                    overline = false,
                    underline = true
                },
                overflow = TextOverflow.Clip,
                opacity = 0.1,
                padding = new _PaddingOption() { 
                    top = new _ValueOption()
                    {
                        type = ValueOptionType.Percentage,
                        value = 0.1
                    }
                }
            };
            xAxis.lineStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.5,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            xAxis.overlappingLabels = OverlappingLabels.Hide;
            xAxis.format = new _FormatOption() { type = "", value = "" };
            xAxis.scale = new _ValueScaleOption() { type = ValueScaleType.Linear };
            xAxis.logBase = 10;
            xAxis.origin = 0;
            xAxis.reversed = true;
            xAxis.dateMode = DateMode.Day;
            xAxis.minorUnit = new _AxisUnitOption() { value = 500, dateMode = DateMode.Hour };
            xAxis.minorTicks = TickMark.Cross;
            xAxis.minorTickSize = 10;
            xAxis.minorTickStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.5,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            xAxis.minorGrid = true;
            xAxis.minorGridStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.5,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            xAxis.groupGrid = TickMark.Inside;
            xAxis.groupGridStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.5,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            xAxis.majorUnit = new _AxisUnitOption() { value = 500, dateMode = DateMode.Hour };
            xAxis.majorTicks = TickMark.Cross;
            xAxis.majorTickSize = 10;
            xAxis.majorTickStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.5,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            xAxis.majorGridStyle = new _LineStyleOption()
            {
                strokeOpacity = 0.5,
                stroke = new _CssColorOption() { color = "" },
                strokeWidth = 1,
                strokeDasharray = ""
            };
            xAxis.position = AxisPosition.Near;
            xAxis.min = new _ValueOption() { type = ValueOptionType.Percentage, value = 10 };
            xAxis.max = new _ValueOption() { type = ValueOptionType.Number, value = 10 };
            xAxis.useActualMax = true;
            xAxis.useActualMin = true;
            xAxis.height = new _ValueOption() { type = ValueOptionType.Percentage, value = 0.5 };
            xAxis.maxHeight = new _ValueOption() { };
            xAxis.width = new _ValueOption() { type = ValueOptionType.Pixel, value = 1 };
            xAxis.maxWidth = new _ValueOption() { };
            xAxis.viewSize = 0.5;
            xAxis.scrollbarVisible = true;
            xAxis.rules = new List<IRuleOption>() {
                new _RuleOption() {
                    condition = "",
                    type = "",
                    actions = new List<IRuleActionOption>() {
                        new _RuleActionOption {
                            targetElement = "",
                            properties = new List<IRuleActionPropertyOption>() {
                                new _RuleActionPropertyOption {
                                    name = "",
                                    value = ""
                                },
                                new _RuleActionPropertyOption { }
                            }
                        }
                    }
                },
                new _RuleOption() { }
            };
            xAxis.unitLabel = new _UnitLabelOption()
            {
                text = "",
                textStyle = new _LabelStyleOption()
                {
                    color = "red",
                    fontSize = "20",
                    fontFamily = "YouYuan",
                    fontStyle = FontStyle.Italic,
                    fontWeight = "Bold",
                    textDecoration = new _TextDecorationOption() { underline = true },
                    padding = new _PaddingOption() { 
                        bottom = new _ValueOption()
                        {
                            type = ValueOptionType.Percentage,
                            value = 0.1
                        }
                    }
                },
                style = new _StyleOption()
                {
                    backgroundColor = new _CssColorOption() { color = "lightblue" },
                    stroke = new _CssColorOption() { color = "lightblue" },
                    strokeWidth = 6,
                    strokeDasharray = "10, 10"
                },
                labelAngle = 45
            };
            xAxis.trackers = new List<ITrackerOption>() {
                new _TrackAreaOption() {
                    //type = TrackerType.Area,
                    fill = new _CssColorOption() { color = "" },
                    opacity = 0.5
                }
            };
            xAxis.style = new _StyleOption() { };
            xAxis.textStyle = new _TextStyleOption() { };
            xAxis.textStyle.color = "rgba(89,89,89,1)";
            xAxis.textStyle.fontFamily = "Calibri";
            xAxis.textStyle.fontSize = "12";
            plotArea.axes.Add(xAxis);

            _AxisOption yAxis = new _AxisOption();

            _PlotOption plotOption2 = new _PlotOption();
            plotOption2.name = "p2";

            var plotAreas = new List<IPlotAreaOption>();
            plotAreas.Add(plotArea);
            dvOption.config.plotAreas = plotAreas;

            _BinTransformOption transformOption = new _BinTransformOption();
            transformOption.field = "Sales";
            transformOption.bin = new _BinOption()
            {
                steps = new List<double> { 3000, 6000, 9000, 12000 }
            };
            transformOption.outputAs = "SalesBin";

            dvOption.transform.Add(transformOption);

            dvOption.data = GetData();
        }

        private static GcBitmap DrawImage(IDvOption dvOption, Size size)
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

        private static string DrawSvg(IDvOption dvOption, Size size)
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

        internal static void DAT_3351(Size size)
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

        internal static void DAT_3359(Size size)
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

        internal static void DAT_3361(Size size)
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

        internal static void DAT_3386(Size size)
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

            dvOption.data = DAT_3386();

            // result is svg
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
        }

        internal static void DAT_2742(Size size)
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
                data = GetData()
            };
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
        }

        internal static void DAT_2746(Size size)
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
                data = DAT_2746()
            };
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_2747(Size size)
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
                data = DAT_2747()
            };
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_2726(Size size)
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
                data = GetData()
            };
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_2745(Size size)
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
                data = GetData()
            };
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_2722(Size size)
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
                data = GetData()
            };
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_3575(Size size)
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
                                    path = new List<String>() {"M 250,75 L 323,301 131,161 369,161 177,301 z"}
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
                data = GetData()
            };
            DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
            File.WriteAllText(casePath + "_CSharp.svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_3575B(Size size)
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
                data = GetData()
            };
            DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
            File.WriteAllText(casePath + "_CSharp.svg", DrawSvg(dvOption, size));
            var jsonContents = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson.json", jsonContents);
        }

        internal static void DAT_3592(Size size)
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
            DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

            // result is svg
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));

            // after
            var jsonAfter = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson_After.json", jsonAfter);
        }

        internal static void DAT_3807(Size size)
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
            DrawImage(dvOption, size).SaveAsPng(casePath + ".png");

            // result is svg
            File.WriteAllText(casePath + ".svg", DrawSvg(dvOption, size));

            // after
            var jsonAfter = dvOption.ToJson();
            File.WriteAllText(casePath + "_ToJson_After.json", jsonAfter);
        }

        internal static void DAT_3609(Size size)
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
            DrawImage(dvOption, size).SaveAsPng(casePath + "_CSharp.png");
            // result is svg
            File.WriteAllText(casePath + "_CSharp.svg", DrawSvg(dvOption, size));

            Thread.CurrentThread.CurrentCulture = savedCulture;
            System.Console.WriteLine("Restore： " + numberDecimalSeparator.ToString());
        }

        public static List<IDataOption> GetData()
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
                    values = new List<object> { dict1, dict2, dict3, dict4, dict5, dict6, dict7 }
                }
            };

            return data;
        }

        public static List<IDataOption> GetCalculateTransform()
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

        public static List<IDataOption> NaNTest()
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

        // DAT-3286 ues same data
        public static List<IDataOption> DAT_3287()
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

        public static List<IDataOption> HLOC()
        {
            var caseData = new List<IDataOption>()
            {new _DataOption()
            {dateFormats = new List<System.String>()
            {"false"}, name = "sample", values = new List<System.Object>()
            {new Dictionary<string, object>()
            {{"date", "01/05/15"}, {"Year", "2000-01-05T11:23:15.000Z"}, {"Day", "2011-01-05T11:23:15.000Z"}, {"Day1", "2020-01-01T11:23:15.000Z"}, {"Month", "2020-01-01T11:23:15.000Z"}, {"Hour", "2011-01-01T01:23:15.000Z"}, {"Hour1", "2011-01-01T00:23:15.000Z"}, {"Minute", "2019-01-01T12:00:00.000Z"}, {"Second", "2019-01-01T12:00:00.000Z"}, {"MilliSecond", "2019-01-01T12:00:00.000Z"}, {"open", 77.98}, {"high", 79.25}, {"low", 76.86}, {"close", 77.19}, {"negative", -77.19}, {"volume", 26452191}, {"openA", 75.71}, {"highA", 75.98}, {"lowA", 75.21}, {"closeA", 75.62}, {"volumeA", 15062573}}, new Dictionary<string, object>()
            {{"date", "01/06/15"}, {"Year", "2001-02-05T11:23:15.000Z"}, {"Day", "2011-01-06T12:13:25.000Z"}, {"Day1", "2020-01-02T11:23:15.000Z"}, {"Month", "2020-02-02T11:23:15.000Z"}, {"Hour", "2011-01-01T02:23:15.000Z"}, {"Hour1", "2011-01-01T03:23:15.000Z"}, {"Minute", "2019-01-01T12:01:00.000Z"}, {"Second", "2019-01-01T12:00:01.000Z"}, {"MilliSecond", "2019-01-01T12:00:00.999Z"}, {"open", 77.23}, {"high", 77.59}, {"low", 75.36}, {"close", 76.15}, {"negative", -76.15}, {"volume", 27399288}, {"openA", 75.68}, {"highA", 75.7}, {"lowA", 74.25}, {"closeA", 74.47}, {"volumeA", 21210994}}, new Dictionary<string, object>()
            {{"date", "01/07/15"}, {"Year", "2002-03-05T11:23:15.000Z"}, {"Day", "2011-01-07T11:23:15.000Z"}, {"Day1", "2020-01-15T11:23:15.000Z"}, {"Month", "2020-03-03T11:23:15.000Z"}, {"Hour", "2011-01-01T03:23:15.000Z"}, {"Hour1", "2011-01-01T06:23:15.000Z"}, {"Minute", "2019-01-01T12:02:00.000Z"}, {"Second", "2019-01-01T12:00:02.000Z"}, {"MilliSecond", "2019-01-01T12:00:00.100Z"}, {"open", 76.76}, {"high", 77.36}, {"low", 75.82}, {"close", 76.15}, {"negative", -75.82}, {"volume", 22045333}, {"openA", 74.05}, {"highA", 74.83}, {"lowA", 73.45}, {"closeA", 74.44}, {"volumeA", 16194322}}, new Dictionary<string, object>()
            {{"date", "01/08/15"}, {"Year", "2003-04-05T11:23:15.000Z"}, {"Day", "2011-01-08T02:59:25.000Z"}, {"Day1", "2020-01-30T11:23:15.000Z"}, {"Hour", "2011-01-01T04:23:15.000Z"}, {"Hour1", "2011-01-01T09:23:15.000Z"}, {"Minute", "2019-01-01T12:15:00.000Z"}, {"Second", "2019-01-01T12:00:15.000Z"}, {"open", 76.74}, {"high", 78.23}, {"low", 76.08}, {"close", 78.18}, {"negative", -76.74}, {"volume", 23960953}, {"openA", 74.85}, {"highA", 75.34}, {"lowA", 74.5}, {"closeA", 75.19}, {"volumeA", 15811344}}, new Dictionary<string, object>()
            {{"date", "01/09/15"}, {"Year", "2004-05-05T11:23:15.000Z"}, {"Day", "2011-01-09T11:23:15.000Z"}, {"Day1", "2020-01-31T11:23:15.000Z"}, {"Hour", "2011-01-01T05:23:15.000Z"}, {"Hour1", "2011-01-01T12:23:15.000Z"}, {"Minute", "2019-01-01T12:30:00.000Z"}, {"Second", "2019-01-01T12:00:30.000Z"}, {"open", 78.2}, {"high", 78.62}, {"low", 77.2}, {"close", 77.74}, {"negative", -77.74}, {"volume", 21157007}, {"openA", 75.09}, {"highA", 76.75}, {"lowA", 75.03}, {"closeA", 76.51}, {"volumeA", 20877427}}, new Dictionary<string, object>()
            {{"date", "01/12/15"}, {"Year", "2005-06-05T11:23:15.000Z"}, {"Day", "2011-01-12T13:23:15.000Z"}, {"Hour", "2011-01-01T06:23:15.000Z"}, {"Hour1", "2011-01-01T13:23:15.000Z"}, {"Minute", "2019-01-01T12:45:00.000Z"}, {"Second", "2019-01-01T12:00:45.000Z"}, {"open", 77.84}, {"high", 78}, {"low", 76.21}, {"close", 76.72}, {"negative", -76.19}, {"volume", 19190194}, {"openA", 76.86}, {"highA", 76.87}, {"lowA", 75.89}, {"closeA", 76.23}, {"volumeA", 17234976}}, new Dictionary<string, object>()
            {{"date", "01/13/15"}, {"Year", "2006-07-05T11:23:15.000Z"}, {"Day", "2011-01-13T03:00:00.000Z"}, {"Hour", "2011-01-01T07:23:15.000Z"}, {"Hour1", "2011-01-01T18:23:15.000Z"}, {"Month", "2020-07-07T11:23:15.000Z"}, {"Minute", "2019-01-01T12:59:00.000Z"}, {"Second", "2019-01-01T12:00:59.000Z"}, {"open", 77.23}, {"high", 78.08}, {"low", 75.85}, {"close", 76.45}, {"negative", -72.19}, {"volume", 25179561}, {"openA", 76.46}, {"highA", 76.48}, {"lowA", 75.5}, {"closeA", 75.74}, {"volumeA", 18621860}}, new Dictionary<string, object>()
            {{"date", "01/14/15"}, {"Year", "2008-08-05T11:23:15.000Z"}, {"Day", "2011-01-14T11:23:15.000Z"}, {"Hour", "2011-01-01T08:23:15.000Z"}, {"Hour1", "2011-01-01T21:23:15.000Z"}, {"Month", "2021-01-07T11:23:15.000Z"}, {"Minute", "2019-01-01T12:58:00.000Z"}, {"open", 76.42}, {"high", 77.2}, {"low", 76.03}, {"close", 76.28}, {"negative", -71.19}, {"volume", 25918564}, {"openA", 75.3}, {"highA", 76.91}, {"lowA", 75.08}, {"closeA", 75.6}, {"volumeA", 25254400}}, new Dictionary<string, object>()
            {{"date", "01/15/15"}, {"Year", "2009-09-05T11:23:15.000Z"}, {"Day", "2011-01-15T01:11:15.000Z"}, {"Hour", "2011-01-01T09:23:15.000Z"}, {"Minute1", "2019-01-02T12:00:00.000Z"}, {"open", 76.4}, {"high", 76.57}, {"low", 73.54}, {"close", 74.05}, {"negative", -80.19}, {"volume", 34133974}, {"openA", 75.94}, {"highA", 76.9}, {"lowA", 75.45}, {"closeA", 76.71}, {"volumeA", 22426421}}, new Dictionary<string, object>()
            {{"date", "01/16/15"}, {"Year", "2010-10-05T11:23:15.000Z"}, {"Day", "2011-01-16T22:22:22.000Z"}, {"Hour", "2011-01-01T10:23:15.000Z"}, {"Month", "2020-10-10T11:23:15.000Z"}, {"open", 74.04}, {"high", 75.32}, {"low", 73.84}, {"close", 75.18}, {"negative", -75.29}, {"volume", 21791529}, {"openA", 76.99}, {"highA", 79.84}, {"lowA", 76.95}, {"closeA", 79.42}, {"volumeA", 45851177}}, new Dictionary<string, object>()
            {{"date", "01/20/15"}, {"Year", "2011-11-05T11:23:15.000Z"}, {"Day", "2011-01-20T11:23:15.000Z"}, {"Hour", "2011-01-01T11:23:15.000Z"}, {"open", 75.72}, {"high", 76.31}, {"low", 74.82}, {"close", 76.24}, {"negative", -70.09}, {"volume", 22821614}}, new Dictionary<string, object>()
            {{"date", "01/21/15"}, {"Year", "2012-12-05T11:23:15.000Z"}, {"Day", "2011-01-21T12:02:03.000Z"}, {"Hour", "2011-01-01T12:23:15.000Z"}, {"Month", "2020-12-12T11:23:15.000Z"}, {"open", 76.16}, {"high", 77.3}, {"low", 75.85}, {"close", 76.74}, {"negative", -71.1}, {"volume", 25096737}, {"openA", 79.55}, {"highA", 80.34}, {"lowA", 79.2}, {"closeA", 79.9}, {"volumeA", 36931698}}, new Dictionary<string, object>()
            {{"date", "01/22/15"}, {"Year", "2013-01-05T11:23:15.000Z"}, {"Day", "2011-01-22T01:20:15.000Z"}, {"Hour", "2011-01-01T13:23:15.000Z"}, {"Month", "2020-12-13T11:23:15.000Z"}, {"open", 77.17}, {"high", 77.75}, {"low", 76.68}, {"close", 77.65}, {"negative", -72}, {"volume", 19519458}, {"openA", 79.96}, {"highA", 80.19}, {"lowA", 78.38}, {"closeA", 78.84}, {"volumeA", 24139056}}, new Dictionary<string, object>()
            {{"date", "01/23/15"}, {"Year", "2014-02-05T11:23:15.000Z"}, {"Day", "2011-01-23T23:23:15.000Z"}, {"Hour", "2011-01-01T14:23:15.000Z"}, {"Month", "2019-07-07T11:23:15.000Z"}, {"open", 77.65}, {"high", 78.19}, {"low", 77.04}, {"close", 77.83}, {"negative", -77}, {"volume", 16746503}, {"openA", 78.5}, {"highA", 79.48}, {"lowA", 78.1}, {"closeA", 78.45}, {"volumeA", 18897133}}, new Dictionary<string, object>()
            {{"date", "01/26/15"}, {"Year", "2015-03-05T11:23:15.000Z"}, {"Day", "2011-01-26T19:23:15.000Z"}, {"Hour", "2011-01-01T15:23:15.000Z"}, {"open", 77.98}, {"high", 78.47}, {"low", 77.29}, {"close", 77.5}, {"negative", -73}, {"volume", 19260820}, {"openA", 78.5}, {"highA", 80.2}, {"lowA", 78.5}, {"closeA", 79.56}, {"volumeA", 25593800}}, new Dictionary<string, object>()
            {{"date", "01/27/15"}, {"Year", "2016-04-05T11:23:15.000Z"}, {"Day", "2011-01-27T23:23:15.000Z"}, {"Hour", "2011-01-01T16:23:15.000Z"}, {"open", 76.71}, {"high", 76.88}, {"low", 75.63}, {"close", 75.78}, {"negative", -79}, {"volume", 20109977}, {"openA", 79.88}, {"highA", 81.37}, {"lowA", 79.72}, {"closeA", 80.41}, {"volumeA", 31111891}}, new Dictionary<string, object>()
            {{"date", "01/28/15"}, {"Year", "2017-05-05T11:23:15.000Z"}, {"Day", "2011-01-28T03:23:15.000Z"}, {"Hour", "2011-01-01T17:23:15.000Z"}, {"open", 76.9}, {"high", 77.64}, {"low", 76}, {"close", 76.24}, {"negative", -79.19}, {"volume", 53306422}, {"openA", 80.68}, {"highA", 81.23}, {"lowA", 78.62}, {"closeA", 78.97}, {"volumeA", 30739197}}, new Dictionary<string, object>()
            {{"date", "01/29/15"}, {"Year", "2018-06-05T11:23:15.000Z"}, {"Day", "2011-01-29T13:59:15.000Z"}, {"Hour", "2011-01-01T18:23:15.000Z"}, {"open", 76.85}, {"high", 78.02}, {"low", 74.21}, {"close", 78}, {"negative", -72.59}, {"volume", 61293468}, {"openA", 79.61}, {"highA", 79.7}, {"lowA", 78.52}, {"closeA", 79.6}, {"volumeA", 18634973}}}}};
            return caseData;
        }

        public static List<IDataOption> DAT_3323()
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

        public static List<IDataOption> DAT_3386()
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

        public static List<IDataOption> DAT_3356()
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

        public static List<IDataOption> DAT_2746()
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

        public static List<IDataOption> DAT_2747()
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

        internal static void RunTimeModel(Size size, string casePath)
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
            System.Console.WriteLine("-----------------------------------------------------------------------------");
            WriteFile(casePath, result);

            //var json = this.GenerateJson(dv.Model);

            //var runTimeModels = dv.Model;
            //System.Console.WriteLine("-------" + runTimeModels + "--------");
            //foreach (var runTimeModel in runTimeModels.GetType().GetProperties())
            //{
            //    var value = runTimeModel.GetValue(runTimeModels);
            //    if (!runTimeModel.Name.StartsWith("_"))
            //    {
            //        if (runTimeModel.PropertyType.Name.Equals("List`1"))
            //        {
            //            var itemType = runTimeModel.PropertyType.GetGenericArguments()[0];
            //            System.Console.WriteLine(runTimeModel.Name + "\t" + value);
            //            GetGenericProperty(itemType, visitedTypes);
            //            //var items = value as System.Collections.IEnumerable;
            //            //foreach (var obj in items)
            //            //{
            //            //    GetGenericProperty(obj, itemType, visitedTypes);
            //            //}
            //        }
            //        else
            //        {
            //            System.Console.WriteLine(runTimeModel.Name + "\t" + value);
            //        }
            //    }
            //}

            //var contents = new List<string>();
            //GetProperty(dv);

            //var legendsModels = dv.Model.plotAreas[0].legends;
            //GetLegends(legendsModels);

            //var dict = DictionaryToJson(casePath);
            //TraversalDictionary(dict);
        }

        private static Dictionary<string, object> GenerateRunTimeModel(object models, List<object> visitedTypes)
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
                    if (item.Name == "type")
                    {
                        System.Console.WriteLine("----------------" + propertyValue);
                    }
                    if (item.PropertyType.Name.Equals("List`1"))
                    {
                        System.Console.WriteLine("-------List: " + item.Name);
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
                    else if (propertyValue is Enum)
                    {
                        System.Console.WriteLine("Enum: " + item.Name + "\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                    else if (propertyValue is Int32)
                    {
                        System.Console.WriteLine("Int32: " + item.Name + "\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                    else if (propertyValue is double)
                    {
                        System.Console.WriteLine("double: " + item.Name + "\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                    else if (propertyValue is string)
                    {
                        System.Console.WriteLine("string: " + item.Name + "\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                    else if (propertyValue is Boolean)
                    {
                        System.Console.WriteLine("Boolean: " + item.Name + "\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                    else if (propertyValue == null)
                    {
                        System.Console.WriteLine("null: " + item.Name + "\t" + null);
                        dictionaryRoot.Add(item.Name, null);
                    }
                    else if (propertyValue is Point)
                    {
                        System.Console.WriteLine("Point: " + item.Name + "\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                    else if (propertyValue is FlexDV)
                    {
                    }
                    else if (item.Name.Equals("label"))
                    {
                        //System.Console.WriteLine("---Remove label");
                        //var itemType = item.GetType().GetProperties();

                        List<object> child = new List<object>();
                        //Dictionary<string, object> dictionaryChild = GenerateRunTimeModel(item, visitedTypes);
                        
                        var propertys = propertyValue.GetType().GetProperties();
                        foreach (var property in propertys)
                        {
                            //dictionaryChild.Add(property.Name, propertyValue);
                            //child.Add(dictionaryChild);
                            //if (!dictionaryRoot.ContainsKey(item.Name))
                            //{
                            //    dictionaryRoot.Add(item.Name, child);
                            //}
                            if (!property.Name.StartsWith("_") && !property.Name.Equals("parent"))
                            {
                                var aa = property.PropertyType.GetGenericArguments()[0];
                                System.Console.WriteLine(property.Name + ":" + aa);
                                //child.Add(property);
                            }
                        }
                        dictionaryRoot.Add(item.Name, child);
                        System.Console.WriteLine();
                    }
                    else
                    {
                        System.Console.WriteLine("else: " + item.Name +"\t" + propertyValue);
                        dictionaryRoot.Add(item.Name, propertyValue);
                    }
                }
            }
            return dictionaryRoot;
        }

        private static void GenerateRunTimeModel(object model)
        {
            System.Console.WriteLine("--------- " + model);
            foreach (var item in model.GetType().GetProperties())
            {
                if (!item.Name.StartsWith("_"))
                {
                    var propertyValue = item.GetValue(model, null);
                    var propertyItems = propertyValue as System.Collections.IEnumerable;

                    if (propertyValue is Array)
                    {
                        System.Console.WriteLine("Array: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is List<object>)
                    {
                        System.Console.WriteLine("List: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is string)
                    {
                        System.Console.WriteLine("string: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is int)
                    {
                        System.Console.WriteLine("int: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is Enum)
                    {
                        System.Console.WriteLine("Enum: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is null)
                    {
                        System.Console.WriteLine("null: " + item.Name + "\t" + propertyValue);
                    }
                    else if(propertyValue is FlexDV)
                    {
                        System.Console.WriteLine("FlexDV: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is IConfigOption)
                    {
                        System.Console.WriteLine("IConfigOption: " + item.Name + "\t" + propertyValue);
                    }
                    else if (propertyValue is IPlotAreaView)
                    {
                        System.Console.WriteLine("IPlotAreaView: " + item.Name + "\t" + propertyValue);
                    }
                    else
                    {
                        System.Console.WriteLine("else: " + item.Name + "\t" + propertyValue);
                    }

                    if (propertyItems != null)
                    {
                        System.Console.WriteLine("---------");
                        foreach (var propertyItem in propertyItems.GetType().GetProperties())
                        {
                            var propertiesValue = propertyItem.GetValue(propertyItems, null);
                            System.Console.WriteLine(propertyItem.Name + "\t" + propertiesValue);
                        }
                    }
                }
            }
            System.Console.WriteLine("--------- " + model + " end");
        }

        private static void GenerateRunTimeModelProperty(List<object> models)
        {
            foreach (var model in models)
            {
                System.Console.WriteLine("----GetLegends----- " + model);
                foreach (var item in model.GetType().GetProperties())
                {
                    var value = item.GetValue(model);
                    if (!item.Name.StartsWith("_"))
                    {
                        if (item.PropertyType.Name.Equals("List`1"))
                        {
                            var itemType = item.PropertyType.GetGenericArguments()[0];
                            System.Console.WriteLine(item.Name + "\t" + value);
                            var items = value as System.Collections.IEnumerable;
                            foreach (var obj in items)
                            {
                                GetLegendsProperty(obj, itemType, item.Name);
                            }
                        }
                        else
                        {
                            System.Console.WriteLine(item.Name + "\t" + value);
                        }
                    }
                }
                System.Console.WriteLine("----GetLegends----- " + model + " end");
            }
        }

        private Dictionary<string, object> GenerateDictionary(object model)
        {
            var dictionary = new Dictionary<string, object>();

            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                //if (this.IsIgnoredProperty(propertyInfo))
                //{
                //    continue;
                //}

                var propertyValue = propertyInfo.GetValue(model);
                if (propertyValue is Array)
                {

                } else if (propertyValue is object)
                {
                    propertyValue = this.GenerateDictionary(propertyValue);
                }
                dictionary.Add(propertyInfo.Name, propertyValue);
            }

            return dictionary;
        }

        private static List<string> GetGenericProperty(Type type, List<Type> visitedTypes)
        {
            System.Console.WriteLine("----GetGenericProperty----- " + type.Name);
            List<string> result = new List<string>();

            if (visitedTypes.Contains(type))
            {
                System.Console.WriteLine("----GetGenericProperty----- " + type.Name + " out");
                return result;
            }
            visitedTypes.Add(type);

            foreach (var item in type.GetProperties())
            {
                if (!item.Name.StartsWith("_"))
                {
                    if (item.PropertyType.Name.Equals("List`1"))
                    {
                        var itemType = item.PropertyType.GetGenericArguments()[0];
                        System.Console.WriteLine(item);
                        GetGenericProperty(itemType, visitedTypes);
                    }
                    else
                    {
                        System.Console.WriteLine(item);
                    }
                }
            }
            System.Console.WriteLine("----GetGenericProperty----- " + type.Name + " end");
            return result;
        }

        private static List<string> GetGenericProperty(object obj, Type type, string name, List<Type> visitedTypes)
        {
            System.Console.WriteLine("----GetGenericProperty----- " + type.Name);
            List<string> result = new List<string>();

            if (visitedTypes.Contains(type))
            {
                System.Console.WriteLine("----GetGenericProperty----- " + type.Name + " out");
                return result;
            }
            visitedTypes.Add(type);

            foreach (var item in type.GetProperties())
            {
                var value = item.GetValue(obj);
                if (!item.Name.StartsWith("_"))
                {
                    if (item.PropertyType.Name.Equals("List`1"))
                    {
                        var itemType = item.PropertyType.GetGenericArguments()[0];
                        System.Console.WriteLine(item.Name + "\t" + value);
                        GetGenericProperty(obj, itemType, item.Name, visitedTypes);
                    }
                    else
                    {
                        System.Console.WriteLine(item.Name + "\t" + value);
                    }
                }
            }
            System.Console.WriteLine("----GetGenericProperty----- " + type.Name + " end");
            return result;
        }

        private static List<string> GetProperty(FlexDV FlexDV)
        {
            List<Type> visitedTypes = new List<Type>();

            var plotAreasModel = FlexDV.Model.plotAreas;
            var legnedsModels = FlexDV.Model.plotAreas[0].legends;
            var plotsPanesModels = FlexDV.Model.plotAreas[0].plotsPanes;

            System.Console.WriteLine("----GetProperty----- " + plotAreasModel);
            var contents = new List<string>() { };
            foreach (var Model in plotAreasModel)
            {
                foreach (var item in Model.GetType().GetProperties())
                {
                    var value = item.GetValue(Model, null);
                    if (!item.Name.StartsWith("_"))
                    {
                        if (item.PropertyType.Name.Equals("List`1"))
                        {
                            switch (item.Name)
                            {
                                case "legends":
                                    System.Console.WriteLine(item.Name + "\t" + value);
                                    GetLegends(legnedsModels);
                                    break;
                                case "plotsPanes":
                                    //System.Console.WriteLine(item.Name + "\t" + value);
                                    //GetPlotsPanes(plotsPanesModels, visitedTypes);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine(item.Name + "\t" + value);
                        }
                    }
                }
            }
            System.Console.WriteLine("----GetProperty----- " + plotAreasModel + " end");
            contents.Add("\n");
            return contents;
        }

        private static void GetLegends(object models)
        {
            var modelsItems = models as System.Collections.IEnumerable;
            foreach (var model in modelsItems)
            {
                System.Console.WriteLine("----GetLegends----- " + model);
                foreach (var item in model.GetType().GetProperties())
                {
                    var value = item.GetValue(model);
                    if (!item.Name.StartsWith("_"))
                    {
                        if (item.PropertyType.Name.Equals("List`1"))
                        {
                            var itemType = item.PropertyType.GetGenericArguments()[0];
                            System.Console.WriteLine(item.Name + "\t" + value);
                            var items = value as System.Collections.IEnumerable;
                            foreach (var obj in items)
                            {
                                GetLegendsProperty(obj, itemType, item.Name);
                            }
                        }
                        else if (value is ISize)
                        {
                            var itemType = item.PropertyType.GetGenericArguments()[0];
                            System.Console.WriteLine(item.Name + "\t" + value);
                        }
                        else
                        {
                            System.Console.WriteLine(item.Name + "\t" + value);
                        }
                    }
                }
                System.Console.WriteLine("----GetLegends----- " + model + " end");
            }
        }

        private static void GetPlotsPanes(object models, List<Type> visitedTypes)
        {
            var modelsItems = models as System.Collections.IEnumerable;
            foreach (var model in modelsItems)
            {
                System.Console.WriteLine("----GetPlotsPanes----- " + model);
                foreach (var item in model.GetType().GetProperties())
                {
                    var value = item.GetValue(model);
                    if (!item.Name.StartsWith("_"))
                    {
                        if (item.PropertyType.Name.Equals("List`1"))
                        {
                            var itemType = item.PropertyType.GetGenericArguments()[0];
                            System.Console.WriteLine(item.Name + "\t" + value);
                            var items = value as System.Collections.IEnumerable;
                            foreach (var obj in items)
                            {
                                GetPlotsPanesProperty(obj, itemType, item.Name, visitedTypes);
                            }
                        }
                        else
                        {
                            System.Console.WriteLine(item.Name + "\t" + value);
                        }
                    }
                }
                System.Console.WriteLine("----GetPlotsPanes----- " + model + " end");
            }
        }

        private static List<string> GetLegendsProperty(object obj, Type type, string name)
        {
            System.Console.WriteLine("----GetLegendsProperty----- " + type.Name);
            List<string> result = new List<string>();
            foreach (var item in type.GetProperties())
            {
                var value = item.GetValue(obj);
                if (!item.Name.StartsWith("_"))
                {
                    if (item.PropertyType.Name.Equals("List`1"))
                    {
                        var itemType = item.PropertyType.GetGenericArguments()[0];
                        System.Console.WriteLine(item.Name + "\t" + value);
                        GetLegendsProperty(obj, itemType, item.Name);
                    }
                    else if (item.PropertyType.Name.Equals("IColor"))
                    {

                    }
                    else
                    {
                        System.Console.WriteLine(item.Name + "\t" + value);
                    }
                }
            }
            System.Console.WriteLine("----GetLegendsProperty----- " + type.Name + " end");
            return result;
        }

        private static List<string> GetPlotsPanesProperty(object obj, Type type, string name, List<Type> visitedTypes)
        {
            System.Console.WriteLine("----GetPlotsPanesProperty----- " + type.Name);
            List<string> result = new List<string>();
            if (visitedTypes.Contains(type))
            {
                System.Console.WriteLine("----GetGenericProperty----- " + type.Name + " out");
                return result;
            }
            visitedTypes.Add(type);

            foreach (var item in type.GetProperties())
            {
                var value = item.GetValue(obj);
                if (!item.Name.StartsWith("_"))
                {
                    if (item.PropertyType.Name.Equals("List`1"))
                    {
                        var itemType = item.PropertyType.GetGenericArguments()[0];
                        //System.Console.WriteLine(item);
                        System.Console.WriteLine(item.Name + "\t" + value);
                        GetPlotsPanesProperty(obj, itemType, item.Name, visitedTypes);
                    }
                    else
                    {
                        //System.Console.WriteLine(item);
                        System.Console.WriteLine(item.Name + "\t" + value);
                    }
                }
            }
            System.Console.WriteLine("----GetPlotsPanesProperty----- " + type.Name + " end");
            return result;
        }

        private static void WriteFile(string path, List<string> Contents)
        {
            //string replaceContent = "<svg width=\"800\" height=\"400\" xmlns=\"http://www.w3.org/2000/svg\"><text x=\"10\" y=\"50\">Content</text></svg>";
            //string contents = "";
            //foreach (var content in Contents)
            //{
            //    //contents += content + "\n";
            //    contents += content;
            //}
            string content = JsonConvert.SerializeObject(Contents);
            File.WriteAllText(path + ".txt", content);
            //File.WriteAllText(path + ".txt", contents);
            //File.WriteAllText(path + ".svg", replaceContent.Replace("Content", contents));
        }

        private static void WriteFile(string path, Dictionary<string, object> contents)
        {
            string content = JsonConvert.SerializeObject(contents);
            File.WriteAllText(path + "_.json", content);
        }

        private static Dictionary<string, object> DictionaryToJson(string path)
        {
            List<object> listRoot = new List<object>();

            Dictionary<string, object> dictionaryRoot = new Dictionary<string, object>();
            dictionaryRoot.Add("control", "GrapeCity.DataVisualization.Chart.FlexDV");
            dictionaryRoot.Add("parent", null);

            List<object> childrenLayer1 = new List<object>();
            Dictionary<string, object> dictionaryChildLayer1 = new Dictionary<string, object>();
            dictionaryChildLayer1.Add("Layer1-aa", 123);
            dictionaryChildLayer1.Add("Layer1-bb", 456);
            childrenLayer1.Add(dictionaryChildLayer1);

            List<object> childrenLayer2 = new List<object>();
            Dictionary<string, object> dictionaryChildLayer2 = new Dictionary<string, object>();
            dictionaryChildLayer2.Add("Layer2-aa", 123);
            dictionaryChildLayer2.Add("Layer2-bb", 456);
            childrenLayer2.Add(dictionaryChildLayer2);
            if (!dictionaryChildLayer2.ContainsKey("Layer2-bb"))
            {
                dictionaryChildLayer2.Add("Layer2-bb", 000);
            }

            if (!dictionaryChildLayer2.ContainsKey("Layer2-dd"))
            {
                dictionaryChildLayer2.Add("Layer2-dd", 111);
            }

            dictionaryChildLayer1.Add("Layer1-cc", childrenLayer2);
            dictionaryRoot.Add("plotAreas", childrenLayer1);

            //listRoot.Add(dictionaryRoot);
            //listRoot.Add(dictionaryChildLayer1);
            //listRoot.Add(dictionaryChildLayer2);
            //foreach (var item in listRoot)
            //{
            //    System.Console.WriteLine("--------------");
            //    var itemDict = item as Dictionary<string, object>;
            //    foreach (var dict in itemDict)
            //    {
            //        System.Console.WriteLine(dict.Key + ": " + dict.Value);
            //    }
            //}

            var roots = dictionaryRoot["plotAreas"];
            var aa = roots as System.Collections.IEnumerable;
            foreach (var item in aa)
            {
                var dicts = item as Dictionary<string, object>;
                foreach (var dict in dicts)
                {
                    if (dict.Value is List<object>)
                    {
                        System.Console.WriteLine("00: "+ dict.Key + "\t" + dict.Value);
                    }
                    else
                    {
                        System.Console.WriteLine(dict.Key + "\t" + dict.Value);
                    }   
                }
            }
            string content = JsonConvert.SerializeObject(dictionaryRoot);
            File.WriteAllText(path + "_0.json", content);
            return dictionaryRoot;
        }

        private static Dictionary<string, object> TraversalDictionary(Dictionary<string, object> dictionarys)
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
    }
}
