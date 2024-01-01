<Query Kind="Statements">
  <NuGetReference>AWSSDK.S3</NuGetReference>
  <NuGetReference>Moq</NuGetReference>
  <Namespace>Moq</Namespace>
  <Namespace>Amazon.S3</Namespace>
  <Namespace>Amazon</Namespace>
  <Namespace>Amazon.Runtime</Namespace>
  <Namespace>Amazon.S3.Model</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// data for mock s3 object
var testDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\test.dat");
var docStream = new FileInfo(testDataPath).OpenRead();

Mock<IAmazonS3> s3ClientMock = new Mock<IAmazonS3>();
s3ClientMock
    // set the return value to mock
    .Setup(x => x.GetObjectAsync(
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(
        (string bucket, string key, CancellationToken ct) =>
            new GetObjectResponse
            {
                BucketName = bucket,
                Key = key,
                HttpStatusCode = HttpStatusCode.OK,
                ResponseStream = docStream,
            });

// get s3 client mock
IAmazonS3 s3Client = s3ClientMock.Object;

// When calling the method, it returns mock value.
var downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\downloadedFile.dat");
using (var res = s3Client.GetObjectAsync("dummy-bucket", "/foo/bar")) {
    res.Result.WriteResponseStreamToFileAsync(downloadPath, append: false, CancellationToken.None);
}
