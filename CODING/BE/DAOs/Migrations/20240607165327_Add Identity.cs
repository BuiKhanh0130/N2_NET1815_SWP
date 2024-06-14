using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAOs.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ConversationID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Conversa__C050D897C401235F", x => x.ConversationID);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grade__54F87A37CC152DE4", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE3A42B64DA9", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectGroup",
                columns: table => new
                {
                    SubjectGroupID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    SubjectName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SubjectG__2F88B016AD652F27", x => x.SubjectGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateExpireRefreshToken = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(5)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    GradeID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    SubjectGroupID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subject__AC1BA388537DD7A1", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FKSubject340947",
                        column: x => x.SubjectGroupID,
                        principalTable: "SubjectGroup",
                        principalColumn: "SubjectGroupID");
                    table.ForeignKey(
                        name: "FKSubject866932",
                        column: x => x.GradeID,
                        principalTable: "Grade",
                        principalColumn: "GradeID");
                });

            migrationBuilder.CreateTable(
                name: "Conversation_Account",
                columns: table => new
                {
                    ConversationID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Conversa__B31902CF056C16DA", x => new { x.ConversationID, x.AccountID });
                    table.ForeignKey(
                        name: "FKConversati818528",
                        column: x => x.AccountID,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FKConversati872380",
                        column: x => x.ConversationID,
                        principalTable: "Conversation",
                        principalColumn: "ConversationID");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Time = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ConversationID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Message__C87C037C2D324FDF", x => x.MessageID);
                    table.ForeignKey(
                        name: "FKMessage125602",
                        column: x => x.ConversationID,
                        principalTable: "Conversation",
                        principalColumn: "ConversationID");
                    table.ForeignKey(
                        name: "FKMessage179454",
                        column: x => x.AccountID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E32FFBD5FC4", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FKNotificati765224",
                        column: x => x.AccountID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    SchoolName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AccountID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__32C52A79D012377F", x => x.StudentID);
                    table.ForeignKey(
                        name: "FKStudent718314",
                        column: x => x.AccountID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    TutorID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    Education = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TypeOfDegree = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<float>(type: "real", nullable: false),
                    Photo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Headline = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tutor__77C70FC2A16C50DB", x => x.TutorID);
                    table.ForeignKey(
                        name: "FKTutor387597",
                        column: x => x.AccountID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    WalletID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    BankName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    BankNumber = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Wallet__84D4F92E9F63180B", x => x.WalletID);
                    table.ForeignKey(
                        name: "FKWallet115696",
                        column: x => x.AccountID,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FindTutorForm",
                columns: table => new
                {
                    FormID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    SubjectName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TutorGender = table.Column<bool>(type: "bit", nullable: false),
                    TypeOfDegree = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DescribeTutor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StudentID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    SubjectID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FindTuto__FB05B7BD12F4FFB4", x => x.FormID);
                    table.ForeignKey(
                        name: "FKFindTutorF134374",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FKFindTutorF727263",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TutorID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    StudentID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    SubjectID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Class__CB1927A0090BF352", x => x.ClassID);
                    table.ForeignKey(
                        name: "FKClass105998",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID");
                    table.ForeignKey(
                        name: "FKClass301112",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FKClass479452",
                        column: x => x.TutorID,
                        principalTable: "Tutor",
                        principalColumn: "TutorID");
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TutorID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    StudentID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complain__740D89AFCEF50736", x => x.ComplaintID);
                    table.ForeignKey(
                        name: "FKComplaint196647",
                        column: x => x.TutorID,
                        principalTable: "Tutor",
                        principalColumn: "TutorID");
                    table.ForeignKey(
                        name: "FKComplaint416082",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateTable(
                name: "Subject_Tutor",
                columns: table => new
                {
                    SubjectID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    TutorID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subject___9B67D374BBB4AFD2", x => new { x.SubjectID, x.TutorID });
                    table.ForeignKey(
                        name: "FKSubject_Tu3188",
                        column: x => x.TutorID,
                        principalTable: "Tutor",
                        principalColumn: "TutorID");
                    table.ForeignKey(
                        name: "FKSubject_Tu675031",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateTable(
                name: "Tutor_Ads",
                columns: table => new
                {
                    AdsID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Video = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TutorID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tutor_Ad__46AAC65A5EF65941", x => x.AdsID);
                    table.ForeignKey(
                        name: "FKTutor_Ads572887",
                        column: x => x.TutorID,
                        principalTable: "Tutor",
                        principalColumn: "TutorID");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    TransactionMoney = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    WalletID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transact__55433A4B61451DBE", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FKTransactio181260",
                        column: x => x.WalletID,
                        principalTable: "Wallet",
                        principalColumn: "WalletID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CreateDay = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StudentID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    TutorID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    ClassID = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__6A4BEDF65E258262", x => x.FeedbackID);
                    table.ForeignKey(
                        name: "FKFeedback348843",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                    table.ForeignKey(
                        name: "FKFeedback431721",
                        column: x => x.TutorID,
                        principalTable: "Tutor",
                        principalColumn: "TutorID");
                    table.ForeignKey(
                        name: "FKFeedback912586",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_StudentID",
                table: "Class",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_SubjectID",
                table: "Class",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TutorID",
                table: "Class",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_StudentID",
                table: "Complaint",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_TutorID",
                table: "Complaint",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_Account_AccountID",
                table: "Conversation_Account",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ClassID",
                table: "Feedback",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_StudentID",
                table: "Feedback",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_TutorID",
                table: "Feedback",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_FindTutorForm_StudentID",
                table: "FindTutorForm",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_FindTutorForm_SubjectID",
                table: "FindTutorForm",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_AccountID",
                table: "Message",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ConversationID",
                table: "Message",
                column: "ConversationID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_AccountID",
                table: "Notification",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AccountID",
                table: "Student",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_GradeID",
                table: "Subject",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SubjectGroupID",
                table: "Subject",
                column: "SubjectGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Tutor_TutorID",
                table: "Subject_Tutor",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_WalletID",
                table: "Transaction",
                column: "WalletID");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_AccountID",
                table: "Tutor",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Tutor_Ads_TutorID",
                table: "Tutor_Ads",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_AccountID",
                table: "Wallet",
                column: "AccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Conversation_Account");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "FindTutorForm");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Subject_Tutor");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Tutor_Ads");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropTable(
                name: "SubjectGroup");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
