package com.grapecity.datavisualization.tests.tools.practise.models;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;

public class CallJsModel {
    public static void CallNodeJs(String jsFile) throws IOException {
        ProcessBuilder pb = new ProcessBuilder("node", jsFile, "123", "abc");
        Process process = pb.start();

        InputStream stdout = process.getInputStream();
        BufferedReader reader = new BufferedReader(new InputStreamReader(stdout));

        String line;
        while ((line = reader.readLine()) != null) {
            System.out.println(line);
        }
    }
}
