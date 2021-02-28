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
