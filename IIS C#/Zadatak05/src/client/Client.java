/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package client;

/**
 *
 * @author arjan
 */
import java.net.MalformedURLException;
import org.apache.xmlrpc.client.XmlRpcClient;
import org.apache.xmlrpc.client.XmlRpcClientConfigImpl;

import java.net.URL;
import org.apache.xmlrpc.XmlRpcException;
public class Client {

    public static void main(String[] args) {
        try {
            XmlRpcClientConfigImpl config = new XmlRpcClientConfigImpl();
            config.setServerURL(new URL("http://localhost:8080/xmlrpc"));
            config.setEnabledForExtensions(true);
            config.setConnectionTimeout(60 * 1000);
            config.setReplyTimeout(60 * 1000);

            XmlRpcClient client = new XmlRpcClient();
            client.setConfig(config);

            // Promijenite "Zagreb" u ime grada za koji želite dohvatiti temperaturu
            Object[] params = new Object[]{ "Crikvenica" };
            Double temperature = (Double) client.execute("Temperature.getTemperature", params);

            System.out.println("Trenutna temperatura u Crikvenica je: " + temperature + "°C");
        } catch (MalformedURLException | XmlRpcException e) {
            System.err.println("TemperatureClient: " + e.getMessage());
        }
    }
}