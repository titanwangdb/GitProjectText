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

import com.grapecity.datavisualization.chart.core.drawing.Size;
import com.grapecity.datavisualization.chart.hierarchical.plugins.sunburstPlot.views.plot.layout.SunburstPlotViewLayoutPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.coordinateSystemLayout.LineCartesianCoordinateSystemLayoutPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.coordinateSystemLayout.MirrorLineCartesianCoordinateSystemLayoutPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.coordinateSystemLayout.RadialCartesianCoordinateSystemLayoutPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.dataLabels.echartsSmartDataLabelOverlay.GcesRadialPlotSmartDataLabelPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.lightnessLegend.ScatterCartesianLightnessLegendPlugin;
import com.grapecity.datavisualization.chart.cartesian.plugins.trapezoidLegendView.ScatterCartesianTrapezoidLegendViewPlugin;
import com.grapecity.datavisualization.chart.component.core.FlexDV;
import com.grapecity.datavisualization.chart.component.core._plugin.PluginCollection;
import com.grapecity.datavisualization.chart.component.core.renderEngines.IRenderEngine;
import com.grapecity.datavisualization.chart.options.*;
import com.grapecity.datavisualization.chart.plugins.AutoOrdinalAxisScalePolicyPlugin;
import com.grapecity.datavisualization.chart.plugins.cartesianAxesCommonScale.CartesianAxesCommonScalePlugin;
import com.grapecity.datavisualization.chart.plugins.gcesLineCartesianCoordinateSystemLayout.GcesLineCartesianCoordinateSystemLayoutPlugin;
import com.grapecity.datavisualization.chart.plugins.lightnessLegendView.LightnessLegendViewPlugin;
import com.grapecity.datavisualization.chart.plugins.multiRowTickLabel.MultiRowTickLabelLayoutPlugin;
import com.grapecity.datavisualization.chart.plugins.overlayDetailKeyPolicy.CompatibleOverlayDetailKeyPlugin;
import com.grapecity.datavisualization.chart.plugins.sjsLegendViewManager.SjsLegendViewManagerPlugin;
import com.grapecity.datavisualization.chart.plugins.sjsWaterfallOverlay.ExcelWaterfallOverlayPlugin;
import com.grapecity.datavisualization.chart.plugins.swingCoordinateSystem.SwingLineCartesianCoordinateSystemLayoutPlugin;
import com.grapecity.datavisualization.chart.plugins.swingCoordinateSystem.SwingLineCartesianCoordinateSystemPlugin;
import com.grapecity.datavisualization.chart.plugins.viewRender.PictorialBarCartesianPointViewRenderPlugin;

import console.plugins.calcengine.CustomCalculateEnginePlugin;
import console.plugins.image.CustomImageInfoBuilder;
import console.plugins.stringformatting.CustomStringFormattingPlugin;

public class pluginCase {

    public enum pluginType {
        CommonScale,                                // DAT-4416
        CustomStringFormattingPlugin,
        ScatterCartesianTrapezoidLegendViewPlugin,  // DAT-3933
        ScatterCartesianLightnessLegendPlugin,      // DAT-3945
        GcesRadialPlotSmartDataLabel,               // DAT-4024
        RadialCartesianCoordinateSystemLayoutPlugin,    // DAT-4098
        SunburstPlotViewLayout,                     // DAT-4099
        AutoOrdinalAxisScalePolicyPlugin,           // DAT-3950
        SwingCoordinateSystem,                      // DAT-4063
        LineCartesian,                              // DAT-4039
        MirrorLineCartesian,
        SwingLineCartesian,
        PictorialBarCartesianPointViewRender,
        SjsLegendViewManagerPlugin,
        SjsWaterfall,                               // DAT-4447
        OverlayDetailKey,
        GcesLineCartesian,                          // DAT-4443
        MultiRowTickLabelLayoutPlugin;
    }

