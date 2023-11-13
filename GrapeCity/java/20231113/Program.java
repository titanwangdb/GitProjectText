package console;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

import javax.annotation.processing.FilerException;
import javax.sound.sampled.LineListener;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.LineIterator;
import org.apache.commons.io.filefilter.CanWriteFileFilter;

import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.google.gson.stream.JsonReader;
import com.grapecity.datavisualization.chart.component.core.renderEngines.IRenderEngine;
import com.grapecity.datavisualization.chart.core.drawing.Size;
import com.grapecity.datavisualization.chart.enums.AxisMode;
import com.grapecity.datavisualization.chart.enums.Group;
import com.grapecity.datavisualization.chart.enums.ValueOptionType;
import com.grapecity.datavisualization.chart.cartesian.plugins.lightnessLegend.ScatterCartesianLightnessLegendPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.trapezoidLegendView.ScatterCartesianTrapezoidLegendViewPlugin;
import com.grapecity.datavisualization.chart.component.core.FlexDV;
import com.grapecity.datavisualization.chart.component.core._plugin.PluginCollection;
import com.grapecity.datavisualization.chart.options.*;
import com.grapecity.datavisualization.chart.plugins.AutoOrdinalAxisScalePolicyPlugin;
import com.grapecity.datavisualization.chart.plugins.GcesReferenceLineLabelTextStylePolicyPlugin;
import com.grapecity.datavisualization.chart.plugins.lightnessLegendView.LightnessLegendViewPlugin;
import com.grapecity.datavisualization.chart.plugins.swingCoordinateSystem.SwingLineCartesianCoordinateSystemPlugin;

import console.plugins.calcengine.CustomCalculateEnginePlugin;
import console.plugins.image.CustomImageInfoBuilder;
import testcase.dataSource;
import testcase.performance;
import testcase.pluginCase;
import testcase.testcase;
import testcase.pluginCase.pluginType;

import java.io.InputStream;
import java.io.InputStreamReader;

