package testcase;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

import com.google.gson.JsonObject;
import com.google.gson.JsonParser;

import com.grapecity.datavisualization.chart.component.core.renderEngines.IRenderEngine;
import com.grapecity.datavisualization.chart.core.drawing.Size;
import com.grapecity.datavisualization.chart.hierarchical.plugins.sunburstPlot.views.plot.layout.SunburstPlotViewLayoutPlugin;
import com.grapecity.datavisualization.chart.component.core.FlexDV;
import com.grapecity.datavisualization.chart.component.core._plugin.PluginCollection;
import com.grapecity.datavisualization.chart.options.*;
import com.grapecity.datavisualization.chart.plugins.AutoOrdinalAxisScalePolicyPlugin;

import console.plugins.calcengine.CustomCalculateEnginePlugin;
import console.plugins.image.CustomImageInfoBuilder;

public class performance {

    public static void DAT_3846(String path, Size size) {
        String plot = getPlot(path);
        String type = getType(path);

        System.out.println("The " + plot + " chart data points " + type + ": ");

        long startTime = System.currentTimeMillis();

        long startReadFile = System.currentTimeMillis();

        String dvJson = readFile(path);
        JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();

        long endReadFile = System.currentTimeMillis();
        System.out.printf("Read File Spend: %d ms", (endReadFile - startReadFile));
        System.out.println("");

        DvOption dvOption = new DvOption(jsonObject);

        // Global plugin sample.
        CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
        PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);
        // Instance plugin sample.
        PluginCollection customPluginCollection = new PluginCollection();
        //
        CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();

        // DAT-3876
        //customPluginCollection.register(RadialCartesianCoordinateSystemLayoutPlugin._defaultPlugin, true);

        // DAT-3950
        customPluginCollection.register(AutoOrdinalAxisScalePolicyPlugin.defaultPlugin, true);

        FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);

        long startDvPaint = System.currentTimeMillis();

        dv.paint();

        long endDvPaint = System.currentTimeMillis();
        System.out.printf("DV Paint Spend: %d ms", (endDvPaint - startDvPaint));
        System.out.println("");

        IRenderEngine renderEngine = dv.getRenderEngine();
        writeFile(renderEngine.toString(), path + "_java.svg");

        long endTime = System.currentTimeMillis();
        System.out.printf("Summary Spend: %d ms", (endTime - startTime));
        System.out.println("");
        System.out.println("The " + plot + " chart data points " + type + " end");
    }

    public static void DAT_4035(String path, Size size) {
        String type = getType(path);

        System.out.println("The data points " + type + ": ");

        long startReadFile = System.currentTimeMillis();
        String dvJson = readFile(path);
        JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();
        long endReadFile = System.currentTimeMillis();
        System.out.printf("Read File Spend: %d ms", (endReadFile - startReadFile));
        System.out.println("");

        long startDvPaint = System.currentTimeMillis();
        DvOption dvOption = new DvOption(jsonObject);
        // Global plugin sample.
        CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
        PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);
        // Instance plugin sample.
        PluginCollection customPluginCollection = new PluginCollection();
        //
        CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();
        // DAT-4035
        customPluginCollection.register(SunburstPlotViewLayoutPlugin._defaultPlugin, true);
        FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
        dv.paint();
        long endDvPaint = System.currentTimeMillis();
        System.out.printf("DV Paint Spend: %d ms", (endDvPaint - startDvPaint));
        System.out.println("");

        IRenderEngine renderEngine = dv.getRenderEngine();
        writeFile(renderEngine.toString(), path + "_java.svg");
    }

    public static void PerformanceCase(String path, Size size) {
        String type = getType(path);

        System.out.println("The data points " + type + ": ");

        long startReadFile = System.currentTimeMillis();
        String dvJson = readFile(path);
        JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();
        long endReadFile = System.currentTimeMillis();
        System.out.printf("Read Json File Spend: %d ms", (endReadFile - startReadFile));
        System.out.println("");

        long startDvPaint = System.currentTimeMillis();
        DvOption dvOption = new DvOption(jsonObject);
        // Global plugin sample.
        CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
        PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);
        // Instance plugin sample.
        PluginCollection customPluginCollection = new PluginCollection();
        //
        CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();
        FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
        dv.paint();
        long endDvPaint = System.currentTimeMillis();
        System.out.printf("SVG Paint Spend: %d ms", (endDvPaint - startDvPaint));
        System.out.println("");

        IRenderEngine renderEngine = dv.getRenderEngine();
        writeFile(renderEngine.toString(), path + "_java.svg");
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

    private static String getPlot(String plot) {
        if (plot.contains("Bar")) {
            return "Bar";
        } else if (plot.contains("Line")) {
            return "Line";
        } else if (plot.contains("Scatter")) {
            return "Scatter";
        } else if (plot.contains("Pie")) {
            return "Pie";
        } else {
            return "";
        }
    }

    private static String getType(String plot) {
        if (plot.contains("1k")) {
            return "1k";
        } else if (plot.contains("5k")) {
            return "5k";
        } else if (plot.contains("1w")) {
            return "1w";
        } else if (plot.contains("2w")) {
            return "2w";
        } else if (plot.contains("5w")) {
            return "5w";
        } else if (plot.contains("5000")) {
            return "5000";
        } else if (plot.contains("500")) {
            return "500";
        } else if (plot.contains("1000")) {
            return "1000";
        } else if (plot.contains("50")) {
            return "50";
        } else if (plot.contains("100")) {
            return "100";
        }  else {
            return "";
        }
    }
}
