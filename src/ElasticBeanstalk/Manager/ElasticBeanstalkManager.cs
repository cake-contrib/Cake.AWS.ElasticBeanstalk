using System;
using System.Threading.Tasks;
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;
using Cake.Core;
using Cake.Core.Diagnostics;

namespace Cake.AWS.ElasticBeanstalk
{
    public class ElasticBeanstalkManager : IElasticBeanstalkManager
    {
        private readonly ICakeEnvironment _Environment;
        private readonly ICakeLog _Log;

        /// <summary>
        /// If the manager should output progrtess events to the cake log
        /// </summary>
        public bool LogProgress { get; set; }

        public ElasticBeanstalkManager(ICakeEnvironment environment, ICakeLog log)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            _Environment = environment;
            _Log = log;

            this.LogProgress = true;
        }

        //Request
        private AmazonElasticBeanstalkClient GetClient(ElasticBeanstalkSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            if (settings.Region == null)
            {
                throw new ArgumentNullException("settings.Region");
            }

            if (settings.Credentials == null)
            {
                if (String.IsNullOrEmpty(settings.AccessKey))
                {
                    throw new ArgumentNullException("settings.AccessKey");
                }
                if (String.IsNullOrEmpty(settings.SecretKey))
                {
                    throw new ArgumentNullException("settings.SecretKey");
                }

                if (!String.IsNullOrEmpty(settings.SessionToken))
                {
                    return new AmazonElasticBeanstalkClient(settings.AccessKey, settings.SecretKey, settings.SessionToken, settings.Region);
                }

                return new AmazonElasticBeanstalkClient(settings.AccessKey, settings.SecretKey, settings.Region);
            }
            else
            {
                return new AmazonElasticBeanstalkClient(settings.Credentials, settings.Region);
            }
        }


        public async Task<bool> CreateApplicationVersionAsync(string applicationName, string description, string versionLabel, string s3Bucket, string s3Key, bool autoCreateApplication, ElasticBeanstalkSettings settings)
        {
            if (string.IsNullOrEmpty(applicationName))
            {
                throw new ArgumentNullException("applicationName");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("description");
            }

            if (string.IsNullOrEmpty(versionLabel))
            {
                throw new ArgumentNullException("versionLabel");
            }

            if (string.IsNullOrEmpty(s3Bucket))
            {
                throw new ArgumentNullException("s3Bucket");
            }

            if (string.IsNullOrEmpty(s3Key))
            {
                throw new ArgumentNullException("s3Key");
            }


            try
            {
                var client = GetClient(settings);
                await client.CreateApplicationVersionAsync(new CreateApplicationVersionRequest
                {
                    ApplicationName = applicationName,
                    AutoCreateApplication = autoCreateApplication,
                    Description = description,
                    //Process = true,
                    VersionLabel = versionLabel,
                    SourceBundle = new S3Location
                    {
                        S3Bucket = s3Bucket,
                        S3Key = s3Key
                    }
                });
            }
            catch (Exception ex)
            {
                _Log.Error("Failed to create new application version '{0}'", ex.Message);
                return false;
            }

            _Log.Verbose("Successfully created new application version '{0}' for application '{1}'", versionLabel, applicationName);
            return true;
        }


        public async Task<bool> DeployApplicationVersionAsync(string applicationName, string environmentName, string versionLabel, ElasticBeanstalkSettings settings)
        {
            if (string.IsNullOrEmpty(applicationName))
            {
                throw new ArgumentNullException("applicationName");
            }

            if (string.IsNullOrEmpty(environmentName))
            {
                throw new ArgumentNullException("environmentName");
            }

            if (string.IsNullOrEmpty(versionLabel))
            {
                throw new ArgumentNullException("versionLabel");
            }

            try
            {
                var client = GetClient(settings);
                await client.UpdateEnvironmentAsync(new UpdateEnvironmentRequest()
                {
                    ApplicationName = applicationName,
                    EnvironmentName = environmentName,
                    VersionLabel = versionLabel
                });
            }
            catch (Exception ex)
            {
                _Log.Error("Failed to deploy application version '{0}'", ex.Message);
                return false;
            }

            _Log.Verbose("Successfully deployed application version '{0}' for environment '{1}' in application '{2}'", versionLabel, environmentName, applicationName);
            return true;
        }

    }

}