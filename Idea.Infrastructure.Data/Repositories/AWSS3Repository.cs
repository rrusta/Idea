

using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Idea.Infrastructure.Data.Helpers;
using Idea.Infrastructure.Data.Interfaces;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Idea.Infrastructure.Data.Repositories
{
    public class AWSS3Repository : IAWSS3Repository
    {
        private readonly IOptions<AWSSettings> _awsConfig;

        public AWSS3Repository(IOptions<AWSSettings> awsConfig)
        {
            _awsConfig = awsConfig;
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var credentials = new BasicAWSCredentials(_awsConfig.Value.AccessKey, _awsConfig.Value.AccessSecret);
            var config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.EUCentral1
            };

            using var client = new AmazonS3Client(credentials, config);

            await using var newMemoryStream = new MemoryStream();
            MagickImage image = new MagickImage(file.OpenReadStream());
            image.Quality = 75;
            image.Write(newMemoryStream);

            var key = Guid.NewGuid().ToString() + file.FileName;

            var uploadRequest = new TransferUtilityUploadRequest
            {               
                InputStream = newMemoryStream,
                Key = key,
                BucketName = _awsConfig.Value.BucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            var fileTransferUtility = new TransferUtility(client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            return string.Format("https://{0}.s3.amazonaws.com/{1}", _awsConfig.Value.BucketName, key);
        }
    }
}
