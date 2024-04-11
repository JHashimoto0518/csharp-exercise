<Query Kind="Statements">
  <Output>DataGrids</Output>
  <NuGetReference>AWSSDK.S3</NuGetReference>
  <Namespace>Amazon.S3</Namespace>
  <Namespace>Amazon.S3.Encryption</Namespace>
  <Namespace>Amazon.S3.Encryption.Internal</Namespace>
  <Namespace>Amazon.S3.Internal</Namespace>
  <Namespace>Amazon.S3.Model</Namespace>
  <Namespace>Amazon.S3.Model.Internal.MarshallTransformations</Namespace>
  <Namespace>Amazon.S3.Transfer</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

const string Profile = "<replace-your-profile";
RegionEndpoint region = RegionEndpoint.APNortheast1;

var chain = new CredentialProfileStoreChain();
AWSCredentials awsCredentials;
if (chain.TryGetAWSCredentials(Profile, out awsCredentials) == false) {
	"Can't get the credential.".Dump();
	return;
}

using (var s3Client = new AmazonS3Client(awsCredentials, region)) {
	var request = new PutObjectRequest();
	request.FilePath = "<replace-mp3-path>";
	request.BucketName = "<replace-bucket-name";

	// ContentType does not have to be specified, but can be specified explicitly.
	request.ContentType = "audio/mp3";
	request.Key = "<replace-key>";
	var response = await s3Client.PutObjectAsync(request);
	response.Dump();
}
