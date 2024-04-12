<Query Kind="Program">
  <NuGetReference>AWSSDK.EC2</NuGetReference>
</Query>

void Main() {
	// sample
	var options = new Amazon.Runtime.CredentialManagement.CredentialProfileOptions {
		AccessKey = "<replace-your-access-key>", // Access Key
		SecretKey = "<replace-your-secret-key>", // Don't commit with Secret Key
	};

	var profile = new Amazon.Runtime.CredentialManagement.CredentialProfile("<replace-your-profile>", options);
	profile.Region = Amazon.RegionEndpoint.APNortheast1; // Tokyo Region
	var netSDKFile = new Amazon.Runtime.CredentialManagement.NetSDKCredentialsFile();
	netSDKFile.RegisterProfile(profile);

	"finished".Dump();
}