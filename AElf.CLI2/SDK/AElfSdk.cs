﻿using System;
using AElf.CLI2.JS;
using AElf.Common.Attributes;
using NLog;

namespace AElf.CLI2.SDK
{
    [LoggerName("aelf.sdk")]
    public class AElfSdk : IAElfSdk
    {
        private readonly IJSEngine _engine;
        private readonly ILogger _logger;

        public AElfSdk(IJSEngine engine, ILogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public IChain Chain()
        {
            return new Chain(_engine.Get("aelf").Get("chain"), _logger);
        }
    }


    [LoggerName("aelf.sdk.chain")]
    public class Chain : IChain
    {
        private readonly IJSObject _obj;
        private readonly ILogger _logger;

        public Chain(IJSObject obj, ILogger logger)
        {
            _obj = obj;
            _logger = logger;
        }


        public void ConnectChain()
        {
            _logger.Debug("connect to chain");
            _obj.InvokeAndGetJSObject("connectChain");
        }
    }
}