public class Program {
  public static void main(String[] args) throws ParseException, IOException {
    Size size = new Size(800, 400);
    //size = new Size(900, 300);
    String casePath = "D:/temp/DAT/4654/DAT-4500-EmpetArea07";
    // casePath = "D:/temp/DailyCheck/DataBinding_Category";

    // long startTime = System.currentTimeMillis();

    // load json
    // LoadJson(casePath, size);

    // Plugin
    pluginCase.plugin(casePath, size, pluginType.GcesLineCartesian, true);

    // long endTime = System.currentTimeMillis();
    // System.out.printf("Spend Time: %d", (endTime - startTime));

    //IDvOption dvOption = testcase.createOption();
    // IDvOption dvOption = EncodingDemo();
    // dvOption.setData(DATA_3287());
    // dvOption.setData(GetData());
    // dvOption.setData(DATA_3323());
    // dvOption.setData(DATA_3356());
    
    // IDvOption dvOption = EncodingAll02();
    // dvOption.setData(BarChartData01());

    // Encoding
    // String caseSavePath = "D:/temp/DAT/4281/case02";
    // caseSavePath = "D:/temp/DailyCheck/createOption02";
    // // IDvOption dvOption = testcase.DAT_3386();
    // // IDvOption dvOption = testcase.DAT_4281();
    // IDvOption dvOption = testcase.createOption02();
    // // dvOption.setData(dataSource.GetData());
    // Encoding(dvOption, caseSavePath, size);

    // String caseSavePath = "D:/temp/DailyCheck/sankey";
    // IDvOption dvOption = EncodingSankey();
    // dvOption.setData(dataSource.Data_Sankey());
    // Encoding(dvOption, caseSavePath, size);

    // String caseSavePath = "D:/temp/DailyCheck/case01";
    // caseSavePath = "D:/temp/DAT/4280/DAT_4280B";
    // IDvOption dvOption = testcase.DAT_3386();
    // IDvOption dvOption = testcase.DAT_2722();
    // IDvOption dvOption = testcase.DAT_3575();
    // IDvOption dvOption = testcase.DAT_4280();
    // IDvOption dvOption = testcase.DAT_4280B();
    // dvOption.setData(dataSource.DATA_4280B());
    // Encoding(dvOption, caseSavePath, size);

    // NaN (3287|3323|3799)
    // LoadJsonNaN(casePath, size);

    // Data
    // ArrayList<IDataOption> data = dataSource.Aggregate_CountDistinct_Type();
    // LoadJsonData(casePath, size, data);

    // inject
    // ArrayList<Integer> indexs = new ArrayList<Integer>(Arrays.asList(1, 2, 3, 4));
    // testcase.DAT_4447(casePath, size, indexs);

    //
    // testcase.DAT_4483();

    /*
     * performance(DAT-3846)
     * Bar1k|Bar5k|Bar1w|Bar2w|Bar5w
     * Line1k|Line5k|Line1w|Line2w|Line5w
     * Scatter1k|Scatter5k|Scatter1w|Scatter2w|Scatter5w
     * Pie1k|Pie5k|Pie1w|Pie2w|Pie5w
    */
    // String path = "D:/temp/Performance/TestCase/Pie/1k.json";    // 1k|5k|1w|2w|5w
    // performance.DAT_3846(path, size);

    /*
     * performance(DAT-4035)    50|100|500|1000
     * dv.plugins.PluginCollection.defaultPluginCollection.register( dv.plugins.SunburstPlotViewLayoutPlugin._defaultPlugin, true);
    */
    // String path = "D:/temp/Performance/TestCase/DAT-4035/500.json";    // 50|100|500|1000
    // performance.DAT_4035(path, size);

    /*
     * performance(DAT-4036)
     * barInPolarChart50|barInPolarChart100|barInPolarChart500|barInPolarChart1000
     * stackedBarInPolarChart50|stackedBarInPolarChart100|stackedBarInPolarChart500|stackedBarInPolarChart1000
     * radialStackedBarChart50|radialStackedBarChart100|radialStackedBarChart500|radialStackedBarChart1000
     * roseChart50|roseChart100|roseChart500|roseChart1000
     * bubbleChart50|bubbleChart100|bubbleChart500|bubbleChart1000
    */
    // String path = "D:/temp/Performance/TestCase/DAT-4036/bubbleChart1000.json";
    // performance.PerformanceCase(path, size);

    // performance(DAT-4097) funnelChart50|funnelChart100|funnelChart500|funnelChart1000
    // String path = "D:/temp/Performance/TestCase/DAT-4097/funnelChart1000.json";
    // performance.PerformanceCase(path, size);

    // performance(DAT-4101)  roseChart50|roseChart100|roseChart500|roseChart1000|roseChart5000
    // String path = "D:/temp/Performance/TestCase/DAT-4101/roseChart5000.json";
    // performance.PerformanceCase(path, size);

    // DAT-3806
    // String path = "D:/temp/Performance/Data/DAT-3806/DAT-3806.json";
    // performance.PerformanceCase(path, size);

    // String dvJson = readFile(casePath + ".json");
    // JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();
    // DvOption dvOption = new DvOption(jsonObject);
    // demo01(dvOption, size);

    System.out.println("End");
  }

  private static void demo01(IDvOption option, Size size) throws IOException {
    int aa = 1234;
    ProcessBuilder pb = new ProcessBuilder("node", "D:\\practise\\b.js", "aa", "abc");
    // ProcessBuilder pb = new ProcessBuilder("node", "D:\\practise\\b.js", option, size);
    Process process = pb.start();

    InputStream stdout = process.getInputStream();
    BufferedReader reader = new BufferedReader(new InputStreamReader(stdout));

    String line;
    while ((line = reader.readLine()) != null) {
        System.out.println(line);
    }
  }

