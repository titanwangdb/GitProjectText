package com.grapecity.datavisualization.tests.tools.practise;

import picocli.CommandLine;

import org.apache.logging.log4j.Logger;
import org.apache.logging.log4j.LogManager;

public class Program {

    private static final Logger LOGGER = LogManager.getLogger(Program.class);

    public static void main(String[] args) {
        System.out.println("GrapeCity (R) Data Visualization practise.");
        System.out.println("Copyright (C) GrapeCity Corporation. All rights reserved.");
        System.out.println();
        
        PractiseApplication application = new PractiseApplication();

        try {
            System.out.println("Start practise...");
            System.exit(new CommandLine(application).execute(args));
            System.out.println("End practise...");
        } catch (Exception e) {
            LOGGER.error(e.getMessage());
            System.exit(1);
        }
    }
}
