using Server.repository;
using Server.server;
using Server.service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Hashtable = System.Collections.Hashtable;

namespace ConcursInot.server
{
    class StartServer
    {
        static void Main(string[] args)
        {
            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 55555;
            TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            ChannelServices.RegisterChannel(channel, false);

            IDictionary<string, string> pr = new SortedList<string, string>();
            pr.Add("ConnectionString", "URI=file:ConcursInot.db");
            OficiuRepository oficiu = new OficiuRepository(pr);
            ParticipantRepository participant = new ParticipantRepository(pr);
            ProbaRepository proba = new ProbaRepository(pr);
            InscriereRepository inscriere = new InscriereRepository(pr);
            Service service = new Service(oficiu, participant, proba, inscriere);

            var server = new ServerImplementation(service);
            RemotingServices.Marshal(server, "Server");

            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServerImplementation), "Server",
            //    WellKnownObjectMode.Singleton);

            Console.WriteLine("Server started ...");
            Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }
    }
}
