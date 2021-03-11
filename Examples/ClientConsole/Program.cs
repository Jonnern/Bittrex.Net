﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bittrex.Net;
using Bittrex.Net.Objects;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            BittrexClient.SetDefaultOptions(new BittrexClientOptions()
            {
                ApiCredentials = new ApiCredentials("APIKEY", "APISECRET"),
                LogVerbosity = LogVerbosity.Info,
                LogWriters = new List<TextWriter>() { Console.Out }
            });

            var client = new BittrexClient();
            
            // public
            var markets = client.GetSymbols();
            var currencies = client.GetCurrencies();
            var price = client.GetTicker("BTC-ETH");
            var marketSummary = client.GetSymbolSummary("BTC-ETH");
            var marketSummaries = client.GetSymbolSummaries();
            var orderbook = client.GetOrderBook("BTC-ETH");
            var marketHistory = client.GetSymbolTrades("BTC-ETH");

            // private
            // Commented to prevent accidental order placement
            //var placedOrder = 
            //    client.PlaceOrder("BTC-USDT", OrderSide.Sell, OrderTypeV3.Limit, TimeInForce.GoodTillCancelled, 1, 1);
            //var orderInfo = client.GetOrder(placedOrder.Data.Id);
            //var canceledOrder = client.CancelOrder(placedOrder.Data.Id);
            var openOrders = client.GetOpenOrders("BTC-USDT");
            var orderTrades = client.GetExecutions("BTC-NEO");

            var balance = client.GetBalance("NEO");
            var balances = client.GetBalances();
            var depositAddress = client.GetDepositAddress("BTC");
            var withdraw = client.Withdraw("TEST", 1, "TEST", "TEST");
            var withdrawHistory = client.GetClosedWithdrawals();
            var depositHistory = client.GetClosedDeposits();
            

            // Websocket
            var socketClient = new BittrexSocketClient();
            var subscription = socketClient.SubscribeToSymbolTickerUpdatesAsync("ETH-BTC", ticker =>
            {
                Console.WriteLine($"ETH-BTC: {ticker.LastTradeRate}");
            });

            var subscription2 = socketClient.SubscribeToOrderBookUpdatesAsync("ETH-BTC", 25, state =>
            {
                // Order book update
            });

            var subscription3 = socketClient.SubscribeToBalanceUpdatesAsync(data =>
            {
                // Balance update
            });

            Console.ReadLine();
            socketClient.UnsubscribeAll();
        }
    }
}
