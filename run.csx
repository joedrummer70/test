using System;
using System.Net;
using System.Diagnostics;



// This is the Cloud Function entry point.
public static async Task<HttpResponseMessage> Run(HttpRequestMessage a_oReq, string reqparams, TraceWriter a_oLog)
{
    HttpResponseMessage oResp;
    HttpStatusCode      eCode;

    eCode = HttpStatusCode.OK;
    oResp = a_oReq.CreateResponse(eCode);
    return (oResp);
} // end Task
