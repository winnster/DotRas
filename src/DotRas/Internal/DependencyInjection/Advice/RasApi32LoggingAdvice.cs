﻿using System.Diagnostics;
using System.Text;
using DotRas.Diagnostics;
using DotRas.Diagnostics.Events;
using DotRas.Win32;
using DotRas.Win32.SafeHandles;
using static DotRas.Win32.ExternDll;
using static DotRas.Win32.NativeMethods;
using static DotRas.Win32.Ras;

namespace DotRas.Internal.DependencyInjection.Advice
{
    internal class RasApi32LoggingAdvice : LoggingAdvice<IRasApi32>, IRasApi32
    {
        public RasApi32LoggingAdvice(IRasApi32 instance, IEventLoggingPolicy eventLoggingPolicy)
            : base(instance, eventLoggingPolicy)
        {
        }

        public int RasEnumConnections(RASCONN[] lpRasConn, ref int lpCb, ref int lpConnections)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AttachedObject.RasEnumConnections(lpRasConn, ref lpCb, ref lpConnections);
            stopwatch.Stop();

            var callEvent = new PInvokeCallCompletedTraceEvent
            {
                DllName = RasApi32Dll,
                Duration = stopwatch.Elapsed,
                MethodName = nameof(RasEnumConnections),
                Result = result
            };

            callEvent.Args.Add(nameof(lpRasConn), lpRasConn);
            callEvent.OutArgs.Add(nameof(lpCb), lpCb);
            callEvent.OutArgs.Add(nameof(lpConnections), lpConnections);

            LogInformation(callEvent);
            return result;
        }

        public int RasDial(ref RASDIALEXTENSIONS lpRasDialExtensions, string lpszPhoneBook, ref RASDIALPARAMS lpRasDialParams, NotifierType dwNotifierType, RasDialFunc2 lpvNotifier, out RasHandle lphRasConn)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AttachedObject.RasDial(ref lpRasDialExtensions, lpszPhoneBook, ref lpRasDialParams, dwNotifierType, lpvNotifier, out lphRasConn);
            stopwatch.Stop();

            var callEvent = new PInvokeCallCompletedTraceEvent
            {
                DllName = RasApi32Dll,
                Duration = stopwatch.Elapsed,
                MethodName = nameof(RasDial),
                Result = result,
            };

            callEvent.Args.Add(nameof(lpRasDialExtensions), lpRasDialExtensions);
            callEvent.Args.Add(nameof(lpszPhoneBook), lpszPhoneBook);
            callEvent.Args.Add(nameof(lpRasDialParams), lpRasDialParams);
            callEvent.Args.Add(nameof(dwNotifierType), dwNotifierType);
            callEvent.Args.Add(nameof(lpvNotifier), lpvNotifier);
            callEvent.OutArgs.Add(nameof(lphRasConn), lphRasConn);

            LogInformation(callEvent);
            return result;
        }

        public int RasGetConnectStatus(RasHandle hRasConn, ref RASCONNSTATUS lpRasConnStatus)
        {
            return AttachedObject.RasGetConnectStatus(hRasConn, ref lpRasConnStatus);
        }

        public int RasGetCredentials(string lpszPhonebook, string lpszEntryName, ref RASCREDENTIALS lpCredentials)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AttachedObject.RasGetCredentials(lpszPhonebook, lpszEntryName, ref lpCredentials);
            stopwatch.Stop();

            var callEvent = new PInvokeCallCompletedTraceEvent
            {
                DllName = RasApi32Dll,
                Duration = stopwatch.Elapsed,
                MethodName = nameof(RasGetCredentials),
                Result = result,
            };

            callEvent.Args.Add(nameof(lpszPhonebook), lpszPhonebook);
            callEvent.Args.Add(nameof(lpszEntryName), lpszEntryName);
            callEvent.OutArgs.Add(nameof(lpCredentials), lpCredentials);

            LogInformation(callEvent);
            return result;
        }

        public int RasGetErrorString(int uErrorValue, StringBuilder lpszErrorString, int cBufSize)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AttachedObject.RasGetErrorString(uErrorValue, lpszErrorString, cBufSize);
            stopwatch.Stop();

            var callEvent = new PInvokeCallCompletedTraceEvent
            {
                DllName = RasApi32Dll,
                Duration = stopwatch.Elapsed,
                MethodName = nameof(RasGetErrorString),
                Result = result
            };

            callEvent.Args.Add(nameof(uErrorValue), uErrorValue);
            callEvent.Args.Add(nameof(lpszErrorString), lpszErrorString);
            callEvent.Args.Add(nameof(cBufSize), cBufSize);

            LogInformation(callEvent);
            return result;
        }

        public int RasHangUp(RasHandle hRasConn)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AttachedObject.RasHangUp(hRasConn);
            stopwatch.Stop();

            var callEvent = new PInvokeCallCompletedTraceEvent
            {
                DllName = RasApi32Dll,
                Duration = stopwatch.Elapsed,
                MethodName = nameof(RasHangUp),
                Result = result
            };

            callEvent.Args.Add(nameof(hRasConn), hRasConn);

            LogInformation(callEvent);
            return result;
        }

        public int RasValidateEntryName(string lpszPhonebook, string lpszEntryName)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AttachedObject.RasValidateEntryName(lpszPhonebook, lpszEntryName);
            stopwatch.Stop();

            var callEvent = new PInvokeCallCompletedTraceEvent
            {
                DllName = RasApi32Dll,
                Duration = stopwatch.Elapsed,
                MethodName = nameof(RasValidateEntryName),
                Result = result
            };

            callEvent.Args.Add(nameof(lpszPhonebook), lpszPhonebook);
            callEvent.Args.Add(nameof(lpszEntryName), lpszEntryName);

            LogInformation(callEvent);
            return result;
        }
    }
}