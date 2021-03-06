﻿using System.Collections.Generic;
using System.Linq;
using NBitcoin;

namespace x42.ServerNode
{
    public class X42TestServerNode : ServerNodeBase
    {
        /// <summary> The default name used for the x42 server configuration file. </summary>
        public const string x42DefaultConfigFilename = "xServer.conf";

        public X42TestServerNode()
        {
            Name = "x42 Test xServer";
            DefaultPort = 4243;
            DefaultNodeAPIPort = 42221;
            DefaultNodePort = 62342;
            DefaultConfigFilename = x42DefaultConfigFilename;

            List<Tier> Tiers = new List<Tier>
            {
                new Tier(
                    Tier.TierLevel.One,
                    new Collateral {Amount = Money.Coins(1000)}
                ),
                new Tier(
                    Tier.TierLevel.Two,
                    new Collateral {Amount = Money.Coins(20000)}
                ),
                new Tier(
                    Tier.TierLevel.Three,
                    new Collateral {Amount = Money.Coins(50000)}
                )
            };
            this.Tiers = Tiers;

            DowntimeGracePeriod = 90;
            BlockGracePeriod = 6;

            string[] seedServers = { "63.32.82.169" };
            SeedServers = ConvertToNetworkAddresses(seedServers, DefaultPort).ToList();
        }
    }
}