    public static void plugin(String path, Size size, pluginType pluginType, boolean flag) {
        String dvJson = readFile(path + ".json");
        JsonObject jsonObject = JsonParser.parseString(dvJson).getAsJsonObject();

        DvOption dvOption = new DvOption(jsonObject);

        // Global plugin sample.
        CustomCalculateEnginePlugin customCalculateEnginePlugin = new CustomCalculateEnginePlugin();
        PluginCollection.defaultPluginCollection.register(customCalculateEnginePlugin);
                
        // Instance plugin sample.
        PluginCollection customPluginCollection = new PluginCollection();
        //
        CustomImageInfoBuilder customImageInfoBuilder = new CustomImageInfoBuilder();

        // PluginCollection.defaultPluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, true);
        // PluginCollection.defaultPluginCollection.register(SwingLineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, true);

        pluginRegister(customPluginCollection, pluginType, flag);

        FlexDV dv = new FlexDV(dvOption, size, null, customPluginCollection, customImageInfoBuilder);
        dv.paint();
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

    private static void pluginRegister(PluginCollection pluginCollection, pluginType pluginType, boolean flag) {
        switch (pluginType) {
            case CommonScale:
                pluginCollection.register(new CartesianAxesCommonScalePlugin(), flag);
                break;
            case CustomStringFormattingPlugin:
                pluginCollection.register(new CustomStringFormattingPlugin(), flag);
                break;
            case ScatterCartesianTrapezoidLegendViewPlugin:             // DAT-3933
                pluginCollection.register(new ScatterCartesianTrapezoidLegendViewPlugin(), flag);
                break;
            case ScatterCartesianLightnessLegendPlugin:                 // DAT-3945
                pluginCollection.register(new ScatterCartesianLightnessLegendPlugin(), flag);
                pluginCollection.register(new LightnessLegendViewPlugin(), flag);
                break;
            case AutoOrdinalAxisScalePolicyPlugin:                      // DAT-3950
                pluginCollection.register(AutoOrdinalAxisScalePolicyPlugin.defaultPlugin, flag);
                break;
            case GcesRadialPlotSmartDataLabel:                          // DAT-4024
                pluginCollection.register(new GcesRadialPlotSmartDataLabelPlugin(), flag);
                break;
            case RadialCartesianCoordinateSystemLayoutPlugin:           // DAT-4098
                pluginCollection.register(RadialCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
                break;
            case SunburstPlotViewLayout:                                // DAT-4099
                pluginCollection.register(SunburstPlotViewLayoutPlugin._defaultPlugin, flag);
                break;
            case SjsLegendViewManagerPlugin:
                pluginCollection.register(new SjsLegendViewManagerPlugin(), flag);
                break;
            case SwingCoordinateSystem:                                 // DAT-4063
                pluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, flag);
                break;
            case LineCartesian:                                         // 4039
                pluginCollection.register(LineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
                break;
            case MirrorLineCartesian:
                pluginCollection.register(MirrorLineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
                break;
            case SwingLineCartesian:
                pluginCollection.register(SwingLineCartesianCoordinateSystemPlugin.defaultPlugin, flag);
                pluginCollection.register(SwingLineCartesianCoordinateSystemLayoutPlugin._defaultPlugin, flag);
                break;
            // case Gauge:
            //     pluginCollection.register(new TrellisRadialCartesianCoordinateSystemLayoutPlugin(), flag);
            // break;
            case PictorialBarCartesianPointViewRender:
                pluginCollection.register(new PictorialBarCartesianPointViewRenderPlugin(), flag);
                break;
            case MultiRowTickLabelLayoutPlugin:
                pluginCollection.register(new MultiRowTickLabelLayoutPlugin(), flag);
                break;
            case SjsWaterfall:
                pluginCollection.register(new ExcelWaterfallOverlayPlugin(), flag);
                break;
            case OverlayDetailKey:
                pluginCollection.register(new CompatibleOverlayDetailKeyPlugin(), flag);
                break;
            case GcesLineCartesian:
                pluginCollection.register(new GcesLineCartesianCoordinateSystemLayoutPlugin(), flag);
                break;
            default:
                break;
        }
    }
}
