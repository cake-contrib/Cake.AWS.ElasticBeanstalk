
using System.Threading.Tasks;

namespace Cake.AWS.ElasticBeanstalk
{
    public interface IElasticBeanstalkManager
    {
        Task<bool> CreateApplicationVersionAsync(string applicationName, 
            string description, 
            string versionLabel, 
            string s3Bucket,
            string s3Key, 
            bool autoCreateApplication, ElasticBeanstalkSettings settings);

        Task<bool> DeployApplicationVersionAsync(string applicationName,
            string environmentName,
            string versionLabel,
            ElasticBeanstalkSettings settings);
    }
}
