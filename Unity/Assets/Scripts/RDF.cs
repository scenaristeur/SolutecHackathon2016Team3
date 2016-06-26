using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Text;
using SimpleJSON;
using System.Text.RegularExpressions;
using UnityEngine;

public class RDF {

	public string getValue (string subject, string predicate) {

        string uri = "http://192.168.101.39:3030/test/";
        string query = "query?query=PREFIX+DC%3A++++%3Chttp%3A%2F%2Fwww.smag0%2FNS%2FhackathonSolutec%2FDC%23%3E+%0APREFIX+rdf%3A+++%3Chttp%3A%2F%2Fwww.w3.org%2F1999%2F02%2F22-rdf-syntax-ns%23%3E%0APREFIX+rdfs%3A+++%3Chttp%3A%2F%2Fwww.w3.org%2F2000%2F01%2Frdf-schema%23%3E%0APREFIX+owl%3A+%3Chttp%3A%2F%2Fwww.w3.org%2F2002%2F07%2Fowl%23%3E%0A%0ASELECT+%3Fobjet+%0AWHERE+%7B%0A%0A++DC%3A"+subject+"++DC%3A"+predicate+"+%3Fobjet%0A++%0A%0A%7D%0ALIMIT+25&output=json";

		// Create a request for the URL. 
		WebRequest request = WebRequest.Create (uri+query);
		// If required by the server, set the credentials.
		request.Credentials = CredentialCache.DefaultCredentials;
		// Get the response.
		WebResponse response = request.GetResponse ();
		// Display the status.
		//Debug.Log (((HttpWebResponse)response).StatusDescription);
		// Get the stream containing content returned by the server.
		Stream dataStream = response.GetResponseStream ();
		// Open the stream using a StreamReader for easy access.
		StreamReader reader = new StreamReader (dataStream);
		// Read the content.
		string responseFromServer = reader.ReadToEnd ();
		// Display the content.
		//Debug.Log (responseFromServer);

        //Parse the JSON to read the data.
		var N = JSON.Parse(responseFromServer);

		string res = N["results"]["bindings"][0]["objet"]["value"].Value;
		// Clean up the streams and the response.
		reader.Close ();
		response.Close ();
        
        //	
        Regex re = new Regex(@".*#(.*)|(.*)");
        MatchCollection mc = re.Matches(res);
        res = mc[0].Groups[1].Value;
        if(res == "")
            res = mc[0].Groups[0].Value;
        return res;
	}
}