/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package server;

/**
 *
 * @author arjan
 */
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.net.URL;
public class TemperatureService {

    public double getTemperature(String cityName) throws Exception {
        String url = "https://vrijeme.hr/hrvatska_n.xml";
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        DocumentBuilder db = dbf.newDocumentBuilder();
        Document doc = db.parse(new URL(url).openStream());

        NodeList cityList = doc.getElementsByTagName("Grad");

         for (int i = 0; i < cityList.getLength(); i++) {
            Element city = (Element) cityList.item(i);
            NodeList cityNameList = city.getElementsByTagName("GradIme");
            Element cityNameElement = (Element) cityNameList.item(0);
            String currentCityName = cityNameElement.getTextContent();

            if (currentCityName.equalsIgnoreCase(cityName)) {
                NodeList podatciList = city.getElementsByTagName("Podatci");
                Element podatci = (Element) podatciList.item(0);
                NodeList temperatureList = podatci.getElementsByTagName("Temp");
                Element temperatureElement = (Element) temperatureList.item(0);
                return Double.parseDouble(temperatureElement.getTextContent().trim());
            }
        }
        throw new Exception("City not found");
    }
}