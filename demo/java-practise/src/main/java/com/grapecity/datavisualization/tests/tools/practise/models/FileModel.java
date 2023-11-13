package com.grapecity.datavisualization.tests.tools.practise.models;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.nio.file.Paths;

public class FileModel {

    public static String separator = File.separator.equals("\\") ? File.separator + File.separator : File.separator;

    private static int count = 0;

    public static String readFile(File file) {
        FileModel.count ++ ;
        //System.out.println("Read" + FileUtil.count  + file.getPath());
        //System.out.println(file.getPath());
        StringBuilder sb = new StringBuilder(512);
        try {
            FileInputStream fis = new FileInputStream(file);
            InputStreamReader isr = new InputStreamReader(fis, "UTF-8");
            BufferedReader reader = new BufferedReader(isr);

            String line;
            while ((line = reader.readLine()) != null) {
                sb.append((line));
            }
            reader.close();
        } catch (IOException e) {
            System.out.println("Read" + file.getPath() + "Error!");
            e.printStackTrace();
        }
        return sb.toString();
    }

    public static String getDirectoryPath(File file) {
        return file.toPath().getParent().toString();
    }

    public static String getFullPath(String path, String basePath) {
        String fullPath = null;
        try {
            fullPath = Paths.get(basePath, path).toFile().getCanonicalPath();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return fullPath;
    }

    // public static void writeFile(String content, String filePath) {
    //     try {
    //         File dirPath = new File(filePath);
    //         if (!dirPath.exists()) {
    //             dirPath.getParentFile().mkdirs();
    //         }
    //         Writer myWriter = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(filePath), "UTF-8"));
    //         myWriter.write(content);
    //         myWriter.close();
    //     } catch (IOException e) {
    //         System.out.println("Write" + filePath + "Error!");
    //         e.printStackTrace();
    //     }
    // }

    // public static void deleteFile(String filePath) {
    //     File file = new File(filePath);
    //     if (file.exists()) {
    //         file.delete();
    //     }
    // }

    // public static void deleteDirectory(String directoryPath) {
    //     File directory = new File(directoryPath);
    //     if (directory.isDirectory()) {
    //         File[] files = directory.listFiles();
    //         if (files != null) {
    //             for (File file : files) {
    //                 deleteDirectory(file.getPath());
    //             }
    //         }
    //     }
    //     directory.delete();
    // }

}
