package com.grapecity.datavisualization.tests.tools.practise.exceptions;

public class ConfigFileNotFindException extends RuntimeException {
    public ConfigFileNotFindException(String filePath) {
        super(String.format("The config file '%s' is not found.", filePath));
    }
}