  private static void LoadJson(String casePath, Size size) {
    // String dvJson = readLargeFile(casePath + ".json");
    String dvJson = readFile(casePath + ".json");
    JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();

    DvOption dvOption = new DvOption(jsonObject);

    // Global plugin sample.
    CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
    PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

    // Instance plugin sample.
    PluginCollection customPluginCollection = new PluginCollection();
    // CustomStringFormattingPlugin customStringFormattingPlugin = new
    // CustomStringFormattingPlugin();
    // customPluginCollection.register(customStringFormattingPlugin);
    //
    CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();

    PluginCollection.defaultPluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, true);

        
    // DAT-2577
    // NullValueTextInfoPolicyPlugin nullValueTextInfoPolicyPlugin = new
    // NullValueTextInfoPolicyPlugin();
    // customPluginCollection.register(nullValueTextInfoPolicyPlugin);
    // DAT-3185
    // ExcelLinearAxisScalePolicyPlugin ExcelLinearAxisScalePolicyPlugin = new
    // ExcelLinearAxisScalePolicyPlugin();
    // customPluginCollection.register(ExcelLinearAxisScalePolicyPlugin);
    //
    // PiePlotLayoutPlugin piePlotLayoutPlugin = new PiePlotLayoutPlugin();
    // customPluginCollection.register(piePlotLayoutPlugin);
    // DAT-3149|3404
    // customPluginCollection.register(new SjsStackBarOverlapPolicyPlugin());
    // customPluginCollection.register(new SjsStackBarOverlapPolicyPlugin(),false);
    // DAT-3420
    // customPluginCollection.register(new SjsGridLineDisplayPolicyPlugin());
    // customPluginCollection.register(new SjsGridLineDisplayPolicyPlugin(), false);
    // DAT-3290
    // customPluginCollection.register(new TrendlineExpressionPlugin());
    // DAT-2777
    // customPluginCollection.register(new CompatibleOverlayDetailKeyPlugin(), true);
    //
    // customPluginCollection.register(new GcesTrendlineExpressionTextStylePolicyPlugin(), true);
    //
    // customPluginCollection.register(new GcesReferenceLineLabelTextStylePolicyPlugin(), true);
    // DAT-3933
    // customPluginCollection.register(new ScatterCartesianTrapezoidLegendViewPlugin(), true);
    // DAT-3945
    // customPluginCollection.register(new ScatterCartesianLightnessLegendPlugin(), true);
    // customPluginCollection.register(new LightnessLegendViewPlugin(), true);

    // DAT-3950
    // customPluginCollection.register(AutoOrdinalAxisScalePolicyPlugin.defaultPlugin, true);

    FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
    dv.paint();

    // DAT-3655
    // double kind = dv.getModel().getPlotAreas().get(0).getLegends().get(0).getKind();

    IRenderEngine renderEngine = dv.getRenderEngine();
    writeFile(renderEngine.toString(), casePath + "_java.svg");
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

  private static String readLargeFile(String fileName) throws IOException {
    File file = new File(fileName);
    StringBuilder sb = new StringBuilder();
    BufferedReader br = new BufferedReader(new FileReader(file));
    char[] cbuf = new char[1000];
    int len;
    while ((len = br.read(cbuf)) != -1) {
      sb.append(cbuf, 0, len);
    }
    br.close();
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

  private static void Encoding(IDvOption dvOption, String casePath, Size size) {
    CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
    PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);
    PluginCollection customPluginCollection = new PluginCollection();
    CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();

    FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
    dv.paint();

    IRenderEngine renderEngine = dv.getRenderEngine();
    writeFile(renderEngine.toString(), casePath + "_java.svg");
  }

  private static void LoadJsonNaN(String casePath, Size size) {
    String dvJson = readFile(casePath + ".json");
    JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();

    DvOption dvOption = new DvOption(jsonObject);

    // 3287|3323|3799
    dvOption.setData(dataSource.DATA_3799());

    CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
    PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

    PluginCollection customPluginCollection = new PluginCollection();

    CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();

    FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
    dv.paint();

    IRenderEngine renderEngine = dv.getRenderEngine();
    writeFile(renderEngine.toString(), casePath + "_java.svg");
  }

  private static void LoadJsonData(String casePath, Size size, ArrayList<IDataOption> data) {
    String dvJson = readFile(casePath + ".json");
    JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();

    DvOption dvOption = new DvOption(jsonObject);

    // 3287|3323|3799
    dvOption.setData(data);

    CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
    PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);

    PluginCollection customPluginCollection = new PluginCollection();

    CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();

    FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
    dv.paint();

    IRenderEngine renderEngine = dv.getRenderEngine();
    writeFile(renderEngine.toString(), casePath + "_java.svg");
  }
}
