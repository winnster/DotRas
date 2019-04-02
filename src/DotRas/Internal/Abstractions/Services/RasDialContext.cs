﻿using System;
using System.Net;
using System.Threading;
using DotRas.ExtensibleAuthentication;
using DotRas.Internal.Interop;

namespace DotRas.Internal.Abstractions.Services
{
    internal class RasDialContext
    {
        public string PhoneBookPath { get; set; }
        public string EntryName { get; set; }
        public NetworkCredential Credentials { get; set; }
        public Action<StateChangedEventArgs> OnStateChangedCallback { get; set; }
        public RasDialerOptions Options { get; set; }
        public CancellationToken CancellationToken { get; set; }        
        public NativeMethods.RasDialFunc2 Callback { get; set; }
        public NativeMethods.RASDIALPARAMS DialParams { get; set; }
        public NativeMethods.RASDIALEXTENSIONS DialExtensions { get; set; }
        public IntPtr LpDialExtensions { get; set; }
        public IntPtr LpDialParams { get; set; }
    }
}