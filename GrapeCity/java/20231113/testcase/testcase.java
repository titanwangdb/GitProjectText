package testcase;

import java.util.ArrayList;
import java.util.HashMap;

import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.grapecity.datavisualization.chart.cartesian.plugins.overlays.waterfallConnectLine.viewModels.IWaterfallPointModel;
import com.grapecity.datavisualization.chart.component.core.FlexDV;
import com.grapecity.datavisualization.chart.component.core._plugin.PluginCollection;
import com.grapecity.datavisualization.chart.component.core._views.visual.HitTestResult;
import com.grapecity.datavisualization.chart.core.drawing.FontStyle;
import com.grapecity.datavisualization.chart.core.drawing.Point;
import com.grapecity.datavisualization.chart.core.drawing.Size;
import com.grapecity.datavisualization.chart.core.drawing.TextWritingMode;
import com.grapecity.datavisualization.chart.core.drawing.path.IPath;
import com.grapecity.datavisualization.chart.core.drawing.path.builders.IPathBuilder;
import com.grapecity.datavisualization.chart.core.drawing.path.builders.PathBuilder;
import com.grapecity.datavisualization.chart.core.drawing.path.command.IPathCommand;
import com.grapecity.datavisualization.chart.core.drawing.path.command.builders.IPathCommandBuilder;
import com.grapecity.datavisualization.chart.core.drawing.path.command.builders.PathCommandBuilder;
import com.grapecity.datavisualization.chart.component.core.models.shapes.IShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.arc.IArcShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.donut.IDonutShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.polygon.IPolygonShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.polygonLine.IPolygonalLineShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.rectangle.IRectangleShape;
import com.grapecity.datavisualization.chart.component.core.models.viewModels.IViewModel;
import com.grapecity.datavisualization.chart.component.core.renderEngines.IRenderEngine;
import com.grapecity.datavisualization.chart.component.models.shapeModels.IShapeModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.IFlexDvModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.IPointModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.axes.IAxisModel;
import com.grapecity.datavisualization.chart.enums.*;
import com.grapecity.datavisualization.chart.options.*;
import com.grapecity.datavisualization.chart.plugins.swingCoordinateSystem.SwingLineCartesianCoordinateSystemPlugin;
import com.grapecity.datavisualization.chart.typescript.ArrayExtension;

import console.plugins.calcengine.CustomCalculateEnginePlugin;
import console.plugins.image.CustomImageInfoBuilder;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;

public class testcase {

