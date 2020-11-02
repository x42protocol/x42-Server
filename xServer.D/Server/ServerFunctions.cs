﻿using System.Collections.Generic;
using System.Linq;
using x42.Controllers.Results;
using x42.Feature.Database.Context;
using x42.Feature.Database.Tables;

namespace x42.Server
{
    public class ServerFunctions
    {
        private string ConnectionString { get; set; }

        /// <summary>The amount of xServers to grab at a time.</summary>
        private readonly int xServerTake = 10;

        public ServerFunctions(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public TopResult GetTopXServers(int top)
        {
            TopResult result = new TopResult();

            using (X42DbContext dbContext = new X42DbContext(ConnectionString))
            {
                IQueryable<ServerNodeData> servers = dbContext.ServerNodes.Where(n => n.Active).OrderByDescending(u => u.Priority);
                if (top > 0)
                {
                    servers = servers.Take(top);
                }

                if (servers.Count() > 0)
                {
                    servers.ToList().ForEach(
                        server => result.XServers.Add(
                            new XServerConnectionInfo()
                            {
                                Name = server.ProfileName,
                                NetworkProtocol = server.NetworkProtocol,
                                NetworkAddress = server.NetworkAddress,
                                NetworkPort = server.NetworkPort,
                                Priotiry = server.Priority,
                                Tier = server.Tier
                            }
                    ));
                }
            }

            return result;
        }

        public int GetActiveServerCount()
        {
            int result = 0;

            using (X42DbContext dbContext = new X42DbContext(ConnectionString))
            {
                result = dbContext.ServerNodes.Where(s => s.Active).Count();
            }

            return result;
        }

        /// <summary>
        ///     Return active xServers available
        /// </summary>
        /// <param name="fromId">The Id to resume from</param>
        /// <returns>Will return active servers from the Id specified.</returns>
        public List<ServerRegisterResult> GetActiveXServers(int fromId)
        {
            List<ServerRegisterResult> result = new List<ServerRegisterResult>();

            using (X42DbContext dbContext = new X42DbContext(ConnectionString))
            {
                IQueryable<ServerNodeData> servers = dbContext.ServerNodes.Where(n => n.Active && n.Id > fromId).Take(xServerTake);
                if (servers.Count() > 0)
                {
                    servers.ToList().ForEach(
                        server => result.Add(
                            new ServerRegisterResult()
                            {
                                Id = server.Id,
                                ProfileName = server.ProfileName,
                                NetworkProtocol = server.NetworkProtocol,
                                NetworkAddress = server.NetworkAddress,
                                NetworkPort = server.NetworkPort,
                                Signature = server.Signature,
                                Tier = server.Tier,
                                FeeAddress = server.FeeAddress,
                                KeyAddress = server.KeyAddress,
                                SignAddress = server.SignAddress
                            }
                    ));
                }
            }

            return result;
        }
    }
}
