﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using x42.Feature.X42Client.RestClient.Responses;
using x42.Feature.X42Client.Utils.Web;
using x42.Utilities;

namespace x42.Feature.X42Client.RestClient
{
    public partial class X42RestClient : ApiClient
    {
        /// <summary>Instance logger.</summary>
        private readonly ILogger logger;

        public X42RestClient(string baseUrl, ILogger mainLogger) : base(baseUrl, mainLogger)
        {
            logger = mainLogger;
        }

        /// <summary>
        ///     Gets Status Information For The Target Node
        /// </summary>
        public async Task<NodeStatusResponse> GetNodeStatus()
        {
            try
            {
                NodeStatusResponse response = await base.SendGet<NodeStatusResponse>("api/Node/status");

                Guard.Null(response, nameof(response), "'api/Node/status' API Response Was Null!");

                logger.LogDebug("Got Node Status Response!");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogDebug($"An Error '{ex.Message}' Occured When Getting The Node Status!", ex);

                return null;
            }
        }

        /// <summary>
        ///     Gets the Blockchain Information For The Target Node
        /// </summary>
        public async Task<BlockchainInfoResponse> GetBlockchainInfo()
        {
            try
            {
                BlockchainInfoResponse response = await base.SendGet<BlockchainInfoResponse>("api/Node/getblockchaininfo");

                Guard.Null(response, nameof(response), "'api/Node/getblockchaininfo' API Response Was Null!");

                logger.LogDebug("Got Node Blockchain Response!");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogDebug($"An Error '{ex.Message}' Occured When Getting The Node Blockchain info!", ex);

                return null;
            }
        }

        /// <summary>
        /// Gets an unspent transaction
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">The vout of the transaction</param>
        /// <param name="includeMemPool">Whether or not to include the mempool</param>
        /// <returns>The unspent transaction for the specified transaction and vout</returns>
        public async Task<GetTXOutResponse> GetTXOut(string txid, string vout, string includeMemPool = "false")
        {
            try
            {
                GetTXOutResponse response = await base.SendGet<GetTXOutResponse>
                    ($"api/Node/gettxout?trxid={txid}&vout={vout}&includeMemPool={includeMemPool}");

                Guard.Null(response, nameof(response), "'api/Node/gettxout' API Response Was Null!");

                logger.LogDebug("Got GetTXOut Response!");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogDebug($"An Error '{ex.Message}' Occured When Getting The GetTXOut!", ex);

                return null;
            }
        }

        /// <summary>
        /// Gets address balance
        /// </summary>
        /// <param name="address">Public address</param>
        /// <param name="minConfirmations">Minimum confirmations</param>
        /// <returns>The available balance for the address</returns>
        public async Task<GetAddressesBalancesResponse> GetAddressBalances(string address, int minConfirmations = 1)
        {
            try
            {
                GetAddressesBalancesResponse response = await base.SendGet<GetAddressesBalancesResponse>
                    ($"api/BlockStore/getaddressesbalances?addresses={address}&minConfirmations={minConfirmations}");

                Guard.Null(response, nameof(response), "'api/BlockStore/getaddressesbalances' API Response Was Null!");

                logger.LogDebug("Got Address Balance Response!");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogDebug($"An Error '{ex.Message}' Occured When Getting The Address Balance!", ex);

                return null;
            }
        }
    }
}