﻿namespace Tweetinvi.Models.DTO
{
    public interface IUploadProcessingInfo
    {
        string State { get; set; }
        ProcessingState ProcessingState { get; set; }
        int CheckAfterInSeconds { get; set; }
        int CheckAfterInMilliseconds { get; }
        int ProgressPercentage { get; set; }
        IUploadProcessingError Error { get; set; }
    }
}