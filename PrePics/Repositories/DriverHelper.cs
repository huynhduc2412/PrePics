using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using static NuGet.Packaging.PackagingConstants;

namespace PrePics.Repositories
{
    public class DriverHelper
    {
        private readonly DriveService _driveService;
        public DriverHelper(string path)
        {
            string credentialsPath = path;

            GoogleCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
                {
                        DriveService.ScopeConstants.DriveFile
                    });
                _driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "File Upload Console App"
                });

            }
         }
            public void UploadFilesToDrive(IFormFile filePath)
            {
                try
                {
                    string folderId = "1di-rw0a5J8qSEpkG9BhYscZvuyWhHM-q";

                    var fileMetaData = new Google.Apis.Drive.v3.Data.File()
                        {
                            Name = Path.GetFileName(filePath.FileName),
                            Parents = new List<string> { folderId },
                        };
                    FilesResource.CreateMediaUpload request;
                    using (var streamFile = new MemoryStream())
                    {
                        filePath.CopyTo(streamFile);
                        streamFile.Position = 0;
                        request = _driveService.Files.Create(fileMetaData, streamFile, "");
                        request.Fields = "id";
                        request.Upload();
                    }
                    var uploadedFile = request.ResponseBody;
                    //Console.WriteLine($"File '{fileMetaData.Name}' uploaded with ID: {uploadedFile.Id}");

                }
                catch (Google.GoogleApiException ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");

                    if (ex.Error != null)
                    {
                        Console.WriteLine($"HTTP Status Code: {ex.Error.Code}");
                        Console.WriteLine($"Error Message: {ex.Error.Message}");
                    }
                }
        }
        public async Task<IList<Google.Apis.Drive.v3.Data.File>> GetFilesAsync()
        {
            string folderId = "1di-rw0a5J8qSEpkG9BhYscZvuyWhHM-q";
            var request = _driveService.Files.List();
            request.Q = $"'{folderId}' in parents ";
            request.Fields = "nextPageToken, files(id, name, mimeType, thumbnailLink)";

            var result = await request.ExecuteAsync();
            return result.Files;
        }


    }
}
