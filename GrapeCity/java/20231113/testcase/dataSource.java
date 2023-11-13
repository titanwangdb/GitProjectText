package testcase;

import java.util.ArrayList;
import java.util.HashMap;

import com.grapecity.datavisualization.chart.component.core.FlexDV;
import com.grapecity.datavisualization.chart.component.core._views.visual.HitTestResult;
import com.grapecity.datavisualization.chart.core.drawing.Point;
import com.grapecity.datavisualization.chart.component.core.models.shapes.IShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.arc.IArcShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.donut.IDonutShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.polygon.IPolygonShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.polygonLine.IPolygonalLineShape;
import com.grapecity.datavisualization.chart.component.core.models.shapes.rectangle.IRectangleShape;
import com.grapecity.datavisualization.chart.component.core.models.viewModels.IViewModel;
import com.grapecity.datavisualization.chart.component.models.shapeModels.IShapeModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.IFlexDvModel;
import com.grapecity.datavisualization.chart.component.models.viewModels.axes.IAxisModel;
import com.grapecity.datavisualization.chart.enums.*;
import com.grapecity.datavisualization.chart.options.*;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;

public class dataSource {

    public static ArrayList < IDataOption > GetData() {
        HashMap < String, Object > dict1 = new HashMap < String, Object > ();
        dict1.put("Company", "IBM");
        dict1.put("Sales", 3545);

        HashMap < String, Object > dict2 = new HashMap < String, Object > ();
        dict2.put("Company", "MS");
        dict2.put("Sales", 6545);

        HashMap < String, Object > dict3 = new HashMap < String, Object > ();
        dict3.put("Company", "MAC");
        dict3.put("Sales", 1545);

        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();

        values.add(dict1);
        values.add(dict2);
        values.add(dict3);

        dataOption.setValues(values);
        data.add(dataOption);

        return data;
      }

    public static ArrayList < IDataOption > GetData01() {
        ArrayList < IDataOption > caseData = new ArrayList < IDataOption > () {
          {
            add(new DataOption() {
              {
                setDateFormats(new ArrayList < java.lang.String > () {
                {
                  add("false");
                }
                });
                setName("App1");
                setValues(new ArrayList < java.lang.Object > () {
                  {
                    add(new HashMap < String, Object > () {
                      {
                        put("Radio_Button", "KrewDashboard");
                        put("Count", 265);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Radio_Button", "KrewData");
                        put("Count", 227);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Radio_Button", "KrewSheet");
                        put("Count", 8);
                      }
                    });
                  }
                });
              }
            });
          }
        };
        return caseData;
    }

