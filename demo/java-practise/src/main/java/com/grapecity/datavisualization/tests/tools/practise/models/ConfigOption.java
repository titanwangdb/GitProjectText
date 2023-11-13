package com.grapecity.datavisualization.tests.tools.practise.models;

public class ConfigOption {
    private String source;
    private String target;

    public ConfigOption() {
        this.source = "../source";
        this.target = "../target";
    }

    public String getSource() {
        return this.source;
    }

    public String getTarget() {
        return this.target;
    }

    public void setSource(String value) {
        this.source = value;
    }

    public void setTarget(String value) {
        this.target = value;
    }

}
