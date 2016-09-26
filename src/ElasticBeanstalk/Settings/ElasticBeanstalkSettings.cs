using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;

namespace Cake.Aws.ElasticBeanstalk.Settings
{
    public class ElasticBeanstalkSettings
    {
        /// <summary>
        /// The AWS Access Key ID
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS Secret Access Key.
        /// </summary>
        public string SecretKey { get; set; }

        internal AWSCredentials Credentials { get; set; }

        /// <summary>
        /// The endpoints available to AWS clients.
        /// </summary>
        public RegionEndpoint Region { get; set; }

        /// <summary>
        /// Gets or sets the name of the S3 bucket.
        /// </summary>
        public string BucketName { get; set; }

        public ElasticBeanstalkSettings()
        {
            Region = RegionEndpoint.USEast1;
        }
    }
}
