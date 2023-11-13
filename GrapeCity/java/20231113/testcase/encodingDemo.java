package testcase;

import java.util.ArrayList;
import java.util.HashMap;

import com.grapecity.datavisualization.chart.component.core.FlexDV;
import com.grapecity.datavisualization.chart.component.core._views.visual.HitTestResult;
import com.grapecity.datavisualization.chart.core.drawing.FontStyle;
import com.grapecity.datavisualization.chart.core.drawing.Point;
import com.grapecity.datavisualization.chart.core.drawing.TextWritingMode;
import com.grapecity.datavisualization.chart.component.core.models.shapes.IShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.arc.IArcShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.donut.IDonutShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.polygon.IPolygonShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.polygonLine.IPolygonalLineShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.rectangle.IRectangleShape;
import com.grapecity.datavisualization.chart.component.core.models.viewModels.IViewModel;
import com.grapecity.datavisualization.chart.component.models.shapeModels.IShapeModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.IFlexDvModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.axes.IAxisModel;
import com.grapecity.datavisualization.chart.enums.*;
import com.grapecity.datavisualization.chart.options.*;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;

public class encodingDemo {
    public static IDvOption EncodingDemoAll() {
        IDvOption dvOption = new DvOption();
      
        IPlotOption plotOption = new PlotOption();
        plotOption.setType("Bar");
        plotOption.setName("p1");
      
        IPlotEncodingsOption plotEncodingOption = new PlotEncodingsOption();
        plotEncodingOption.setValues(new ArrayList < IValueEncodingOption > () {
          {
            add(new FieldsValueEncodingOption() {
              {
                // setField("Company, Sales");
                setField("Sales");
                // setField("high, low, open, close");
                setAggregate(Aggregate.Max);
                setExcludeNulls(true);
              }
            });
            add(new StockFieldValueEncodingOption() {
              {
                setField(new StockFieldOption() {
                  {
                    setClose("close");
                    setHigh("high");
                    setLow("low");
                    setOpen("open");
                    setX("date");
                  }
                });
              }
            });
            add(new RangeFieldValueEncodingOption() {
              {
                setField(new RangeFieldOption() {
                  {
                    setLower("lower");
                    setUpper("upper");
                  }
                });
              }
            });
          }
        });
        plotEncodingOption.setCategory(new CategoryEncodingOption() {
          {
            setField("Country");
            setLabel("value");
            setSort(new SortEncodingOption() {
              {
                setAggregate(Aggregate.List);
                setField("Sales");
                setOnlySortBeforeGrouping(false);
                setOrder(OrderType.Ascending);
              }
            });
          }
        });
        plotEncodingOption.setDetails(new ArrayList < IDetailEncodingOption > () {
          {
            add(new DetailEncodingOption() {
              {
                setField("NewCustomer");
                setGroup(Group.Cluster);
                setExcludeNulls(true);
              }
            });
          }
        });
        plotEncodingOption.setText(new ArrayList < IContentEncodingOption > () {
          {
            add(new ContentEncodingOption() {
              {
                setField("Country");
                setAggregate(Aggregate.Count);
              }
            });
            add(new ContentEncodingOption() {
              {
                setField("Sales");
                setLabel("Sales(Text)");
              }
            });
          }
        });
        plotEncodingOption.setColor(new ColorEncodingOption() {
          {
            setField("NewCustomer");
            setAggregate(Aggregate.Average);
            setItems(new ArrayList < ILegendItemEncodingOption > () {
              {
                add(new LegendItemEncodingOption() {
                  {
                    setRuleType("Increase");
                    setTitle("Increase");
                  }
                });
                add(new LegendItemEncodingOption() {
                  {
                    setRuleType("Decrease");
                    setTitle("Decrease");
                  }
                });
              }
            });
          }
        });
        plotEncodingOption.setShape(new ShapeEncodingOption() {
          {
            setField("Expenses:C3");
          }
        });
        plotEncodingOption.setSize(new SizeEncodingOption() {
          {
            setField("Sales:c1");
          }
        });
        plotEncodingOption.setBackgroundColor(new BackgroundColorEncodingOption() {
          {
            setField("Country");
            setAggregate(Aggregate.PopulationVariance);
          }
        });
      
        IPlotConfigOption plotConfigOption = new PlotConfigOption();
        plotConfigOption.setSymbols(true);
        plotConfigOption.setSwapAxes(true);
        plotConfigOption.setOffset(new ArrayList < IValueOption > () {
          {
            add(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.25);
              }
            });
          }
        });
        plotConfigOption.setClippingMode(ClippingMode.Fit);
        plotConfigOption.setLineAspect(LineAspect.Spline);
        plotConfigOption.setShowNaNs(ShowNulls.Zeros);
        plotConfigOption.setBar(new PlotBarOption() {
          {
            setWidth(0.5);
            setOverlap(0.5);
            setGroups(new ArrayList < IBarGroupOption > () {
              {
                add(new BarGroupOption() {
                  {
                    setCluster("cluster-A");
                    setKey(new DataValueType(true));
                    setValueField("Sales");
                    setWidth(1.0);
                  }
                });
                add(new BarGroupOption() {
                  {
                    setCluster("cluster-B");
                    setKey(new DataValueType(false));
                    setValueField("Sales");
                    setWidth(0.5);
                  }
                });
              }
            });
            setBottomWidth(0.9);
            setNeckHeight(0.5);
            setTopWidth(0.2);
          }
        });
        plotConfigOption.setText(new ArrayList < IPlotConfigTextOption > () {
          {
            add(new PlotConfigTextOption() {
              {
                setTemplate("{categoryField.name}:{categoryField.value}\n{colorField.name}:{colorField.value}");
                setAngle(90.0);
                setConnectingLine(new LineStyleOption() {
                  {
                    setStrokeWidth(1.0);
                  }
                });
                setFormat(new FormatOption() {
                  {
                    setValue("d3");
                  }
                });
                setLinePosition(LinePosition.Center);
                setMaxWidth(35.0);
                setOffset(10.0);
                setOverlappingLabels(OverlappingLabels.HideAll);
                setPlacement(Placement.Right);
                setPosition(TextPosition.Inside);
                setScope("Default");
                setStyle(new StyleOption() {
                  {
                    setBackgroundColor(new CssColorOption() {
                      {
                        setColor("#90ee90");
                      }
                    });
                    setStroke(new CssColorOption() {
                      {
                        setColor("#ff0000");
                      }
                    });
                    setStrokeDasharray("3, 3");
                    setStrokeWidth(2.0);
                  }
                });
                setTemplate("{categoryField.name}:{categoryField.value}");
                setTextStyle(new TextStyleOption() {
                  {
                    setColor("red");
                    setFontFamily("YouYuan");
                    setFontSize("20");
                    setFontStyle(FontStyle.Oblique);
                    setFontWeight("Bold");
                    setOpacity(0.5);
                    setOverflow(TextOverflow.Wrap);
                    setTextDecoration(new TextDecorationOption() {
                      {
                        setLineThrough(true);
                        setOverline(true);
                        setUnderline(true);
                      }
                    });
                    setWritingMode(TextWritingMode.Horizontal);
                  }
                });
              }
            });
          }
        });
        plotConfigOption.setStyle(new DataPointStyleOption() {
          {
            setFill(new CssColorOption() {
              {
                setColor("#add8e6");
              }
            });
            setFill(new LinearGradientOption() {
              {
                setAngle(180.0);
                setColorStops(new ArrayList < IColorStopOption > () {
                  {
                    add(new ColorStopOption() {
                      {
                        setColor("rgba(255,0,0,0)");
                      }
                    });
                    add(new ColorStopOption() {
                      {
                        setColor("#ff0000");
                      }
                    });
                  }
                });
              }
            });
            setOpacity(0.5);
            setStroke(new CssColorOption() {
              {
                setColor("#0000ff");
              }
            });
            setStrokeDasharray("5, 5");
            setStrokeWidth(new StrokeWidthOption() {
              {
                setBottom(2.0);
                setLeft(2.0);
                setRight(2.0);
                setTop(2.0);
              }
            });
            setSymbolFill(new CssColorOption() {
              {
                setColor("#add8e6");
              }
            });
            setSymbolOpacity(0.5);
            setSymbolShape("Dot");
            setSymbolStroke(new CssColorOption() {
              {
                setColor("#ff0000");
              }
            });
            setSymbolStrokeDasharray("5, 5");
            setSymbolStrokeWidth(3.0);
            setSymbolSize(30.0);
            setSymbolShape("Diamond");
            setBackgroundColor(new CssColorOption() {
              {
                setColor("#add8e6");
              }
            });
            setBorderRadius(new BorderRadiusOption() {
              {
                setHorizontalRadius(new BorderRadiusValueOption() {
                  {
                    setBottomLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setBottomRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                  }
                });
                setVerticalRadius(new BorderRadiusValueOption() {
                  {
                    setBottomLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setBottomRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                  }
                });
              }
            });
          }
        });
        plotConfigOption.setOverlays(new ArrayList < IOverlayOption > () {
          {
            add(new TextOverlayOption() {
              {
                setType("Text");
              }
            });
            add(new BarLineOverlayOption() {
              {
                setType("BarLine");
                setDisplay(OverlayDisplay.Front);
                setRules(new ArrayList < IRuleOption > ());
              }
            });
            add(new ErrorBarOption() {
              {
                setType("ErrorBar");
                setDisplay(OverlayDisplay.Front);
                setRules(new ArrayList < IRuleOption > ());
      
              }
            });
            add(new ImageOverlayOption() {
              {
                setType("Image");
                setDisplay(OverlayDisplay.Front);
                setRules(new ArrayList < IRuleOption > ());
      
              }
            });
            add(new PathAnnotationOption() {
              {
                setType("Path");
                setDisplay(OverlayDisplay.FrontOfPlot);
                setRules(new ArrayList < IRuleOption > ());
              }
            });
            add(new RectangleOverlayOption() {
              {
                setType("Rectangle");
                setDisplay(OverlayDisplay.Back);
                setRules(new ArrayList < IRuleOption > ());
      
              }
            });
            add(new ReferenceBandOverlayOption() {
              {
                setType("ReferenceBand");
                setDisplay(OverlayDisplay.Back);
                setRules(new ArrayList < IRuleOption > ());
      
              }
            });
            add(new ReferenceLineOverlayOption() {
              {
                setType("ReferenceLine");
                setDisplay(com.grapecity.datavisualization.chart.enums.OverlayDisplay.Back);
                setRules(new ArrayList < IRuleOption > ());
      
              }
            });
            add(new PolynomialTrendlineOverlayOption() {
              {
                setType("PolynomialTrendline");
                setDisplay(com.grapecity.datavisualization.chart.enums.OverlayDisplay.Front);
                setRules(new ArrayList < IRuleOption > ());
              }
            });
          }
        });
        plotConfigOption.setPalette(new ArrayList < IPaletteItemOption > () {
          {
            add(new PaletteItemOption() {
              {
                setColor(new CssColorOption() {
                  {
                    setColor("#f07f09");
                  }
                });
                setType(PaletteItemType.Index);
              }
            });
            add(new PaletteItemOption() {
              {
                setColor(new CssColorOption() {
                  {
                    setColor("#9f2936");
                  }
                });
                setType(PaletteItemType.Data);
              }
            });
          }
        });
        plotConfigOption.setTextStyle(new TextStyleOption() {
          {
            setAlignment(HAlign.Left);
            setColor("red");
            setFontFamily("YouYuan");
            setFontSize("25");
            setFontStyle(FontStyle.Oblique);
            setFontWeight("600");
            setOpacity(0.5);
            setOverflow(TextOverflow.Clip);
            setTextDecoration(new TextDecorationOption() {
              {
                setLineThrough(true);
                setOverline(true);
                setUnderline(true);
              }
            });
            setWritingMode(TextWritingMode.Horizontal);
          }
        });
        plotConfigOption.setBar(new PlotBarOption() {
          {
            setConnectorLineStyle(new LineStyleOption() {
              {
                setStroke(new CssColorOption() {
                  {
                    setColor("rgba(255,0,0,0.5)");
                  }
                });
                setStrokeDasharray("3, 3");
                setStrokeOpacity(0.5);
                setStrokeWidth(6.0);
              }
            });
            setConnectorLines(true);
            setWaterfall(new WaterfallOption());
          }
        });
        plotConfigOption.setHAlign(HAlign.Left);
        plotConfigOption.setVAlign(VAlign.Top);
      
        plotOption.setEncodings(plotEncodingOption);
        plotOption.setConfig(plotConfigOption);
        dvOption.getPlots().add(plotOption);
      
        IConfigOption configOption = new ConfigOption();
        configOption.setHeader(new HeaderOption() {
          {
            setHAlign(HAlign.Left);
            setHeight(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.25);
              }
            });
            setMaxHeight(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.3);
              }
            });
            setPadding(new PaddingOption() {
              {
                setBottom(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setLeft(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setRight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setTop(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
              }
            });
            setStyle(new StyleOption() {
              {
                setBackgroundColor(new CssColorOption() {
                  {
                    setColor("#add8e6");
                  }
                });
                setStroke(new CssColorOption() {
                  {
                    setColor("#ff0000");
                  }
                });
                setStrokeDasharray("10, 10");
                setStrokeWidth(1.0);
              }
            });
            setTextStyle(new TextStyleOption() {
              {
                setColor("red");
                setFontFamily("Tahoma");
                setFontSize("24");
                // setFontStyle(com.grapecity.datavisualization.chart.enums.FontStyle.Italic);
                setFontStyle(FontStyle.Italic);
                setFontWeight("Bold");
                setTextDecoration(new TextDecorationOption() {
                  {
                    setLineThrough(true);
                    setOverline(true);
                    setUnderline(true);
                  }
                });
              }
            });
            setTitle("this is header title.");
            setVAlign(VAlign.Bottom);
            setWidth(new ValueOption() {
              {
                setType(ValueOptionType.Pixel);
                setValue(220.0);
              }
            });
          }
        });
        configOption.setFooter(new FooterOption() {});
        configOption.setBackgroundColor(new CssColorOption() {
          {
            setColor("#add8e6");
          }
        });
        configOption.setBar(new BarOption() {
          {
            setWidth(0.5);
            setOverlap(0.5);
            setBottomWidth(0.9);
            setNeckHeight(0.5);
            setTopWidth(0.2);
            setFunnelType(FunnelType.Bar);
            setBorderRadius(new BorderRadiusOption() {
              {
                setHorizontalRadius(new BorderRadiusValueOption() {
                  {
                    setBottomLeft(new ValueOption() {
                      {
                        setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setBottomRight(new ValueOption() {
                      {
                        setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopLeft(new ValueOption() {
                      {
                        setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopRight(new ValueOption() {
                      {
                        setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                  }
                });
                setVerticalRadius(new BorderRadiusValueOption() {
                  {
                    setBottomLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setBottomRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                    setTopRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(20.0);
                      }
                    });
                  }
                });
              }
            });
          }
        });
        configOption.setBorderStyle(new LineStyleOption() {
          {
            setStroke(new CssColorOption() {
              {
                setColor("#008000");
              }
            });
            setStrokeDasharray("10, 10");
            setStrokeOpacity(0.7);
            setStrokeWidth(6.0);
          }
        });
        configOption.setLegend(new GlobalLegendOption() {
          {
            setBorderStyle(new LineStyleOption() {
              {
                setStroke(new CssColorOption() {
                  {
                    setColor("#ff0000");
                  }
                });
                setStrokeDasharray("3, 3");
                setStrokeOpacity(0.5);
                setStrokeWidth(4.0);
              }
            });
            setGroupHAlign(HAlign.Center);
            setGroupOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
            setGroupPadding(new PaddingOption() {
              {
                setBottom(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setLeft(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setRight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setTop(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
              }
            });
            setGroupVAlign(VAlign.Bottom);
            setItemPadding(new PaddingOption() {
              {
                setBottom(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setLeft(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setRight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setTop(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
              }
            });
            setItemSpace(new ValueOption() {
              {
                setType(ValueOptionType.Pixel);
                setValue(50.0);
              }
            });
            setLeft(0.25);
            setMargin(new MarginOption() {
              {
                setBottom(30.0);
                setLeft(40.0);
                setRight(20.0);
                setTop(10.0);
              }
            });
            setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
            setPadding(new PaddingOption() {
              {
                setBottom(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setLeft(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setRight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setTop(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
              }
            });
            setPosition(LegendPosition.Floating);
            setStyle(new LegendStyleOption() {
              {
                setBackgroundColor(new CssColorOption() {
                  {
                    setColor("#90ee90");
                  }
                });
                setIconColor(new CssColorOption() {
                  {
                    setColor("#ffff00");
                  }
                });
                setStroke(new CssColorOption() {
                  {
                    setColor("#ff0000");
                  }
                });
                setStrokeDasharray("10, 5");
                setStrokeWidth(3.0);
              }
            });
            setTextStyle(new TextStyleOption() {
              {
                setColor("red");
                setFontFamily("LiSu");
                setFontSize("20");
                setFontStyle(FontStyle.Italic);
                setFontWeight("Bold");
                setOpacity(0.5);
                setTextDecoration(new TextDecorationOption() {
                  {
                    setLineThrough(true);
                    setOverline(true);
                    setUnderline(true);
                  }
                });
              }
            });
            setTitlePosition(Position.Bottom);
            setTitleStyle(new TextStyleOption() {
              {
                setColor("green");
                setFontFamily("LiSu");
                setFontSize("30");
                setFontStyle(FontStyle.Italic);
                setFontWeight("Bold");
                setOpacity(0.8);
                setTextDecoration(new TextDecorationOption() {
                  {
                    setLineThrough(true);
                    setOverline(true);
                    setUnderline(true);
                  }
                });
              }
            });
            setTop(0.25);
            setWrapping(false);
          }
        });
        configOption.setPadding(new PaddingOption() {
          {
            setBottom(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.3);
              }
            });
            setLeft(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.3);
              }
            });
            setRight(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.3);
              }
            });
            setTop(new ValueOption() {
              {
                setType(ValueOptionType.Percentage);
                setValue(0.3);
              }
            });
          }
        });
        configOption.setPalette(new ArrayList < IPaletteItemOption > () {
          {
            add(new PaletteItemOption() {
              {
                setColor(new CssColorOption() {
                  {
                    setColor("#f07f09");
                  }
                });
                setType(PaletteItemType.Index);
              }
            });
          }
        });
        configOption.setPlotAreaLayout(new PlotAreaLayoutOption() {
          {
            setColumnWidths(new ArrayList < IValueOption > () {
              {
                add(new ValueOption() {
                  {
                    setType(ValueOptionType.Available);
                    setValue(1.0);
                  }
                });
                add(new ValueOption() {
                  {
                    setType(ValueOptionType.Available);
                    setValue(2.0);
                  }
                });
              }
            });
            setRowHeights(new ArrayList < IValueOption > () {
              {
                add(new ValueOption() {
                  {
                    setType(ValueOptionType.Available);
                    setValue(1.0);
                  }
                });
                add(new ValueOption() {
                  {
                    setType(ValueOptionType.Available);
                    setValue(2.0);
                  }
                });
              }
            });
          }
        });
        configOption.setShapes(new ArrayList < ISymbolItemOption > () {
          {
            add(new SymbolItemOption() {
              {
                setShape(new SymbolShapeOption() {
                  {
                    setContent("");
                    setName("Box");
                  }
                });
                setType(SymbolItemType.Index);
              }
            });
            add(new SymbolItemOption() {
              {
                setData(new DataValueType("US"));
                setShape(new SymbolShapeOption() {
                  {
                    setContent("");
                    setName("US");
                  }
                });
                setType(SymbolItemType.Data);
              }
            });
          }
        });
        configOption.setStyle(new StyleOption() {
          {
            setBackgroundColor(new CssColorOption() {
              {
                setColor("#90ee90");
              }
            });
            setFill(new CssColorOption() {
              {
                setColor("#0000ff");
              }
            });
            setStroke(new CssColorOption() {
              {
                setColor("#ff0000");
              }
            });
            setStrokeDasharray("5, 5");
            setStrokeWidth(4.0);
          }
        });
        configOption.setTextStyle(new TextStyleOption() {
          {
            setAlignment(HAlign.Left);
            setColor("red");
            setFontFamily("YouYuan");
            setFontSize("25");
            setFontStyle(FontStyle.Oblique);
            setFontWeight("600");
            setOpacity(0.5);
            setOverflow(TextOverflow.Clip);
            setTextDecoration(new TextDecorationOption() {
              {
                setLineThrough(true);
                setOverline(true);
                setUnderline(true);
              }
            });
            setWritingMode(TextWritingMode.Horizontal);
          }
        });
        configOption.setPlotAreas(new ArrayList < IPlotAreaOption > () {
          {
            add(new PlotAreaOption() {
              {
                setColumn(0);
                setRow(1);
                setBackgroundColor(new CssColorOption() {
                  {
                    setColor("#add8e6");
                  }
                });
                setBorderStyle(new LineStyleOption() {
                  {
                    setStroke(new CssColorOption() {
                      {
                        setColor("#008000");
                      }
                    });
                    setStrokeDasharray("10%, 20%");
                    setStrokeOpacity(0.7);
                    setStrokeWidth(6.0);
                  }
                });
                setLegend(new GlobalLegendOption() {
                  {
                    setBorderStyle(new LineStyleOption() {
                      {
                        setStroke(new CssColorOption() {
                          {
                            setColor("#ff0000");
                          }
                        });
                        setStrokeDasharray("3, 3");
                        setStrokeOpacity(0.5);
                        setStrokeWidth(4.0);
                      }
                    });
                    setPosition(LegendPosition.Floating);
                    setGroupHAlign(HAlign.Center);
                    setGroupVAlign(VAlign.Top);
                    setGroupOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                    setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                    setTitlePosition(Position.Bottom);
                    setGroupPadding(new PaddingOption() {
                      {
                        setBottom(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setLeft(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setRight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setTop(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                      }
                    });
                    setItemPadding(new PaddingOption() {
                      {
                        setBottom(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setLeft(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setRight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setTop(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                      }
                    });
                    setItemSpace(new ValueOption() {
                      {
                        setType(ValueOptionType.Pixel);
                        setValue(50.0);
                      }
                    });
                    setMargin(new MarginOption() {
                      {
                        setBottom(30.0);
                        setLeft(40.0);
                        setRight(20.0);
                        setTop(10.0);
                      }
                    });
                    setPadding(new PaddingOption() {
                      {
                        setBottom(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setLeft(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setRight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setTop(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                      }
                    });
                    setStyle(new LegendStyleOption() {
                      {
                        setBackgroundColor(new CssColorOption() {
                          {
                            setColor("#90ee90");
                          }
                        });
                        setIconColor(new CssColorOption() {
                          {
                            setColor("#ffff00");
                          }
                        });
                        setStroke(new CssColorOption() {
                          {
                            setColor("#ff0000");
                          }
                        });
                        setStrokeDasharray("10, 5");
                        setStrokeWidth(3.0);
                      }
                    });
                    setTextStyle(new TextStyleOption() {
                      {
                        setColor("red");
                        setFontFamily("LiSu");
                        setFontSize("20");
                        setFontStyle(FontStyle.Italic);
                        setFontWeight("Bold");
                        setOpacity(0.5);
                        setTextDecoration(new TextDecorationOption() {
                          {
                            setLineThrough(true);
                            setOverline(true);
                            setUnderline(true);
                          }
                        });
                      }
                    });
                    setTitleStyle(new TextStyleOption() {
                      {
                        setColor("green");
                        setFontFamily("LiSu");
                        setFontSize("30");
                        setFontStyle(FontStyle.Italic);
                        setFontWeight("Bold");
                        setOpacity(0.8);
                        setTextDecoration(new TextDecorationOption() {
                          {
                            setLineThrough(true);
                            setOverline(true);
                            setUnderline(true);
                          }
                        });
                      }
                    });
                    setLeft(0.65);
                    setTop(0.1);
                    setWrapping(false);
                  }
                });
                setLegends(new ArrayList < ILegendOption > () {
                  {
                    add(new LegendOption() {
                      {
                        setType(LegendType.Color);
                        setGradient(new LegendGradientOption() {
                          {
                            setEnabled(false);
                            setPalette(new ArrayList < java.lang.String > ());
                          }
                        });
                        setRanges(new ArrayList < ILegendRangeOption > () {
                          {
                            add(new LegendRangeOption() {
                              {
                                setTitle("Min - 1000");
                                setTo(1000.0);
                              }
                            });
                            add(new LegendRangeOption() {
                              {
                                setTitle("1000 - 2000");
                                setTo(2000.0);
                              }
                            });
                          }
                        });
                        setPosition(LegendPosition.Left);
                        setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                        setBorderStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#ff0000");
                              }
                            });
                            setStrokeDasharray("10, 10");
                            setStrokeOpacity(0.55);
                            setStrokeWidth(0.5);
                          }
                        });
                        setHeight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.25);
                          }
                        });
                        setItemSpace(new ValueOption() {
                          {
                            setType(ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setLeft(0.75);
                        setMargin(new MarginOption() {
                          {
                            setBottom(10.0);
                            setLeft(20.0);
                            setRight(10.0);
                            setTop(20.0);
                          }
                        });
                        setMaxHeight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.25);
                          }
                        });
                        setSortOrder(SortOrder.Ascending);
                        setTitle("Color.title");
                        setTop(0.5);
                        setType(LegendType.Color);
                        setVAlign(VAlign.Top);
                      }
                    });
                    add(new LegendOption() {
                      {
                        setType(LegendType.Shape);
                        setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                        setPosition(LegendPosition.Top);
                      }
                    });
                  }
                });
                setPadding(new PaddingOption() {
                  {
                    setBottom(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setTop(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                  }
                });
                setPlotsMargin(new MarginOption() {
                  {
                    setBottom(0.3);
                    setLeft(0.0);
                    setRight(0.0);
                    setTop(0.0);
                  }
                });
                setStyle(new PlotAreaStyleOption() {
                  {
                    setBackgroundColor(new CssColorOption() {
                      {
                        setColor("#90ee90");
                      }
                    });
                    setFill(new CssColorOption() {
                      {
                        setColor("#add8e6");
                      }
                    });
                    setInnerStroke(new CssColorOption() {
                      {
                        setColor("#008000");
                      }
                    });
                    setInnerStrokeDasharray("3, 3");
                    setInnerStrokeWidth(2.0);
                    setStroke(new CssColorOption() {
                      {
                        setColor("#ff0000");
                      }
                    });
                    setStrokeDasharray("5, 5");
                    setStrokeWidth(4.0);
                  }
                });
                setTextStyle(new TextStyleOption() {
                  {
                    setAlignment(HAlign.Left);
                    setColor("red");
                    setFontFamily("YouYuan");
                    setFontSize("25");
                    setFontStyle(FontStyle.Oblique);
                    setFontWeight("600");
                    setOpacity(0.5);
                    setOverflow(TextOverflow.Clip);
                    setTextDecoration(new TextDecorationOption() {
                      {
                        setLineThrough(true);
                        setOverline(true);
                        setUnderline(true);
                      }
                    });
                    setWritingMode(TextWritingMode.Horizontal);
                  }
                });
                setAxes(new ArrayList < IAxisOption > () {
                  {
                    add(new AxisOption() {
                      {
                        setPlots(new ArrayList < java.lang.String > () {
                          {
                            add("p1");
                          }
                        });
                        setType(AxisType.X);
                        setTitle("This is Axes-X title.");
                        setTitleStyle(new LabelStyleOption() {
                          {
                            setColor("red");
                            setFontFamily("YouYuan");
                            setFontSize("15");
                            setFontStyle(FontStyle.Oblique);
                            setFontWeight("600");
                            setOpacity(0.5);
                            setOverflow(TextOverflow.Clip);
                            setTextDecoration(new TextDecorationOption() {
                              {
                                setLineThrough(true);
                              }
                            });
                          }
                        });
                        setAxisLine(false);
                        setAxisPadding(1.0);
                        setDateMode(DateMode.Day);
                        setFormat(new FormatOption() {
                          {
                            setValue("Y");
                          }
                        });
                        setGroupGrid(TickMark.Inside);
                        setGroupGridStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#0000ff");
                              }
                            });
                            setStrokeDasharray("3, 3");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(2.0);
                          }
                        });
                        setHeight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.5);
                          }
                        });
                        setWidth(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.5);
                          }
                        });
                        setLabelAngle(new ArrayList < java.lang.Double > () {
                          {
                            add(45.0);
                          }
                        });
                        setLabelStyle(new LabelStyleOption() {
                          {
                            setColor("red");
                            setFontFamily("YouYuan");
                            setFontSize("15");
                            setFontStyle(FontStyle.Oblique);
                            setFontWeight("600");
                            setOpacity(0.5);
                            setOverflow(TextOverflow.Clip);
                            setTextDecoration(new TextDecorationOption() {
                              {
                                setLineThrough(true);
                              }
                            });
                          }
                        });
                        setLabelTemplate("{Country}");
                        setLabels(AxisPosition.Far);
                        setLineStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#ff0000");
                              }
                            });
                            setStrokeOpacity(0.3);
                            setStrokeWidth(3.0);
                          }
                        });
                        setLogBase(100.0);
                        setHeight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.5);
                          }
                        });
                        setMaxWidth(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.25);
                          }
                        });
                        setMax(new ValueOption() {
                          {
                            setType(ValueOptionType.Number);
                            setValue(18000.0);
                          }
                        });
                        setMin(new ValueOption() {
                          {
                            setType(ValueOptionType.Number);
                            setValue( - 1000.0);
                          }
                        });
                        setMajorGrid(true);
                        setMajorGridStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#0000ff");
                              }
                            });
                            setStrokeDasharray("3, 3");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(2.0);
                          }
                        });
                        setMajorTickSize(30.0);
                        setMajorTickStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#0000ff");
                              }
                            });
                            setStrokeDasharray("4, 2");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(1.0);
                          }
                        });
                        setMajorTicks(TickMark.Outside);
                        setMajorUnit(new AxisUnitOption() {
                          {
                            setValue(5000.0);
                          }
                        });
                        setMinorTickSize(5.0);
                        setMinorTickStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#0000ff");
                              }
                            });
                            setStrokeDasharray("4, 2");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(1.0);
                          }
                        });
                        setMinorTicks(TickMark.Inside);
                        setMinorUnit(new AxisUnitOption() {
                          {
                            setValue(0.5);
                          }
                        });
                        setOrigin(10000.0);
                        setOverlappingLabels(OverlappingLabels.Hide);
                        setPosition(AxisPosition.Far);
                        setReversed(true);
                        setRules(new ArrayList < IRuleOption > () {
                          {
                            add(new RuleOption() {
                              {
                                setActions(new ArrayList < IRuleActionOption > () {
                                  {
                                    add(new RuleActionOption() {
                                      {
                                        setProperties(new ArrayList < IRuleActionPropertyOption > () {
                                          {
                                            add(new RuleActionPropertyOption() {
                                              {
                                                setName("textStyle.color");
                                                setValue("red");
                                              }
                                            });
                                          }
                                        });
                                        setTargetElement("Label");
                                      }
                                    });
                                  }
                                });
                                setCondition("current.value = \"US\"");
                                setType("Label");
                              }
                            });
                          }
                        });
                        setScale(new ValueScaleOption() {
                          {
                            setType(ValueScaleType.Linear);
                          }
                        });
                        setStyle(new StyleOption() {
                          {
                            setBackgroundColor(new CssColorOption() {
                              {
                                setColor("#add8e6");
                              }
                            });
                            setStroke(new CssColorOption() {
                              {
                                setColor("#ff0000");
                              }
                            });
                            setStrokeDasharray("3,3");
                            setStrokeWidth(1.0);
                          }
                        });
                        setTextStyle(new TextStyleOption() {
                          {
                            setColor("red");
                            setFontFamily("YouYuan");
                            setFontSize("15");
                            setFontStyle(FontStyle.Oblique);
                            setFontWeight("600");
                            setOpacity(0.5);
                            setOverflow(TextOverflow.Clip);
                            setTextDecoration(new TextDecorationOption() {
                              {
                                setLineThrough(true);
                              }
                            });
                          }
                        });
                        setUnitLabel(new UnitLabelOption() {
                          {
                            setStyle(new StyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#ff0000");
                                  }
                                });
                                setStrokeDasharray("3,3");
                                setStrokeWidth(2.0);
                              }
                            });
                            setText("Axes-y unitLabel.");
                            setTextStyle(new LabelStyleOption() {
                              {
                                setColor("red");
                                setFontFamily("YouYuan");
                                setFontSize("15");
                                setFontStyle(FontStyle.Oblique);
                                setFontWeight("600");
                                setOpacity(0.5);
                                setOverflow(TextOverflow.Clip);
                                setTextDecoration(new TextDecorationOption() {
                                  {
                                    setLineThrough(true);
                                  }
                                });
                              }
                            });
                          }
                        });
                        setUseActualMax(true);
                        setUseActualMin(true);
                        setScrollbarVisible(true);
                        setViewSize(0.5);
                        setPlugins(new ArrayList < IConfigPluginOption > () {
                          {
                            add(new ConfigPluginOption() {
                              {
                                setName("Excel");
                                setType("AxisLabelExpandPolicy");
                                setArguments(new SjsLegendViewManagerOption() {
                                  {
                                    setExcelPosition(SjsLegendPosition.Bottom);
                                  }
                                });
                              }
                            });
                          }
                        });
                      }
                    });
                    add(new AxisOption() {
                      {
                        setPlots(new ArrayList < java.lang.String > () {
                          {
                            add("p1");
                          }
                        });
                        setType(AxisType.Y);
                      }
                    });
                  }
                });
              }
            });
            add(new PlotAreaOption() {});
          }
        });
      
        dvOption.setConfig(configOption);
      
        ArrayList < ITransformOption > transformOptions = new ArrayList < ITransformOption > () {
          {
            add(new BinTransformOption() {
              {
                setType(TransformType.Bin);
                setBin(new BinOption() {
                  {
                    setSteps(new ArrayList < java.lang.Double > ());
                    setSteps(new ArrayList < java.lang.Double > () {
                      {
                        add(5000.0);
                        add(10000.0);
                        add(15000.0);
                        add(20000.0);
                      }
                    });
                  }
                });
                setField("Sales");
                setOutputAs("SalesBin");
              }
            });
            add(new AggregateTransformOption() {
              {
                setType(TransformType.Aggregate);
                setAggregate(new ArrayList < IAggregateOption > () {
                  {
                    add(new AggregateOption() {
                      {
                        setField("Sales");
                        setOp(Aggregate.Count);
                        setOutputAs("SalesCount");
                      }
                    });
                    add(new AggregateOption() {
                      {
                        setField("Sales");
                        setOp(Aggregate.Sum);
                        setOutputAs("SalesSum");
                      }
                    });
                  }
                });
                setConcat(new ConcatOption() {
                  {
                    setCustomArray(new ArrayList < java.lang.Integer > ());
                    setType(ConcatType.GroupEnd);
                  }
                });
                setGroupby(new ArrayList < java.lang.String > () {
                  {
                    add("Country");
                  }
                });
              }
            });
            add(new CalculateTransformOption() {
              {
                setType(TransformType.Calculate);
                setCalculate("=IF(ISBLANK(current.销售大区), \"NULL\", current.销售大区)");
                setOutputAs("SalesRegion");
              }
            });
            add(new UnpivotTransformOption() {
              {
                setType(TransformType.Unpivot);
                setCategory(new UnpivotCategoryOption() {
                  {
                    setFieldAs("category");
                    setFrom(new ArrayList < java.lang.String > () {
                      {
                        add("category");
                      }
                    });
                  }
                });
                setNames(new ArrayList < java.lang.String > () {
                  {
                    add("sample");
                  }
                });
                setOutputAs("unpivotData");
                setValueFieldAs("value");
              }
            });
          }
        };
      
        dvOption.setTransform(transformOptions);
      
        return dvOption;
      }
  
    public static IDvOption EncodingDemo() {
        IDvOption dvOption = new DvOption();
      
        IPlotOption plotOption = new PlotOption();
        plotOption.setType("Line");
        plotOption.setName("p1");
      
        IPlotEncodingsOption plotEncodingOption = new PlotEncodingsOption();
        plotEncodingOption.setValues(new ArrayList < IValueEncodingOption > () {
          {
            add(new FieldsValueEncodingOption() {
              {
                setField("Sales");
              }
            });
          }
        });
        plotEncodingOption.setCategory(new CategoryEncodingOption() {
          {
            setField("Country");
          }
        });
        plotEncodingOption.setColor(new ColorEncodingOption() {
          {
            setField("SalesBin");
          }
        });
      
        IPlotConfigOption plotConfigOption = new PlotConfigOption();
        plotConfigOption.setSymbols(true);
      
        plotOption.setEncodings(plotEncodingOption);
        plotOption.setConfig(plotConfigOption);
        dvOption.getPlots().add(plotOption);
      
        IConfigOption configOption = new ConfigOption();
        configOption.setHeader(new HeaderOption() {
          {
            setTitle("this is header title.");
          }
        });
        configOption.setPlotAreas(new ArrayList < IPlotAreaOption > () {
          {
            add(new PlotAreaOption() {
              {
                setBackgroundColor(new CssColorOption() {
                  {
                    setColor("#add8e6");
                  }
                });
              }
            });
          }
        });
        dvOption.setConfig(configOption);
      
        ArrayList < ITransformOption > transformOptions = new ArrayList < ITransformOption > () {
          {
            add(new BinTransformOption() {
              {
                setType(TransformType.Bin);
                setBin(new BinOption() {
                  {
                    setSteps(new ArrayList < java.lang.Double > ());
                  }
                });
                setField("Sales");
                setOutputAs("SalesBin");
              }
            });
          }
        };
        dvOption.setTransform(transformOptions);
      
        return dvOption;
    }

    public static IDvOption EncodingDemo02() {
        IDvOption dvOption = new DvOption();
        dvOption.setPlots(new ArrayList < IPlotOption > () {
          {
            add(new PlotOption() {
              {
                setName("p1");
                setType("Bar");
                setEncodings(new PlotEncodingsOption() {
                  {
                    setValues(new ArrayList < IValueEncodingOption > () {
                      {
                        add(new FieldsValueEncodingOption() {
                          {
                            // setField("Company, Sales");
                            setField("Sales");
                            // setField("high, low, open, close");
                            setAggregate(Aggregate.Max);
                            setExcludeNulls(true);
                          }
                        });
                        add(new StockFieldValueEncodingOption() {
                          {
                            setField(new StockFieldOption() {
                              {
                                setClose("close");
                                setHigh("high");
                                setLow("low");
                                setOpen("open");
                                setX("date");
                              }
                            });
                          }
                        });
                        add(new RangeFieldValueEncodingOption() {
                          {
                            setField(new RangeFieldOption() {
                              {
                                setLower("lower");
                                setUpper("upper");
                              }
                            });
                          }
                        });
                      }
                    });
                    setCategory(new CategoryEncodingOption() {
                      {
                        setField("Country");
                        setSort(new SortEncodingOption() {
                          {
                            setAggregate(Aggregate.List);
                            setField("Sales");
                            setOnlySortBeforeGrouping(false);
                            setOrder(OrderType.Ascending);
                          }
                        });
                      }
                    });
                    setDetails(new ArrayList < IDetailEncodingOption > () {
                      {
                        add(new DetailEncodingOption() {
                          {
                            setField("NewCustomer");
                            setGroup(Group.Cluster);
                            setExcludeNulls(true);
                          }
                        });
                      }
                    });
                    setText(new ArrayList < IContentEncodingOption > () {
                      {
                        add(new ContentEncodingOption() {
                          {
                            setField("Country");
                            setAggregate(Aggregate.Count);
                          }
                        });
                        add(new ContentEncodingOption() {
                          {
                            setField("Sales");
                            setLabel("Sales(Text)");
                          }
                        });
                      }
                    });
                    setColor(new ColorEncodingOption() {
                      {
                        setField("NewCustomer");
                        setAggregate(Aggregate.Average);
                        setItems(new ArrayList < ILegendItemEncodingOption > () {
                          {
                            add(new LegendItemEncodingOption() {
                              {
                                setRuleType("Increase");
                                setTitle("Increase");
                              }
                            });
                            add(new LegendItemEncodingOption() {
                              {
                                setRuleType("Decrease");
                                setTitle("Decrease");
                              }
                            });
                          }
                        });
                      }
                    });
                    setShape(new ShapeEncodingOption() {
                      {
                        setField("Expenses:C3");
                      }
                    });
                    setSize(new SizeEncodingOption() {
                      {
                        setField("Sales:c1");
                      }
                    });
                    setBackgroundColor(new BackgroundColorEncodingOption() {
                      {
                        setField("Country");
                        setAggregate(Aggregate.PopulationVariance);
                      }
                    });
                  }
                });
                //setConfig(new PlotConfigOption() {})
                setConfig(new SankeyPlotConfigOption() {
                  {
                    setAxisMode(AxisMode.Cartesian);
                    setSymbols(true);
                    setSwapAxes(true);
                    setOffset(new ArrayList<IValueOption>(){
                      {
                        add(new ValueOption(){
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.25);
                          }
                        });
                      }
                    });
                    setClippingMode(ClippingMode.Fit);
                    setLineAspect(LineAspect.Spline);
                    setShowNaNs(ShowNulls.Zeros);
                    setBar(new PlotBarOption() {
                      {
                        setWidth(0.5);
                        setOverlap(0.5);
                        setGroups(new ArrayList < IBarGroupOption > () {
                          {
                            add(new BarGroupOption() {
                              {
                                setCluster("cluster-A");
                                setKey(new DataValueType(true));
                                setValueField("Sales");
                                setWidth(1.0);
                              }
                            });
                            add(new BarGroupOption() {
                              {
                                setCluster("cluster-B");
                                setKey(new DataValueType(false));
                                setValueField("Sales");
                                setWidth(0.5);
                              }
                            });
                          }
                        });
                        setBottomWidth(0.9);
                        setNeckHeight(0.5);
                        setTopWidth(0.2);
                      }
                    });
                    setText(new ArrayList < IPlotConfigTextOption > () {
                      {
                        add(new PlotConfigTextOption() {
                          {
                            setTemplate("{categoryField.name}:{categoryField.value}\n{colorField.name}:{colorField.value}");
                            setAngle(90.0);
                            setConnectingLine(new LineStyleOption() {
                              {
                                setStrokeWidth(1.0);
                              }
                            });
                            setFormat(new FormatOption() {
                              {
                                setValue("d3");
                              }
                            });
                            setLinePosition(LinePosition.Center);
                            setMaxWidth(35.0);
                            setOffset(10.0);
                            setOverlappingLabels(OverlappingLabels.HideAll);
                            setPlacement(Placement.Right);
                            setPosition(TextPosition.Inside);
                            setScope("Default");
                            setStyle(new StyleOption() {
                              {
                                setBackgroundColor(new CssColorOption() {
                                  {
                                    setColor("#90ee90");
                                  }
                                });
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#ff0000");
                                  }
                                });
                                setStrokeDasharray("3, 3");
                                setStrokeWidth(2.0);
                              }
                            });
                            setTemplate("{categoryField.name}:{categoryField.value}");
                            setTextStyle(new TextStyleOption() {
                              {
                                setColor("red");
                                setFontFamily("YouYuan");
                                setFontSize("20");
                                setFontStyle(FontStyle.Oblique);
                                setFontWeight("Bold");
                                setOpacity(0.5);
                                setOverflow(TextOverflow.Wrap);
                                setTextDecoration(new TextDecorationOption() {
                                  {
                                    setLineThrough(true);
                                    setOverline(true);
                                    setUnderline(true);
                                  }
                                });
                                setWritingMode(TextWritingMode.Horizontal);
                              }
                            });
                          }
                        });
                      }
                    });
                    setStyle(new DataPointStyleOption() {
                      {
                        setFill(new CssColorOption() {
                          {
                            setColor("#add8e6");
                          }
                        });
                        setFill(new LinearGradientOption() {
                          {
                            setAngle(180.0);
                            setColorStops(new ArrayList < IColorStopOption > () {
                              {
                                add(new ColorStopOption() {
                                  {
                                    setColor("rgba(255,0,0,0)");
                                  }
                                });
                                add(new ColorStopOption() {
                                  {
                                    setColor("#ff0000");
                                  }
                                });
                              }
                            });
                          }
                        });
                        setOpacity(0.5);
                        setStroke(new CssColorOption() {
                          {
                            setColor("#0000ff");
                          }
                        });
                        setStrokeDasharray("5, 5");
                        setStrokeWidth(new StrokeWidthOption() {
                          {
                            setBottom(2.0);
                            setLeft(2.0);
                            setRight(2.0);
                            setTop(2.0);
                          }
                        });
                        setSymbolFill(new CssColorOption() {
                          {
                            setColor("#add8e6");
                          }
                        });
                        setSymbolOpacity(0.5);
                        setSymbolShape("Dot");
                        setSymbolStroke(new CssColorOption() {
                          {
                            setColor("#ff0000");
                          }
                        });
                        setSymbolStrokeDasharray("5, 5");
                        setSymbolStrokeWidth(3.0);
                        setSymbolSize(30.0);
                        setSymbolShape("Diamond");
                        setBackgroundColor(new CssColorOption() {
                          {
                            setColor("#add8e6");
                          }
                        });
                        setBorderRadius(new BorderRadiusOption() {
                          {
                            setHorizontalRadius(new BorderRadiusValueOption() {
                              {
                                setBottomLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setBottomRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                              }
                            });
                            setVerticalRadius(new BorderRadiusValueOption() {
                              {
                                setBottomLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setBottomRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                              }
                            });
                          }
                        });
                      }
                    });
                    setOverlays(new ArrayList < IOverlayOption > () {
                      {
                        add(new TextOverlayOption() {
                          {
                            setType("Text");
                            setDisplay(OverlayDisplay.Front);
                            setText("Text");
                            setTextStyle(new TextStyleOption() {
                              {
                                setColor("red");
                                setFontFamily("YouYuan");
                                setFontSize("20");
                                setFontStyle(FontStyle.Oblique);
                                setFontWeight("Bold");
                                setOpacity(0.5);
                                setOverflow(TextOverflow.Wrap);
                                setTextDecoration(new TextDecorationOption() {
                                  {
                                    setLineThrough(true);
                                    setOverline(true);
                                    setUnderline(true);
                                  }
                                });
                                setWritingMode(TextWritingMode.Horizontal);
                              }
                            });
                            setWidth(20.0);
                            setStyle(new OverlayStyleOption() {
                              {
                                setOpacity(0.5);
                                setStrokeOpacity(0.5);
                                setFill(new CssColorOption() {
                                  {
                                    setColor("#add8e6");
                                  }
                                });
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#0000ff");
                                  }
                                });
                                setStrokeDasharray("5, 5");
                                setStrokeWidth(0.5);
                                setBackgroundColor(new CssColorOption() {
                                  {
                                    setColor("#add8e6");
                                  }
                                });
                              }
                            });
                          }
                        });
                        add(new BarLineOverlayOption() {
                          {
                            setType("BarLine");
                            setDisplay(OverlayDisplay.Front);
                            setRules(new ArrayList < IRuleOption > ());
                          }
                        });
                        add(new ErrorBarOption() {
                          {
                            setType("ErrorBar");
                            setDisplay(OverlayDisplay.Front);
                            setRules(new ArrayList < IRuleOption > ());
      
                          }
                        });
                        add(new ImageOverlayOption() {
                          {
                            setType("Image");
                            setDisplay(OverlayDisplay.Front);
                            setRules(new ArrayList < IRuleOption > ());
      
                          }
                        });
                        add(new PathAnnotationOption() {
                          {
                            setType("Path");
                            setDisplay(OverlayDisplay.FrontOfPlot);
                            setRules(new ArrayList < IRuleOption > ());
                          }
                        });
                        add(new RectangleOverlayOption() {
                          {
                            setType("Rectangle");
                            setDisplay(OverlayDisplay.Back);
                            setRules(new ArrayList < IRuleOption > ());
      
                          }
                        });
                        add(new ReferenceBandOverlayOption() {
                          {
                            setType("ReferenceBand");
                            setDisplay(OverlayDisplay.Back);
                            setRules(new ArrayList < IRuleOption > ());
      
                          }
                        });
                        add(new ReferenceLineOverlayOption() {
                          {
                            setType("ReferenceLine");
                            setDisplay(com.grapecity.datavisualization.chart.enums.OverlayDisplay.Back);
                            setRules(new ArrayList < IRuleOption > ());
      
                          }
                        });
                        add(new PolynomialTrendlineOverlayOption() {
                          {
                            setType("PolynomialTrendline");
                            setDisplay(com.grapecity.datavisualization.chart.enums.OverlayDisplay.Front);
                            setRules(new ArrayList < IRuleOption > ());
                          }
                        });
                      }
                    });
                    setPalette(new ArrayList < IPaletteItemOption > () {
                      {
                        add(new PaletteItemOption() {
                          {
                            setColor(new CssColorOption() {
                              {
                                setColor("#f07f09");
                              }
                            });
                            setType(PaletteItemType.Index);
                          }
                        });
                        add(new PaletteItemOption() {
                          {
                            setColor(new CssColorOption() {
                              {
                                setColor("#9f2936");
                              }
                            });
                            setType(PaletteItemType.Data);
                          }
                        });
                      }
                    });
                    setTextStyle(new TextStyleOption() {
                      {
                        setAlignment(HAlign.Left);
                        setColor("red");
                        setFontFamily("YouYuan");
                        setFontSize("25");
                        setFontStyle(FontStyle.Oblique);
                        setFontWeight("600");
                        setOpacity(0.5);
                        setOverflow(TextOverflow.Clip);
                        setTextDecoration(new TextDecorationOption() {
                          {
                            setLineThrough(true);
                            setOverline(true);
                            setUnderline(true);
                          }
                        });
                        setWritingMode(TextWritingMode.Horizontal);
                      }
                    });
                    setBar(new PlotBarOption() {
                      {
                        setConnectorLineStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("rgba(255,0,0,0.5)");
                              }
                            });
                            setStrokeDasharray("3, 3");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(6.0);
                          }
                        });
                        setConnectorLines(true);
                        setWaterfall(new WaterfallOption());
                      }
                    });
                    setHAlign(HAlign.Left);
                    setVAlign(VAlign.Top);
                    setNode(new SankeyNodeOption() {
                      {
                        setBorderRadius(new BorderRadiusOption() {
                          {
                            setHorizontalRadius(new BorderRadiusValueOption() {
                              {
                                setBottomLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setBottomRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                              }
                            });
                            setVerticalRadius(new BorderRadiusValueOption() {
                              {
                                setBottomLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setBottomRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopLeft(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                                setTopRight(new ValueOption() {
                                  {
                                    setType(ValueOptionType.Pixel);
                                    setValue(20.0);
                                  }
                                });
                              }
                            });
                          }
                        });
                        setNodeGap(20.0);
                        setWidth(20);
                        setPadAngle(10);
                        setPalette(new ArrayList < IPaletteItemOption > ());
                        setStyle(new DataPointStyleOption() {
                          {
                            setFill(new CssColorOption() {
                              {
                                setColor("blue");
                              }
                            });
                            setOpacity(0.8);
                            setStroke(new CssColorOption() {
                              {
                                setColor("blue");
                              }
                            });
                            setStrokeDasharray("3, 3");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(new StrokeWidthOption() {
                              {
                                setBottom(2.0);
                                setLeft(2.0);
                                setRight(2.0);
                                setTop(2.0);
                              }
                            });
                          }
                        });
                      }
                    });
                  }
                });
              }
            });
          }
        });
        dvOption.setConfig(new ConfigOption() {
          {
            setHeader(new HeaderOption() {
              {
                setHAlign(HAlign.Left);
                setHeight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.25);
                  }
                });
                setMaxHeight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setPadding(new PaddingOption() {
                  {
                    setBottom(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setTop(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                  }
                });
                setStyle(new StyleOption() {
                  {
                    setBackgroundColor(new CssColorOption() {
                      {
                        setColor("#add8e6");
                      }
                    });
                    setStroke(new CssColorOption() {
                      {
                        setColor("#ff0000");
                      }
                    });
                    setStrokeDasharray("10, 10");
                    setStrokeWidth(1.0);
                  }
                });
                setTextStyle(new TextStyleOption() {
                  {
                    setColor("red");
                    setFontFamily("Tahoma");
                    setFontSize("24");
                    setFontStyle(FontStyle.Italic);
                    setFontWeight("Bold");
                    setTextDecoration(new TextDecorationOption() {
                      {
                        setLineThrough(true);
                        setOverline(true);
                        setUnderline(true);
                      }
                    });
                  }
                });
                setTitle("this is header title.");
                setVAlign(VAlign.Bottom);
                setWidth(new ValueOption() {
                  {
                    setType(ValueOptionType.Pixel);
                    setValue(220.0);
                  }
                });
              }
            });
            setFooter(new FooterOption() {});
            setBackgroundColor(new CssColorOption() {
              {
                setColor("#add8e6");
              }
            });
            setBar(new BarOption() {
              {
                setWidth(0.5);
                setOverlap(0.5);
                setBottomWidth(0.9);
                setNeckHeight(0.5);
                setTopWidth(0.2);
                setFunnelType(FunnelType.Bar);
                setBorderRadius(new BorderRadiusOption() {
                  {
                    setHorizontalRadius(new BorderRadiusValueOption() {
                      {
                        setBottomLeft(new ValueOption() {
                          {
                            setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setBottomRight(new ValueOption() {
                          {
                            setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setTopLeft(new ValueOption() {
                          {
                            setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setTopRight(new ValueOption() {
                          {
                            setType(com.grapecity.datavisualization.chart.enums.ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                      }
                    });
                    setVerticalRadius(new BorderRadiusValueOption() {
                      {
                        setBottomLeft(new ValueOption() {
                          {
                            setType(ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setBottomRight(new ValueOption() {
                          {
                            setType(ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setTopLeft(new ValueOption() {
                          {
                            setType(ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                        setTopRight(new ValueOption() {
                          {
                            setType(ValueOptionType.Pixel);
                            setValue(20.0);
                          }
                        });
                      }
                    });
                  }
                });
              }
            });
            setBorderStyle(new LineStyleOption() {
              {
                setStroke(new CssColorOption() {
                  {
                    setColor("#008000");
                  }
                });
                setStrokeDasharray("10, 10");
                setStrokeOpacity(0.7);
                setStrokeWidth(6.0);
              }
            });
            setLegend(new GlobalLegendOption() {
              {
                setBorderStyle(new LineStyleOption() {
                  {
                    setStroke(new CssColorOption() {
                      {
                        setColor("#ff0000");
                      }
                    });
                    setStrokeDasharray("3, 3");
                    setStrokeOpacity(0.5);
                    setStrokeWidth(4.0);
                  }
                });
                setGroupHAlign(HAlign.Center);
                setGroupOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                setGroupPadding(new PaddingOption() {
                  {
                    setBottom(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setTop(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                  }
                });
                setGroupVAlign(VAlign.Bottom);
                setItemPadding(new PaddingOption() {
                  {
                    setBottom(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setTop(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                  }
                });
                setItemSpace(new ValueOption() {
                  {
                    setType(ValueOptionType.Pixel);
                    setValue(50.0);
                  }
                });
                setLeft(0.25);
                setMargin(new MarginOption() {
                  {
                    setBottom(30.0);
                    setLeft(40.0);
                    setRight(20.0);
                    setTop(10.0);
                  }
                });
                setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                setPadding(new PaddingOption() {
                  {
                    setBottom(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setLeft(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setRight(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                    setTop(new ValueOption() {
                      {
                        setType(ValueOptionType.Percentage);
                        setValue(0.3);
                      }
                    });
                  }
                });
                setPosition(LegendPosition.Floating);
                setStyle(new LegendStyleOption() {
                  {
                    setBackgroundColor(new CssColorOption() {
                      {
                        setColor("#90ee90");
                      }
                    });
                    setIconColor(new CssColorOption() {
                      {
                        setColor("#ffff00");
                      }
                    });
                    setStroke(new CssColorOption() {
                      {
                        setColor("#ff0000");
                      }
                    });
                    setStrokeDasharray("10, 5");
                    setStrokeWidth(3.0);
                  }
                });
                setTextStyle(new TextStyleOption() {
                  {
                    setColor("red");
                    setFontFamily("LiSu");
                    setFontSize("20");
                    setFontStyle(FontStyle.Italic);
                    setFontWeight("Bold");
                    setOpacity(0.5);
                    setTextDecoration(new TextDecorationOption() {
                      {
                        setLineThrough(true);
                        setOverline(true);
                        setUnderline(true);
                      }
                    });
                  }
                });
                setTitlePosition(Position.Bottom);
                setTitleStyle(new TextStyleOption() {
                  {
                    setColor("green");
                    setFontFamily("LiSu");
                    setFontSize("30");
                    setFontStyle(FontStyle.Italic);
                    setFontWeight("Bold");
                    setOpacity(0.8);
                    setTextDecoration(new TextDecorationOption() {
                      {
                        setLineThrough(true);
                        setOverline(true);
                        setUnderline(true);
                      }
                    });
                  }
                });
                setTop(0.25);
                setWrapping(false);
              }
            });
            setPadding(new PaddingOption() {
              {
                setBottom(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setLeft(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setRight(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
                setTop(new ValueOption() {
                  {
                    setType(ValueOptionType.Percentage);
                    setValue(0.3);
                  }
                });
              }
            });
            setPalette(new ArrayList < IPaletteItemOption > () {
              {
                add(new PaletteItemOption() {
                  {
                    setColor(new CssColorOption() {
                      {
                        setColor("#f07f09");
                      }
                    });
                    setType(PaletteItemType.Index);
                  }
                });
              }
            });
            setPlotAreaLayout(new PlotAreaLayoutOption() {
              {
                setColumnWidths(new ArrayList < IValueOption > () {
                  {
                    add(new ValueOption() {
                      {
                        setType(ValueOptionType.Available);
                        setValue(1.0);
                      }
                    });
                    add(new ValueOption() {
                      {
                        setType(ValueOptionType.Available);
                        setValue(2.0);
                      }
                    });
                  }
                });
                setRowHeights(new ArrayList < IValueOption > () {
                  {
                    add(new ValueOption() {
                      {
                        setType(ValueOptionType.Available);
                        setValue(1.0);
                      }
                    });
                    add(new ValueOption() {
                      {
                        setType(ValueOptionType.Available);
                        setValue(2.0);
                      }
                    });
                  }
                });
              }
            });
            setShapes(new ArrayList < ISymbolItemOption > () {
              {
                add(new SymbolItemOption() {
                  {
                    setShape(new SymbolShapeOption() {
                      {
                        setContent("");
                        setName("Box");
                      }
                    });
                    setType(SymbolItemType.Index);
                  }
                });
                add(new SymbolItemOption() {
                  {
                    setData(new DataValueType("US"));
                    setShape(new SymbolShapeOption() {
                      {
                        setContent("");
                        setName("US");
                      }
                    });
                    setType(SymbolItemType.Data);
                  }
                });
              }
            });
            setStyle(new StyleOption() {
              {
                setBackgroundColor(new CssColorOption() {
                  {
                    setColor("#90ee90");
                  }
                });
                setFill(new CssColorOption() {
                  {
                    setColor("#0000ff");
                  }
                });
                setStroke(new CssColorOption() {
                  {
                    setColor("#ff0000");
                  }
                });
                setStrokeDasharray("5, 5");
                setStrokeWidth(4.0);
              }
            });
            setTextStyle(new TextStyleOption() {
              {
                setAlignment(HAlign.Left);
                setColor("red");
                setFontFamily("YouYuan");
                setFontSize("25");
                setFontStyle(FontStyle.Oblique);
                setFontWeight("600");
                setOpacity(0.5);
                setOverflow(TextOverflow.Clip);
                setTextDecoration(new TextDecorationOption() {
                  {
                    setLineThrough(true);
                    setOverline(true);
                    setUnderline(true);
                  }
                });
                setWritingMode(TextWritingMode.Horizontal);
              }
            });
            setPlotAreas(new ArrayList < IPlotAreaOption > () {
              {
                add(new PlotAreaOption() {
                  {
                    setColumn(0);
                    setRow(1);
                    setBackgroundColor(new CssColorOption() {
                      {
                        setColor("#add8e6");
                      }
                    });
                    setBorderStyle(new LineStyleOption() {
                      {
                        setStroke(new CssColorOption() {
                          {
                            setColor("#008000");
                          }
                        });
                        setStrokeDasharray("10%, 20%");
                        setStrokeOpacity(0.7);
                        setStrokeWidth(6.0);
                      }
                    });
                    setLegend(new GlobalLegendOption() {
                      {
                        setBorderStyle(new LineStyleOption() {
                          {
                            setStroke(new CssColorOption() {
                              {
                                setColor("#ff0000");
                              }
                            });
                            setStrokeDasharray("3, 3");
                            setStrokeOpacity(0.5);
                            setStrokeWidth(4.0);
                          }
                        });
                        setPosition(LegendPosition.Floating);
                        setGroupHAlign(HAlign.Center);
                        setGroupVAlign(VAlign.Top);
                        setGroupOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                        setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                        setTitlePosition(Position.Bottom);
                        setGroupPadding(new PaddingOption() {
                          {
                            setBottom(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setLeft(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setRight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setTop(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                          }
                        });
                        setItemPadding(new PaddingOption() {
                          {
                            setBottom(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setLeft(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setRight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setTop(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                          }
                        });
                        setItemSpace(new ValueOption() {
                          {
                            setType(ValueOptionType.Pixel);
                            setValue(50.0);
                          }
                        });
                        setMargin(new MarginOption() {
                          {
                            setBottom(30.0);
                            setLeft(40.0);
                            setRight(20.0);
                            setTop(10.0);
                          }
                        });
                        setPadding(new PaddingOption() {
                          {
                            setBottom(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setLeft(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setRight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                            setTop(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.3);
                              }
                            });
                          }
                        });
                        setStyle(new LegendStyleOption() {
                          {
                            setBackgroundColor(new CssColorOption() {
                              {
                                setColor("#90ee90");
                              }
                            });
                            setIconColor(new CssColorOption() {
                              {
                                setColor("#ffff00");
                              }
                            });
                            setStroke(new CssColorOption() {
                              {
                                setColor("#ff0000");
                              }
                            });
                            setStrokeDasharray("10, 5");
                            setStrokeWidth(3.0);
                          }
                        });
                        setTextStyle(new TextStyleOption() {
                          {
                            setColor("red");
                            setFontFamily("LiSu");
                            setFontSize("20");
                            setFontStyle(FontStyle.Italic);
                            setFontWeight("Bold");
                            setOpacity(0.5);
                            setTextDecoration(new TextDecorationOption() {
                              {
                                setLineThrough(true);
                                setOverline(true);
                                setUnderline(true);
                              }
                            });
                          }
                        });
                        setTitleStyle(new TextStyleOption() {
                          {
                            setColor("green");
                            setFontFamily("LiSu");
                            setFontSize("30");
                            setFontStyle(FontStyle.Italic);
                            setFontWeight("Bold");
                            setOpacity(0.8);
                            setTextDecoration(new TextDecorationOption() {
                              {
                                setLineThrough(true);
                                setOverline(true);
                                setUnderline(true);
                              }
                            });
                          }
                        });
                        setLeft(0.65);
                        setTop(0.1);
                        setWrapping(false);
                      }
                    });
                    setLegends(new ArrayList < ILegendOption > () {
                      {
                        add(new LegendOption() {
                          {
                            setType(LegendType.Color);
                            setGradient(new LegendGradientOption() {
                              {
                                setEnabled(false);
                                setPalette(new ArrayList < java.lang.String > ());
                              }
                            });
                            setRanges(new ArrayList < ILegendRangeOption > () {
                              {
                                add(new LegendRangeOption() {
                                  {
                                    setTitle("Min - 1000");
                                    setTo(1000.0);
                                  }
                                });
                                add(new LegendRangeOption() {
                                  {
                                    setTitle("1000 - 2000");
                                    setTo(2000.0);
                                  }
                                });
                              }
                            });
                            setPosition(LegendPosition.Left);
                            setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                            setBorderStyle(new LineStyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#ff0000");
                                  }
                                });
                                setStrokeDasharray("10, 10");
                                setStrokeOpacity(0.55);
                                setStrokeWidth(0.5);
                              }
                            });
                            setHeight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.25);
                              }
                            });
                            setItemSpace(new ValueOption() {
                              {
                                setType(ValueOptionType.Pixel);
                                setValue(20.0);
                              }
                            });
                            setLeft(0.75);
                            setMargin(new MarginOption() {
                              {
                                setBottom(10.0);
                                setLeft(20.0);
                                setRight(10.0);
                                setTop(20.0);
                              }
                            });
                            setMaxHeight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.25);
                              }
                            });
                            setSortOrder(SortOrder.Ascending);
                            setTitle("Color.title");
                            setTop(0.5);
                            setType(LegendType.Color);
                            setVAlign(VAlign.Top);
                          }
                        });
                        add(new LegendOption() {
                          {
                            setType(LegendType.Shape);
                            setOrientation(com.grapecity.datavisualization.chart.core.Orientation.Horizontal);
                            setPosition(LegendPosition.Top);
                          }
                        });
                      }
                    });
                    setPadding(new PaddingOption() {
                      {
                        setBottom(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setLeft(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setRight(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                        setTop(new ValueOption() {
                          {
                            setType(ValueOptionType.Percentage);
                            setValue(0.3);
                          }
                        });
                      }
                    });
                    setPlotsMargin(new MarginOption() {
                      {
                        setBottom(0.3);
                        setLeft(0.0);
                        setRight(0.0);
                        setTop(0.0);
                      }
                    });
                    setStyle(new PlotAreaStyleOption() {
                      {
                        setBackgroundColor(new CssColorOption() {
                          {
                            setColor("#90ee90");
                          }
                        });
                        setFill(new CssColorOption() {
                          {
                            setColor("#add8e6");
                          }
                        });
                        setInnerStroke(new CssColorOption() {
                          {
                            setColor("#008000");
                          }
                        });
                        setInnerStrokeDasharray("3, 3");
                        setInnerStrokeWidth(2.0);
                        setStroke(new CssColorOption() {
                          {
                            setColor("#ff0000");
                          }
                        });
                        setStrokeDasharray("5, 5");
                        setStrokeWidth(4.0);
                      }
                    });
                    setTextStyle(new TextStyleOption() {
                      {
                        setAlignment(HAlign.Left);
                        setColor("red");
                        setFontFamily("YouYuan");
                        setFontSize("25");
                        setFontStyle(FontStyle.Oblique);
                        setFontWeight("600");
                        setOpacity(0.5);
                        setOverflow(TextOverflow.Clip);
                        setTextDecoration(new TextDecorationOption() {
                          {
                            setLineThrough(true);
                            setOverline(true);
                            setUnderline(true);
                          }
                        });
                        setWritingMode(TextWritingMode.Horizontal);
                      }
                    });
                    setAxes(new ArrayList < IAxisOption > () {
                      {
                        add(new AxisOption() {
                          {
                            setPlots(new ArrayList < java.lang.String > () {
                              {
                                add("p1");
                              }
                            });
                            setType(AxisType.X);
                            setTitle("This is Axes-X title.");
                            setTitleStyle(new LabelStyleOption() {
                              {
                                setColor("red");
                                setFontFamily("YouYuan");
                                setFontSize("15");
                                setFontStyle(FontStyle.Oblique);
                                setFontWeight("600");
                                setOpacity(0.5);
                                setOverflow(TextOverflow.Clip);
                                setTextDecoration(new TextDecorationOption() {
                                  {
                                    setLineThrough(true);
                                  }
                                });
                              }
                            });
                            setAxisLine(false);
                            setAxisPadding(1.0);
                            setDateMode(DateMode.Day);
                            setFormat(new FormatOption() {
                              {
                                setValue("Y");
                              }
                            });
                            setGroupGrid(TickMark.Inside);
                            setGroupGridStyle(new LineStyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#0000ff");
                                  }
                                });
                                setStrokeDasharray("3, 3");
                                setStrokeOpacity(0.5);
                                setStrokeWidth(2.0);
                              }
                            });
                            setHeight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.5);
                              }
                            });
                            setWidth(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.5);
                              }
                            });
                            setLabelAngle(new ArrayList < java.lang.Double > () {
                              {
                                add(45.0);
                              }
                            });
                            setLabelStyle(new LabelStyleOption() {
                              {
                                setColor("red");
                                setFontFamily("YouYuan");
                                setFontSize("15");
                                setFontStyle(FontStyle.Oblique);
                                setFontWeight("600");
                                setOpacity(0.5);
                                setOverflow(TextOverflow.Clip);
                                setTextDecoration(new TextDecorationOption() {
                                  {
                                    setLineThrough(true);
                                  }
                                });
                              }
                            });
                            setLabelTemplate("{Country}");
                            setLabels(AxisPosition.Far);
                            setLineStyle(new LineStyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#ff0000");
                                  }
                                });
                                setStrokeOpacity(0.3);
                                setStrokeWidth(3.0);
                              }
                            });
                            setLogBase(100.0);
                            setHeight(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.5);
                              }
                            });
                            setMaxWidth(new ValueOption() {
                              {
                                setType(ValueOptionType.Percentage);
                                setValue(0.25);
                              }
                            });
                            setMax(new ValueOption() {
                              {
                                setType(ValueOptionType.Number);
                                setValue(18000.0);
                              }
                            });
                            setMin(new ValueOption() {
                              {
                                setType(ValueOptionType.Number);
                                setValue( - 1000.0);
                              }
                            });
                            setMajorGrid(true);
                            setMajorGridStyle(new LineStyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#0000ff");
                                  }
                                });
                                setStrokeDasharray("3, 3");
                                setStrokeOpacity(0.5);
                                setStrokeWidth(2.0);
                              }
                            });
                            setMajorTickSize(30.0);
                            setMajorTickStyle(new LineStyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#0000ff");
                                  }
                                });
                                setStrokeDasharray("4, 2");
                                setStrokeOpacity(0.5);
                                setStrokeWidth(1.0);
                              }
                            });
                            setMajorTicks(TickMark.Outside);
                            setMajorUnit(new AxisUnitOption() {
                              {
                                setValue(5000.0);
                              }
                            });
                            setMinorTickSize(5.0);
                            setMinorTickStyle(new LineStyleOption() {
                              {
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#0000ff");
                                  }
                                });
                                setStrokeDasharray("4, 2");
                                setStrokeOpacity(0.5);
                                setStrokeWidth(1.0);
                              }
                            });
                            setMinorTicks(TickMark.Inside);
                            setMinorUnit(new AxisUnitOption() {
                              {
                                setValue(0.5);
                              }
                            });
                            setOrigin(10000.0);
                            setOverlappingLabels(OverlappingLabels.Hide);
                            setPosition(AxisPosition.Far);
                            setReversed(true);
                            setRules(new ArrayList < IRuleOption > () {
                              {
                                add(new RuleOption() {
                                  {
                                    setActions(new ArrayList < IRuleActionOption > () {
                                      {
                                        add(new RuleActionOption() {
                                          {
                                            setProperties(new ArrayList < IRuleActionPropertyOption > () {
                                              {
                                                add(new RuleActionPropertyOption() {
                                                  {
                                                    setName("textStyle.color");
                                                    setValue("red");
                                                  }
                                                });
                                              }
                                            });
                                            setTargetElement("Label");
                                          }
                                        });
                                      }
                                    });
                                    setCondition("current.value = \"US\"");
                                    setType("Label");
                                  }
                                });
                              }
                            });
                            setScale(new ValueScaleOption() {
                              {
                                setType(ValueScaleType.Linear);
                              }
                            });
                            setStyle(new StyleOption() {
                              {
                                setBackgroundColor(new CssColorOption() {
                                  {
                                    setColor("#add8e6");
                                  }
                                });
                                setStroke(new CssColorOption() {
                                  {
                                    setColor("#ff0000");
                                  }
                                });
                                setStrokeDasharray("3,3");
                                setStrokeWidth(1.0);
                              }
                            });
                            setTextStyle(new TextStyleOption() {
                              {
                                setColor("red");
                                setFontFamily("YouYuan");
                                setFontSize("15");
                                setFontStyle(FontStyle.Oblique);
                                setFontWeight("600");
                                setOpacity(0.5);
                                setOverflow(TextOverflow.Clip);
                                setTextDecoration(new TextDecorationOption() {
                                  {
                                    setLineThrough(true);
                                  }
                                });
                              }
                            });
                            setUnitLabel(new UnitLabelOption() {
                              {
                                setStyle(new StyleOption() {
                                  {
                                    setStroke(new CssColorOption() {
                                      {
                                        setColor("#ff0000");
                                      }
                                    });
                                    setStrokeDasharray("3,3");
                                    setStrokeWidth(2.0);
                                  }
                                });
                                setText("Axes-y unitLabel.");
                                setTextStyle(new LabelStyleOption() {
                                  {
                                    setColor("red");
                                    setFontFamily("YouYuan");
                                    setFontSize("15");
                                    setFontStyle(FontStyle.Oblique);
                                    setFontWeight("600");
                                    setOpacity(0.5);
                                    setOverflow(TextOverflow.Clip);
                                    setTextDecoration(new TextDecorationOption() {
                                      {
                                        setLineThrough(true);
                                      }
                                    });
                                  }
                                });
                              }
                            });
                            setUseActualMax(true);
                            setUseActualMin(true);
                            setScrollbarVisible(true);
                            setViewSize(0.5);
                            setPlugins(new ArrayList < IConfigPluginOption > () {
                              {
                                add(new ConfigPluginOption() {
                                  {
                                    setName("Excel");
                                    setType("AxisLabelExpandPolicy");
                                    setArguments(new SjsLegendViewManagerOption() {
                                      {
                                        setExcelPosition(SjsLegendPosition.Bottom);
                                      }
                                    });
                                  }
                                });
                              }
                            });
                          }
                        });
                        add(new AxisOption() {
                          {
                            setPlots(new ArrayList < java.lang.String > () {
                              {
                                add("p1");
                              }
                            });
                            setType(AxisType.Y);
                          }
                        });
                      }
                    });
                  }
                });
                add(new PlotAreaOption() {});
              }
            });
          }
        });
        dvOption.setTransform(new ArrayList < ITransformOption > () {
          {
            add(new AggregateTransformOption() {
              {
                setType(TransformType.Aggregate);
                setAggregate(new ArrayList < IAggregateOption > () {
                  {
                    add(new AggregateOption() {
                      {
                        setField("Sales");
                        setOp(Aggregate.Count);
                        setOutputAs("SalesCount");
                      }
                    });
                    add(new AggregateOption() {
                      {
                        setField("Sales");
                        setOp(Aggregate.Sum);
                        setOutputAs("SalesSum");
                      }
                    });
                  }
                });
                setConcat(new ConcatOption() {
                  {
                    setCustomArray(new ArrayList < java.lang.Integer > ());
                    setType(ConcatType.GroupEnd);
                  }
                });
                setGroupby(new ArrayList < java.lang.String > () {
                  {
                    add("Country");
                  }
                });
              }
            });
            add(new BinTransformOption() {
              {
                setType(TransformType.Bin);
                setBin(new BinOption() {
                  {
                    setSteps(new ArrayList < java.lang.Double > ());
                    setSteps(new ArrayList < java.lang.Double > () {
                      {
                        add(5000.0);
                        add(10000.0);
                        add(15000.0);
                        add(20000.0);
                      }
                    });
                  }
                });
                setField("Downloads");
                setOutputAs("DownloadsBin");
              }
            });
            add(new CalculateTransformOption() {
              {
                setType(TransformType.Calculate);
                setCalculate("=IF(ISBLANK(current.销售大区), \"NULL\", current.销售大区)");
                setOutputAs("SalesRegion");
              }
            });
            add(new UnpivotTransformOption() {
              {
                setType(TransformType.Unpivot);
                setCategory(new UnpivotCategoryOption() {
                  {
                    setFieldAs("category");
                    setFrom(new ArrayList < java.lang.String > () {
                      {
                        add("category");
                      }
                    });
                  }
                });
                setNames(new ArrayList < java.lang.String > () {
                  {
                    add("sample");
                  }
                });
                setOutputAs("unpivotData");
                setValueFieldAs("value");
              }
            });
          }
        });
        return dvOption;
    }

    public static IDvOption DAT_Demo() {
        IDvOption dvOption = new DvOption();
      
        dvOption.setPlots(new ArrayList < IPlotOption > () {
          {
            add(new PlotOption() {
              {
                setType("Bar");
                setEncodings(new PlotEncodingsOption() {
                  {
                    setValues(new ArrayList < IValueEncodingOption > () {
                      {
                        add(new FieldsValueEncodingOption() {
                          {
                            setField("Sales");
                          }
                        });
                      }
                    });
                    setCategory(new CategoryEncodingOption() {
                      {
                        setField("Country");
                      }
                    });
                  }
                });
              }
            });
          }
        });
        return dvOption;
    }

    public static IDvOption createOption() {
        IDvOption dvOption = new DvOption();
        // Date today = new Date();
        // Calendar calendar = Calendar.getInstance();
        // calendar.setTime(today);
        // calendar.add(Calendar.DATE, 1);
        // Date tomorrow = calendar.getTime();
      
        HashMap < String,
        Object > dict1 = new HashMap < String,
        Object > ();
        dict1.put("Company", "IBM");
        dict1.put("Sales", 3545);
      
        HashMap < String,
        Object > dict2 = new HashMap < String,
        Object > ();
        dict2.put("Company", "MS");
        dict2.put("Sales", 6545);
      
        HashMap < String,
        Object > dict3 = new HashMap < String,
        Object > ();
        dict3.put("Company", "MAC");
        dict3.put("Sales", 1545);
      
        HashMap < String,
        Object > dict4 = new HashMap < String,
        Object > ();
        dict4.put("Company", "MS");
        dict4.put("Sales", 6545);
      
        HashMap < String,
        Object > dict5 = new HashMap < String,
        Object > ();
        dict5.put("Company", "Alibaba");
        dict5.put("Sales", 4663);
      
        HashMap < String,
        Object > dict6 = new HashMap < String,
        Object > ();
        dict6.put("Company", "HuaWei");
        dict6.put("Sales", 6663);
      
        HashMap < String,
        Object > dict7 = new HashMap < String,
        Object > ();
        dict7.put("Company", "GrapeCity");
        dict7.put("Sales", 3603);
      
        HashMap < String,
        Object > dict8 = new HashMap < String,
        Object > ();
        dict8.put("Company", "ABBYY");
        dict8.put("Sales", 5828);
      
        HashMap < String,
        Object > dict9 = new HashMap < String,
        Object > ();
        dict9.put("Company", "SONY");
        dict9.put("Sales", 3863);
      
        HashMap < String,
        Object > dict10 = new HashMap < String,
        Object > ();
        dict10.put("Company", "SOFTBANK");
        dict10.put("Sales", 2863);
      
        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();
        values.add(dict1);
        values.add(dict2);
        values.add(dict3);
        values.add(dict4);
        values.add(dict5);
        values.add(dict6);
        values.add(dict7);
        values.add(dict8);
        values.add(dict9);
        values.add(dict10);
        dataOption.setValues(values);
        data.add(dataOption);
        dvOption.setData(data);
      
        IPlotOption plotOption = new PlotOption();
        plotOption.setType("Bar");
        plotOption.setName("p1");
      
        IPlotEncodingsOption plotEncodingOption = new PlotEncodingsOption();
        plotEncodingOption.setCategory(new CategoryEncodingOption() {
          {
            setField("Company");
          }
        });
      
        ArrayList < IContentEncodingOption > textEncodingOption = new ArrayList < IContentEncodingOption > ();
        ContentEncodingOption contentEncodingOption = new ContentEncodingOption();
        contentEncodingOption.setField("Company");
        textEncodingOption.add(contentEncodingOption);
        plotEncodingOption.setText(textEncodingOption);
      
        FieldsValueEncodingOption valueEncodingOpiton = new FieldsValueEncodingOption();
        valueEncodingOpiton.setField("Sales");
        plotEncodingOption.getValues().add(valueEncodingOpiton);
      
        plotOption.setEncodings(plotEncodingOption);
        dvOption.getPlots().add(plotOption);
      
        IPlotConfigOption plotConfig = new PlotConfigOption();
        final IRuleOption ruleOption = new RuleOption();
        ruleOption.setCondition("current.value = \"MS\"");
        ruleOption.setType("DataPoint");
        final IRuleActionOption ruleAction = new RuleActionOption();
        ruleAction.setTargetElement("DataPoint");
      
        ArrayList < IRuleActionPropertyOption > ruleProperties = new ArrayList < IRuleActionPropertyOption > ();
        final IRuleActionPropertyOption prop1 = new RuleActionPropertyOption() {
          {
            setName("style.stroke");
            setValue("green");
          }
        };
        final IRuleActionPropertyOption prop2 = new RuleActionPropertyOption() {
          {
            setName("style.strokeWidth");
            setValue(5);
          }
        };
        final IRuleActionPropertyOption prop4 = new RuleActionPropertyOption() {
          {
            setName("style.backgroundColor");
            setValue("red");
          }
        };
        ruleProperties.addAll(new ArrayList < IRuleActionPropertyOption > () {
          {
            add(prop1);
            add(prop2);
            add(prop4);
          }
        });
      
        final IRuleActionPropertyOption propText1 = new RuleActionPropertyOption() {
          {
            setName("text.style.stroke");
            setValue("yellow");
          }
        };
        final IRuleActionPropertyOption propText2 = new RuleActionPropertyOption() {
          {
            setName("text.style.strokeWidth");
            setValue(2);
          }
        };
        final IRuleActionPropertyOption propText3 = new RuleActionPropertyOption() {
          {
            setName("text.style.strokeDashArray");
            setValue("1");
          }
        };
        final IRuleActionPropertyOption propText4 = new RuleActionPropertyOption() {
          {
            setName("text.style.backgroundColor");
            setValue("green");
          }
        };
        ArrayList < IRuleActionPropertyOption > props = new ArrayList < IRuleActionPropertyOption > ();
        props.add(propText1);
        props.add(propText2);
        props.add(propText3);
        props.add(propText4);
        ruleProperties.addAll(props);
        ruleAction.setProperties(ruleProperties);
      
        ruleOption.setActions(new ArrayList < IRuleActionOption > () {
          {
            add(ruleAction);
          }
        });
        plotConfig.setRules(new ArrayList < IRuleOption > () {
          {
            add(ruleOption);
          }
        });
        plotOption.setConfig(plotConfig);
      
        // var config = new _ConfigOption();
        // IPlotAreaOption plotAreaOption = new _PlotAreaOption();
        // IAxisOption axisOption = new _AxisOption();
        // axisOption.plots = new List<string>() { "p1");}};
        // axisOption.type = AxisType.X;
      
        // IRuleOption ruleOption = new _RuleOption();
        // ruleOption.condition = "current.value = \"MS\"";
        // ruleOption.type = "Label";
        // IRuleActionOption ruleAction = new _RuleActionOption();
        // ruleAction.targetElement = "Label";
        // var prop1 = new RuleActionPropertyOption() { { setName("textStyle.color");
        // setValue("red");}};
        // var prop2 = new RuleActionPropertyOption() { {
        // setName("textStyle.strokeWidth"); setValue(2);}};
        // var prop3 = new RuleActionPropertyOption() { {
        // setName("textStyle.strokeDashArray"); setValue("1");}};
        // ruleAction.properties = new List<IRuleActionPropertyOption>() { prop1);}};
      
        // ruleOption.actions = new List<IRuleActionOption>() { ruleAction);}};
        // axisOption.rules = new List<IRuleOption>() { ruleOption);}};
        // plotAreaOption.axes = new List<IAxisOption>() { axisOption);}};
        // config.plotAreas = new List<IPlotAreaOption>() { plotAreaOption);}};
        // dvOption.config = config;
      
        return dvOption;
    }

}
