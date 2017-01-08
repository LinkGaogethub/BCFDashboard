using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;

namespace BCFDashboard.Helpers
{
    public class BcfApi
    {
        private Uri _baseUrl = new Uri("https://bcf.bimsync.com/bcf");

        private readonly string _accountSid;
        private readonly string _secretKey;

        public BcfApi()
        {
            //string accountSid, string secretKey
            //_accountSid = accountSid;
            //_secretKey = secretKey;
            GetApiVersion();
        }

        private void GetApiVersion()
        {
            RestRequest request = new RestRequest();
            request.Resource = "version";

            Version version = Execute<Version>(request);

            _baseUrl = new Uri(_baseUrl.OriginalString + "/" + version.version_id);
        }

        public List<Models.Project> GetProjects()
        {
            RestRequest request = new RestRequest();
            request.Resource = "projects";

            return Execute<List<Models.Project>>(request);
        }

        public List<Models.Topic> GetTopics(string project_id)
        {
            RestRequest request = new RestRequest();
            request.Resource = "projects/{project_id}/topics";
            request.RootElement = "Topic";

            request.AddParameter("project_id", project_id, ParameterType.UrlSegment);

            return Execute<List<Models.Topic>>(request);
        }

        public List<Models.Comment> GetComments(string project_id, string topic_guid)
        {
            RestRequest request = new RestRequest();
            request.Resource = "projects/{project_id}/topics/{topic_guid}/comments";
            request.RootElement = "Comment";

            request.AddParameter("project_id", project_id, ParameterType.UrlSegment);
            request.AddParameter("topic_guid", topic_guid, ParameterType.UrlSegment);

            return Execute<List<Models.Comment>>(request);
        }

        //

        private T Execute<T>(RestRequest request) where T : new()
        {
            RestClient client = new RestClient(_baseUrl);
            request.AddHeader("Authorization", "Bearer the code here");// used on every request
            IRestResponse<T> response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }
            return response.Data;
        }
    }

    public class Version
    {
        public string version_id { get; set; }
        public string detailed_version { get; set; }
    }
}
