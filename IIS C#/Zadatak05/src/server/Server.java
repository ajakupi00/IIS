/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package server;

/**
 *
 * @author arjan
 */
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServerConfigImpl;
import org.apache.xmlrpc.webserver.WebServer;

public class Server {
    public static void main(String[] args) throws Exception {
        WebServer server = new WebServer(8080);
        PropertyHandlerMapping handlerMapping = new PropertyHandlerMapping();
        handlerMapping.addHandler("Temperature", TemperatureService.class);
        server.getXmlRpcServer().setHandlerMapping(handlerMapping);
        XmlRpcServerConfigImpl serverConfig = (XmlRpcServerConfigImpl) server.getXmlRpcServer().getConfig();
        serverConfig.setEnabledForExtensions(true);
        serverConfig.setContentLengthOptional(false);
        server.start();
    }
}
