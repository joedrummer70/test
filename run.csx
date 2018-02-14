#load "AzureIncludes.csx"
using System;
using System.Net;
using System.Diagnostics;



// This is the Cloud Function entry point.
public static async Task<HttpResponseMessage> Run(HttpRequestMessage a_oReq, string reqparams, TraceWriter a_oLog)
{
    string              zParams;
    AzureShellHandler   oAzHandler;
    AzureReq            oAzReq;
    AzureResp           oAzResp;
    HttpResponseMessage oResp;
    HttpStatusCode      eCode;

    // Error:  Access to the registry key 'Global' is denied.
    //PerformanceCounter  oCpu,
    //                    oMem;
    //oCpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
    //oMem = new PerformanceCounter("Memory", "Available MBytes");
    //oCpu.NextValue() // Percent CPU
    //oMem.NextValue() // MB

    zParams = a_oReq.GetQueryNameValuePairs()
                    .FirstOrDefault(q => string.Compare(q.Key, "reqparams", true) == 0)
                    .Value;
    oAzReq = AzureShellUtils.jsonToObj<AzureReq>(zParams);

    oAzHandler = new AzureShellHandler();
    oAzResp = oAzHandler.handleRequest(oAzReq, a_oLog);
    
    if (oAzResp.getOk() == true)
    {
        eCode = HttpStatusCode.OK;
    }
    else
    {
        eCode = HttpStatusCode.BadRequest;
    }
    
    oResp = a_oReq.CreateResponse(eCode, oAzResp);
    return (oResp);
} // end Run
