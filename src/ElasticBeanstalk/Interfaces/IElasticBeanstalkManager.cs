
namespace Cake.AWS.ElasticBeanstalk
{
    public interface IElasticBeanstalkManager
    {
        bool CreateApplicationVersion(string applicationName, 
            string description, 
            string versionLabel, 
            string s3Bucket,
            string s3Key, 
            bool autoCreateApplication, ElasticBeanstalkSettings settings);
    }
}