    public static ArrayList < IDataOption > BarChartData01() {
        ArrayList < IDataOption > caseData = new ArrayList < IDataOption > () {
          {
            add(new DataOption() {
              {
                setName("sample");
                setValues(new ArrayList < java.lang.Object > () {
                  {
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "US");
                        put("Company", "IBM");
                        put("Date", "2011-02-05T11:23:15.000Z");
                        put("Date2", "2011-02-05T11:23:15.000Z");
                        put("Date3", "2011-02-05T11:23:15.000Z");
                        put("Downloads", 5834);
                        put("Sales", 3545.711769757831);
                        put("numberGroup", 10);
                        put("Sales3", 1111);
                        put("Sales4", 2);
                        put("Sales2", 3545.711769757831);
                        put("Expenses", 2645.3865232777175);
                        put("NewCustomer2", false);
                        put("NewCustomer", true);
                        put("Salesman", "John");
                        put("Detail", null);
                        put("errorField", 1000);
                        put("stringField", "S1");
                        put("booleanField", true);
                        put("emptyField", "");
                        put("DateField", "2011-02-05T11:23:15.000Z");
                        put("numberField", 20);
                        put("errorField2", 1000);
                        put("trellisField", "S100000000000000000000000000000000000000000000000000000000000000S");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "US");
                        put("Company", "MS");
                        put("Date", "2011-03-05T12:20:15.000Z");
                        put("Date2", "2011-02-05T11:23:15.000Z");
                        put("Date3", "2011-03-05T11:23:15.000Z");
                        put("numberGroup", 10);
                        put("Sales2", 3545.711769757831);
                        put("Sales3", 2111);
                        put("Sales4", 122);
                        put("Downloads", 3834);
                        put("Sales", 6545.711769757831);
                        put("Expenses", 3645.3865232777175);
                        put("NewCustomer", false);
                        put("NewCustomer2", true);
                        put("stringField", "S1");
                        put("booleanField", false);
                        put("numberField", 40);
                        put("emptyField", "  XX  ");
                        put("DateField", "2012-02-05T11:23:15.000Z");
                        put("Detail", null);
                        put("errorField", 500);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "US");
                        put("Company", "MAC");
                        put("Date", "2011-04-05T11:23:45.000Z");
                        put("Date2", "2011-02-05T11:23:15.000Z");
                        put("Date3", "2011-03-05T11:23:15.000Z");
                        put("Sales2", 3545.711769757831);
                        put("Sales3", 6111);
                        put("Sales4", 222);
                        put("Downloads", 2834);
                        put("Sales", 1545.111761757831);
                        put("Expenses", 4643.312323277718);
                        put("numberGroup", 20);
                        put("NewCustomer", true);
                        put("NewCustomer2", true);
                        put("booleanField", true);
                        put("DateField", "2013-02-05T11:23:15.000Z");
                        put("Salesman", "Glod");
                        put("Detail", null);
                        put("stringField", "S2");
                        put("numberField", 30);
                        put("errorField", 1500);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "US");
                        put("Company", "MS");
                        put("Date", "2011-05-15T12:22:15.000Z");
                        put("Date2", "2011-02-05T11:23:15.000Z");
                        put("Sales2", 3545.711769757831);
                        put("Downloads", 3834);
                        put("Sales", 6545.711769757831);
                        put("Expenses", 3645.3865232777175);
                        put("NewCustomer", false);
                        put("NewCustomer2", false);
                        put("stringField", "S3");
                        put("DateField", "2014-02-05T11:23:15.000Z");
                        put("booleanField", true);
                        put("numberField", 40);
                        put("Detail", null);
                        put("errorField", 2500);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "CHINA");
                        put("Company", "Alibaba");
                        put("Date", "2013-04-05T12:20:15.000Z");
                        put("Date2", "2013-04-05T12:20:15.000Z");
                        put("Date3", "2011-02-05T11:23:15.000Z");
                        put("Downloads", 18470);
                        put("Sales", 4663.452628406266);
                        put("Sales2", 4663.452628406266);
                        put("Expenses", 3900.295760434449);
                        put("numberGroup", 10);
                        put("NewCustomer", true);
                        put("NewCustomer2", true);
                        put("Salesman", "Peter");
                        put("stringField", null);
                        put("booleanField", null);
                        put("numberField", null);
                        put("emptyField", "X  X");
                        put("DateField", null);
                        put("errorField", -1000);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "CHINA");
                        put("Company", "HuaWei");
                        put("Date", "2012-06-05T12:20:15.000Z");
                        put("Date2", "2013-04-05T12:20:15.000Z");
                        put("Date3", "2011-03-05T11:23:15.000Z");
                        put("Sales2", 4663.452628406266);
                        put("Downloads", 12470);
                        put("Sales", 6663.452628406266);
                        put("Expenses", 5900.295760434449);
                        put("numberGroup", 20);
                        put("NewCustomer", false);
                        put("NewCustomer2", false);
                        put("booleanField", true);
                        put("stringField", "S3!@#$%^&*()_+{}?>中文<:'“”！@#￥%……&*（）——+/\\");
                        put("numberField", 20);
                        put("Salesman", "John");
                        put("DateField", "2011-02-05T11:23:15.000Z");
                        put("errorField", 1000);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "CHINA");
                        put("Company", "GrapeCity");
                        put("Date", "2012-06-25T12:20:15.000Z");
                        put("Date2", "2013-04-05T12:20:15.000Z");
                        put("numberGroup", 30);
                        put("Sales2", 4663.452628406266);
                        put("Downloads", 19470);
                        put("Sales", 3603.452628406266);
                        put("Expenses", 6780.295760434449);
                        put("NewCustomer", true);
                        put("NewCustomer2", true);
                        put("booleanField", false);
                        put("Salesman", "John");
                        put("numberField", null);
                        put("DateField", "2012-02-05T11:23:15.000Z");
                        put("errorField", 500);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "RUSSIA");
                        put("Company", "ABBYY");
                        put("Date", "2013-05-05T12:20:15.000Z");
                        put("Date2", "2013-05-05T12:20:15.000Z");
                        put("Date3", "2011-03-05T11:23:15.000Z");
                        put("Downloads", 3356);
                        put("Sales", 5828.891491163088);
                        put("Sales2", 5828.891491163088);
                        put("numberGroup", 10);
                        put("Expenses", 2571.7099001738097);
                        put("NewCustomer", false);
                        put("NewCustomer2", false);
                        put("Salesman", "John");
                        put("errorField", 500);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "JAPAN");
                        put("Company", "SONY");
                        put("Date", "2014-07-05T12:20:15.000Z");
                        put("Date2", "2014-07-05T12:20:15.000Z");
                        put("Date3", "2011-03-05T11:23:15.000Z");
                        put("Downloads", 27470);
                        put("Sales", 3863.452628406266);
                        put("Sales2", 3863.452628406266);
                        put("Expenses", 3700.295760434449);
                        put("numberGroup", 20);
                        put("NewCustomer", true);
                        put("NewCustomer2", false);
                        put("Salesman", "Peter");
                        put("stringField", "S2");
                        put("numberField", 40);
                        put("booleanField", null);
                        put("DateField", "2013-02-05T11:23:15.000Z");
                        put("emptyField", "  ");
                        put("errorField", 500);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "JAPAN");
                        put("Company", "SOFTBANK");
                        put("Date", "2012-07-05T12:20:15.000Z");
                        put("Date2", "2014-07-05T12:20:15.000Z");
                        put("Date3", "2011-02-05T11:23:15.000Z");
                        put("Sales2", 3863.452628406266);
                        put("Downloads", 17470);
                        put("Sales", 2863.452628406266);
                        put("Expenses", 5700.295760434449);
                        put("numberGroup", 10);
                        put("NewCustomer", false);
                        put("NewCustomer2", false);
                        put("booleanField", true);
                        put("numberField", 60);
                        put("emptyField", "");
                        put("DateField", "2013-02-05T11:23:15.000Z");
                        put("Salesman", "Peter");
                        put("errorField", 1500);
                      }
                    });
                  }
                });
              }
            });
          }
        };
        return caseData;
    }

    public static ArrayList < IDataOption > Data_Done() {
        ArrayList < IDataOption > caseData = new ArrayList < IDataOption > () {
          {
            add(new DataOption() {
              {
                setName("sample");
                setValues(new ArrayList < java.lang.Object > () {
                  {
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "US");
                        put("Date", "2011-02-05T11:23:15.000Z");
                        put("Downloads", 5834);
                        put("Sales", 3545.711769757831);
                        put("NewCustomer", false);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "CHINA");
                        put("Date", "2011-02-06T11:23:15.000Z");
                        put("Downloads", 5834);
                        put("Sales", 4545.711769757831);
                        put("NewCustomer", false);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "RUSSIA");
                        put("Date", "2011-02-07T11:23:15.000Z");
                        put("Downloads", 5834);
                        put("Sales", 2545.711769757831);
                        put("NewCustomer", false);
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("Country", "JAPAN");
                        put("Date", "2011-02-08T11:23:15.000Z");
                        put("Downloads", 5834);
                        put("Sales", 1545.711769757831);
                        put("NewCustomer", false);
                      }
                    });
                  }
                });
              }
            });
          }
        };
        return caseData;
      }
    
    public static ArrayList < IDataOption > DATA_3356() {
        HashMap < String, Object > dict1 = new HashMap < String, Object > ();
        dict1.put("Country", "US");
        dict1.put("Sales", 3545.711769757831);
        dict1.put("Expenses", 5834);
        dict1.put("Date", new com.grapecity.datavisualization.chart.typescript.Date(2011, 02, 05, 12, 23, 15));
      
        HashMap < String, Object > dict2 = new HashMap < String, Object > ();
        dict2.put("Country", "RUSSIA");
        dict2.put("Sales", 6545.711769757831);
        dict2.put("Expenses", 3834);
        dict2.put("Date", new com.grapecity.datavisualization.chart.typescript.Date(2011, 03, 05, 12, 20, 15));
      
        HashMap < String, Object > dict3 = new HashMap < String, Object > ();
        dict3.put("Country", "JAPAN");
        dict3.put("Sales", 4663.452628406266);
        dict3.put("Expenses", 18470);
        dict3.put("Date", new com.grapecity.datavisualization.chart.typescript.Date(2013, 05, 05, 12, 23, 15));
      
        HashMap < String, Object > dict4 = new HashMap < String, Object > ();
        dict4.put("Country", "CHINA");
        dict4.put("Sales", 6663.452628406266);
        dict4.put("Expenses", 12470);
        dict4.put("Date", new com.grapecity.datavisualization.chart.typescript.Date(2012, 06, 05, 12, 20, 15));
      
        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();
      
        values.add(dict1);
        values.add(dict2);
        values.add(dict3);
        values.add(dict4);
      
        dataOption.setValues(values);
        data.add(dataOption);
        return data;
    }

    // NaN
    public static ArrayList < IDataOption > DATA_3287() {
        ArrayList < IDataOption > caseData = new ArrayList < IDataOption > () {
          {
            add(new DataOption() {
              {
                setDateFormats(new ArrayList < java.lang.String > () {
                {
                  add("false");
                }
                });
                setName("2");
                setValues(new ArrayList < java.lang.Object > () {
                  {
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 10);
                        put("x", "A");
                        put("color2", "S1");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 51);
                        put("x", "B");
                        put("color2", "S1");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", Double.NaN);
                        put("x", "C");
                        put("color2", "S1");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 37);
                        put("x", "D");
                        put("color2", "S1");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 23);
                        put("x", "E");
                        put("color2", "S1");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 25);
                        put("x", "A");
                        put("color2", "S2");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 36);
                        put("x", "B");
                        put("color2", "S2");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 85);
                        put("x", "C");
                        put("color2", "S2");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 65);
                        put("x", "D");
                        put("color2", "S2");
                      }
                    });
                    add(new HashMap < String, Object > () {
                      {
                        put("value2", 69);
                        put("x", "E");
                        put("color2", "S2");
                      }
                    });
                  }
                });
              }
            });
          }
        };
        return caseData;
    }

    public static ArrayList < IDataOption > DATA_3323() {
        HashMap < String, Object > dict1 = new HashMap < String, Object > ();
        dict1.put("country", "US");
        dict1.put("sales", Double.NaN);
        dict1.put("active", "false");
      
        HashMap < String, Object > dict2 = new HashMap < String, Object > ();
        dict2.put("country", "Germany");
        dict2.put("active", "false");
      
        HashMap < String, Object > dict3 = new HashMap < String, Object > ();
        dict3.put("country", "UK");
        dict3.put("sales", 9627.725374596032);
        dict3.put("active", "false");
      
        HashMap < String, Object > dict4 = new HashMap < String, Object > ();
        dict4.put("country", "Japan");
        dict4.put("sales", 4531.63710148669);
        dict4.put("active", "false");
      
        HashMap < String, Object > dict5 = new HashMap < String, Object > ();
        dict5.put("country", "Italy");
        dict5.put("sales", 9927.989879079592);
        dict5.put("active", "false");
      
        HashMap < String, Object > dict6 = new HashMap < String, Object > ();
        dict6.put("country", "Greece");
        dict6.put("sales", 526.8966243795559);
        dict6.put("active", "false");
      
        HashMap < String, Object > dict7 = new HashMap < String, Object > ();
        dict7.put("country", "US");
        dict7.put("sales", 9142.080421541787);
        dict7.put("active", "true");
      
        HashMap < String, Object > dict8 = new HashMap < String, Object > ();
        dict8.put("country", "Germany");
        dict8.put("sales", 9780.104103590214);
        dict8.put("active", "true");
      
        HashMap < String, Object > dict9 = new HashMap < String, Object > ();
        dict9.put("country", "UK");
        dict9.put("sales", 4831.725374596032);
        dict9.put("active", "true");
      
        HashMap < String, Object > dict10 = new HashMap < String, Object > ();
        dict10.put("country", "Japan");
        dict10.put("sales", 6740.63710148669);
        dict10.put("active", "true");
      
        HashMap < String, Object > dict11 = new HashMap < String, Object > ();
        dict11.put("country", "Italy");
        dict11.put("sales", 4287.989879079592);
        dict11.put("active", "true");
      
        HashMap < String, Object > dict12 = new HashMap < String, Object > ();
        dict12.put("country", "Greece");
        dict12.put("sales", 4202.8966243795559);
        dict12.put("active", "true");
      
        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();
      
        values.add(dict1);
        values.add(dict2);
        values.add(dict3);
        values.add(dict4);
        values.add(dict5);
        values.add(dict6);
        values.add(dict7);
        values.add(dict8);
        values.add(dict9);
        values.add(dict10);
        values.add(dict11);
        values.add(dict12);
      
        dataOption.setValues(values);
        data.add(dataOption);
        return data;
    }

    public static ArrayList < IDataOption > DATA_3799() {
        HashMap < String, Object > dict1 = new HashMap < String, Object > ();
        dict1.put("from", "A1");
        dict1.put("to", "B2");
        dict1.put("weight", Double.NaN);
          
        HashMap < String, Object > dict2 = new HashMap < String, Object > ();
        dict2.put("from", "A4");
        dict2.put("to", "B2");
        dict2.put("weight", Double.NaN);
      
        HashMap < String, Object > dict3 = new HashMap < String, Object > ();
        dict3.put("from", "A1");
        dict3.put("to", "B1");
        dict3.put("weight", 10);
        
        HashMap < String, Object > dict4 = new HashMap < String, Object > ();
        dict4.put("from", "A5");
        dict4.put("to", "B1");
        
        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();
      
        values.add(dict1);
        values.add(dict2);
        values.add(dict3);
        values.add(dict4);
      
        dataOption.setValues(values);
        data.add(dataOption);
        return data;
    }
    
    // Data
    public static ArrayList < IDataOption > Aggregate_CountDistinct_Type() {
        HashMap < String, Object > dict1 = new HashMap < String, Object > ();
        dict1.put("category", "A1");
        dict1.put("value", 10.01);
          
        HashMap < String, Object > dict2 = new HashMap < String, Object > ();
        dict2.put("category", "A1");
        dict2.put("value", 10);
      
        HashMap < String, Object > dict3 = new HashMap < String, Object > ();
        dict3.put("category", "A2");
        dict3.put("value", 10);
        
        HashMap < String, Object > dict4 = new HashMap < String, Object > ();
        dict4.put("category", "A2");
        dict4.put("value", 10.0);

        HashMap < String, Object > dict5 = new HashMap < String, Object > ();
        dict5.put("category", "A3");
        dict5.put("value", 1e10);
          
        HashMap < String, Object > dict6 = new HashMap < String, Object > ();
        dict6.put("category", "A3");
        dict6.put("value", 10000000000L);
      
        HashMap < String, Object > dict7 = new HashMap < String, Object > ();
        dict7.put("category", "A4");
        dict7.put("value", 2e10);
        
        HashMap < String, Object > dict8 = new HashMap < String, Object > ();
        dict8.put("category", "A4");
        dict8.put("value", 10000000000F);
        
        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();
      
        values.add(dict1);
        values.add(dict2);
        values.add(dict3);
        values.add(dict4);
        values.add(dict5);
        values.add(dict6);
        values.add(dict7);
        values.add(dict8);
      
        dataOption.setValues(values);
        data.add(dataOption);
        return data;
    }


    public static ArrayList < IDataOption > DATA_3386() {
        HashMap < String,
        Object > dict1 = new HashMap < String,
        Object > ();
        dict1.put("Fields!quantity.Value\u002B25", 92);
        dict1.put("Fields!quantity.Value\u002B10", 415);
        dict1.put("quantity", 59);
        dict1.put("Fields!quantity.Value-20", 340);
      
        HashMap < String,
        Object > dict2 = new HashMap < String,
        Object > ();
        dict2.put("Fields!quantity.Value\u002B25", 60);
        dict2.put("Fields!quantity.Value\u002B10", 365);
        dict2.put("quantity", 30);
        dict2.put("Fields!quantity.Value-20", 255);
      
        HashMap < String,
        Object > dict3 = new HashMap < String,
        Object > ();
        dict3.put("Fields!quantity.Value\u002B25", 42);
        dict3.put("Fields!quantity.Value\u002B10", 325);
        dict3.put("quantity", 38);
        dict3.put("Fields!quantity.Value-20", 350);
      
        HashMap < String,
        Object > dict4 = new HashMap < String,
        Object > ();
        dict4.put("Fields!quantity.Value\u002B25", 25);
        dict4.put("Fields!quantity.Value\u002B10", 25);
        dict4.put("quantity", 7);
        dict4.put("Fields!quantity.Value-20", 445);
      
        ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
        IDataOption dataOption = new DataOption();
        ArrayList < Object > values = new ArrayList < Object > ();
      
        values.add(dict1);
        values.add(dict2);
        values.add(dict3);
        values.add(dict4);
      
        dataOption.setValues(values);
        data.add(dataOption);
        return data;
    }

    public static ArrayList < IDataOption > Data_Sankey() {
      HashMap < String,
      Object > dict1 = new HashMap < String,
      Object > ();
      dict1.put("from", "Coal");
      dict1.put("to", "Heating");
      dict1.put("weight", 5);
    
      HashMap < String,
      Object > dict2 = new HashMap < String,
      Object > ();
      dict2.put("from", "Coal");
      dict2.put("to", "Electricity");
      dict2.put("weight", 3);
    
      HashMap < String,
      Object > dict3 = new HashMap < String,
      Object > ();
      dict3.put("from", "Coal");
      dict3.put("to", "Reserves");
      dict3.put("weight", 8);
    
      HashMap < String,
      Object > dict4 = new HashMap < String,
      Object > ();
      dict4.put("from", "Natural Gas");
      dict4.put("to", "Electricity");
      dict4.put("weight", 3);
  
      HashMap < String,
      Object > dict5 = new HashMap < String,
      Object > ();
      dict5.put("from", "Natural Gas");
      dict5.put("to", "Heating");
      dict5.put("weight", 1);
    
      HashMap < String,
      Object > dict6 = new HashMap < String,
      Object > ();
      dict6.put("from", "Natural Gas");
      dict6.put("to", "Reserves");
      dict6.put("weight", 2);
    
      HashMap < String,
      Object > dict7 = new HashMap < String,
      Object > ();
      dict7.put("from", "Electricity");
      dict7.put("to", "Import");
      dict7.put("weight", 8);
    
      HashMap < String,
      Object > dict8 = new HashMap < String,
      Object > ();
      dict8.put("from", "Electricity");
      dict8.put("to", "Coal Exports");
      dict8.put("weight", 3);
  
      HashMap < String,
      Object > dict9 = new HashMap < String,
      Object > ();
      dict9.put("from", "Electricity");
      dict9.put("to", "Reserves");
      dict9.put("weight", 1);
    
      HashMap < String,
      Object > dict10 = new HashMap < String,
      Object > ();
      dict10.put("from", "Electricity");
      dict10.put("to", "Lighting");
      dict10.put("weight", 2);
    
      ArrayList < IDataOption > data = new ArrayList < IDataOption > ();
      IDataOption dataOption = new DataOption();
      ArrayList < Object > values = new ArrayList < Object > ();
    
      values.add(dict1);
      values.add(dict2);
      values.add(dict3);
      values.add(dict4);
      values.add(dict5);
      values.add(dict6);
      values.add(dict7);
      values.add(dict8);
      values.add(dict9);
      values.add(dict10);
  
      dataOption.setValues(values);
      data.add(dataOption);
      return data;
    }

    public static ArrayList < IDataOption > DATA_4280B() throws ParseException {
      SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");

      HashMap<String, Object> dict1 = new HashMap<String, Object>();
      dict1.put("value9", 100);
      dict1.put("label", 44986);
      dict1.put("x", dateFormat.parse("2023/03/01"));
      dict1.put("color9", "Series1");

      HashMap<String, Object> dict2 = new HashMap<String, Object>();
      dict2.put("value9", 150);
      dict2.put("label", 45017);
      dict2.put("x", dateFormat.parse("2023/04/01"));
      dict2.put("color9", "Series1");

      ArrayList<IDataOption> data = new ArrayList<IDataOption>();
      IDataOption dataOption = new DataOption();
      ArrayList<Object> values = new ArrayList<Object>();
      values.add(dict1);
      values.add(dict2);

      dataOption.setValues(values);
      data.add(dataOption);

      return data;
    }

    public static ArrayList < IDataOption > DATA_4280() {
      ArrayList < IDataOption > caseData = new ArrayList < IDataOption > () {
        {
          add(new DataOption() {
            {
              setDateFormats(new ArrayList < java.lang.String > () {
              {
                add("yyyy/MM/dd");
              }
              });
              setName("2");
              setValues(new ArrayList < java.lang.Object > () {
                {
                  add(new HashMap < String, Object > () {
                    {
                      put("value9", 100);
                      put("label", 44986);
                      put("x", "2023/03/01");
                      put("color9", "Series1");
                    }
                  });
                  add(new HashMap < String, Object > () {
                    {
                      put("value9", 150);
                      put("label", 45017);
                      put("x", "2023/04/01");
                      put("color9", "Series1");
                    }
                  });
                }
              });
            }
          });
        }
      };
      return caseData;
  }

}
