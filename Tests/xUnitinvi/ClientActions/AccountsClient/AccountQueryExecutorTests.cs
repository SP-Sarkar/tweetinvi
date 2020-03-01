﻿using System.Threading.Tasks;
using FakeItEasy;
using Tweetinvi;
using Tweetinvi.Controllers.Account;
using Tweetinvi.Core.QueryGenerators;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO;
using Tweetinvi.Models.DTO.QueryDTO;
using Tweetinvi.Parameters;
using Xunit;
using xUnitinvi.TestHelpers;

namespace xUnitinvi.ClientActions.AccountsClient
{
    public class AccountQueryExecutorTests
    {
        public AccountQueryExecutorTests()
        {
            _fakeBuilder = new FakeClassBuilder<AccountQueryExecutor>();
            _fakeUserQueryGenerator = _fakeBuilder.GetFake<IUserQueryGenerator>().FakedObject;
            _fakeTwitterAccessor = _fakeBuilder.GetFake<ITwitterAccessor>().FakedObject;
        }

        private readonly FakeClassBuilder<AccountQueryExecutor> _fakeBuilder;
        private readonly IUserQueryGenerator _fakeUserQueryGenerator;
        private readonly ITwitterAccessor _fakeTwitterAccessor;

        private AccountQueryExecutor CreateAccountQueryExecutor()
        {
            return _fakeBuilder.GenerateClass();
        }

        [Fact]
        public async Task GetAuthenticatedUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new GetAuthenticatedUserParameters();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            request.ExecutionContext.TweetMode = TweetMode.Extended;

            A.CallTo(() => _fakeUserQueryGenerator.GetAuthenticatedUserQuery(parameters, TweetMode.Extended)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetAuthenticatedUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        // BLOCK
        [Fact]
        public async Task BlockUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var userDTO = A.Fake<IUserDTO>();

            var url = TestHelper.GenerateString();
            var parameters = new BlockUserParameters(userDTO);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetBlockUserQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.BlockUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }

        [Fact]
        public async Task UnblockUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var userDTO = A.Fake<IUserDTO>();

            var url = TestHelper.GenerateString();
            var parameters = new UnblockUserParameters(userDTO);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUnblockUserQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.UnblockUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }

        [Fact]
        public async Task ReportUserForSpam_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new ReportUserForSpamParameters(42);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetReportUserForSpamQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.ReportUserForSpam(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetBlockedUserIds_ReturnsUserIds()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new GetBlockedUserIdsParameters();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IIdsCursorQueryResultDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetBlockedUserIdsQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IIdsCursorQueryResultDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetBlockedUserIds(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetBlockedUsers_ReturnsUserDTOs()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new GetBlockedUsersParameters();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserCursorQueryResultDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetBlockedUsersQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserCursorQueryResultDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetBlockedUsers(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        // FOLLOWERS
        [Fact]
        public async Task FollowUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var userDTO = A.Fake<IUserDTO>();

            var url = TestHelper.GenerateString();
            var parameters = new FollowUserParameters(userDTO);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetFollowUserQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.FollowUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }
        [Fact]
        public async Task UnFollowUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var userDTO = A.Fake<IUserDTO>();

            var url = TestHelper.GenerateString();
            var parameters = new UnFollowUserParameters(userDTO);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUnFollowUserQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.UnFollowUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetUserIdsRequestingFriendship_ReturnsPendingFollowers()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var parameters = new GetUserIdsRequestingFriendshipParameters();

            var url = TestHelper.GenerateString();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IIdsCursorQueryResultDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUserIdsRequestingFriendshipQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IIdsCursorQueryResultDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetUserIdsRequestingFriendship(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetUserIdsYouRequestedToFollow_ReturnsPendingFollowers()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var parameters = new GetUserIdsYouRequestedToFollowParameters();

            var url = TestHelper.GenerateString();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IIdsCursorQueryResultDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUserIdsYouRequestedToFollowQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IIdsCursorQueryResultDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetUserIdsYouRequestedToFollow(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        [Fact]
        public async Task UpdateRelationship_ReturnsRelationships()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var parameters = new UpdateRelationshipParameters(42);

            var url = TestHelper.GenerateString();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IRelationshipDetailsDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUpdateRelationshipQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IRelationshipDetailsDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.UpdateRelationship(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetRelationshipsWith_ReturnsRelationships()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();
            var parameters = new GetRelationshipsWithParameters(new long[] { 42 });

            var url = TestHelper.GenerateString();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IRelationshipStateDTO[]>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetRelationshipsWithQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IRelationshipStateDTO[]>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetRelationshipsWith(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        // MUTE
        [Fact]
        public async Task GetUserIdsWhoseRetweetsAreMuted_ReturnsUserIds()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new GetUserIdsWhoseRetweetsAreMutedParameters();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<long[]>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUserIdsWhoseRetweetsAreMutedQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<long[]>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetUserIdsWhoseRetweetsAreMuted(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetMutedUserIds_ReturnsUserIds()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new GetMutedUserIdsParameters();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IIdsCursorQueryResultDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetMutedUserIdsQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IIdsCursorQueryResultDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetMutedUserIds(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        [Fact]
        public async Task GetMutedUsers_ReturnsUserDTOs()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new GetMutedUsersParameters();
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserCursorQueryResultDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetMutedUsersQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserCursorQueryResultDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.GetMutedUsers(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.GET, request.Query.HttpMethod);
        }

        [Fact]
        public async Task MutedUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new MuteUserParameters(42);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetMuteUserQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.MuteUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }

        [Fact]
        public async Task UnMutedUser_ReturnsUserDTO()
        {
            // Arrange
            var queryExecutor = CreateAccountQueryExecutor();

            var url = TestHelper.GenerateString();
            var parameters = new UnMuteUserParameters(42);
            var request = A.Fake<ITwitterRequest>();
            var expectedResult = A.Fake<ITwitterResult<IUserDTO>>();

            A.CallTo(() => _fakeUserQueryGenerator.GetUnMuteUserQuery(parameters)).Returns(url);
            A.CallTo(() => _fakeTwitterAccessor.ExecuteRequest<IUserDTO>(request)).Returns(expectedResult);

            // Act
            var result = await queryExecutor.UnMuteUser(parameters, request);

            // Assert
            Assert.Equal(result, expectedResult);
            Assert.Equal(request.Query.Url, url);
            Assert.Equal(HttpMethod.POST, request.Query.HttpMethod);
        }
    }
}