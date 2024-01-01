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

var pathToTestDoc = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\test.dat");

var docStream = new FileInfo(pathToTestDoc).OpenRead();

// S3アクセスするクライアントのモックを設定
Mock<IAmazonS3> s3ClientMock = new Mock<IAmazonS3>();
s3ClientMock
	// GetObjectAsyncメソッドの戻り値をモックに設定
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

// モックを取得する
IAmazonS3 s3Client = s3ClientMock.Object;

var downloadedFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\downloadedFile.dat");

// モックのGetObjectAsyncを呼び出すと、事前に設定した戻り値が返される。
using (var res = s3Client.GetObjectAsync("dummy-bucket", "/foo/bar")) {
	res.Result.WriteResponseStreamToFileAsync(downloadedFile, append: false, CancellationToken.None);
}