  public static IDvOption createOption() {
    IDvOption dvOption = new DvOption();
    // Date today = new Date();
    // Calendar calendar = Calendar.getInstance();
    // calendar.setTime(today);
    // calendar.add(Calendar.DATE, 1);
    // Date tomorrow = calendar.getTime();

    HashMap<String, Object> dict1 = new HashMap<String, Object>();
    dict1.put("Company", "IBM");
    dict1.put("Sales", 3545);

    HashMap<String, Object> dict2 = new HashMap<String, Object>();
    dict2.put("Company", "MS");
    dict2.put("Sales", 6545);

    HashMap<String, Object> dict3 = new HashMap<String, Object>();
    dict3.put("Company", "MAC");
    dict3.put("Sales", 1545);

    HashMap<String, Object> dict4 = new HashMap<String, Object>();
    dict4.put("Company", "MS");
    dict4.put("Sales", 6545);

    HashMap<String, Object> dict5 = new HashMap<String, Object>();
    dict5.put("Company", "Alibaba");
    dict5.put("Sales", 4663);

    HashMap<String, Object> dict6 = new HashMap<String, Object>();
    dict6.put("Company", "HuaWei");
    dict6.put("Sales", 6663);

    HashMap<String, Object> dict7 = new HashMap<String, Object>();
    dict7.put("Company", "GrapeCity");
    dict7.put("Sales", 3603);

    HashMap<String, Object> dict8 = new HashMap<String, Object>();
    dict8.put("Company", "ABBYY");
    dict8.put("Sales", 5828);

    HashMap<String, Object> dict9 = new HashMap<String, Object>();
    dict9.put("Company", "SONY");
    dict9.put("Sales", 3863);

    HashMap<String, Object> dict10 = new HashMap<String, Object>();
    dict10.put("Company", "SOFTBANK");
    dict10.put("Sales", 2863);

    ArrayList<IDataOption> data = new ArrayList<IDataOption>();
    IDataOption dataOption = new DataOption();
    ArrayList<Object> values = new ArrayList<Object>();
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

    ArrayList<IContentEncodingOption> textEncodingOption = new ArrayList<IContentEncodingOption>();
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

    ArrayList<IRuleActionPropertyOption> ruleProperties = new ArrayList<IRuleActionPropertyOption>();
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
    ruleProperties.addAll(new ArrayList<IRuleActionPropertyOption>() {
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
    ArrayList<IRuleActionPropertyOption> props = new ArrayList<IRuleActionPropertyOption>();
    props.add(propText1);
    props.add(propText2);
    props.add(propText3);
    props.add(propText4);
    ruleProperties.addAll(props);
    ruleAction.setProperties(ruleProperties);

    ruleOption.setActions(new ArrayList<IRuleActionOption>() {
      {
        add(ruleAction);
      }
    });
    plotConfig.setRules(new ArrayList<IRuleOption>() {
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

  // Encoding
  public static IDvOption DAT_3386() {
    IDvOption dvOption = new DvOption();

    dvOption.setPlots(new ArrayList<IPlotOption>() {
      {
        add(new PlotOption() {
          {
            setType("Bar");
            setName("Plot1");
            setEncodings(new PlotEncodingsOption() {
              {
                setValues(new ArrayList<IValueEncodingOption>() {
                  {
                    add(new FieldsValueEncodingOption() {
                      {
                        setField("Fields!quantity.Value\u002B25");
                        setAggregate(Aggregate.Sum);
                      }
                    });
                    add(new FieldsValueEncodingOption() {
                      {
                        setField("Fields!quantity.Value\u002B10");
                        setAggregate(Aggregate.Sum);
                      }
                    });
                    add(new FieldsValueEncodingOption() {
                      {
                        setField("quantity");
                        setAggregate(Aggregate.Sum);
                      }
                    });
                    add(new FieldsValueEncodingOption() {
                      {
                        setField("Fields!quantity.Value-20");
                        setAggregate(Aggregate.Sum);
                      }
                    });
                  }
                });
              }
            });
            setConfig(new PlotConfigOption() {
              {
                setAxisMode(AxisMode.Radial);
                setShowNulls(ShowNulls.Gaps);
                setShowNaNs(ShowNulls.Connected);
                setInnerRadius(0.80000000000000004);
                setSweep(270);
                setStartAngle(-135);
                setBar(new PlotBarOption() {
                  {
                    setOverlap(1.0);
                  }
                });
                setOverlays(new ArrayList<IOverlayOption>() {
                  {
                    add(new NeedleOverlayOption() {
                      {
                        setType("Needle");
                        setDisplay(OverlayDisplay.Front);
                        setStart("center");
                        setEndOffset(10);
                        setWidth(0);
                        setEnd("0.0");
                        setPlacement(Placement.Auto);
                        setPosition(AnnotationPosition.Outside);
                        setStyle(new OverlayStyleOption() {
                          {
                            setFill(new CssColorOption() {
                              {
                                setColor("DarkSlateGray");
                              }
                            });
                            setStroke(new CssColorOption() {
                              {
                                setColor("DarkSlateGray");
                              }
                            });
                          }
                        });
                      }
                    });
                    add(new NeedleOverlayOption() {
                      {
                        setType("Needle");
                        setDisplay(OverlayDisplay.Front);
                        setStart("center");
                        setEnd("0.10");
                      }
                    });
                    add(new TextOverlayOption() {
                      {
                        setType("Text");
                        setDisplay(OverlayDisplay.Front);
                        setText("Text");
                        setPosition(AnnotationPosition.Center);
                        setPointPath("center");
                        setOffset("0,12");
                        setTextStyle(new TextStyleOption() {
                          {
                            setColor("Black");
                            setFontFamily("Arial");
                            setFontSize("22pt");
                            setFontStyle(FontStyle.Oblique);
                            setFontWeight("700");
                            setOpacity(0.5);
                            setWritingMode(TextWritingMode.Horizontal);
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
        setPlotAreas(new ArrayList<IPlotAreaOption>() {
          {
            add(new PlotAreaOption() {
              {
                setAxes(new ArrayList<IAxisOption>() {
                  {
                    add(new AxisOption() {
                      {
                        setType(AxisType.X);
                        setPlots(new ArrayList<java.lang.String>() {
                          {
                            add("Plot1");
                          }
                        });
                        setPosition(AxisPosition.None);
                      }
                    });
                    add(new AxisOption() {
                      {
                        setType(AxisType.Y);
                        setPlots(new ArrayList<java.lang.String>() {
                          {
                            add("Plot1");
                          }
                        });
                        setPosition(AxisPosition.Far);
                        setTitle("Value");
                        setMax(new ValueOption() {
                          {
                            setType(ValueOptionType.Number);
                            setValue(500);
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

    return dvOption;
  }

  // DAT_2742
  // DAT_2746
  // DAT_2747
  // DAT_2726

  public static IDvOption DAT_3575() {
    IDvOption dvOption = new DvOption();

    dvOption.setPlots(new ArrayList<IPlotOption>() {
      {
        add(new PlotOption() {
          {
            setType("Bar");
            setEncodings(new PlotEncodingsOption() {
              {
                setValues(new ArrayList<IValueEncodingOption>() {
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
            setConfig(new PlotConfigOption() {
              {
                setOverlays(new ArrayList<IOverlayOption>() {
                  {
                    add(new ReferenceLineOverlayOption() {
                      {
                        setAxis(AxisType.Y);
                        setDisplay(OverlayDisplay.Front);
                        setAggregate(ReferenceLineAggregate.Average);
                      }
                    });
                    add(new ReferenceBandOverlayOption() {
                      {
                        setAxis(AxisType.X);
                        setDisplay(OverlayDisplay.Back);
                        setStart(1.0);
                        setEnd(2.0);
                      }
                    });
                    add(new TextOverlayOption() {
                      {
                        setDisplay(OverlayDisplay.Front);
                        setText("Text");
                        setPointPath("$[0]");
                      }
                    });
                    // add(new BarLineOverlayOption() {
                    // {
                    // setType("BarLine");
                    // setDisplay(OverlayDisplay.Front);
                    // setRules(new ArrayList < IRuleOption > ());
                    // }
                    // });
                    // add(new ErrorBarOption() {
                    // {
                    // setType("ErrorBar");
                    // setDisplay(OverlayDisplay.Front);
                    // setRules(new ArrayList < IRuleOption > ());

                    // }
                    // });
                    // add(new ImageOverlayOption() {
                    // {
                    // setType("Image");
                    // setDisplay(OverlayDisplay.Front);
                    // setRules(new ArrayList < IRuleOption > ());

                    // }
                    // });
                    // add(new PathAnnotationOption() {
                    // {
                    // setType("Path");
                    // setDisplay(OverlayDisplay.FrontOfPlot);
                    // setRules(new ArrayList < IRuleOption > ());
                    // }
                    // });
                    // add(new RectangleOverlayOption() {
                    // {
                    // setType("Rectangle");
                    // setDisplay(OverlayDisplay.Back);
                    // setRules(new ArrayList < IRuleOption > ());

                    // }
                    // });
                    // add(new PolynomialTrendlineOverlayOption() {
                    // {
                    // setType("PolynomialTrendline");
                    // setDisplay(com.grapecity.datavisualization.chart.enums.OverlayDisplay.Front);
                    // setRules(new ArrayList < IRuleOption > ());
                    // }
                    // });
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

  public static IDvOption DAT_2722() {
    IDvOption dvOption = new DvOption();

    dvOption.setPlots(new ArrayList<IPlotOption>() {
      {
        add(new PlotOption() {
          {
            setType("Bar");
            setName("Plot1");
            setEncodings(new PlotEncodingsOption() {
              {
                setValues(new ArrayList<IValueEncodingOption>() {
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
                setColor(new ColorEncodingOption() {
                  {
                    setField("SalesBin");
                  }
                });
              }
            });
          }
        });
      }
    });
    dvOption.setTransform(new ArrayList<ITransformOption>() {
      {
        add(new BinTransformOption() {
          {
            setType(TransformType.Bin);
            setBin(new BinOption() {
              {
                setSteps(new ArrayList<java.lang.Double>() {
                  {
                    add(3000.0);
                    add(6000.0);
                    add(9000.0);
                    add(12000.0);
                  }
                });
              }
            });
            setField("Sales");
            setOutputAs("SalesBin");
          }
        });
      }
    });
    return dvOption;
  }

  public static IDvOption DAT_4281() {
    IDvOption dvOption = new DvOption();

    IPlotOption plotOption = new PlotOption();
    plotOption.setType("Bar");

    IPlotEncodingsOption plotEncodingOption = new PlotEncodingsOption();
    plotEncodingOption.setValues(new ArrayList<IValueEncodingOption>() {
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
        setField("Company");
      }
    });
    plotEncodingOption.setColor(new ColorEncodingOption() {
      {
        setField("Company");
      }
    });

    plotOption.setEncodings(plotEncodingOption);
    dvOption.getPlots().add(plotOption);

    IConfigOption configOption = new ConfigOption();
    configOption.setPlotAreas(new ArrayList<IPlotAreaOption>() {
      {
        add(new PlotAreaOption() {
          {
            setPlugins(new ArrayList<IConfigPluginOption>() {
              {
                add(new ConfigPluginOption() {
                  {
                    setName("SjsLegendViewManagerPlugin");
                    setType("LegendViewManagerModel");
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
      }
    });
    dvOption.setConfig(configOption);

    return dvOption;
  }

  private static IDvOption EncodingSankey() {
    IDvOption dvOption = new DvOption();
    dvOption.setPlots(new ArrayList<IPlotOption>() {
      {
        add(new PlotOption() {
          {
            setType("Sankey");
            setEncodings(new PlotEncodingsOption() {
              {
                setValues(new ArrayList<IValueEncodingOption>() {
                  {
                    add(new FieldsValueEncodingOption() {
                      {
                        setField("weight");
                      }
                    });
                  }
                });
                setCategory(new CategoryEncodingOption() {
                  {
                    setField("from,to");
                  }
                });
              }
            });
            setConfig(new SankeyPlotConfigOption() {
              {
                setAxisMode(AxisMode.Cartesian);
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
                    // setPalette(new ArrayList < IPaletteItemOption > ());
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
                            setColor("#blue");
                          }
                        });
                        setStrokeDasharray("3, 3");
                        setStrokeWidth(new StrokeWidthOption() {
                          {
                            setBottom(2.0);
                            setLeft(2.0);
                            setRight(2.0);
                            setTop(2.0);
                          }
                        });
                        setStrokeOpacity(0.5);
                      }
                    });
                    setNodeGap(20.0);
                    setWidth(20);
                    setPadAngle(10);
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

  // HitTest
  public static void DAT_3351(FlexDV dv) {
    // LegendItemLabel
    // Point point = new Point(737, 174);
    // LegendItemSymbol
    // Point point = new Point(730, 174);
    // LegendTitle
    Point point = new Point(747, 151);
    HitTestResult hittestResult = dv.HitTest(point);
    IViewModel dvModel = hittestResult.getModel();
    if (dvModel != null) {
      System.out.println(dvModel.getType());
      IShapeModel shapeModel = (IShapeModel) dvModel.queryInterface("IShapeModel");
      if (shapeModel != null) {
        for (IShape shape : shapeModel.getShapes()) {
          System.out.println(shape.getType());
          System.out.println("----------------------");
          if (shape.getType() == "Line") {
            IPolygonalLineShape lineShape = (IPolygonalLineShape) shape;
            System.out.println(lineShape.getCenter());
            System.out.println(lineShape.getStrokeWidth());
          } else if (shape.getType() == "Rectangle") {
            IRectangleShape rectangleShape = (IRectangleShape) shape;
            System.out.println(rectangleShape.getCenter().getX() + "," + rectangleShape.getCenter().getY());
            System.out.println(rectangleShape.getSize().getWidth() + "," + rectangleShape.getSize().getHeight());
            System.out.println(rectangleShape.getAngle());
          } else if (shape.getType() == "Donut") {
            IDonutShape dountShape = (IDonutShape) shape;
            System.out.println(dountShape.getCenter());
            System.out.println(dountShape.getRadius());
            System.out.println(dountShape.getInnerRadius());
            System.out.println(dountShape.getStartAngle());
            System.out.println(dountShape.getSweepAngle());
          } else if (shape.getType() == "Polygon") {
            IPolygonShape polygonShape = (IPolygonShape) shape;
            System.out.println(polygonShape.getPoints());
          } else if (shape.getType() == "PolygonalLine") {
            IPolygonalLineShape polygonalLineShape = (IPolygonalLineShape) shape;
            System.out.println(polygonalLineShape.getCenter());
            System.out.println(polygonalLineShape.getRadius());
            System.out.println(polygonalLineShape.getAngles());
            System.out.println(polygonalLineShape.getStrokeWidth());
          } else if (shape.getType() == "Arc") {
            IArcShape arcShape = (IArcShape) shape;
            System.out.println(arcShape.getCenter());
            System.out.println(arcShape.getRadius());
            System.out.println(arcShape.getStrokeWidth());
            System.out.println(arcShape.getStartAngle());
            System.out.println(arcShape.getSweepAngle());
          }
        }
      }
    }
  }

  public static void DAT_3361(FlexDV dv) {
    // Axis
    Point point = new Point(70, 204);
    HitTestResult hittestResult = dv.HitTest(point);
    if (hittestResult != null) {
      IViewModel dvModel = hittestResult.getModel();
      if (dvModel != null) {
        System.out.println(dvModel.getType());
        IAxisModel axisModel = (IAxisModel) dvModel.queryInterface("IAxisModel");
        if (axisModel != null) {
          System.out.println(axisModel.getType());
        } else {
          System.out.println("axisModel is Null");
        }
      } else {
        System.out.println("dvModel is Null");
      }
    } else {
      System.out.println("HitTest is Null");
    }
  }

  // Runtime
  public static void DAT_3359(FlexDV dv) {
    IViewModel dvModel = dv.getModel();
    if (dvModel != null) {
      System.out.println(dvModel.getType());
      IFlexDvModel flexDvModel = (IFlexDvModel) dvModel.queryInterface("IFlexDvModel");
      if (flexDvModel != null) {
        System.out.println(flexDvModel.getType());
      }
    }
  }

  // Inject
  public static void DAT_4447(String casePath, Size size, ArrayList<Integer> indexs) {
    String dvJson = readFile(casePath + ".json");
    JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();

    DvOption dvOption = new DvOption(jsonObject);

    CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
    PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);
    PluginCollection customPluginCollection = new PluginCollection();
    CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();
    PluginCollection.defaultPluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, true);

    FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
    dv.paint();

    ArrayList<IPointModel> pts = dv.getModel().getPlotAreas().get(0).getPlotsPanes().get(0).getPlots().get(0).getPoints();
    for(int x = 0; x < indexs.size(); x++){
      setTotal(pts.get(indexs.get(x)));
    }
    dv.paint();

    IRenderEngine renderEngine = dv.getRenderEngine();
    writeFile(renderEngine.toString(), casePath + "_java.svg");
  }

  private static void setTotal(IPointModel point){
    IWaterfallPointModel waterfallPoint = (IWaterfallPointModel) point.queryInterface("IWaterfallPointModel");
    if (waterfallPoint != null) {
      waterfallPoint.setWaterfallType("Total");
    }
  }

  // DAT_3655
  // double kind =
  // dv.getModel().getPlotAreas().get(0).getLegends().get(0).getKind();

  public static IDvOption DAT_4280() throws ParseException {
    IDvOption dvOption = new DvOption();
    SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");

    HashMap<String, Object> dict1 = new HashMap<String, Object>();
    dict1.put("value9", 100);
    dict1.put("label", 44986);
    dict1.put("x", dateFormat.parse("2023/03/01"));
    dict1.put("color9", "Series1");

    HashMap<String, Object> dict2 = new HashMap<String, Object>();
    dict2.put("value9", 150);
    dict2.put("label", 45017);
    dict2.put("x", dateFormat.parse("2023/04/01"));
    dict2.put("color9", "Series1");

    ArrayList<IDataOption> data = new ArrayList<IDataOption>();
    IDataOption dataOption = new DataOption();
    ArrayList<Object> values = new ArrayList<Object>();
    values.add(dict1);
    values.add(dict2);

    dataOption.setValues(values);
    data.add(dataOption);
    dvOption.setData(data);

    IPlotOption plotOption = new PlotOption();
    plotOption.setType("Line");
    plotOption.setName("p1");

    IPlotEncodingsOption plotEncodingOption = new PlotEncodingsOption();

    FieldsValueEncodingOption valueEncodingOpiton = new FieldsValueEncodingOption();
    valueEncodingOpiton.setField("x, value9");
    valueEncodingOpiton.setExcludeNulls(false);
    plotEncodingOption.getValues().add(valueEncodingOpiton);

    // ICategoryEncodingOption categoryEncodingOption = new
    // CategoryEncodingOption();
    // categoryEncodingOption.setExcludeNulls(false);
    // categoryEncodingOption.setOnlySortBeforeGrouping(false);
    // plotEncodingOption.setCategory(categoryEncodingOption);

    IDetailEncodingOption detailEncodingOption = new DetailEncodingOption();
    detailEncodingOption.setGroup(Group.Cluster);
    detailEncodingOption.setField("color9");
    detailEncodingOption.setExcludeNulls(false);
    detailEncodingOption.setOnlySortBeforeGrouping(false);
    plotEncodingOption.getDetails().add(detailEncodingOption);

    IColorEncodingOption colorEncodingOption = new ColorEncodingOption();
    colorEncodingOption.setField("color9");
    plotEncodingOption.setColor(colorEncodingOption);

    plotOption.setEncodings(plotEncodingOption);
    dvOption.getPlots().add(plotOption);

    // IPlotConfigOption plotConfig = new PlotConfigOption();
    // ArrayList<ISeriesStyleOption> styleOptions = new ArrayList<>();
    // ISeriesStyleOption seriesStyleOption = new SeriesStyleOption();
    // seriesStyleOption.setValueField("value9");
    // seriesStyleOption.setSymbols(false);
    // IColorOption stroke = new CssColorOption();
    // stroke.
    // seriesStyleOption.setStroke();
    // styleOptions.add(seriesStyleOption);
    // plotConfig.setSeriesStyles(styleOptions);

    // plotOption.setConfig(plotConfig);
    return dvOption;
  }

  public static IDvOption DAT_4280B() {
    IDvOption dvOption = new DvOption();

    IPlotOption plotOption = new PlotOption();
    plotOption.setType("Line");
    plotOption.setName("p1");

    IPlotEncodingsOption plotEncodingOption = new PlotEncodingsOption();
    plotEncodingOption.setValues(new ArrayList<IValueEncodingOption>() {
      {
        add(new FieldsValueEncodingOption() {
          {
            setField("x, value9");
            setExcludeNulls(false);
          }
        });
      }
    });

    plotEncodingOption.setDetails(new ArrayList<IDetailEncodingOption>() {
      {
        add(new DetailEncodingOption() {
          {
            setField("color9");
            setExcludeNulls(false);
            setOnlySortBeforeGrouping(false);
          }
        });
      }
    });

    plotEncodingOption.setColor(new ColorEncodingOption() {
      {
        setField("color9");
      }
    });

    IPlotConfigOption plotConfigOption = new PlotConfigOption();
    plotConfigOption.setSymbols(true);

    plotOption.setEncodings(plotEncodingOption);
    plotOption.setConfig(plotConfigOption);
    dvOption.getPlots().add(plotOption);

    return dvOption;
  }

  public static IDvOption DAT_3877() {
    IDvOption dvOption = new DvOption();
    dvOption.setPlots(new ArrayList<IPlotOption>() {
      {
        add(new PlotOption() {
          {
            setType("Bar");
            setEncodings(new PlotEncodingsOption() {
              {
                setValues(new ArrayList<IValueEncodingOption>() {
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

  public static void DAT_4483() {
    final IPathCommandBuilder builder = PathCommandBuilder._defaultPathCommandBuilder;

    final ArrayList<IPathCommand> commands = new ArrayList<IPathCommand>();
    ArrayExtension.push(commands, builder._buildMoveToPathCommand(350, 200));
    ArrayExtension.push(commands,
        builder._buildCanvasArcToPathCommand(175, 200, 0, 175, 200, 0, 2 * Math.PI - 0.001, 0));
    ArrayExtension.push(commands, builder._buildClosePathCommand());

    final IPath path = PathBuilder._defaultPathBuilder._buildPath(commands);
    // M 350 200 A 175 200 0 1 1 349.9999125000073 199.80000003333322Z
    System.out.println(path.getExpression());
  }

  private static String readFile(String fileName) {
    StringBuilder sb = new StringBuilder();
    try {
      File file = new File(fileName);
      FileInputStream fis = new FileInputStream(file);
      InputStreamReader isr = new InputStreamReader(fis, "UTF-8");
      BufferedReader reader = new BufferedReader(isr);

      String line;
      while ((line = reader.readLine()) != null) {
        sb.append((line));
      }
      reader.close();
    } catch (IOException e) {
      e.printStackTrace();
    }
    return sb.toString();
  }

  private static void writeFile(String text, String path) {
    try {
      FileOutputStream file = new FileOutputStream(path);
      OutputStreamWriter writer = new OutputStreamWriter(file, "UTF-8");
      writer.write(text);
      writer.close();
    } catch (Exception e) {
      e.printStackTrace();
    }
  }

}
