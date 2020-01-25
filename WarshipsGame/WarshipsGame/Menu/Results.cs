using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace WarshipsGame.Menu
{
    public class Results
    {

        public Results()
        {
            var client = new AmazonDynamoDBClient();
            //var table = Table.LoadTable(client, "WarshipsScores");

            var request = new ScanRequest
            {
                TableName = "WarshipsScores",
            };

            var response = client.Scan(request);

            foreach (Dictionary<string, AttributeValue> item in response.Items)
            {
                PrintItem(item);
            }

            void PrintItem(
            Dictionary<string, AttributeValue> attributeList)
            {
                foreach (KeyValuePair<string, AttributeValue> kvp in attributeList)
                {
                    string attributeName = kvp.Key;
                    AttributeValue value = kvp.Value;

                    Console.WriteLine(
                        attributeName + " " +
                        (value.S == null ? "" : value.S ) +
                        (value.N == null ? "" : value.N )
                        );
                }
                Console.WriteLine("************************************************");
            }

            Console.WriteLine();

        }
    }
}

            
