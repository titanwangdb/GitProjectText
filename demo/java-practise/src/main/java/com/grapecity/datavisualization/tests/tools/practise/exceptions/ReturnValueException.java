package com.grapecity.datavisualization.tests.tools.practise.exceptions;

public class ReturnValueException extends RuntimeException {
    public ReturnValueException(String type) {
        super(String.format("The \"{0}\" value return exception.", type));
    }
}