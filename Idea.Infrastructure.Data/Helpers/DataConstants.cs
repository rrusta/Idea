using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Infrastructure.Data.Helpers
{
    public static class DataConstants
    {
        public class AppSettings
        {
            public const string ConnectionString = "RealEstateDBConnection";
        }

        public class EmailTemplates
        {
            public const string ChangeEmailConfirmation = "ChangeEmailConfirmation";

            public const string ConfirmEmail = "ConfirmEmail";

            public const string ResetPassword = "ResetPassword";

            public const string SendEmail = "SendEmail";

            public const string SendUserMessageEmail = "SendUserMessageEmail";

            public const string ApprovePublication = "ApprovePublication";

            public const string PublicationAdded = "PublicationAdded";

            public const string PublicationEdited = "PublicationEdited";

            public const string RejectPublication = "RejectPublication";
        }
        public class Settings
        {
            public const string ClientBaseUrl = "ClientBaseUrl";

            public const string ApiBaseUrl = "ApiBaseUrl";
        }

        public class Auth
        {
            public const string Username = "Username";
            public const string UserId = "UserId";
            public const string EmailConfirmed = "EmailConfirmed";
        }

        public class AspNetRoles
        {
            public const string Admin = "Admin";  
        }
    }
}
