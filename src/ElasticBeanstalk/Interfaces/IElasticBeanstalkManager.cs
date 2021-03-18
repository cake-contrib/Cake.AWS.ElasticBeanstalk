
using System.Threading.Tasks;

namespace Cake.AWS.ElasticBeanstalk
{
    /// <summary>
    /// The ElasticBeanstalkManager interface
    /// </summary>
    public interface IElasticBeanstalkManager
    {
        /// <summary>
        /// Creates an application version
        /// </summary>
        /// <param name="applicationName">The application name</param>
        /// <param name="description">The description</param>
        /// <param name="versionLabel">The version label</param>
        /// <param name="s3Bucket">The S3 bucket</param>
        /// <param name="s3Key">The S3 key</param>
        /// <param name="autoCreateApplication">The auto create application</param>
        /// <param name="settings">The settings</param>
        /// <returns></returns>
        Task<bool> CreateApplicationVersionAsync(string applicationName, 
            string description, 
            string versionLabel, 
            string s3Bucket,
            string s3Key, 
            bool autoCreateApplication, ElasticBeanstalkSettings settings);

        /// <summary>
        /// Deploys an application version
        /// </summary>
        /// <param name="applicationName">The application name</param>
        /// <param name="environmentName"></param>
        /// <param name="versionLabel">The version label</param>
        /// <param name="settings">The settings</param>
        /// <returns></returns>
        Task<bool> DeployApplicationVersionAsync(string applicationName,
            string environmentName,
            string versionLabel,
            ElasticBeanstalkSettings settings);
    }
}
