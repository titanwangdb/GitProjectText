package com.grapecity.datavisualization.tests.tools.practise.builders;

import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.grapecity.datavisualization.tests.tools.practise.models.ConfigOption;
import com.grapecity.datavisualization.tests.tools.practise.models.FileModel;

public class ConfigOptionBuilder {

    public ConfigOption Build(JsonElement json, String basePath) {
        Gson gson = new Gson();
        ConfigOption option = gson.fromJson(json, ConfigOption.class);
        option.setSource(FileModel.getFullPath(option.getSource(), basePath));
        option.setTarget(FileModel.getFullPath(option.getTarget(), basePath));
        return option;
    }

}
