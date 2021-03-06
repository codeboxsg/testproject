



















// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `ApplicationServices`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `data source=idea-pc\SQLEXPRESS2008r2;Initial Catalog=redemptiondb2;User ID=redemptionuser;password=**zapped**;`
//     Schema:                 ``
//     Include Views:          `True`



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace ApplicationServices
{

	public partial class ApplicationServicesDB : Database
	{
		public ApplicationServicesDB() 
			: base("ApplicationServices")
		{
			CommonConstruct();
		}

		public ApplicationServicesDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			ApplicationServicesDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static ApplicationServicesDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new ApplicationServicesDB();
        }

		[ThreadStatic] static ApplicationServicesDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        

		public class Record<T> where T:new()
		{
			public static ApplicationServicesDB repo { get { return ApplicationServicesDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }

			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }

			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }

		}

	}
	



    
	[TableName("RedemptionByPointReceipt")]


	[PrimaryKey("redemptionbypointreceiptid")]



	[ExplicitColumns]
    public partial class RedemptionByPointReceipt : ApplicationServicesDB.Record<RedemptionByPointReceipt>  
    {



		[Column] public int redemptionbypointreceiptid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string receiptpath { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public int status { get; set; }





		[Column] public string invoiceno { get; set; }





		[Column] public int totalpoints { get; set; }





		[Column] public int? resellerid { get; set; }





		[Column] public DateTime? purchasedate { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("RedemptionByPointReceiptItem")]


	[PrimaryKey("redemptionbypointreceiptitemid")]



	[ExplicitColumns]
    public partial class RedemptionByPointReceiptItem : ApplicationServicesDB.Record<RedemptionByPointReceiptItem>  
    {



		[Column] public int redemptionbypointreceiptitemid { get; set; }





		[Column] public int redemptionbypointreceiptid { get; set; }





		[Column] public int productid { get; set; }





		[Column] public string serialno { get; set; }





		[Column] public string productmodel { get; set; }





		[Column] public int productpoints { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("RedemptionByPointTransaction")]


	[PrimaryKey("redemptionbypointtransactionid")]



	[ExplicitColumns]
    public partial class RedemptionByPointTransaction : ApplicationServicesDB.Record<RedemptionByPointTransaction>  
    {



		[Column] public int redemptionbypointtransactionid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public int type { get; set; }





		[Column] public int points { get; set; }





		[Column] public int balance { get; set; }





		[Column] public string notes { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("RedemptionChild")]


	[PrimaryKey("childid")]



	[ExplicitColumns]
    public partial class RedemptionChild : ApplicationServicesDB.Record<RedemptionChild>  
    {



		[Column] public int childid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string firstname { get; set; }





		[Column] public string lastname { get; set; }





		[Column] public bool gender { get; set; }





		[Column] public DateTime dateofbirth { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("PromotionByPointReward")]


	[PrimaryKey("promotionid", autoIncrement=false)]

	[ExplicitColumns]
    public partial class PromotionByPointReward : ApplicationServicesDB.Record<PromotionByPointReward>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("aspnet_Applications")]


	[PrimaryKey("ApplicationId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_Application : ApplicationServicesDB.Record<aspnet_Application>  
    {



		[Column] public string ApplicationName { get; set; }





		[Column] public string LoweredApplicationName { get; set; }





		[Column] public Guid ApplicationId { get; set; }





		[Column] public string Description { get; set; }



	}

    
	[TableName("aspnet_Membership")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_Membership : ApplicationServicesDB.Record<aspnet_Membership>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string Password { get; set; }





		[Column] public int PasswordFormat { get; set; }





		[Column] public string PasswordSalt { get; set; }





		[Column] public string MobilePIN { get; set; }





		[Column] public string Email { get; set; }





		[Column] public string LoweredEmail { get; set; }





		[Column] public string PasswordQuestion { get; set; }





		[Column] public string PasswordAnswer { get; set; }





		[Column] public bool IsApproved { get; set; }





		[Column] public bool IsLockedOut { get; set; }





		[Column] public DateTime CreateDate { get; set; }





		[Column] public DateTime LastLoginDate { get; set; }





		[Column] public DateTime LastPasswordChangedDate { get; set; }





		[Column] public DateTime LastLockoutDate { get; set; }





		[Column] public int FailedPasswordAttemptCount { get; set; }





		[Column] public DateTime FailedPasswordAttemptWindowStart { get; set; }





		[Column] public int FailedPasswordAnswerAttemptCount { get; set; }





		[Column] public DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }





		[Column] public string Comment { get; set; }



	}

    
	[TableName("aspnet_Paths")]


	[PrimaryKey("PathId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_Path : ApplicationServicesDB.Record<aspnet_Path>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid PathId { get; set; }





		[Column] public string Path { get; set; }





		[Column] public string LoweredPath { get; set; }



	}

    
	[TableName("RedemptionMember")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class RedemptionMember : ApplicationServicesDB.Record<RedemptionMember>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public string firstname { get; set; }





		[Column] public string lastname { get; set; }





		[Column] public bool gender { get; set; }





		[Column] public string contactno { get; set; }





		[Column] public string NRIC { get; set; }





		[Column] public DateTime dateofbirth { get; set; }





		[Column] public string mailingaddress { get; set; }





		[Column] public string postalcode { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("aspnet_PersonalizationAllUsers")]


	[PrimaryKey("PathId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_PersonalizationAllUser : ApplicationServicesDB.Record<aspnet_PersonalizationAllUser>  
    {



		[Column] public Guid PathId { get; set; }





		[Column] public byte[] PageSettings { get; set; }





		[Column] public DateTime LastUpdatedDate { get; set; }



	}

    
	[TableName("RedemptionMemberClient")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class RedemptionMemberClient : ApplicationServicesDB.Record<RedemptionMemberClient>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public int pointbalance { get; set; }





		[Column] public bool discliamer { get; set; }





		[Column] public bool receivenewsletter { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("aspnet_PersonalizationPerUser")]


	[PrimaryKey("Id", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_PersonalizationPerUser : ApplicationServicesDB.Record<aspnet_PersonalizationPerUser>  
    {



		[Column] public Guid Id { get; set; }





		[Column] public Guid? PathId { get; set; }





		[Column] public Guid? UserId { get; set; }





		[Column] public byte[] PageSettings { get; set; }





		[Column] public DateTime LastUpdatedDate { get; set; }



	}

    
	[TableName("aspnet_Profile")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_Profile : ApplicationServicesDB.Record<aspnet_Profile>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public string PropertyNames { get; set; }





		[Column] public string PropertyValuesString { get; set; }





		[Column] public byte[] PropertyValuesBinary { get; set; }





		[Column] public DateTime LastUpdatedDate { get; set; }



	}

    
	[TableName("AuditLog")]


	[PrimaryKey("Id")]



	[ExplicitColumns]
    public partial class AuditLog : ApplicationServicesDB.Record<AuditLog>  
    {



		[Column] public int Id { get; set; }





		[Column] public DateTime Date { get; set; }





		[Column] public string Thread { get; set; }





		[Column] public string Level { get; set; }





		[Column] public string Logger { get; set; }





		[Column] public string Message { get; set; }





		[Column] public string Exception { get; set; }



	}

    
	[TableName("aspnet_Roles")]


	[PrimaryKey("RoleId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_Role : ApplicationServicesDB.Record<aspnet_Role>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid RoleId { get; set; }





		[Column] public string RoleName { get; set; }





		[Column] public string LoweredRoleName { get; set; }





		[Column] public string Description { get; set; }



	}

    
	[TableName("aspnet_SchemaVersions")]


	[PrimaryKey("Feature", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_SchemaVersion : ApplicationServicesDB.Record<aspnet_SchemaVersion>  
    {



		[Column] public string Feature { get; set; }





		[Column] public string CompatibleSchemaVersion { get; set; }





		[Column] public bool IsCurrentVersion { get; set; }



	}

    
	[TableName("aspnet_Users")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_User : ApplicationServicesDB.Record<aspnet_User>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public string LoweredUserName { get; set; }





		[Column] public string MobileAlias { get; set; }





		[Column] public bool IsAnonymous { get; set; }





		[Column] public DateTime LastActivityDate { get; set; }



	}

    
	[TableName("aspnet_UsersInRoles")]


	[PrimaryKey("UserId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_UsersInRole : ApplicationServicesDB.Record<aspnet_UsersInRole>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public Guid RoleId { get; set; }



	}

    
	[TableName("aspnet_WebEvent_Events")]


	[PrimaryKey("EventId", autoIncrement=false)]

	[ExplicitColumns]
    public partial class aspnet_WebEvent_Event : ApplicationServicesDB.Record<aspnet_WebEvent_Event>  
    {



		[Column] public string EventId { get; set; }





		[Column] public DateTime EventTimeUtc { get; set; }





		[Column] public DateTime EventTime { get; set; }





		[Column] public string EventType { get; set; }





		[Column] public decimal EventSequence { get; set; }





		[Column] public decimal EventOccurrence { get; set; }





		[Column] public int EventCode { get; set; }





		[Column] public int EventDetailCode { get; set; }





		[Column] public string Message { get; set; }





		[Column] public string ApplicationPath { get; set; }





		[Column] public string ApplicationVirtualPath { get; set; }





		[Column] public string MachineName { get; set; }





		[Column] public string RequestUrl { get; set; }





		[Column] public string ExceptionType { get; set; }





		[Column] public string Details { get; set; }



	}

    
	[TableName("StockReceive")]


	[PrimaryKey("stockreceiveid")]



	[ExplicitColumns]
    public partial class StockReceive : ApplicationServicesDB.Record<StockReceive>  
    {



		[Column] public int stockreceiveid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public string rewardname { get; set; }





		[Column] public int companyid { get; set; }





		[Column] public string companyname { get; set; }





		[Column] public int qty { get; set; }





		[Column] public int balance { get; set; }





		[Column] public string invoice { get; set; }





		[Column] public string remarks { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("vw_aspnet_Applications")]


	[ExplicitColumns]
    public partial class vw_aspnet_Application : ApplicationServicesDB.Record<vw_aspnet_Application>  
    {



		[Column] public string ApplicationName { get; set; }





		[Column] public string LoweredApplicationName { get; set; }





		[Column] public Guid ApplicationId { get; set; }





		[Column] public string Description { get; set; }



	}

    
	[TableName("vw_aspnet_MembershipUsers")]


	[ExplicitColumns]
    public partial class vw_aspnet_MembershipUser : ApplicationServicesDB.Record<vw_aspnet_MembershipUser>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public int PasswordFormat { get; set; }





		[Column] public string MobilePIN { get; set; }





		[Column] public string Email { get; set; }





		[Column] public string LoweredEmail { get; set; }





		[Column] public string PasswordQuestion { get; set; }





		[Column] public string PasswordAnswer { get; set; }





		[Column] public bool IsApproved { get; set; }





		[Column] public bool IsLockedOut { get; set; }





		[Column] public DateTime CreateDate { get; set; }





		[Column] public DateTime LastLoginDate { get; set; }





		[Column] public DateTime LastPasswordChangedDate { get; set; }





		[Column] public DateTime LastLockoutDate { get; set; }





		[Column] public int FailedPasswordAttemptCount { get; set; }





		[Column] public DateTime FailedPasswordAttemptWindowStart { get; set; }





		[Column] public int FailedPasswordAnswerAttemptCount { get; set; }





		[Column] public DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }





		[Column] public string Comment { get; set; }





		[Column] public Guid ApplicationId { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public string MobileAlias { get; set; }





		[Column] public bool IsAnonymous { get; set; }





		[Column] public DateTime LastActivityDate { get; set; }



	}

    
	[TableName("vw_aspnet_Profiles")]


	[ExplicitColumns]
    public partial class vw_aspnet_Profile : ApplicationServicesDB.Record<vw_aspnet_Profile>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public DateTime LastUpdatedDate { get; set; }





		[Column] public int? DataSize { get; set; }



	}

    
	[TableName("RedemptionByProductReceipt")]


	[PrimaryKey("redemptionbyproductreceiptid")]



	[ExplicitColumns]
    public partial class RedemptionByProductReceipt : ApplicationServicesDB.Record<RedemptionByProductReceipt>  
    {



		[Column] public int redemptionbyproductreceiptid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string receiptpath { get; set; }





		[Column] public int status { get; set; }





		[Column] public string invoiceno { get; set; }





		[Column] public int? resellerid { get; set; }





		[Column] public DateTime? purchasedate { get; set; }





		[Column] public int promotionid { get; set; }





		[Column] public string promotionname { get; set; }





		[Column] public int modeofcollection { get; set; }





		[Column] public string remarks { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("vw_aspnet_Roles")]


	[ExplicitColumns]
    public partial class vw_aspnet_Role : ApplicationServicesDB.Record<vw_aspnet_Role>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid RoleId { get; set; }





		[Column] public string RoleName { get; set; }





		[Column] public string LoweredRoleName { get; set; }





		[Column] public string Description { get; set; }



	}

    
	[TableName("vw_aspnet_Users")]


	[ExplicitColumns]
    public partial class vw_aspnet_User : ApplicationServicesDB.Record<vw_aspnet_User>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public string LoweredUserName { get; set; }





		[Column] public string MobileAlias { get; set; }





		[Column] public bool IsAnonymous { get; set; }





		[Column] public DateTime LastActivityDate { get; set; }



	}

    
	[TableName("RedemptionReward")]


	[PrimaryKey("redemptionrewardid")]



	[ExplicitColumns]
    public partial class RedemptionReward : ApplicationServicesDB.Record<RedemptionReward>  
    {



		[Column] public int redemptionrewardid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public int? redemptionbyproductreceiptid { get; set; }





		[Column] public int promotionid { get; set; }





		[Column] public string promotionname { get; set; }





		[Column] public int productid { get; set; }





		[Column] public string productname { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public string rewardname { get; set; }





		[Column] public int rewardpoints { get; set; }





		[Column] public int modeofcollection { get; set; }





		[Column] public string serialno { get; set; }





		[Column] public string remarks { get; set; }





		[Column] public int type { get; set; }





		[Column] public int status { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("vw_aspnet_UsersInRoles")]


	[ExplicitColumns]
    public partial class vw_aspnet_UsersInRole : ApplicationServicesDB.Record<vw_aspnet_UsersInRole>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public Guid RoleId { get; set; }



	}

    
	[TableName("vw_aspnet_WebPartState_Paths")]


	[ExplicitColumns]
    public partial class vw_aspnet_WebPartState_Path : ApplicationServicesDB.Record<vw_aspnet_WebPartState_Path>  
    {



		[Column] public Guid ApplicationId { get; set; }





		[Column] public Guid PathId { get; set; }





		[Column] public string Path { get; set; }





		[Column] public string LoweredPath { get; set; }



	}

    
	[TableName("View_1")]


	[ExplicitColumns]
    public partial class View_1 : ApplicationServicesDB.Record<View_1>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public int points { get; set; }





		[Column] public int qty { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }





		[Column] public string promotionname { get; set; }





		[Column] public string brief { get; set; }





		[Column] public DateTime startdate { get; set; }





		[Column] public DateTime enddate { get; set; }



	}

    
	[TableName("vw_aspnet_WebPartState_Shared")]


	[ExplicitColumns]
    public partial class vw_aspnet_WebPartState_Shared : ApplicationServicesDB.Record<vw_aspnet_WebPartState_Shared>  
    {



		[Column] public Guid PathId { get; set; }





		[Column] public int? DataSize { get; set; }





		[Column] public DateTime LastUpdatedDate { get; set; }



	}

    
	[TableName("View_2")]


	[ExplicitColumns]
    public partial class View_2 : ApplicationServicesDB.Record<View_2>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public int points { get; set; }





		[Column] public int qty { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }





		[Column] public string promotionname { get; set; }





		[Column] public string brief { get; set; }





		[Column] public DateTime startdate { get; set; }





		[Column] public DateTime enddate { get; set; }



	}

    
	[TableName("vw_aspnet_WebPartState_User")]


	[ExplicitColumns]
    public partial class vw_aspnet_WebPartState_User : ApplicationServicesDB.Record<vw_aspnet_WebPartState_User>  
    {



		[Column] public Guid? PathId { get; set; }





		[Column] public Guid? UserId { get; set; }





		[Column] public int? DataSize { get; set; }





		[Column] public DateTime LastUpdatedDate { get; set; }



	}

    
	[TableName("View_3")]


	[ExplicitColumns]
    public partial class View_3 : ApplicationServicesDB.Record<View_3>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public int points { get; set; }





		[Column] public int qty { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }





		[Column] public string promotionname { get; set; }





		[Column] public string brief { get; set; }





		[Column] public DateTime startdate { get; set; }





		[Column] public DateTime enddate { get; set; }



	}

    
	[TableName("RedemptionPointTransaction")]


	[PrimaryKey("redemptionbypointtransactionid")]



	[ExplicitColumns]
    public partial class RedemptionPointTransaction : ApplicationServicesDB.Record<RedemptionPointTransaction>  
    {



		[Column] public int redemptionbypointtransactionid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public int type { get; set; }





		[Column] public int points { get; set; }





		[Column] public int balance { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("Reward")]


	[PrimaryKey("rewardid")]



	[ExplicitColumns]
    public partial class Reward : ApplicationServicesDB.Record<Reward>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string brief { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public int points { get; set; }





		[Column] public int qty { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("PromotionByPointProduct")]


	[PrimaryKey("promotionid", autoIncrement=false)]

	[ExplicitColumns]
    public partial class PromotionByPointProduct : ApplicationServicesDB.Record<PromotionByPointProduct>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int productid { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("Event")]


	[PrimaryKey("eventid")]



	[ExplicitColumns]
    public partial class Event : ApplicationServicesDB.Record<Event>  
    {



		[Column] public int eventid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string brief { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public string url { get; set; }





		[Column] public DateTime startdate { get; set; }





		[Column] public DateTime enddate { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("PromotionByProductProductReward")]


	[PrimaryKey("promotionid", autoIncrement=false)]

	[ExplicitColumns]
    public partial class PromotionByProductProductReward : ApplicationServicesDB.Record<PromotionByProductProductReward>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int productid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("Promotion")]


	[PrimaryKey("promotionid")]



	[ExplicitColumns]
    public partial class Promotion : ApplicationServicesDB.Record<Promotion>  
    {



		[Column] public int promotionid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string brief { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public DateTime startdate { get; set; }





		[Column] public DateTime enddate { get; set; }





		[Column] public DateTime gracedate { get; set; }





		[Column] public string prefix { get; set; }





		[Column] public int type { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("StockOut")]


	[PrimaryKey("stockoutid")]



	[ExplicitColumns]
    public partial class StockOut : ApplicationServicesDB.Record<StockOut>  
    {



		[Column] public int stockoutid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public string rewardname { get; set; }





		[Column] public int companyid { get; set; }





		[Column] public string companyname { get; set; }





		[Column] public int qty { get; set; }





		[Column] public int balance { get; set; }





		[Column] public string invoice { get; set; }





		[Column] public string remarks { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("StockReturn")]


	[PrimaryKey("stockreturnid")]



	[ExplicitColumns]
    public partial class StockReturn : ApplicationServicesDB.Record<StockReturn>  
    {



		[Column] public int stockreturnid { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public string rewardname { get; set; }





		[Column] public int companyid { get; set; }





		[Column] public string companyname { get; set; }





		[Column] public int qty { get; set; }





		[Column] public int balance { get; set; }





		[Column] public string invoice { get; set; }





		[Column] public string remarks { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("ViewStockSummary")]


	[ExplicitColumns]
    public partial class ViewStockSummary : ApplicationServicesDB.Record<ViewStockSummary>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public string name { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public int AvailableBalanceFromReward { get; set; }





		[Column] public int? AvailableBalanceCalculated { get; set; }





		[Column] public int? TotalIn { get; set; }





		[Column] public int? TotalOut { get; set; }





		[Column] public int? TotalReturn { get; set; }





		[Column] public int? Redemption { get; set; }





		[Column] public int? Redeemed { get; set; }





		[Column] public int? Outstanding { get; set; }





		[Column] public int? PhysicalBalance { get; set; }



	}

    
	[TableName("ViewRedemption")]


	[ExplicitColumns]
    public partial class ViewRedemption : ApplicationServicesDB.Record<ViewRedemption>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public int? count { get; set; }



	}

    
	[TableName("ViewRedeemed")]


	[ExplicitColumns]
    public partial class ViewRedeemed : ApplicationServicesDB.Record<ViewRedeemed>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public int? Redeemed { get; set; }



	}

    
	[TableName("ViewOutstanding")]


	[ExplicitColumns]
    public partial class ViewOutstanding : ApplicationServicesDB.Record<ViewOutstanding>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public int? Outstanding { get; set; }



	}

    
	[TableName("ViewRedemptionReward")]


	[ExplicitColumns]
    public partial class ViewRedemptionReward : ApplicationServicesDB.Record<ViewRedemptionReward>  
    {



		[Column] public int redemptionrewardid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public Guid UserId { get; set; }





		[Column] public int? redemptionbyproductreceiptid { get; set; }





		[Column] public int promotionid { get; set; }





		[Column] public string promotionname { get; set; }





		[Column] public int productid { get; set; }





		[Column] public string productname { get; set; }





		[Column] public int rewardid { get; set; }





		[Column] public string rewardname { get; set; }





		[Column] public int rewardpoints { get; set; }





		[Column] public int modeofcollection { get; set; }





		[Column] public string serialno { get; set; }





		[Column] public string remarks { get; set; }





		[Column] public int status { get; set; }





		[Column] public int type { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }





		[Column] public string productmodel { get; set; }





		[Column] public string firstname { get; set; }





		[Column] public string lastname { get; set; }





		[Column] public bool? gender { get; set; }





		[Column] public string contactno { get; set; }





		[Column] public string NRIC { get; set; }





		[Column] public DateTime? dateofbirth { get; set; }





		[Column] public string mailingaddress { get; set; }





		[Column] public string postalcode { get; set; }



	}

    
	[TableName("ViewRedemptionRewardProductSummary")]


	[ExplicitColumns]
    public partial class ViewRedemptionRewardProductSummary : ApplicationServicesDB.Record<ViewRedemptionRewardProductSummary>  
    {



		[Column] public int ProductID { get; set; }





		[Column] public string ProductName { get; set; }





		[Column] public string ProductModel { get; set; }





		[Column] public int? PurchaseQty { get; set; }



	}

    
	[TableName("Product")]


	[PrimaryKey("productid")]



	[ExplicitColumns]
    public partial class Product : ApplicationServicesDB.Record<Product>  
    {



		[Column] public int productid { get; set; }





		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string model { get; set; }





		[Column] public string description { get; set; }





		[Column] public string imagepath { get; set; }





		[Column] public int points { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("ViewRedemptionRewardRewardSummary")]


	[ExplicitColumns]
    public partial class ViewRedemptionRewardRewardSummary : ApplicationServicesDB.Record<ViewRedemptionRewardRewardSummary>  
    {



		[Column] public int RewardId { get; set; }





		[Column] public string RewardName { get; set; }





		[Column] public int? RedeemQty { get; set; }



	}

    
	[TableName("ViewAdminUser")]


	[ExplicitColumns]
    public partial class ViewAdminUser : ApplicationServicesDB.Record<ViewAdminUser>  
    {



		[Column] public Guid UserId { get; set; }





		[Column] public string UserName { get; set; }





		[Column] public string LoweredUserName { get; set; }





		[Column] public string Email { get; set; }





		[Column] public string LoweredEmail { get; set; }





		[Column] public DateTime CreateDate { get; set; }





		[Column] public string RoleName { get; set; }



	}

    
	[TableName("ViewStockOut")]


	[ExplicitColumns]
    public partial class ViewStockOut : ApplicationServicesDB.Record<ViewStockOut>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public int? TotalOut { get; set; }



	}

    
	[TableName("ViewStockReturn")]


	[ExplicitColumns]
    public partial class ViewStockReturn : ApplicationServicesDB.Record<ViewStockReturn>  
    {



		[Column] public int rewardid { get; set; }





		[Column] public int? TotalReturn { get; set; }



	}

    
	[TableName("Client")]


	[PrimaryKey("clientid")]



	[ExplicitColumns]
    public partial class Client : ApplicationServicesDB.Record<Client>  
    {



		[Column] public int clientid { get; set; }





		[Column] public string name { get; set; }





		[Column] public string contactname { get; set; }





		[Column] public string phoneno { get; set; }





		[Column] public string logoimagename { get; set; }





		[Column] public string siterelativepath { get; set; }





		[Column] public string emailphysicalpath { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}

    
	[TableName("Reseller")]


	[PrimaryKey("resellerid")]



	[ExplicitColumns]
    public partial class Reseller : ApplicationServicesDB.Record<Reseller>  
    {



		[Column] public int resellerid { get; set; }





		[Column] public string name { get; set; }





		[Column] public DateTime dateentry { get; set; }





		[Column] public DateTime datemodified { get; set; }



	}


}



