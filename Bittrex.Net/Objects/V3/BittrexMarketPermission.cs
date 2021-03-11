﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bittrex.Net.Objects.V3
{
    /// <summary>
    /// Market permission
    /// </summary>
    public class BittrexMarketPermission
    {
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Allowed to view
        /// </summary>
        public bool View { get; set; }
        /// <summary>
        /// Allowed to buy
        /// </summary>
        public bool Buy { get; set; }
        /// <summary>
        /// Allowed to sell
        /// </summary>
        public bool Sell { get; set; }
    }
}
