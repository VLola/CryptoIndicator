using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients.UsdFuturesApi;
using CryptoIndicator.Errors;
using CryptoExchange.Net.Authentication;
using System;
using Binance.Net.Objects;
using CryptoExchange.Net.Interfaces;

namespace CryptoIndicator.Binance
{
    public class Socket
    {
        public string ApiKey { get; private set; }
        public string SecretKey { get; private set; }
        public BinanceClient client;
        public BinanceSocketClient socketClient;
        public IBinanceClientUsdFuturesApi futures { get; set; }
        public IBinanceSocketClientUsdFuturesStreams futuresSocket { get; set; }
        public Socket(string api, string secret)
        {
            try
            {
                // Testnet
                //BinanceClientOptions clientOption = new BinanceClientOptions();
                //clientOption.UsdFuturesApiOptions.BaseAddress = "https://testnet.binancefuture.com";
                //client = new BinanceClient(clientOption);

                //BinanceSocketClientOptions socketClientOption = new BinanceSocketClientOptions();
                //socketClientOption.UsdFuturesStreamsOptions.AutoReconnect = true;
                //socketClientOption.UsdFuturesStreamsOptions.ReconnectInterval = TimeSpan.FromMinutes(1);
                //socketClientOption.UsdFuturesStreamsOptions.BaseAddress = "wss://stream.binancefuture.com";
                //socketClient = new BinanceSocketClient(socketClientOption);
                // Testnet

                // Real
                client = new BinanceClient();
                socketClient = new BinanceSocketClient();
                // Real

                ApiKey = api;
                SecretKey = secret;
                client.SetApiCredentials(new ApiCredentials(ApiKey, SecretKey));
                socketClient.SetApiCredentials(new ApiCredentials(ApiKey, SecretKey));
                futures = client.UsdFuturesApi;
                futuresSocket = socketClient.UsdFuturesStreams;
            }
            catch (Exception e)
            {
                ErrorText.Add($"Connect {e.Message}");
            }
        }
    }
}
