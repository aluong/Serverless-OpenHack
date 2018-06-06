using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;

namespace BFYOC
{
    /*
     {
	    "id" : "cb4be5ff-b01e-003b-4992-fd859d06d52d",
	    "topic" : "/subscriptions/c5eb460e-8650-4d67-b6b9-dd737f5fe2c0/resourceGroups/BFYOC/providers/Microsoft.Storage/storageAccounts/bfyocorders10",
	    "subject" : "/blobServices/default/containers/challengesixblob/blobs/20180606123200-ProductInformation.csv",
	    "data" : {
		    "api" : "PutBlob",
		    "clientRequestId" : "7ff4e16e-25f8-45b6-bcda-4c4106d6bdca",
		    "requestId" : "cb4be5ff-b01e-003b-4992-fd859d000000",
		    "eTag" : "0x8D5CBA98042E6F0",
		    "contentType" : "application/octet-stream",
		    "contentLength" : 264,
		    "blobType" : "BlockBlob",
		    "url" : "https://bfyocorders10.blob.core.windows.net/challengesixblob/20180606123200-ProductInformation.csv",
		    "sequencer" : "000000000000000000000000000036880000000000032d47",
		    "storageDiagnostics" : {
			    "batchId" : "d083296a-ae0a-49a2-9cab-c374d072a37f"
		    }
	    },
	    "eventType" : "Microsoft.Storage.BlobCreated",
	    "eventTime" : "2018-06-06T12:32:00.4582914Z",
	    "metadataVersion" : "1",
	    "dataVersion" : ""
    }
     */
    public class BlobEventHandler
    {
        private static ConcurrentDictionary<string, int> batches = new ConcurrentDictionary<string, int>();

        [FunctionName("BlobEventHandler")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, TraceWriter log)
        {
            dynamic data = eventGridEvent.Data;

            var url = new Uri((string)data.url);

            var path = url.AbsolutePath;

            var file = path.Substring(path.LastIndexOf("/"));
            var batch = file.Substring(0, file.IndexOf("-"));

            batches.AddOrUpdate(batch, 1, (key, prev) => prev + 1);

            if(batches[batch] == 3)
            {
                //call to function
                log.Info($"{batch}, {batches[batch]}");
            }

            


        }
    }
}
