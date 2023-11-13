package com.grapecity.datavisualization.tests.tools.practise;

import java.io.Console;
import java.io.File;
import java.io.IOException;
import java.nio.file.Paths;
import java.util.List;
import java.util.stream.Collectors;

import com.google.gson.JsonElement;
import com.google.gson.JsonParser;

import com.grapecity.datavisualization.tests.tools.practise.builders.ConfigOptionBuilder;
import com.grapecity.datavisualization.tests.tools.practise.exceptions.ConfigFileNotFindException;
import com.grapecity.datavisualization.tests.tools.practise.exceptions.ReturnValueException;
import com.grapecity.datavisualization.tests.tools.practise.models.CallJsModel;
import com.grapecity.datavisualization.tests.tools.practise.models.ConfigOption;
import com.grapecity.datavisualization.tests.tools.practise.models.FileModel;

import picocli.CommandLine.Command;
import picocli.CommandLine.Option;

@Command(name = "Application", version = "Tools 1.0-SNAPSHOT", mixinStandardHelpOptions = true, description = "This is the practise.")
public class PractiseApplication implements Runnable {

    @Option(names = { "-c", "--config" }, description = "the config file with json format")
    private String configFilePath = "./java-call-js/ucgconfig.json";

    @Override
    public void run() {
        ConfigOption configOption = GetConfigInfo(configFilePath);

        System.out.println(configOption.getSource());
        System.out.println(configOption.getTarget());

        System.out.println("End");
    }

    private ConfigOption GetConfigInfo(String configFilePath) {
        File configFile = new File(configFilePath);
        if (!configFile.exists()) {
            throw new ConfigFileNotFindException(configFilePath);
        }
        String json = FileModel.readFile(configFile);
        JsonElement jsonConfig = JsonParser.parseString(json);
        String basePath = FileModel.getDirectoryPath(configFile);
        if (basePath == null) {
            throw new ConfigFileNotFindException(configFile.getParent());
        }
        return new ConfigOptionBuilder().Build(jsonConfig, basePath);
    }

}