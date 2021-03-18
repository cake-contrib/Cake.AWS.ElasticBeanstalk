using Cake.Core;
using Cake.Core.Annotations;
using System.Threading.Tasks;

namespace Cake.AWS.ElasticBeanstalk
{    
    /// <summary>
    /// Contains Cake aliases for configuring Amazon Elastic Load Balancers
    /// </summary>
    [CakeAliasCategory("AWS")]
    [CakeNamespaceImport("Amazon")]
    [CakeNamespaceImport("Amazon.ElasticBeanstalk")]
    public static class ElasticBeanstalkAliases
    {
        private static IElasticBeanstalkManager CreateManager(this ICakeContext context)
        {
            return new ElasticBeanstalkManager(context.Environment, context.Log);
        }

        /// <summary>
        /// Creates an application version
        /// </summary>
        /// <param name="context">The Cake context</param>
        /// <param name="applicationName">The application name</param>
        /// <param name="description">The description</param>
        /// <param name="versionLabel">The version label</param>
        /// <param name="s3Bucket">The S3 bucket</param>
        /// <param name="s3Key">The S3 key</param>
        /// <param name="autoCreateApplication">The auto create application</param>
        /// <param name="settings">The settings</param>
        /// <returns></returns>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticBeanstalk")]
        public static Task<bool> CreateApplicationVersionAsync(this ICakeContext context, string applicationName, string description, string versionLabel, string s3Bucket, string s3Key, bool autoCreateApplication, ElasticBeanstalkSettings settings)
        {
            var manager = context.CreateManager();
            return manager.CreateApplicationVersionAsync(applicationName,                    
                description, 
                versionLabel,
                s3Bucket, 
                s3Key, 
                autoCreateApplication, settings);
        }

        /// <summary>
        /// Deploys an application version
        /// </summary>
        /// <param name="context">The Cake context</param>
        /// <param name="applicationName">The application name</param>
        /// <param name="environmentName"></param>
        /// <param name="versionLabel">The version label</param>
        /// <param name="settings">The settings</param>
        /// <returns></returns>
        [CakeMethodAlias]
        [CakeAliasCategory("ElasticBeanstalk")]
        public static Task<bool> DeployApplicationVersionAsync(this ICakeContext context, string applicationName, string environmentName, string versionLabel, ElasticBeanstalkSettings settings)
        {
            var manager = context.CreateManager();
            return manager.DeployApplicationVersionAsync(applicationName,
                environmentName,
                versionLabel,
                settings);
        }
    }
}
