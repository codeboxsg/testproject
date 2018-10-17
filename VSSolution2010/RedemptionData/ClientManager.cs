using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationServices;
using System.Dynamic;
using PetaPoco;
namespace RedemptionData
{
    public class ClientManager
    {
        #region StockSummary
        private const string ALL_VIEWSTOCKSUMMARY_BYCLIENTID = @"SELECT 
rewardid, name, clientid, 
AvailableBalanceFromReward, AvailableBalanceCalculated, 
TotalIn, TotalOut, TotalReturn,
Redemption, Redeemed, Outstanding, 
PhysicalBalance 
FROM dbo.ViewStockSummary 
where (clientid = @0)
order by rewardid  ";
        [Serializable]
        public sealed class ViewStockSummary2
        {
            public int rewardid { get; set; }
            public string name { get; set; }
            public int clientid { get; set; }
            public int AvailableBalanceFromReward { get; set; }
            public int AvailableBalanceCalculated { get; set; }
            public int TotalIn { get; set; }
            public int TotalOut { get; set; }
            public int TotalReturn { get; set; }
            public int Redemption { get; set; }
            public int Redeemed { get; set; }
            public int Outstanding { get; set; }
            public int PhysicalBalance { get; set; }

        }

        public static List<ViewStockSummary2> getStockSummaryByClient(int clientid)
        {
            List<ViewStockSummary2> lst = new List<ViewStockSummary2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_VIEWSTOCKSUMMARY_BYCLIENTID, clientid))
                {
                    var vewStockSummary = new ViewStockSummary2();
                    vewStockSummary.rewardid = a.rewardid;
                    vewStockSummary.name = a.name;
                    vewStockSummary.clientid = a.clientid;

                    vewStockSummary.AvailableBalanceFromReward = a.AvailableBalanceFromReward;
                    vewStockSummary.AvailableBalanceCalculated = a.AvailableBalanceCalculated;

                    vewStockSummary.TotalIn = a.TotalIn;
                    vewStockSummary.TotalOut = a.TotalOut;
                    vewStockSummary.TotalReturn = a.TotalReturn;

                    vewStockSummary.Redemption = a.Redemption;
                    vewStockSummary.Redeemed = a.Redeemed;
                    vewStockSummary.Outstanding = a.Outstanding;

                    vewStockSummary.PhysicalBalance = a.PhysicalBalance;

                    lst.Add(vewStockSummary);
                }
                return lst;
            }
        }


        private const string ALL_VIEWSTOCKRECEIVE_BYCLIENTID = @"SELECT     
dbo.StockReceive.stockreceiveid, 
dbo.StockReceive.rewardid, dbo.StockReceive.rewardname, 
dbo.Reward.clientid, dbo.Client.name AS clientname, 
dbo.StockReceive.companyid, dbo.StockReceive.companyname, 
dbo.StockReceive.qty, dbo.StockReceive.balance,
dbo.StockReceive.invoice, dbo.StockReceive.remarks, dbo.StockReceive.dateentry, 
                      dbo.StockReceive.datemodified
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Reward ON dbo.Client.clientid = dbo.Reward.clientid RIGHT OUTER JOIN
                      dbo.StockReceive ON dbo.Reward.rewardid = dbo.StockReceive.rewardid
where (dbo.Reward.clientid = @0)
order by rewardid  ";
        [Serializable]
        public sealed class StockReceive2
        {
            public int stockreceiveid { get; set; }
            public int rewardid { get; set; }
            public string rewardname { get; set; }
            public int clientid { get; set; }
            public string clientname { get; set; }

            //public int companyid { get; set; }
            public string companyname { get; set; }
            public int qty { get; set; }
            public int balance { get; set; }
            public string invoice { get; set; }
            public string remarks { get; set; }
            public DateTime dateentry { get; set; }
        }
        public static List<StockReceive2> getStockReceiveByClientid(int clientid)
        {
            List<StockReceive2> lst = new List<StockReceive2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_VIEWSTOCKRECEIVE_BYCLIENTID, clientid))
                {
                    var stockReceive2 = new StockReceive2();
                    stockReceive2.stockreceiveid = a.stockreceiveid;

                    stockReceive2.rewardid = a.rewardid;
                    stockReceive2.rewardname = a.rewardname;
                    stockReceive2.clientid = a.clientid;
                    stockReceive2.clientname = a.clientname;
                    //stockReceive2.companyid = a.companyid;
                    stockReceive2.companyname = a.companyname;
                    stockReceive2.qty = a.qty;
                    stockReceive2.balance = a.balance;
                    stockReceive2.invoice = a.invoice;
                    stockReceive2.remarks = a.remarks;
                    stockReceive2.dateentry = a.dateentry;
                    lst.Add(stockReceive2);
                }
                return lst;
            }
        }


        private const string ALL_VIEWSTOCKOUT = @"SELECT     
dbo.StockOut.StockOutid, 
dbo.StockOut.rewardid, dbo.StockOut.rewardname, 
dbo.Reward.clientid, dbo.Client.name AS clientname, 
dbo.StockOut.companyid, dbo.StockOut.companyname, 
dbo.StockOut.qty, dbo.StockOut.balance,
dbo.StockOut.invoice, dbo.StockOut.remarks, dbo.StockOut.dateentry, 
                      dbo.StockOut.datemodified
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Reward ON dbo.Client.clientid = dbo.Reward.clientid RIGHT OUTER JOIN
                      dbo.StockOut ON dbo.Reward.rewardid = dbo.StockOut.rewardid
where (dbo.Reward.clientid = @0)
order by rewardid  ";
        [Serializable]
        public sealed class StockOut2
        {
            public int StockOutid { get; set; }
            public int rewardid { get; set; }
            public string rewardname { get; set; }
            public int clientid { get; set; }
            public string clientname { get; set; }

           // public int companyid { get; set; }
            public string companyname { get; set; }
            public int qty { get; set; }
            public int balance { get; set; }
            public string invoice { get; set; }
            public string remarks { get; set; }
            public DateTime dateentry { get; set; }
        }
        public static List<StockOut2> getStockOutByClientid(int clientid)
        {
            List<StockOut2> lst = new List<StockOut2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_VIEWSTOCKOUT, clientid))
                {
                    var stockReceive2 = new StockOut2();
                    stockReceive2.StockOutid = a.StockOutid;

                    stockReceive2.rewardid = a.rewardid;
                    stockReceive2.rewardname = a.rewardname;
                    stockReceive2.clientid = a.clientid;
                    stockReceive2.clientname = a.clientname;
                  //  stockReceive2.companyid = a.companyid;
                    stockReceive2.companyname = a.companyname;
                    stockReceive2.qty = a.qty;
                    stockReceive2.balance = a.balance;
                    stockReceive2.invoice = a.invoice;
                    stockReceive2.remarks = a.remarks;
                    stockReceive2.dateentry = a.dateentry;
                    lst.Add(stockReceive2);
                }
                return lst;
            }
        }

        private const string ALL_VIEWSTOCKRETURN = @"SELECT     
dbo.StockReturn.StockReturnid, 
dbo.StockReturn.rewardid, dbo.StockReturn.rewardname, 
dbo.Reward.clientid, dbo.Client.name AS clientname, 
dbo.StockReturn.companyid, dbo.StockReturn.companyname, 
dbo.StockReturn.qty, dbo.StockReturn.balance,
dbo.StockReturn.invoice, dbo.StockReturn.remarks, dbo.StockReturn.dateentry, 
                      dbo.StockReturn.datemodified
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Reward ON dbo.Client.clientid = dbo.Reward.clientid RIGHT OUTER JOIN
                      dbo.StockReturn ON dbo.Reward.rewardid = dbo.StockReturn.rewardid
where (dbo.Reward.clientid = @0)
order by rewardid  ";
        [Serializable]
        public sealed class StockReturn2
        {
            public int StockReturnid { get; set; }
            public int rewardid { get; set; }
            public string rewardname { get; set; }
            public int clientid { get; set; }
            public string clientname { get; set; }

           // public int companyid { get; set; }
            public string companyname { get; set; }
            public int qty { get; set; }
            public int balance { get; set; }
            public string invoice { get; set; }
            public string remarks { get; set; }
            public DateTime dateentry { get; set; }
        }
        public static List<StockReturn2> getStockReturnByClientid(int clientid)
        {
            List<StockReturn2> lst = new List<StockReturn2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_VIEWSTOCKRETURN, clientid))
                {
                    var stockReceive2 = new StockReturn2();
                    stockReceive2.StockReturnid = a.StockReturnid;

                    stockReceive2.rewardid = a.rewardid;
                    stockReceive2.rewardname = a.rewardname;
                    stockReceive2.clientid = a.clientid;
                    stockReceive2.clientname = a.clientname;
                   // stockReceive2.companyid = a.companyid;
                    stockReceive2.companyname = a.companyname;
                    stockReceive2.qty = a.qty;
                    stockReceive2.balance = a.balance;
                    stockReceive2.invoice = a.invoice;
                    stockReceive2.remarks = a.remarks;
                    stockReceive2.dateentry = a.dateentry;
                    lst.Add(stockReceive2);
                }
                return lst;
            }
        }

        #endregion

        #region Cient
        private const string ALL_CLIENTS = "SELECT * FROM Client order by clientid desc ";

        public static List<Client> getAllClients()
        {
            List<Client> lst = new List<Client>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_CLIENTS))
                {
                    var client = new Client();

                    client.clientid = a.clientid;
                    client.contactname = a.contactname;
                    client.name = a.name;
                    client.phoneno = a.phoneno;
                    client.logoimagename = a.logoimagename;
                    client.siterelativepath = a.siterelativepath;
                    client.emailphysicalpath = a.emailphysicalpath;
                    client.datemodified = a.datemodified;
                    client.dateentry = a.dateentry;

                    lst.Add(client);
                }
                return lst;
            }
        }
        private const string ALL_CLIENTSREDEMPTIONMEMBER = @"SELECT    
dbo.Client.clientid, dbo.Client.name, dbo.Client.contactname, 
dbo.Client.phoneno, dbo.Client.logoimagename, dbo.Client.siterelativepath,
dbo.Client.emailphysicalpath, 
dbo.RedemptionMemberClient.pointbalance, dbo.RedemptionMemberClient.receivenewsletter,
dbo.RedemptionMemberClient.discliamer, dbo.RedemptionMemberClient.dateentry, 
dbo.RedemptionMemberClient.datemodified, dbo.RedemptionMemberClient.UserId
FROM         dbo.Client LEFT OUTER JOIN
                      dbo.RedemptionMemberClient ON dbo.Client.clientid = dbo.RedemptionMemberClient.clientid
Where ( dbo.RedemptionMemberClient.UserId = @0)  OR
                      (dbo.RedemptionMemberClient.UserId IS NULL)

ORDER BY dbo.Client.clientid DESC";

        [Serializable]
        public sealed class ClientRedemptionMember2
        {
            public int clientid { get; set; }
            public string name { get; set; }

            public int? pointbalance { get; set; }
            public bool? receivenewsletter { get; set; }
            public bool? discliamer { get; set; }
            public Guid? UserId { get; set; }

            public DateTime? dateentry { get; set; }
            public DateTime? datemodified { get; set; }
        }
        public static List<ClientRedemptionMember2> getAllClientsRedemptionMember(Guid UserId)
        {
            List<ClientRedemptionMember2> lst = new List<ClientRedemptionMember2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_CLIENTSREDEMPTIONMEMBER, UserId))
                {
                    var clientRedemptionMember2 = new ClientRedemptionMember2();

                    clientRedemptionMember2.clientid = a.clientid;

                    clientRedemptionMember2.name = a.name;
                    clientRedemptionMember2.pointbalance = a.pointbalance;
                    clientRedemptionMember2.receivenewsletter = a.receivenewsletter;
                    clientRedemptionMember2.discliamer = a.discliamer;
                    clientRedemptionMember2.UserId = a.UserId;
                    clientRedemptionMember2.datemodified = a.datemodified;
                    clientRedemptionMember2.dateentry = a.dateentry;

                    lst.Add(clientRedemptionMember2);
                }
                return lst;
            }
        }
        public static int insertClient(
            string contactname,
            string name, string phoneno,
            string logoimagename, string siterelativepath,
            string emailphysicalpath)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            int clientid = -1;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var client = new Client();

                    client.contactname = contactname;
                    client.name = name;
                    client.phoneno = phoneno;
                    client.logoimagename = logoimagename;
                    client.siterelativepath = siterelativepath;
                    client.emailphysicalpath = emailphysicalpath;
                    client.datemodified = DateTime.Now;
                    client.dateentry = DateTime.Now;
                    db.Insert(client);
                    success = true;
                    clientid = client.clientid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
           // return success;
            return clientid;
        }

        public static bool updateClient(
            int clientid, string contactname,
            string name, string phoneno,
            string logoimagename, string siterelativepath,
            string emailphysicalpath)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var client = Client.SingleOrDefault("WHERE clientid=@0", clientid);
                    client.contactname = contactname;
                    client.name = name;
                    client.phoneno = phoneno;
                    client.logoimagename = logoimagename;
                    client.siterelativepath = siterelativepath;
                    client.emailphysicalpath = emailphysicalpath;
                    client.datemodified = DateTime.Now;
                    client.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteClient(int clientid)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var client = Client.SingleOrDefault("WHERE clientid=@0", clientid);
                    client.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static Client getClient(int clientid)
        {
            var client = new Client();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    client = Client.SingleOrDefault("WHERE clientid=@0", clientid);


                }
            }
            catch (Exception e)
            {
                //log this
            }
            return client;
        }


        #endregion

        #region Promotion

        public sealed class Promotion2
        {
            public int promotionid { get; set; }

            public string clientname { get; set; }

            public string name { get; set; }
            public string brief { get; set; }
            public string description { get; set; }
            public string imagepath { get; set; }
            public int clientid { get; set; }
            public string prefix { get; set; }
            public int type { get; set; }
            public DateTime startdate { get; set; }
            public DateTime enddate { get; set; }
            public DateTime gracedate { get; set; }
            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }
        }

        private const string ALL_PROMOTIONS = @"SELECT     
dbo.Promotion.promotionid, dbo.Promotion.startdate, 
dbo.Promotion.enddate, dbo.Promotion.gracedate, 
dbo.Promotion.prefix, dbo.Promotion.name,dbo.Promotion.brief, dbo.Promotion.clientid, 
dbo.Client.name AS clientname, dbo.Promotion.datemodified, 
dbo.Promotion.dateentry, dbo.Promotion.type, dbo.Promotion.imagepath, 
dbo.Promotion.description
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Promotion ON dbo.Client.clientid = dbo.Promotion.clientid
order by dbo.Promotion.startdate desc";
        //        private const string LEADERS_FOR_A_WEEK = @"SELECT TOP 10 aspnet_Membership.Comment as FirstName, Game.TimeTaken
        //FROM            aspnet_Membership INNER JOIN
        //                         Game ON aspnet_Membership.UserId = Game.Userid
        //WHERE        (Game.GameState = @2) AND Game.isSuccess = 1
        // AND (Game.StartTime >= @0) AND (Game.StartTime < @1) AND (Game.GameLevel = @3) order by TimeTaken asc";
        public static List<Promotion2> getAllPromotions()
        {
            List<Promotion2> lst = new List<Promotion2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PROMOTIONS))
                {
                    var promotion = new Promotion2();

                    promotion.promotionid = a.promotionid;
                    promotion.name = a.name;
                    promotion.brief = a.brief;
                    promotion.description = a.description;
                    promotion.imagepath = a.imagepath;
                    promotion.clientname = a.clientname;
                    promotion.clientid = a.clientid;
                    promotion.startdate = a.startdate;
                    promotion.enddate = a.enddate;
                    promotion.gracedate = a.gracedate;
                    promotion.prefix = a.prefix;
                    promotion.type = a.type;
                    promotion.datemodified = a.datemodified;
                    promotion.dateentry = a.dateentry;

                    lst.Add(promotion);
                }
                return lst;
            }
        }

        private const string ALL_PROMOTIONS_BYCLIENTID = @"SELECT     
dbo.Promotion.promotionid, dbo.Promotion.startdate, 
dbo.Promotion.enddate, dbo.Promotion.gracedate, 
dbo.Promotion.prefix, dbo.Promotion.name,dbo.Promotion.brief,  dbo.Promotion.clientid, 
dbo.Client.name AS clientname, dbo.Promotion.datemodified, 
dbo.Promotion.dateentry, dbo.Promotion.type, dbo.Promotion.imagepath, 
dbo.Promotion.description
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Promotion ON dbo.Client.clientid = dbo.Promotion.clientid
where (dbo.Promotion.clientid = @0 )
order by dbo.Promotion.startdate desc";
        //        private const string LEADERS_FOR_A_WEEK = @"SELECT TOP 10 aspnet_Membership.Comment as FirstName, Game.TimeTaken
        //FROM            aspnet_Membership INNER JOIN
        //                         Game ON aspnet_Membership.UserId = Game.Userid
        //WHERE        (Game.GameState = @2) AND Game.isSuccess = 1
        // AND (Game.StartTime >= @0) AND (Game.StartTime < @1) AND (Game.GameLevel = @3) order by TimeTaken asc";
        public static List<Promotion2> getAllPromotionsByClientId(int clientid)
        {
            List<Promotion2> lst = new List<Promotion2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PROMOTIONS_BYCLIENTID, clientid))
                {
                    var promotion = new Promotion2();

                    promotion.promotionid = a.promotionid;
                    promotion.name = a.name;
                    promotion.brief = a.brief;
                    promotion.description = a.description;
                    promotion.imagepath = a.imagepath;
                    promotion.clientname = a.clientname;
                    promotion.clientid = a.clientid;
                    promotion.startdate = a.startdate;
                    promotion.enddate = a.enddate;
                    promotion.gracedate = a.gracedate;
                    promotion.prefix = a.prefix;
                    promotion.type = a.type;
                    promotion.datemodified = a.datemodified;
                    promotion.dateentry = a.dateentry;

                    lst.Add(promotion);
                }
                return lst;
            }
        }

        private const string ALL_PROMOTIONS_BYCLIENTIDTODAY = @"SELECT     
dbo.Promotion.promotionid, dbo.Promotion.startdate, 
dbo.Promotion.enddate, dbo.Promotion.gracedate, 
dbo.Promotion.prefix, dbo.Promotion.name,dbo.Promotion.brief,  dbo.Promotion.clientid, 
dbo.Client.name AS clientname, dbo.Promotion.datemodified, 
dbo.Promotion.dateentry, dbo.Promotion.type, dbo.Promotion.imagepath, 
dbo.Promotion.description
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Promotion ON dbo.Client.clientid = dbo.Promotion.clientid

WHERE    (dbo.Promotion.clientid = @0) and  ( @1 <= dbo.Promotion.enddate) AND ( @1 >= dbo.Promotion.startdate) 
order by dbo.Promotion.startdate desc";
        //        private const string LEADERS_FOR_A_WEEK = @"SELECT TOP 10 aspnet_Membership.Comment as FirstName, Game.TimeTaken
        //FROM            aspnet_Membership INNER JOIN
        //                         Game ON aspnet_Membership.UserId = Game.Userid
        //WHERE        (Game.GameState = @2) AND Game.isSuccess = 1
        // AND (Game.StartTime >= @0) AND (Game.StartTime < @1) AND (Game.GameLevel = @3) order by TimeTaken asc";
        public static List<Promotion2> getAllPromotionsByClientIdToday(int clientid)
        {
            List<Promotion2> lst = new List<Promotion2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PROMOTIONS_BYCLIENTIDTODAY, clientid, DateTime.Today))
                {
                    var promotion = new Promotion2();

                    promotion.promotionid = a.promotionid;
                    promotion.name = a.name;
                    promotion.brief = a.brief;
                    promotion.description = a.description;
                    promotion.imagepath = a.imagepath;
                    promotion.clientname = a.clientname;
                    promotion.clientid = a.clientid;
                    promotion.startdate = a.startdate;
                    promotion.enddate = a.enddate;
                    promotion.gracedate = a.gracedate;
                    promotion.prefix = a.prefix;
                    promotion.type = a.type;
                    promotion.datemodified = a.datemodified;
                    promotion.dateentry = a.dateentry;

                    lst.Add(promotion);
                }
                return lst;
            }
        }

        private const string ALL_PROMOTIONS_BYPRODUCT = @"SELECT     
dbo.Promotion.promotionid, dbo.Promotion.startdate, 
dbo.Promotion.enddate, dbo.Promotion.gracedate, 
dbo.Promotion.prefix, dbo.Promotion.name,dbo.Promotion.brief,  dbo.Promotion.clientid, 
dbo.Client.name AS clientname, dbo.Promotion.datemodified, 
dbo.Promotion.dateentry, dbo.Promotion.type, dbo.Promotion.imagepath, 
dbo.Promotion.description
FROM         dbo.Client RIGHT OUTER JOIN
                      dbo.Promotion ON dbo.Client.clientid = dbo.Promotion.clientid
where ( dbo.Promotion.type = 1)
order by dbo.Promotion.startdate desc";
        //        private const string LEADERS_FOR_A_WEEK = @"SELECT TOP 10 aspnet_Membership.Comment as FirstName, Game.TimeTaken
        //FROM            aspnet_Membership INNER JOIN
        //                         Game ON aspnet_Membership.UserId = Game.Userid
        //WHERE        (Game.GameState = @2) AND Game.isSuccess = 1
        // AND (Game.StartTime >= @0) AND (Game.StartTime < @1) AND (Game.GameLevel = @3) order by TimeTaken asc";
        public static List<Promotion2> getAllPromotionsByProduct()
        {
            List<Promotion2> lst = new List<Promotion2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PROMOTIONS_BYPRODUCT))
                {
                    var promotion = new Promotion2();

                    promotion.promotionid = a.promotionid;
                    promotion.name = a.name;
                    promotion.brief = a.brief;
                    promotion.description = a.description;
                    promotion.imagepath = a.imagepath;
                    promotion.clientname = a.clientname;
                    promotion.clientid = a.clientid;
                    promotion.startdate = a.startdate;
                    promotion.enddate = a.enddate;
                    promotion.gracedate = a.gracedate;
                    promotion.prefix = a.prefix;
                    promotion.type = a.type;
                    promotion.datemodified = a.datemodified;
                    promotion.dateentry = a.dateentry;

                    lst.Add(promotion);
                }
                return lst;
            }
        }

        public static int insertPromotion(
            int clientid, DateTime startdate,
            DateTime enddate, DateTime gracedate,
            string prefix, string name, string brief,
           string description, string imagepath, int type)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            int promotionid = -1;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var promotion = new Promotion();
                    promotion.name = name;
                    promotion.brief = brief;
                    promotion.description = description;
                    promotion.imagepath = imagepath;
                    promotion.clientid = clientid;
                    promotion.startdate = startdate;
                    promotion.enddate = enddate;
                    promotion.gracedate = gracedate;
                    promotion.prefix = prefix;
                    promotion.type = type;
                    promotion.dateentry = DateTime.Now;
                    promotion.datemodified = DateTime.Now;
                    db.Insert(promotion);
                    success = true;
                    promotionid = promotion.promotionid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return promotionid;
        }

        public static bool updatePromotion(
            int promotionid, int clientid,
            DateTime startdate, DateTime enddate,
            DateTime gracedate,
            string prefix, string name, string brief,
           string description, string imagepath, int type)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var promotion = Promotion.SingleOrDefault("WHERE promotionid=@0", promotionid);
                    promotion.name = name;
                    promotion.brief = brief;
                    promotion.description = description;
                    promotion.imagepath = imagepath;
                    promotion.clientid = clientid;
                    promotion.startdate = startdate;
                    promotion.enddate = enddate;
                    promotion.gracedate = gracedate;
                    promotion.prefix = prefix;
                    promotion.type = type;
                    promotion.datemodified = DateTime.Now;
                    promotion.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deletePromotion(int promotionid)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var promotion = Promotion.SingleOrDefault("WHERE promotionid=@0", promotionid);
                    promotion.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static Promotion getPromotion(int promotionid)
        {

            var promotion = new Promotion();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    promotion = Promotion.SingleOrDefault("WHERE promotionid=@0", promotionid);


                }
            }
            catch (Exception e)
            {
                //log this
            }
            return promotion;
        }


        #endregion


        #region Events
        public sealed class Event2
        {
            public int eventid { get; set; }
            public int clientid { get; set; }
            public string clientname { get; set; }

            public string name { get; set; }
            public string brief { get; set; }
            public string description { get; set; }
            public string imagepath { get; set; }
            public string url { get; set; }


            public DateTime startdate { get; set; }
            public DateTime enddate { get; set; }

            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }
        }

        private const string ALL_EVENTS_BYTODAY = @"SELECT     dbo.Event.eventid, dbo.Event.clientid, dbo.Event.name, dbo.Event.brief, dbo.Event.description, dbo.Event.imagepath, dbo.Event.url, dbo.Event.startdate, dbo.Event.enddate, dbo.Event.dateentry, 
                      dbo.Event.datemodified, dbo.Client.name AS clientname
FROM         dbo.Event INNER JOIN
                      dbo.Client ON dbo.Event.clientid = dbo.Client.clientid
order by startdate desc";

        public static List<Event2> getAllEvents()
        {
            List<Event2> lst = new List<Event2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_EVENTS_BYTODAY))
                {
                    var anEvent = new Event2();

                    anEvent.eventid = a.eventid;
                    anEvent.clientid = a.clientid;
                    anEvent.clientname = a.clientname;
                    anEvent.name = a.name;
                    anEvent.brief = a.brief;
                    anEvent.description = a.description;
                    anEvent.imagepath = a.imagepath;
                    anEvent.url = a.url;
                    anEvent.startdate = a.startdate;
                    anEvent.enddate = a.enddate;
                    anEvent.datemodified = a.datemodified;
                    anEvent.dateentry = a.dateentry;
                    lst.Add(anEvent);
                }
                return lst;
            }
        }

        private const string ALL_EVENTS_BYCLIENTID = @"SELECT     dbo.Event.eventid, dbo.Event.clientid, dbo.Event.name, dbo.Event.brief, dbo.Event.description, dbo.Event.imagepath, dbo.Event.url, dbo.Event.startdate, dbo.Event.enddate, dbo.Event.dateentry, 
                      dbo.Event.datemodified, dbo.Client.name AS clientname
FROM         dbo.Event INNER JOIN
                      dbo.Client ON dbo.Event.clientid = dbo.Client.clientid
where (dbo.Client.clientid = @0)
order by startdate desc";

        public static List<Event2> getAllEventsByClientId(int clientid)
        {
            List<Event2> lst = new List<Event2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_EVENTS_BYCLIENTID, clientid))
                {
                    var anEvent = new Event2();

                    anEvent.eventid = a.eventid;
                    anEvent.clientid = a.clientid;
                    anEvent.clientname = a.clientname;
                    anEvent.name = a.name;
                    anEvent.brief = a.brief;
                    anEvent.description = a.description;
                    anEvent.imagepath = a.imagepath;
                    anEvent.url = a.url;
                    anEvent.startdate = a.startdate;
                    anEvent.enddate = a.enddate;
                    anEvent.datemodified = a.datemodified;
                    anEvent.dateentry = a.dateentry;
                    lst.Add(anEvent);
                }
                return lst;
            }
        }
        private const string ALL_EVENTS_BYCLIENTID_TODAY = @"SELECT     
dbo.Event.eventid, dbo.Event.clientid, dbo.Event.name, dbo.Event.brief, 
dbo.Event.description, dbo.Event.imagepath, dbo.Event.url, 
dbo.Event.startdate, dbo.Event.enddate, dbo.Event.dateentry, 
                      dbo.Event.datemodified, dbo.Client.name AS clientname
FROM         dbo.Event INNER JOIN
                      dbo.Client ON dbo.Event.clientid = dbo.Client.clientid
WHERE    (dbo.Client.clientid = @0) and  ( @1 <= dbo.Event.enddate) AND ( @1 >= dbo.Event.startdate) 
order by startdate desc";

        public static List<Event2> getAllEventsByClientIdToday(int clientid)
        {
            List<Event2> lst = new List<Event2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_EVENTS_BYCLIENTID_TODAY, clientid, DateTime.Today))
                {
                    var anEvent = new Event2();

                    anEvent.eventid = a.eventid;
                    anEvent.clientid = a.clientid;
                    anEvent.clientname = a.clientname;
                    anEvent.name = a.name;
                    anEvent.brief = a.brief;
                    anEvent.description = a.description;
                    anEvent.imagepath = a.imagepath;
                    anEvent.url = a.url;
                    anEvent.startdate = a.startdate;
                    anEvent.enddate = a.enddate;
                    anEvent.datemodified = a.datemodified;
                    anEvent.dateentry = a.dateentry;
                    lst.Add(anEvent);
                }
                return lst;
            }
        }
        public static int insertEvent(
            int clientid,
            string name, string brief,
            string description, string imagepath,
            string url, DateTime startdate, DateTime enddate)
        {
            int eventid = -1;
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var anEvent = new Event();

                    anEvent.clientid = clientid;
                    anEvent.name = name;
                    anEvent.brief = brief;
                    anEvent.description = description;
                    anEvent.imagepath = imagepath;
                    anEvent.url = url;
                    anEvent.startdate = startdate;
                    anEvent.enddate = enddate;
                    anEvent.dateentry = DateTime.Now;
                    anEvent.datemodified = DateTime.Now;
                    db.Insert(anEvent);
                    eventid = anEvent.eventid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return eventid;
        }

        public static bool updateEvent(
            int eventid, int clientid,
            string name, string brief,
            string description, string imagepath,
            string url, DateTime startdate, DateTime enddate)
        {

            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var anEvent = Event.SingleOrDefault("WHERE eventid=@0", eventid);
                    anEvent.eventid = eventid;
                    anEvent.clientid = clientid;
                    anEvent.name = name;
                    anEvent.brief = brief;
                    anEvent.description = description;
                    anEvent.imagepath = imagepath;
                    anEvent.url = url;
                    anEvent.startdate = startdate;
                    anEvent.enddate = enddate;

                    anEvent.datemodified = DateTime.Now;
                    anEvent.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteEvent(int eventid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var anevent = Event.SingleOrDefault("WHERE eventid=@0", eventid);
                    anevent.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static Event getEvent(int eventid)
        {
            // bool success = false;
            var anevent = new Event();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    anevent = Event.SingleOrDefault("WHERE eventid=@0", eventid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return anevent;
        }

        #endregion

        #region Product

        public sealed class Product2
        {
            public int productid { get; set; }

            public int clientid { get; set; }
            public string clientname { get; set; }
            public string name { get; set; }
            public string model { get; set; }
            public string description { get; set; }
            public string imagepath { get; set; }

            public int points { get; set; }
            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }
        }

        private const string ALL_PRODUCTS = @"SELECT     
dbo.Product.productid, dbo.Product.clientid, dbo.Product.name, 
dbo.Product.model, dbo.Product.description, dbo.Product.imagepath, 
dbo.Product.points, dbo.Product.dateentry, 
 dbo.Product.datemodified, dbo.Client.name AS clientname
FROM         dbo.Product INNER JOIN
                      dbo.Client ON dbo.Product.clientid = dbo.Client.clientid
order by dbo.Product.productid desc";
        public static List<Product2> getAllProducts()
        {
            List<Product2> lst = new List<Product2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PRODUCTS))
                {
                    var product2 = new Product2();

                    product2.productid = a.productid;
                    product2.clientid = a.clientid;
                    product2.clientname = a.clientname;
                    product2.name = a.name;
                    product2.description = a.description;
                    product2.model = a.model;
                    product2.imagepath = a.imagepath;
                    product2.points = a.points;
                    product2.datemodified = a.datemodified;
                    product2.dateentry = a.dateentry;

                    lst.Add(product2);
                }
                return lst;
            }
        }
        private const string ALL_PRODUCTS_BYCLIENTID = @"SELECT 
dbo.Product.productid, dbo.Product.clientid, dbo.Product.name, 
dbo.Product.model, dbo.Product.description, dbo.Product.imagepath, 
dbo.Product.points, dbo.Product.dateentry, 
 dbo.Product.datemodified, dbo.Client.name AS clientname
FROM         dbo.Product INNER JOIN
                      dbo.Client ON dbo.Product.clientid = dbo.Client.clientid
WHERE     (dbo.Product.clientid = @0)
order by dbo.Product.productid desc";
        public static List<Product2> getAllProductsByClientId(int clientid)
        {
            List<Product2> lst = new List<Product2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PRODUCTS_BYCLIENTID, clientid))
                {
                    var product2 = new Product2();

                    product2.productid = a.productid;
                    product2.clientid = a.clientid;
                    product2.clientname = a.clientname;
                    product2.name = a.name;
                    product2.description = a.description;
                    product2.model = a.model;
                    product2.imagepath = a.imagepath;
                    product2.points = a.points;
                    product2.datemodified = a.datemodified;
                    product2.dateentry = a.dateentry;

                    lst.Add(product2);
                }
                return lst;
            }
        }

        private const string ALL_PRODUCTS_BYPROMOTIONID = @"SELECT    
dbo.PromotionByProductProductReward.promotionid, 
dbo.PromotionByProductProductReward.productid, 
dbo.PromotionByProductProductReward.rewardid, 
dbo.PromotionByProductProductReward.dateentry,
dbo.PromotionByProductProductReward.datemodified, 
dbo.Product.name as productname, dbo.Product.model as productmodel
FROM         dbo.PromotionByProductProductReward INNER JOIN
                      dbo.Product ON dbo.PromotionByProductProductReward.productid = dbo.Product.productid
WHERE     (dbo.PromotionByProductProductReward.promotionid = @0)

order by dbo.Product.name";
        public static List<Product2> getAllProductsByPromotionid(int clientid)
        {
            List<Product2> lst = new List<Product2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PRODUCTS_BYPROMOTIONID, clientid))
                {
                    var product2 = new Product2();

                    product2.productid = a.productid;
                    // product2.clientid = a.clientid;
                    //   product2.clientname = a.clientname;
                    product2.name = a.productname;
                    //  product2.description = a.description;
                    product2.model = a.productmodel;
                    //  product2.imagepath = a.imagepath;
                    //   product2.points = a.points;
                    //  product2.datemodified = a.datemodified;
                    //  product2.dateentry = a.dateentry;

                    lst.Add(product2);
                }
                return lst;
            }
        }



        public sealed class ProductReward
        {
            public int productid { get; set; }
            public string productname { get; set; }
            public string productmodel { get; set; }

            public int rewardid { get; set; }
            public string rewardname { get; set; }
        }
        private const string ALL_PRODUCTREWARDS_BYPROMOTIONID = @" SELECT     
dbo.PromotionByProductProductReward.promotionid, 
dbo.PromotionByProductProductReward.productid, 
dbo.Product.name AS productname, 
dbo.Product.model AS productmodel, 
                      dbo.PromotionByProductProductReward.rewardid,
dbo.Reward.name AS rewardname, dbo.PromotionByProductProductReward.dateentry, 
dbo.PromotionByProductProductReward.datemodified
FROM         dbo.PromotionByProductProductReward INNER JOIN
                      dbo.Product ON dbo.PromotionByProductProductReward.productid = dbo.Product.productid INNER JOIN
                      dbo.Reward ON dbo.PromotionByProductProductReward.rewardid = dbo.Reward.rewardid
WHERE     (dbo.PromotionByProductProductReward.promotionid = @0)

order by dbo.Product.name";
        public static List<ProductReward> getAllProductRewardsByPromotionid(int clientid)
        {
            List<ProductReward> lst = new List<ProductReward>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PRODUCTREWARDS_BYPROMOTIONID, clientid))
                {
                    var productReward = new ProductReward();

                    productReward.productid = a.productid;
                    // product2.clientid = a.clientid;
                    //   product2.clientname = a.clientname;
                    productReward.productname = a.productname;
                    //  product2.description = a.description;
                    productReward.productmodel = a.productmodel;
                    productReward.rewardid = a.rewardid;
                    productReward.rewardname = a.rewardname;
                    //  product2.imagepath = a.imagepath;
                    //   product2.points = a.points;
                    //  product2.datemodified = a.datemodified;
                    //  product2.dateentry = a.dateentry;

                    lst.Add(productReward);
                }
                return lst;
            }
        }


        /*
             private const string ALL_PRODUCTS_BYCLIENTID = @"SELECT     
productid, clientid, name, model, description, points, imagepath, dateentry, datemodified
FROM         dbo.Product
WHERE     (clientid = @0)";
             public static List<Product> getAllProductsByClientId(int clientid)
             {
                 List<Product> lst = new List<Product>();
                 using (var db = new ApplicationServices.ApplicationServicesDB())
                 {
                     foreach (var a in db.Fetch<dynamic>(ALL_PRODUCTS_BYCLIENTID, clientid))
                     {
                         var product = new Product();
                         product.productid = a.productid;
                         product.clientid = a.clientid;
                         product.name = a.name;
                         product.model = a.model;
                         product.description = a.description;
                         product.points = a.points;
                         product.imagepath = a.imagepath;


                         product.datemodified = a.datemodified;
                         product.dateentry = a.dateentry;

                         lst.Add(product);
                     }
                     return lst;
                 }
             }
         * */

        public static int insertProduct(
            string name, string model,
           string description, string imagepath,
            int clientid, int points)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            int productid = -1;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var product = new Product();
                    product.name = name;
                    product.model = model;
                    product.description = description;
                    product.imagepath = imagepath;
                    product.clientid = clientid;
                    product.points = points;
                    product.dateentry = DateTime.Now;
                    product.datemodified = DateTime.Now;
                    db.Insert(product);
                    success = true;
                    productid = product.productid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
//return success;
            return productid;
        }

        public static bool updateProduct(int productid,
            string name, string model,
           string description, string imagepath,
            int clientid, int points)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var product = Product.SingleOrDefault("WHERE productid=@0", productid);
                    product.name = name;
                    product.model = model;
                    product.description = description;
                    product.imagepath = imagepath;
                    product.clientid = clientid;
                    product.points = points;
                    product.datemodified = DateTime.Now;
                    product.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteProduct(int productid)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var product = Product.SingleOrDefault("WHERE productid=@0", productid);
                    product.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static Product getProduct(int productid)
        {
            var product = new Product();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    product = Product.SingleOrDefault("WHERE productid=@0", productid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return product;
        }


        #endregion

        #region Rewards


        public sealed class Reward2
        {
            public int rewardid { get; set; }
            public string name { get; set; }
            public string brief { get; set; }
            public int clientid { get; set; }
            public string clientname { get; set; }
            public int promotionid { get; set; }
            public string promotionname { get; set; }

            public string description { get; set; }
            public string imagepath { get; set; }
            public int points { get; set; }
            public int qty { get; set; }
            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }
        }

        private const string ALL_REWARDS = @"SELECT     dbo.Reward.rewardid, dbo.Reward.clientid,
dbo.Reward.name,dbo.Reward.brief, dbo.Reward.description, dbo.Reward.imagepath, dbo.Reward.points, dbo.Reward.qty, dbo.Reward.dateentry, 
                      dbo.Reward.datemodified, dbo.Client.name AS clientname
FROM         dbo.Reward INNER JOIN
                      dbo.Client ON dbo.Reward.clientid = dbo.Client.clientid
order by dbo.Reward.rewardid desc";
        public static List<Reward2> getAllRewards()
        {
            List<Reward2> lst = new List<Reward2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REWARDS))
                {
                    var reward = new Reward2();

                    reward.rewardid = a.rewardid;
                    reward.name = a.name;
                    reward.brief = a.brief;
                    reward.clientid = a.clientid;
                    reward.clientname = a.clientname;
                    reward.description = a.description;
                    reward.imagepath = a.imagepath;
                    reward.points = a.points;
                    reward.qty = a.qty;

                    reward.datemodified = a.datemodified;
                    reward.dateentry = a.dateentry;

                    lst.Add(reward);
                }
                return lst;
            }
        }
        private const string ALL_REWARDS_BYCLIENTID = @"SELECT     dbo.Reward.rewardid, dbo.Reward.clientid, dbo.Reward.name, dbo.Reward.brief,  dbo.Reward.description, dbo.Reward.imagepath, dbo.Reward.points, dbo.Reward.qty, dbo.Reward.dateentry, 
                      dbo.Reward.datemodified, dbo.Client.name AS clientname
FROM         dbo.Reward INNER JOIN
                      dbo.Client ON dbo.Reward.clientid = dbo.Client.clientid
Where (dbo.Reward.clientid= @0)
order by dbo.Reward.rewardid desc";
        public static List<Reward2> getAllRewardsByClientid(int clientid)
        {
            List<Reward2> lst = new List<Reward2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REWARDS_BYCLIENTID, clientid))
                {
                    var reward = new Reward2();

                    reward.rewardid = a.rewardid;
                    reward.name = a.name;
                    reward.brief = a.brief;
                    reward.clientid = a.clientid;
                    reward.clientname = a.clientname;
                    reward.description = a.description;
                    reward.imagepath = a.imagepath;
                    reward.points = a.points;
                    reward.qty = a.qty;

                    reward.datemodified = a.datemodified;
                    reward.dateentry = a.dateentry;

                    lst.Add(reward);
                }
                return lst;
            }
        }

        private const string ALL_BYPOINTS_REWARDS_BY_PROMOTION = @"SELECT     
dbo.PromotionByPointReward.promotionid, dbo.Reward.rewardid, dbo.Reward.clientid, dbo.Reward.name,  dbo.Reward.brief, 
dbo.Reward.description, dbo.Reward.imagepath, dbo.Reward.points, dbo.Reward.qty,
dbo.Reward.dateentry, dbo.Reward.datemodified, dbo.Promotion.name AS promotionname
FROM         dbo.Reward INNER JOIN
                      dbo.PromotionByPointReward ON dbo.Reward.rewardid = dbo.PromotionByPointReward.rewardid INNER JOIN
                      dbo.Promotion ON dbo.PromotionByPointReward.promotionid = dbo.Promotion.promotionid
WHERE     (dbo.PromotionByPointReward.promotionid = @0) AND ( @1 <= dbo.Promotion.enddate) AND ( @1 >= dbo.Promotion.startdate)";
        private const string ALL_BYPRODUCT_REWARDS_BY_PROMOTION = @"SELECT  distinct   
dbo.PromotionByProductProductReward.promotionid, dbo.Reward.rewardid,dbo.Reward.clientid, dbo.Reward.name,  dbo.Reward.brief, 
dbo.Reward.description, dbo.Reward.imagepath, dbo.Reward.points, dbo.Reward.qty, 
dbo.Reward.dateentry, dbo.Reward.datemodified, dbo.Promotion.name AS promotionname
FROM         dbo.Reward INNER JOIN
                      dbo.PromotionByProductProductReward ON dbo.Reward.rewardid = dbo.PromotionByProductProductReward.rewardid INNER JOIN
                      dbo.Promotion ON dbo.PromotionByProductProductReward.promotionid = dbo.Promotion.promotionid
WHERE     (dbo.Promotion.promotionid = @0) AND ( @1 <= dbo.Promotion.enddate) AND ( @1 >= dbo.Promotion.startdate)";

        public static List<Reward2> getAllRewardsByPromotion(int promotionid)
        {
            // ( @1 <= enddate) AND ( @1 >=startdate)", clientid, DateTime.Today))

            Promotion promotion = ClientManager.getPromotion(promotionid);
            string query;
            if (promotion.type == (int)PromotionType.BY_POINT)
            {
                query = ALL_BYPOINTS_REWARDS_BY_PROMOTION;
            }
            else
            {
                query = ALL_BYPRODUCT_REWARDS_BY_PROMOTION;
            }

            List<Reward2> lst = new List<Reward2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(query, promotionid, DateTime.Today))
                {
                    var reward = new Reward2();
                    reward.promotionid = a.promotionid;
                    reward.rewardid = a.rewardid;
                    reward.clientid = a.clientid;
                    reward.name = a.name; reward.brief = a.brief;
                    reward.description = a.description;
                    reward.imagepath = a.imagepath;
                    reward.points = a.points;
                    reward.qty = a.qty;
                    reward.datemodified = a.datemodified;
                    reward.dateentry = a.dateentry;
                    reward.promotionname = a.promotionname;
                    lst.Add(reward);
                }
                return lst;
            }
        }

        private const string ALL_BYPOINTS_REWARDS_BY_CLIENT = @"SELECT    
rewardid, clientid, name,brief, description, imagepath, points, qty, dateentry, datemodified
FROM         dbo.Reward
WHERE     (clientid = @0)";

        public static List<Reward> getAllRewardsByClient(int clientid)
        {
            string query = ALL_BYPOINTS_REWARDS_BY_CLIENT;
            List<Reward> lst = new List<Reward>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(query, clientid))
                {
                    var reward = new Reward();

                    reward.rewardid = a.rewardid;
                    reward.clientid = a.clientid;
                    reward.name = a.name;
                    reward.brief = a.brief;
                    reward.description = a.description;
                    reward.imagepath = a.imagepath;
                    reward.points = a.points;
                    reward.qty = a.qty;
                    reward.datemodified = a.datemodified;
                    reward.dateentry = a.dateentry;

                    lst.Add(reward);
                }
                return lst;
            }
        }
        public static List<Reward2> getAllRewardsByClient2(int clientid)
        {
            //string query = ALL_BYPOINTS_REWARDS_BY_CLIENT;
            List<Reward2> lst = new List<Reward2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                //select * from view_3 where ( '2013/12/18' <= enddate) AND ( '2013/12/18'>=startdate)
                foreach (var a in db.Fetch<dynamic>("select * from View_3 WHERE (clientid = @0) and ( @1 <= enddate) AND ( @1 >=startdate)", clientid, DateTime.Today))
                {
                    var reward = new Reward2();
                    reward.promotionid = a.promotionid;
                    reward.rewardid = a.rewardid;
                    reward.clientid = a.clientid;
                    reward.name = a.name;
                    reward.brief = a.brief;
                    reward.description = a.description;
                    reward.imagepath = a.imagepath;
                    reward.points = a.points;
                    reward.qty = a.qty;
                    reward.datemodified = a.datemodified;
                    reward.dateentry = a.dateentry;
                    reward.promotionname = a.promotionname;
                    lst.Add(reward);
                }
                return lst;
            }
        }
        public static int insertReward(
            int clientid, string name, string brief,
            string description, string imagepath,
            int points, int qty)
        {
            int rewardid = -1;
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var reward = new Reward();
                    reward.clientid = clientid;
                    reward.name = name;
                    reward.brief = brief;
                    reward.description = description;
                    reward.imagepath = imagepath;
                    reward.points = points;
                    reward.qty = qty;
                    reward.dateentry = DateTime.Now;
                    reward.datemodified = DateTime.Now;
                    db.Insert(reward);
                    success = true;
                    rewardid= reward.rewardid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
          //  return success;
            return rewardid;
        }

        public static bool updateReward(
            int rewardid,
            int clientid, string name, string brief,
            string description, string imagepath,
            int points, int qty)
        {

            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);
                    reward.rewardid = rewardid;
                    reward.clientid = clientid;
                    reward.name = name;
                    reward.brief = brief;
                    reward.description = description;
                    reward.imagepath = imagepath;
                    reward.points = points;
                    reward.qty = qty;
                    reward.datemodified = DateTime.Now;
                    reward.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }


        //      SELECT [rewardid]
        //    ,[TotalOut]
        //FROM [RedemptionDB2].[dbo].[ViewStockOut]


        public static bool canReduceRewardQtyBy(int rewardid, int qty)
        {

            bool canReduce = false;

            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                // var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);
                int totalOut = 0;
                int totalReturn = 0;
                //select * from view_3 where ( '2013/12/18' <= enddate) AND ( '2013/12/18'>=startdate)
                foreach (var a in db.Fetch<dynamic>(@" SELECT [rewardid],[TotalOut]
                FROM [ViewStockOut] WHERE rewardid=@0", rewardid))
                {
                    totalOut = a.TotalOut;
                }
                foreach (var a in db.Fetch<dynamic>(@" SELECT [rewardid],[TotalReturn]
                FROM [ViewStockReturn] WHERE rewardid=@0", rewardid))
                {
                    totalReturn = a.TotalReturn;
                }


                if (qty - (totalOut - totalReturn) <= 0)
                {
                    canReduce = true;
                }
            }

            return canReduce;
        }
        public static bool updateRewardQtyBy(int rewardid, int qty)
        {

            bool success = false;

            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);

                reward.qty = reward.qty + qty;
                reward.datemodified = DateTime.Now;
                reward.Update();
                success = true;

            }

            return success;
        }
        public static bool reduceRewardQtyBy1(int rewardid)
        {

            bool success = false;

            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);
                if (reward.qty > 0)
                {
                    reward.qty = reward.qty - 1;
                    reward.datemodified = DateTime.Now;
                    reward.Update();
                    success = true;
                }
                else
                {
                    throw new Exception("Out of stock");
                }

            }

            return success;
        }
        public static bool increaseRewardQtyBy1(int rewardid)
        {

            bool success = false;

            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);
                if (reward.qty > 0)
                {
                    reward.qty = reward.qty +1;
                    reward.datemodified = DateTime.Now;
                    reward.Update();
                    success = true;
                }
                else
                {
                   // throw new Exception("Out of stock");
                }

            }

            return success;
        }

        public static bool canReduceRewardQtyBy1(int rewardid)
        {

            bool canReduce = false;

            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);
                if (reward.qty > 0)
                {
                    canReduce = true;
                }


            }

            return canReduce;
        }

        public static bool deleteReward(int rewardid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);
                    reward.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static Reward getReward(int rewardid)
        {
            // bool success = false;
            var reward = new Reward();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    reward = Reward.SingleOrDefault("WHERE rewardid=@0", rewardid);

                }
            }
            catch (Exception e)
            {
                //log this
            }
            return reward;
        }


        #endregion

        #region RedemptionMember

        private const string ALL_REDEMPTIONMEMBERS = @"SELECT     dbo.RedemptionMember.UserId, dbo.RedemptionMember.firstname, dbo.RedemptionMember.lastname, dbo.RedemptionMember.gender, dbo.RedemptionMember.contactno, 
                      dbo.RedemptionMember.NRIC, dbo.RedemptionMember.dateofbirth, dbo.RedemptionMember.mailingaddress, dbo.RedemptionMember.postalcode, dbo.RedemptionMember.dateentry, 
                      dbo.RedemptionMember.datemodified, dbo.aspnet_Membership.Email, dbo.aspnet_Users.UserName
FROM         dbo.aspnet_Users INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Users.UserId = dbo.aspnet_Membership.UserId AND dbo.aspnet_Users.UserId = dbo.aspnet_Membership.UserId RIGHT OUTER JOIN
                      dbo.RedemptionMember ON dbo.aspnet_Membership.UserId = dbo.RedemptionMember.UserId";


        public sealed class RedemptionMember2
        {
            public Guid UserId { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }

            public string contactno { get; set; }
            public string NRIC { get; set; }
            public bool gender { get; set; }

            public DateTime dateofbirth { get; set; }
            public string mailingaddress { get; set; }
            public string postalcode { get; set; }

            public string username { get; set; }
            public string email { get; set; }

            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }
        }
        public static List<RedemptionMember2> getAllRedemptionMembers()
        {
            List<RedemptionMember2> lst = new List<RedemptionMember2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONMEMBERS))
                {
                    var redemptionMember = new RedemptionMember2();
                    redemptionMember.UserId = a.UserId;
                    redemptionMember.firstname = a.firstname;
                    redemptionMember.lastname = a.lastname;

                    redemptionMember.contactno = a.contactno;
                    redemptionMember.NRIC = a.NRIC;
                    redemptionMember.gender = a.gender;

                    redemptionMember.dateofbirth = a.dateofbirth;
                    redemptionMember.mailingaddress = a.mailingaddress;
                    redemptionMember.postalcode = a.postalcode;

                    redemptionMember.username = a.UserName;
                    redemptionMember.email = a.Email;

                    redemptionMember.datemodified = a.datemodified;
                    redemptionMember.dateentry = a.dateentry;
                    lst.Add(redemptionMember);
                }
                return lst;
            }
        }

        private const string ALL_REDEMPTIONMEMBERS_BYCLIENTID = @"SELECT     
dbo.RedemptionMember.UserId, 
dbo.RedemptionMember.firstname, 
dbo.RedemptionMember.lastname, 
CASE WHEN dbo.RedemptionMember.gender = 1 THEN 'Male' WHEN dbo.RedemptionMember.gender = 0 THEN 'Female' END AS gender, 
dbo.RedemptionMember.contactno, 
dbo.RedemptionMember.NRIC, 
dbo.RedemptionMember.dateofbirth, 
dbo.RedemptionMember.mailingaddress, 
dbo.RedemptionMember.postalcode, 
dbo.RedemptionMember.dateentry, 
dbo.RedemptionMember.datemodified, 
dbo.aspnet_Membership.Email, 
dbo.aspnet_Users.UserName, 

dbo.RedemptionMemberClient.clientid, 
dbo.RedemptionMemberClient.pointbalance, 
dbo.RedemptionMemberClient.discliamer, 
dbo.RedemptionMemberClient.receivenewsletter, 
dbo.RedemptionMemberClient.dateentry AS clientdateentry, 

dbo.RedemptionChild.childid, 
dbo.RedemptionChild.firstname AS childfirstname,
dbo.RedemptionChild.lastname AS childlastname, 
CASE WHEN dbo.RedemptionChild.gender = 1 THEN 'Male' WHEN dbo.RedemptionChild.gender = 0 THEN 'Female' END AS childgender, 
dbo.RedemptionChild.dateofbirth AS childdateofbirth, 
dbo.RedemptionChild.dateentry AS childdateentry
FROM         dbo.RedemptionMemberClient RIGHT OUTER JOIN
                      dbo.RedemptionMember ON dbo.RedemptionMemberClient.UserId = dbo.RedemptionMember.UserId LEFT OUTER JOIN
                      dbo.RedemptionChild ON dbo.RedemptionMember.UserId = dbo.RedemptionChild.UserId LEFT OUTER JOIN
                      dbo.aspnet_Users INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Users.UserId = dbo.aspnet_Membership.UserId AND dbo.aspnet_Users.UserId = dbo.aspnet_Membership.UserId ON 
                      dbo.RedemptionMember.UserId = dbo.aspnet_Membership.UserId
WHERE     (dbo.RedemptionMemberClient.clientid = @0)
";

        public sealed class RedemptionMember3
        {
            public Guid UserId { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }

            public string contactno { get; set; }
            public string NRIC { get; set; }
            public string gender { get; set; }

            public DateTime dateofbirth { get; set; }
            public string mailingaddress { get; set; }
            public string postalcode { get; set; }

            public string username { get; set; }
            public string email { get; set; }

            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }

            //            dbo.RedemptionMemberClient.clientid, 
            //dbo.RedemptionMemberClient.pointbalance, 
            //dbo.RedemptionMemberClient.discliamer, 
            //dbo.RedemptionMemberClient.receivenewsletter, 
            //dbo.RedemptionMemberClient.dateentry AS clientdateentry, 
            public int clientid { get; set; }
            public int pointbalance { get; set; }
            public bool discliamer { get; set; }
            public bool receivenewsletter { get; set; }
            public DateTime clientdateentry { get; set; }
            //            dbo.RedemptionChild.childid, 
            //dbo.RedemptionChild.firstname AS childfirstname,
            //dbo.RedemptionChild.lastname AS childlastname, 
            //CASE WHEN dbo.RedemptionChild.gender = 1 THEN 'Male' WHEN dbo.RedemptionChild.gender = 0 THEN 'Female' END AS childgender, 
            //dbo.RedemptionChild.dateofbirth AS childdateofbirth, 
            //dbo.RedemptionChild.dateentry AS childdateentry
            public string childid { get; set; }
            public string childfirstname { get; set; }
            public string childlastname { get; set; }
            public string childgender { get; set; }
            public string childdateofbirth { get; set; }
            public string childdateentry { get; set; }
        }
        public static List<RedemptionMember3> getAllRedemptionMembersByClient(int clientId)
        {
            List<RedemptionMember3> lst = new List<RedemptionMember3>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONMEMBERS_BYCLIENTID, clientId))
                {
                    var redemptionMember = new RedemptionMember3();
                    redemptionMember.UserId = a.UserId;
                    redemptionMember.firstname = a.firstname;
                    redemptionMember.lastname = a.lastname;

                    redemptionMember.contactno = a.contactno;
                    redemptionMember.NRIC = a.NRIC;
                    redemptionMember.gender = a.gender;

                    redemptionMember.dateofbirth = a.dateofbirth;
                    redemptionMember.mailingaddress = a.mailingaddress;
                    redemptionMember.postalcode = a.postalcode;

                    redemptionMember.username = a.UserName;
                    redemptionMember.email = a.Email;

                    redemptionMember.datemodified = a.datemodified;
                    redemptionMember.dateentry = a.dateentry;

                    //           public int clientid { get; set; }
                    //public int pointbalance { get; set; }
                    //public bool discliamer { get; set; }
                    //public bool receivenewsletter { get; set; }
                    //public DateTime clientdateentry { get; set; }
                    redemptionMember.clientid = a.clientid;
                    redemptionMember.pointbalance = a.pointbalance;
                    redemptionMember.discliamer = a.discliamer;
                    redemptionMember.receivenewsletter = a.receivenewsletter;
                    redemptionMember.clientdateentry = a.clientdateentry;


                    //public int childid { get; set; }
                    //   public string childfirstname { get; set; }
                    //   public string childlastname { get; set; }
                    //   public string childgender { get; set; }
                    //   public DateTime childdateofbirth { get; set; }
                    //   public DateTime childdateentry { get; set; } 
                    if (a.childid != null)
                    {
                        redemptionMember.childid = ((int)a.childid).ToString();
                    }
                    else {
                        redemptionMember.childid = "";

                    }
                    redemptionMember.childfirstname = a.childfirstname;
                    redemptionMember.childlastname = a.childlastname;
                    redemptionMember.childgender = a.childgender;
                    if (a.childdateofbirth != null)
                    {
                        redemptionMember.childdateofbirth = ((DateTime)a.childdateofbirth).ToShortDateString();
                    }
                    else
                    {
                        redemptionMember.childdateofbirth = "";

                    }

           
                    if (a.childdateentry != null)
                    {
                        redemptionMember.childdateentry = ((DateTime)a.childdateentry).ToShortDateString();
                    }
                    else
                    {
                        redemptionMember.childdateentry = "";
                    }
                    lst.Add(redemptionMember);

                }
                return lst;
            }
        }

        public static bool insertRedemptionMember(Guid UserId, string firstname, string lastname,
            string NRIC, bool gender, DateTime dateofbirth,
            string mailingaddress, string contactno, string postalcode)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionMember = new RedemptionMember();
                    redemptionMember.UserId = UserId;
                    redemptionMember.firstname = firstname;
                    redemptionMember.lastname = lastname;
                    redemptionMember.contactno = contactno;
                    redemptionMember.NRIC = NRIC;
                    redemptionMember.gender = gender;
                    redemptionMember.dateofbirth = dateofbirth;
                    redemptionMember.mailingaddress = mailingaddress;
                    redemptionMember.postalcode = postalcode;
                    redemptionMember.datemodified = DateTime.Now;
                    redemptionMember.dateentry = DateTime.Now;
                    db.Insert(redemptionMember);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool updateRedemptionMemberClientBalance(Guid UserId, int clientid,
            int newPointBalance)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionMemberClient = RedemptionMemberClient.SingleOrDefault("WHERE UserId=@0 and clientid=@1", UserId, clientid);

                    redemptionMemberClient.pointbalance = newPointBalance;

                    redemptionMemberClient.datemodified = DateTime.Now;
                    redemptionMemberClient.Update(new string[] { "pointbalance", "datemodified" });
                    // redemptionMemberClient.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool insertRedemptionMemberClient(Guid UserId, int clientid, bool discliamer, bool receivenewsletter)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionMemberClient = new RedemptionMemberClient();
                    redemptionMemberClient.UserId = UserId;
                    redemptionMemberClient.clientid = clientid;
                    redemptionMemberClient.pointbalance = 0;
                    redemptionMemberClient.discliamer = discliamer;
                    redemptionMemberClient.receivenewsletter = receivenewsletter;

                    redemptionMemberClient.datemodified = DateTime.Now;
                    redemptionMemberClient.dateentry = DateTime.Now;
                    db.Insert(redemptionMemberClient);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteRedemptionMemberClient(Guid UserId, int clientid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionMemberClient = RedemptionMemberClient.SingleOrDefault("WHERE UserId = @0 AND clientid = @1", UserId, clientid);
                    redemptionMemberClient.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool updateRedemptionMember(Guid UserId, string firstname, string lastname,
            string NRIC, bool gender, DateTime dateofbirth,
            string mailingaddress, string contactno, string postalcode)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionMember = RedemptionMember.SingleOrDefault("WHERE UserId=@0", UserId);

                    redemptionMember.firstname = firstname;
                    redemptionMember.lastname = lastname;
                    redemptionMember.contactno = contactno;
                    redemptionMember.NRIC = NRIC;
                    redemptionMember.gender = gender;
                    redemptionMember.dateofbirth = dateofbirth;
                    redemptionMember.mailingaddress = mailingaddress;
                    redemptionMember.postalcode = postalcode;
                    redemptionMember.datemodified = DateTime.Now;
                    redemptionMember.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteRedemptionMember(Guid UserId)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionMember = RedemptionMember.SingleOrDefault("WHERE UserId=@0", UserId);
                    redemptionMember.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static RedemptionMember getRedemptionMember(Guid UserId)
        {
            // bool success = false;
            var redemptionMember = new RedemptionMember();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionMember = RedemptionMember.SingleOrDefault("WHERE UserId=@0", UserId);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionMember;
        }
        public static RedemptionMemberClient getRedemptionMemberClient(Guid UserId, int clientid)
        {
            // bool success = false;
            var redemptionMemberClient = new RedemptionMemberClient();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionMemberClient = RedemptionMemberClient.SingleOrDefault("WHERE UserId=@0 and clientid=@1", UserId, clientid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionMemberClient;
        }


        #endregion

        #region RedemptionChild



        public static bool insertRedemptionChild(Guid UserId, string firstname, string lastname,
           bool gender, DateTime dateofbirth)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionChild = new RedemptionChild();
                    redemptionChild.UserId = UserId;
                    redemptionChild.firstname = firstname;
                    redemptionChild.lastname = lastname;

                    redemptionChild.gender = gender;
                    redemptionChild.dateofbirth = dateofbirth;

                    redemptionChild.datemodified = DateTime.Now;
                    redemptionChild.dateentry = DateTime.Now;
                    db.Insert(redemptionChild);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool updateRedemptionChild(int childid, Guid UserId, string firstname, string lastname,
           bool gender, DateTime dateofbirth)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionChild = RedemptionChild.SingleOrDefault("WHERE childid=@0", childid);
                    redemptionChild.UserId = UserId;
                    redemptionChild.firstname = firstname;
                    redemptionChild.lastname = lastname;

                    redemptionChild.gender = gender;
                    redemptionChild.dateofbirth = dateofbirth;

                    redemptionChild.datemodified = DateTime.Now;
                    redemptionChild.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteRedemptionChild(int childid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionChild = RedemptionChild.SingleOrDefault("WHERE childid=@0", childid);
                    redemptionChild.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static RedemptionChild getRedemptionChildByMemberUserId(Guid UserId)
        {
            // bool success = false;
            var redemptionChild = new RedemptionChild();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionChild = RedemptionChild.First("WHERE UserId=@0", UserId);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionChild;
        }
        public static RedemptionChild getRedemptionChild(int childid)
        {
            // bool success = false;
            var redemptionChild = new RedemptionChild();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionChild = RedemptionChild.SingleOrDefault("WHERE childid=@0", childid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionChild;
        }

        #endregion
        #region RedemptionByProductReceipt



        /*
        private const string ALL_REDEMPTIONBYPRODUCTRECEIPT = @"SELECT     
redemptionbyproductreceiptid, clientid, UserId,
receiptpath, status, invoiceno, resellerid, purchasedate, 
promotionid, promotionname, modeofcollection, 
dateentry, datemodified, remarks
FROM         dbo.RedemptionByProductReceipt

order by status, redemptionbyproductreceiptid desc ";
        */


        private const string ALL_REDEMPTIONBYPRODUCTRECEIPT = @"SELECT  
         dbo.RedemptionByProductReceipt.redemptionbyproductreceiptid, dbo.RedemptionByProductReceipt.clientid, dbo.RedemptionByProductReceipt.UserId, 
                      dbo.RedemptionByProductReceipt.receiptpath, dbo.RedemptionByProductReceipt.status, dbo.RedemptionByProductReceipt.invoiceno, dbo.RedemptionByProductReceipt.resellerid, 
                      dbo.RedemptionByProductReceipt.purchasedate, dbo.RedemptionByProductReceipt.promotionid, dbo.RedemptionByProductReceipt.promotionname, 
                      dbo.RedemptionByProductReceipt.modeofcollection, dbo.RedemptionByProductReceipt.dateentry, dbo.RedemptionByProductReceipt.datemodified, dbo.RedemptionByProductReceipt.remarks, 
                      dbo.Client.name AS clientname, dbo.RedemptionMember.firstname, dbo.RedemptionMember.lastname, dbo.RedemptionMember.contactno, dbo.RedemptionMember.NRIC
FROM         dbo.RedemptionByProductReceipt LEFT OUTER JOIN
                      dbo.Client ON dbo.RedemptionByProductReceipt.clientid = dbo.Client.clientid LEFT OUTER JOIN
                      dbo.RedemptionMember ON dbo.RedemptionByProductReceipt.UserId = dbo.RedemptionMember.UserId
ORDER BY dbo.RedemptionByProductReceipt.status, dbo.RedemptionByProductReceipt.redemptionbyproductreceiptid DESC";
        public sealed class RedemptionByProductReceipt2
        {
            public int redemptionbyproductreceiptid { get; set; }
            public Guid UserId { get; set; }
            public int clientid { get; set; }
            public string receiptpath { get; set; }
            public int status { get; set; }

            public string invoiceno { get; set; }
            public int resellerid { get; set; }

            public DateTime? purchasedate { get; set; }
            public int promotionid { get; set; }
            public string promotionname { get; set; }
            public int modeofcollection { get; set; }
            public string remarks { get; set; }

            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }

            public string clientname { get; set; }
            public string lastname { get; set; }
            public string firstname { get; set; }
            public string contactno { get; set; }
            public string NRIC { get; set; }
        }
        public static List<RedemptionByProductReceipt2> getAllRedemptionByProductReceipt()
        {
            List<RedemptionByProductReceipt2> lst = new List<RedemptionByProductReceipt2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONBYPRODUCTRECEIPT))
                {
                    var redemptionByProductReceipt = new RedemptionByProductReceipt2();
                    redemptionByProductReceipt.redemptionbyproductreceiptid = a.redemptionbyproductreceiptid;
                    redemptionByProductReceipt.UserId = a.UserId;
                    redemptionByProductReceipt.clientid = a.clientid;
                    redemptionByProductReceipt.receiptpath = a.receiptpath;
                    redemptionByProductReceipt.status = a.status;
                    redemptionByProductReceipt.invoiceno = a.invoiceno;
                    redemptionByProductReceipt.resellerid = a.resellerid;
                    redemptionByProductReceipt.purchasedate = a.purchasedate;
                    redemptionByProductReceipt.promotionid = a.promotionid;
                    redemptionByProductReceipt.promotionname = a.promotionname;

                    redemptionByProductReceipt.modeofcollection = a.modeofcollection;

                    redemptionByProductReceipt.remarks = a.remarks;

                    redemptionByProductReceipt.datemodified = a.datemodified;
                    redemptionByProductReceipt.dateentry = a.dateentry;

                    redemptionByProductReceipt.clientname = a.clientname;
                    redemptionByProductReceipt.lastname = a.lastname;
                    redemptionByProductReceipt.firstname = a.firstname;
                    redemptionByProductReceipt.contactno = a.contactno;
                    redemptionByProductReceipt.NRIC = a.NRIC;

                    lst.Add(redemptionByProductReceipt);
                }
                return lst;
            }
        }
        public static int insertRedemptionByProductReceipt(
            int clientid, Guid UserId,
            string receiptpath, int status,
            string invoiceno, int resellerid,
            DateTime? purchasedate,
            int promotionid, string promotionname,
           int modeofcollection, string remarks)
        {
            int id = -1;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByProductReceipt = new RedemptionByProductReceipt();
                    redemptionByProductReceipt.clientid = clientid;
                    redemptionByProductReceipt.UserId = UserId;
                    redemptionByProductReceipt.receiptpath = receiptpath;

                    redemptionByProductReceipt.status = status;
                    redemptionByProductReceipt.invoiceno = invoiceno;
                    redemptionByProductReceipt.resellerid = resellerid;
                    redemptionByProductReceipt.purchasedate = purchasedate;

                    redemptionByProductReceipt.promotionid = promotionid;
                    redemptionByProductReceipt.promotionname = promotionname;

                    redemptionByProductReceipt.modeofcollection = modeofcollection;

                    redemptionByProductReceipt.remarks = remarks;

                    redemptionByProductReceipt.dateentry = DateTime.Now;
                    redemptionByProductReceipt.datemodified = DateTime.Now;
                    db.Insert(redemptionByProductReceipt);
                    id = redemptionByProductReceipt.redemptionbyproductreceiptid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return id;
        }
        public static bool duplicateRedemptionByProductReceipt(
         int redemptionbyproductreceiptid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByProductReceipt = RedemptionByProductReceipt.SingleOrDefault("WHERE redemptionbyproductreceiptid=@0", redemptionbyproductreceiptid);
                    redemptionByProductReceipt.status = (int)RedemptionByProductReceiptState.DUPLICATE;

                    redemptionByProductReceipt.datemodified = DateTime.Now;
                    redemptionByProductReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool rejectRedemptionByProductReceipt(
          int redemptionbyproductreceiptid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByProductReceipt = RedemptionByProductReceipt.SingleOrDefault("WHERE redemptionbyproductreceiptid=@0", redemptionbyproductreceiptid);
                    redemptionByProductReceipt.status = (int)RedemptionByProductReceiptState.REJECTED;
              
                    redemptionByProductReceipt.datemodified = DateTime.Now;
                    redemptionByProductReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool updateRedemptionByProductReceipt(
            int redemptionbyproductreceiptid,
          int status,
            string invoiceno, int resellerid,
            DateTime? purchasedate,
            int promotionid, string promotionname)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByProductReceipt = RedemptionByProductReceipt.SingleOrDefault("WHERE redemptionbyproductreceiptid=@0", redemptionbyproductreceiptid);
                    redemptionByProductReceipt.status = status;
                    redemptionByProductReceipt.invoiceno = invoiceno;
                    redemptionByProductReceipt.resellerid = resellerid;
                    redemptionByProductReceipt.purchasedate = purchasedate;
                    redemptionByProductReceipt.promotionid = promotionid;
                    redemptionByProductReceipt.promotionname = promotionname;
                    redemptionByProductReceipt.datemodified = DateTime.Now;
                    redemptionByProductReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static RedemptionByProductReceipt getRedemptionByProductReceipt(int redemptionbyproductreceiptid)
        {
            // bool success = false;
            var redemptionByProductReceipt = new RedemptionByProductReceipt();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionByProductReceipt = RedemptionByProductReceipt.SingleOrDefault("WHERE redemptionbyproductreceiptid=@0", redemptionbyproductreceiptid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionByProductReceipt;
        }
        #endregion
        #region redemption rewards

        private const string ALL_REDEMPTIONREWARDS_BYUSERID_BYCLIENTID = @"SELECT     
redemptionrewardid, clientid, UserId, promotionid, promotionname, productid,productname, rewardid, 
rewardname, rewardpoints, modeofcollection, serialno, remarks, status, type, dateentry, datemodified
FROM         dbo.RedemptionReward
WHERE     (UserId = @0) AND (clientid = @1) order by redemptionrewardid desc";

        public static List<RedemptionReward> getAllRedemptionRewardByUserIdClientId(
             Guid UserId, int ClientId)
        {
            List<RedemptionReward> lst = new List<RedemptionReward>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDS_BYUSERID_BYCLIENTID, UserId, ClientId))
                {
                    var redemptionReward = new RedemptionReward();
                    redemptionReward.redemptionrewardid = a.redemptionrewardid;
                    redemptionReward.UserId = a.UserId;
                    redemptionReward.clientid = a.clientid;
                    redemptionReward.promotionid = a.promotionid;
                    redemptionReward.promotionname = a.promotionname;
                    redemptionReward.productid = a.productid;
                    redemptionReward.productname = a.productname;
                    redemptionReward.rewardid = a.rewardid;
                    redemptionReward.rewardname = a.rewardname;
                    redemptionReward.rewardpoints = a.rewardpoints;
                    redemptionReward.modeofcollection = a.modeofcollection;
                    redemptionReward.serialno = a.serialno;
                    redemptionReward.remarks = a.remarks;
                    redemptionReward.status = a.status;
                    redemptionReward.type = a.type;
                    redemptionReward.datemodified = a.datemodified;
                    redemptionReward.dateentry = a.dateentry;

                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }


        private const string ALL_REDEMPTIONREWARDS__BYPRODUCT_PENDINGPROCESS = @"SELECT     
redemptionrewardid, clientid, UserId, promotionid, promotionname, productid,productname, rewardid, 
rewardname, rewardpoints, modeofcollection, serialno, remarks, status, type, dateentry, datemodified
FROM         dbo.RedemptionReward
WHERE     (status = 0) and (type=1)
order by redemptionrewardid ";

        public static List<RedemptionReward> getAllRedemptionRewardByProductPendingProcess()
        {
            List<RedemptionReward> lst = new List<RedemptionReward>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDS__BYPRODUCT_PENDINGPROCESS))
                {
                    var redemptionReward = new RedemptionReward();
                    redemptionReward.redemptionrewardid = a.redemptionrewardid;
                    redemptionReward.UserId = a.UserId;
                    redemptionReward.clientid = a.clientid;
                    redemptionReward.promotionid = a.promotionid;
                    redemptionReward.promotionname = a.promotionname;
                    redemptionReward.productid = a.productid;
                    redemptionReward.productname = a.productname;
                    redemptionReward.rewardid = a.rewardid;
                    redemptionReward.rewardname = a.rewardname;
                    redemptionReward.rewardpoints = a.rewardpoints;
                    redemptionReward.modeofcollection = a.modeofcollection;
                    redemptionReward.serialno = a.serialno;
                    redemptionReward.remarks = a.remarks;
                    redemptionReward.status = a.status;
                    redemptionReward.type = a.type;
                    redemptionReward.datemodified = a.datemodified;
                    redemptionReward.dateentry = a.dateentry;

                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }

        /*
        private const string ALL_REDEMPTIONREWARDS = @"SELECT     
redemptionrewardid, clientid, UserId,redemptionbyproductreceiptid, promotionid, promotionname, productid,productname, rewardid, 
rewardname, rewardpoints, modeofcollection, serialno, remarks, status, type, dateentry, datemodified
FROM         dbo.RedemptionReward
 order by redemptionrewardid desc";
        */
        private const string ALL_REDEMPTIONREWARDS = @"SELECT
 dbo.RedemptionReward.redemptionrewardid, dbo.RedemptionReward.clientid, dbo.RedemptionReward.UserId, dbo.RedemptionReward.redemptionbyproductreceiptid, 
                      dbo.RedemptionReward.promotionid, dbo.RedemptionReward.promotionname, dbo.RedemptionReward.productid, dbo.RedemptionReward.productname, dbo.RedemptionReward.rewardid, 
                      dbo.RedemptionReward.rewardname, dbo.RedemptionReward.rewardpoints, dbo.RedemptionReward.modeofcollection, dbo.RedemptionReward.serialno, dbo.RedemptionReward.remarks, 
                      dbo.RedemptionReward.status, dbo.RedemptionReward.type, dbo.RedemptionReward.dateentry, dbo.RedemptionReward.datemodified, dbo.Client.name AS clientname, 
                      dbo.RedemptionMember.firstname, dbo.RedemptionMember.lastname, dbo.RedemptionMember.NRIC, dbo.RedemptionMember.contactno
FROM         dbo.RedemptionReward LEFT OUTER JOIN
                      dbo.Client ON dbo.RedemptionReward.clientid = dbo.Client.clientid LEFT OUTER JOIN
                      dbo.RedemptionMember ON dbo.RedemptionReward.UserId = dbo.RedemptionMember.UserId
ORDER BY dbo.RedemptionReward.redemptionrewardid DESC";
        public sealed class RedemptionReward4
        {
            public int redemptionrewardid { get; set; }
            public int redemptionbyproductreceiptid { get; set; }
            public Guid UserId { get; set; }
            public int clientid { get; set; }

            public int promotionid { get; set; }
            public string promotionname { get; set; }
            public int productid { get; set; }
            public string productname { get; set; }

            public int rewardid { get; set; }
            public string rewardname { get; set; }
            public int rewardpoints { get; set; }
            public int modeofcollection { get; set; }

            public string serialno { get; set; }
            public string remarks { get; set; }
            public int status { get; set; }
            public int type { get; set; }
            public DateTime datemodified { get; set; }
            public DateTime dateentry { get; set; }

            public string clientname { get; set; }
            public string lastname { get; set; }
            public string firstname { get; set; }
            public string contactno { get; set; }
            public string NRIC { get; set; }
        }

        public static List<RedemptionReward4> getAllRedemptionRewards()
        {
            List<RedemptionReward4> lst = new List<RedemptionReward4>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDS))
                {
                    var redemptionReward = new RedemptionReward4();
                    redemptionReward.redemptionrewardid = a.redemptionrewardid;
                    redemptionReward.redemptionbyproductreceiptid = a.redemptionbyproductreceiptid;
                    redemptionReward.UserId = a.UserId;
                    redemptionReward.clientid = a.clientid;

                    redemptionReward.promotionid = a.promotionid;
                    redemptionReward.promotionname = a.promotionname;
                    redemptionReward.productid = a.productid;
                    redemptionReward.productname = a.productname;

                    redemptionReward.rewardid = a.rewardid;
                    redemptionReward.rewardname = a.rewardname;
                    redemptionReward.rewardpoints = a.rewardpoints;
                    redemptionReward.modeofcollection = a.modeofcollection;

                    redemptionReward.serialno = a.serialno;
                    redemptionReward.remarks = a.remarks;
                    redemptionReward.status = a.status;
                    redemptionReward.type = a.type;
                    redemptionReward.datemodified = a.datemodified;
                    redemptionReward.dateentry = a.dateentry;

                    redemptionReward.clientname = a.clientname;
                    redemptionReward.lastname = a.lastname;
                    redemptionReward.firstname = a.firstname;
                    redemptionReward.contactno = a.contactno;
                    redemptionReward.NRIC = a.NRIC;

                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }

        [Serializable]
        public sealed class ViewRedemptionReward2
        {
            public int redemptionrewardid { get; set; }

            public Guid UserId { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public bool gender { get; set; }
            public string contactno { get; set; }
            public string NRIC { get; set; }
            public DateTime dateofbirth { get; set; }
            public string mailingaddress { get; set; }
            public string postalcode { get; set; }

            public int rewardid { get; set; }
            public string rewardname { get; set; }
            public int rewardpoints { get; set; }

            public int promotionid { get; set; }
            public string promotionname { get; set; }

            public int redemptionbyproductreceiptid { get; set; }
            public string serialno { get; set; }
            public int productid { get; set; }
            public string productname { get; set; }
            public string productmodel { get; set; }
            public string invoiceno { get; set; }
            public DateTime purchasedate { get; set; }
            public string resellername { get; set; }

            public int modeofcollection { get; set; }
            public string remarks { get; set; }


            public int status { get; set; }
            public int type { get; set; }
            public DateTime dateentry { get; set; }
            public DateTime datemodified { get; set; }






            public int clientid { get; set; }
        }

        private const string ALL_REDEMPTIONREWARDS_BYPROMOTIONPERIOD = @"SELECT     dbo.RedemptionReward.redemptionrewardid, dbo.RedemptionReward.UserId, dbo.RedemptionMember.firstname, dbo.RedemptionMember.lastname, dbo.RedemptionMember.gender, 
                      dbo.RedemptionMember.contactno, dbo.RedemptionMember.NRIC, dbo.RedemptionMember.dateofbirth, dbo.RedemptionMember.mailingaddress, dbo.RedemptionMember.postalcode, 
                      dbo.RedemptionReward.rewardid, dbo.RedemptionReward.rewardname, dbo.RedemptionReward.rewardpoints, dbo.RedemptionReward.redemptionbyproductreceiptid, 
                      dbo.RedemptionReward.serialno, dbo.RedemptionReward.productid, dbo.RedemptionReward.productname, dbo.Product.model AS productmodel, dbo.RedemptionReward.modeofcollection, 
                      dbo.RedemptionReward.remarks, dbo.RedemptionReward.type, dbo.RedemptionReward.dateentry, dbo.RedemptionReward.datemodified, dbo.RedemptionReward.clientid, 
                      dbo.RedemptionReward.promotionid, dbo.RedemptionReward.promotionname, dbo.RedemptionReward.status, dbo.RedemptionByProductReceipt.invoiceno, 
                      dbo.RedemptionByProductReceipt.purchasedate, dbo.Reseller.name AS resellername
FROM         dbo.Reseller INNER JOIN
                      dbo.RedemptionByProductReceipt ON dbo.Reseller.resellerid = dbo.RedemptionByProductReceipt.resellerid RIGHT OUTER JOIN
                      dbo.RedemptionReward ON dbo.RedemptionByProductReceipt.redemptionbyproductreceiptid = dbo.RedemptionReward.redemptionbyproductreceiptid LEFT OUTER JOIN
                      dbo.RedemptionMember ON dbo.RedemptionReward.UserId = dbo.RedemptionMember.UserId LEFT OUTER JOIN
                      dbo.Reward ON dbo.RedemptionReward.rewardid = dbo.Reward.rewardid LEFT OUTER JOIN
                      dbo.Product ON dbo.RedemptionReward.productid = dbo.Product.productid

WHERE     ( dbo.RedemptionReward.dateentry >= @0) and (  @1 >=  dbo.RedemptionReward.dateentry) and (  dbo.RedemptionReward.promotionid = @2) 
 order by redemptionrewardid desc";
        public static List<ViewRedemptionReward2> getAllRedemptionRewardsByPromotionPeriod(DateTime fromDate, DateTime toDate, int promotionid)
        {
            List<ViewRedemptionReward2> lst = new List<ViewRedemptionReward2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDS_BYPROMOTIONPERIOD, fromDate, toDate, promotionid))
                {
                    var redemptionReward = new ViewRedemptionReward2();
                    redemptionReward.redemptionrewardid = a.redemptionrewardid;
                    redemptionReward.clientid = a.clientid;
                    redemptionReward.UserId = a.UserId;
                    redemptionReward.redemptionbyproductreceiptid = a.redemptionbyproductreceiptid;

                    redemptionReward.promotionid = a.promotionid;
                    redemptionReward.promotionname = a.promotionname;
                    redemptionReward.productid = a.productid;
                    redemptionReward.productname = a.productname;
                    redemptionReward.rewardid = a.rewardid;

                    redemptionReward.rewardname = a.rewardname;
                    redemptionReward.rewardpoints = a.rewardpoints;
                    redemptionReward.modeofcollection = a.modeofcollection;
                    redemptionReward.serialno = a.serialno;
                    redemptionReward.remarks = a.remarks;

                    redemptionReward.status = a.status;
                    redemptionReward.type = a.type;
                    redemptionReward.datemodified = a.datemodified;
                    redemptionReward.dateentry = a.dateentry;
                    redemptionReward.productmodel = a.productmodel;

                    redemptionReward.firstname = a.firstname;
                    redemptionReward.lastname = a.lastname;
                    redemptionReward.gender = a.gender;
                    redemptionReward.contactno = a.contactno;
                    redemptionReward.NRIC = a.NRIC;

                    redemptionReward.dateofbirth = a.dateofbirth;
                    redemptionReward.mailingaddress = a.mailingaddress;
                    redemptionReward.postalcode = a.postalcode;

                    redemptionReward.invoiceno = a.invoiceno;
                    if (a.purchasedate != null)
                    {
                        redemptionReward.purchasedate = a.purchasedate;
                    }
                    redemptionReward.resellername = a.resellername;


                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }

        private const string TOTAL_POINTSREDEEMED_BYPROMOTIONPERIOD = @"SELECT     SUM(dbo.RedemptionReward.rewardpoints) AS TotalPointsRedeemed
FROM         dbo.Reseller INNER JOIN
                      dbo.RedemptionByProductReceipt ON dbo.Reseller.resellerid = dbo.RedemptionByProductReceipt.resellerid RIGHT OUTER JOIN
                      dbo.RedemptionReward ON dbo.RedemptionByProductReceipt.redemptionbyproductreceiptid = dbo.RedemptionReward.redemptionbyproductreceiptid LEFT OUTER JOIN
                      dbo.RedemptionMember ON dbo.RedemptionReward.UserId = dbo.RedemptionMember.UserId LEFT OUTER JOIN
                      dbo.Reward ON dbo.RedemptionReward.rewardid = dbo.Reward.rewardid LEFT OUTER JOIN
                      dbo.Product ON dbo.RedemptionReward.productid = dbo.Product.productid

WHERE     ( dbo.RedemptionReward.dateentry >= @0) and (  @1 >=  dbo.RedemptionReward.dateentry) and (  dbo.RedemptionReward.promotionid = @2) ";

        public static int getTotalPointsRedeemedByPromotionPeriod(DateTime fromDate, DateTime toDate, int promotionid)
        {
            int i = 0;
            // bool success = false;
            var redemptionByProductReceipt = new RedemptionByProductReceipt();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    i = db.ExecuteScalar<int>(TOTAL_POINTSREDEEMED_BYPROMOTIONPERIOD, fromDate, toDate, promotionid);
                    //   redemptionByProductReceipt = TotalPointRedeemed.SingleOrDefault(TOTAL_POINTSREDEEMED_BYPROMOTIONPERIOD, fromDate, toDate, promotionid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return i;
        }


        [Serializable]
        public sealed class ViewRedemptionRewardProductSummary2
        {
            public int ProductID { get; set; }

            public string ProductName { get; set; }
            public string ProductModel { get; set; }
            public int PurchaseQty { get; set; }
        }
        private const string ALL_REDEMPTIONREWARDSPRODUCTSUMMARY_BYPROMOTIONPERIOD = @"SELECT     productid AS ProductID, productname AS ProductName, productmodel AS ProductModel, COUNT(productid) AS PurchaseQty
FROM         dbo.ViewRedemptionReward
WHERE     ( @1 >= dateentry) AND (dateentry >= @0) AND (promotionid = @2)

GROUP BY productid, productname, productmodel";
        public static List<ViewRedemptionRewardProductSummary2> getAllViewRedemptionRewardProductSummaryByPromotionPeriod(DateTime fromDate, DateTime toDate, int promotionid)
        {
            List<ViewRedemptionRewardProductSummary2> lst = new List<ViewRedemptionRewardProductSummary2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDSPRODUCTSUMMARY_BYPROMOTIONPERIOD, fromDate, toDate, promotionid))
                {
                    var redemptionReward = new ViewRedemptionRewardProductSummary2();
                    redemptionReward.ProductID = a.ProductID;
                    redemptionReward.ProductName = a.ProductName;
                    redemptionReward.ProductModel = a.ProductModel;
                    redemptionReward.PurchaseQty = a.PurchaseQty;
                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }

        [Serializable]
        public sealed class ViewRedemptionRewardRewardSummary2
        {
            public int RewardId { get; set; }

            public string RewardName { get; set; }

            public int RedeemQty { get; set; }
        }
        private const string ALL_REDEMPTIONREWARDSREWARDSUMMARY_BYPROMOTIONPERIOD = @"SELECT     rewardid AS RewardId, rewardname AS RewardName, COUNT(rewardpoints) AS RedeemQty
FROM         dbo.ViewRedemptionReward
WHERE     ( @1 >= dateentry) AND (dateentry >= @0) AND (promotionid = @2)

GROUP BY rewardid, rewardname, rewardpoints";
        public static List<ViewRedemptionRewardRewardSummary2> getAllViewRedemptionRewardRewardsSummaryByPromotionPeriod(DateTime fromDate, DateTime toDate, int promotionid)
        {
            List<ViewRedemptionRewardRewardSummary2> lst = new List<ViewRedemptionRewardRewardSummary2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDSREWARDSUMMARY_BYPROMOTIONPERIOD, fromDate, toDate, promotionid))
                {
                    var redemptionReward = new ViewRedemptionRewardRewardSummary2();
                    redemptionReward.RewardId = a.RewardId;
                    redemptionReward.RewardName = a.RewardName;

                    redemptionReward.RedeemQty = a.RedeemQty;
                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }

        /*ViewRedemptionRewardProductSummary
         SELECT     productid AS ProductID, productname AS ProductName, productmodel AS ProductModel, COUNT(productid) AS PurchaseQty
FROM         dbo.ViewRedemptionReward
WHERE     ('2014/01/12' >= dateentry) AND (dateentry >= '2012/01/12') AND (promotionid = 2)
GROUP BY productid, productname, productmodel
         * 
         * RedemptionRewardRewardSummary
         * SELECT     rewardid AS RewardId, rewardname AS RewardName, COUNT(rewardpoints) AS RedeemQty
FROM         dbo.ViewRedemptionReward
WHERE     ('2014/01/12' >= dateentry) AND (dateentry >= '2012/01/12') AND (promotionid = 2)
GROUP BY rewardid, rewardname, rewardpoints
         * */

        private const string ALL_REDEMPTIONREWARDS_BYRECEIPTID = @"SELECT     
redemptionrewardid, clientid, UserId, promotionid, promotionname, productid, productname, rewardid, rewardname, rewardpoints, modeofcollection, serialno, remarks, status, type, dateentry, 
                      datemodified, redemptionbyproductreceiptid
FROM         dbo.RedemptionReward
WHERE     (type = 1) AND  (redemptionbyproductreceiptid = @0) order by redemptionrewardid desc";

        public static List<RedemptionReward> getAllRedemptionRewardsByReceiptId(
                    int redemptionbyproductreceiptid)
        {
            List<RedemptionReward> lst = new List<RedemptionReward>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONREWARDS_BYRECEIPTID, redemptionbyproductreceiptid))
                {
                    var redemptionReward = new RedemptionReward();
                    redemptionReward.redemptionrewardid = a.redemptionrewardid;
                    redemptionReward.UserId = a.UserId;
                    redemptionReward.clientid = a.clientid;
                    redemptionReward.promotionid = a.promotionid;
                    redemptionReward.promotionname = a.promotionname;
                    redemptionReward.productid = a.productid;
                    redemptionReward.productname = a.productname;
                    redemptionReward.rewardid = a.rewardid;
                    redemptionReward.rewardname = a.rewardname;
                    redemptionReward.rewardpoints = a.rewardpoints;
                    redemptionReward.modeofcollection = a.modeofcollection;
                    redemptionReward.serialno = a.serialno;
                    redemptionReward.remarks = a.remarks;
                    redemptionReward.status = a.status;
                    redemptionReward.type = a.type;
                    redemptionReward.redemptionbyproductreceiptid = a.redemptionbyproductreceiptid;
                    redemptionReward.datemodified = a.datemodified;
                    redemptionReward.dateentry = a.dateentry;

                    lst.Add(redemptionReward);
                }
                return lst;
            }
        }

        public sealed class DuplicateInvoiceByProduct
        {
            public int redemptionrewardid { get; set; }
            public int redemptionbyproductreceiptid { get; set; }

        }

        private const string FIND_REDEMPTIONREWARD_WITHINVOICENO = @"SELECT     TOP (1) dbo.RedemptionByProductReceipt.invoiceno, dbo.RedemptionReward.redemptionrewardid, dbo.RedemptionReward.redemptionbyproductreceiptid
FROM         dbo.RedemptionReward INNER JOIN
                      dbo.RedemptionByProductReceipt ON dbo.RedemptionReward.redemptionbyproductreceiptid = dbo.RedemptionByProductReceipt.redemptionbyproductreceiptid
WHERE     (dbo.RedemptionByProductReceipt.redemptionbyproductreceiptid <> @0) AND (dbo.RedemptionByProductReceipt.invoiceno = @1)";


        public static DuplicateInvoiceByProduct findRedemptionRewardIdWithInvoiceNo(
                   int receiptid, string invoiceno)
        {
            // bool success = false;
            var duplicateInvoiceByProduct = new DuplicateInvoiceByProduct();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {

                    foreach (var a in db.Fetch<dynamic>(FIND_REDEMPTIONREWARD_WITHINVOICENO, receiptid, invoiceno))
                    {
                        duplicateInvoiceByProduct.redemptionbyproductreceiptid = a.redemptionbyproductreceiptid;
                        duplicateInvoiceByProduct.redemptionrewardid = a.redemptionrewardid;
                    }

                    // duplicateInvoiceByProduct = DuplicateInvoiceByProduct.SingleOrDefault(FIND_REDEMPTIONREWARD_WITHINVOICENO, invoiceno);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return duplicateInvoiceByProduct;
        }

        public sealed class DuplicateInvoiceByPoint
        {

            public int redemptionbypointreceiptid { get; set; }

        }

        private const string FIND_DUPLICATEBYPOINT_WITHINVOICENO = @"SELECT     TOP (1) 
redemptionbypointreceiptid, invoiceno
FROM         dbo.RedemptionByPointReceipt
WHERE     (redemptionbypointreceiptid <> @0) AND (invoiceno = @1)";


        public static DuplicateInvoiceByPoint findDuplicateInvoiceIdWithInvoiceNo(
                   int receiptid, string invoiceno)
        {
            // bool success = false;
            var duplicateInvoiceByPoint = new DuplicateInvoiceByPoint();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {

                    foreach (var a in db.Fetch<dynamic>(FIND_DUPLICATEBYPOINT_WITHINVOICENO, receiptid, invoiceno))
                    {
                        duplicateInvoiceByPoint.redemptionbypointreceiptid = a.redemptionbypointreceiptid;

                    }

                    // duplicateInvoiceByProduct = DuplicateInvoiceByProduct.SingleOrDefault(FIND_REDEMPTIONREWARD_WITHINVOICENO, invoiceno);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return duplicateInvoiceByPoint;
        }

        public static bool updateRedemptionRedemptionReward(
            int redemptionrewardid, int modeofcollection,
          int status)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionReward = RedemptionReward.SingleOrDefault("WHERE redemptionrewardid=@0", redemptionrewardid);
                    redemptionReward.status = status;
                    redemptionReward.modeofcollection = modeofcollection;

                    redemptionReward.datemodified = DateTime.Now;
                    redemptionReward.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static int insertRedemptionReward(
            int clientid, Guid UserId,
              int promotionid, string promotionname,
            int productid, string productname,
            int rewardid, string rewardname, int rewardpoints,
            int modeofcollection, string serialno, string remarks,
            int type, int status, int redemptionbyproductreceiptid)
        {
            int id = -1;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionReward = new RedemptionReward();
                    redemptionReward.clientid = clientid;
                    redemptionReward.UserId = UserId;
                    redemptionReward.promotionid = promotionid;
                    redemptionReward.promotionname = promotionname;
                    redemptionReward.productid = productid;
                    redemptionReward.productname = productname;
                    redemptionReward.rewardid = rewardid;
                    redemptionReward.rewardname = rewardname;
                    redemptionReward.rewardpoints = rewardpoints;
                    redemptionReward.modeofcollection = modeofcollection;
                    redemptionReward.serialno = serialno;
                    redemptionReward.remarks = remarks;
                    redemptionReward.type = type;
                    redemptionReward.status = status;
                    redemptionReward.redemptionbyproductreceiptid = redemptionbyproductreceiptid;
                    redemptionReward.dateentry = DateTime.Now;
                    redemptionReward.datemodified = DateTime.Now;
                    db.Insert(redemptionReward);
                    id = redemptionReward.redemptionrewardid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return id;
        }

        public static bool deleteRedemptionReward(
          int redemptionrewardid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionReward = RedemptionReward.SingleOrDefault("WHERE redemptionrewardid=@0", redemptionrewardid);
                   

                    redemptionReward.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool updateRedemptionRewardTransactionId(
            int redemptionrewardid, int redemptionbyproductreceiptid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionReward = RedemptionReward.SingleOrDefault("WHERE redemptionrewardid=@0", redemptionrewardid);
                    redemptionReward.redemptionbyproductreceiptid = redemptionbyproductreceiptid;


                    redemptionReward.datemodified = DateTime.Now;
                    redemptionReward.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static RedemptionReward getRedemptionReward(int redemptionrewardid)
        {
            // bool success = false;
            var redemptionReward = new RedemptionReward();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionReward = RedemptionReward.SingleOrDefault("WHERE redemptionrewardid=@0", redemptionrewardid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionReward;
        }
        #endregion
        #region redemption by point invoices


        private const string ALL_REDEMPTIONBYPOINTSRECEIPTS_BYUSERID_BYCLIENTID = @"SELECT     
redemptionbypointreceiptid, 
UserId, receiptpath, clientid, status, dateentry, datemodified,totalpoints,resellerid,purchasedate,invoiceno
FROM         dbo.RedemptionByPointReceipt
WHERE     (UserId = @0) AND (clientid = @1) order by redemptionbypointreceiptid desc";

        /*  private const string ALL_REDEMPTIONBYPOINTSRECEIPTS_PENDING_PROCESS = @"SELECT     redemptionbypointreceiptid, 
  UserId, receiptpath, clientid, status, dateentry, datemodified,totalpoints,resellerid,purchasedate,invoiceno
  FROM         dbo.RedemptionByPointReceipt
  order by status,redemptionbypointreceiptid desc
  ";


          */

        public sealed class RedemptionByPointReceipt3
        {
            public int redemptionbypointreceiptid { get; set; }
            public Guid UserId { get; set; }
            public string receiptpath { get; set; }
            public int clientid { get; set; }
            public int status { get; set; }


            public DateTime dateentry { get; set; }
            public DateTime datemodified { get; set; }
            public int totalpoints { get; set; }
            public int resellerid { get; set; }
            public DateTime? purchasedate { get; set; }
            public string invoiceno { get; set; }

            public string firstname { get; set; }
            public string lastname { get; set; }
            public string NRIC { get; set; }
            public string contactno { get; set; }
            public string clientname { get; set; }

        }

        private const string ALL_REDEMPTIONBYPOINTSRECEIPTS_PENDING_PROCESS = @"SELECT  
dbo.RedemptionByPointReceipt.redemptionbypointreceiptid, dbo.RedemptionByPointReceipt.UserId, 
dbo.RedemptionByPointReceipt.receiptpath, 
dbo.RedemptionByPointReceipt.clientid, dbo.RedemptionByPointReceipt.status, 

dbo.RedemptionByPointReceipt.dateentry, dbo.RedemptionByPointReceipt.datemodified, 
dbo.RedemptionByPointReceipt.totalpoints, dbo.RedemptionByPointReceipt.resellerid, 
dbo.RedemptionByPointReceipt.purchasedate, dbo.RedemptionByPointReceipt.invoiceno, 

dbo.RedemptionMember.firstname, dbo.RedemptionMember.lastname,
dbo.RedemptionMember.NRIC, dbo.RedemptionMember.contactno, 
dbo.Client.name AS clientname
FROM         dbo.RedemptionByPointReceipt LEFT OUTER JOIN
                      dbo.Client ON dbo.RedemptionByPointReceipt.clientid = dbo.Client.clientid LEFT OUTER JOIN
                      dbo.RedemptionMember ON dbo.RedemptionByPointReceipt.UserId = dbo.RedemptionMember.UserId
ORDER BY dbo.RedemptionByPointReceipt.status, dbo.RedemptionByPointReceipt.redemptionbypointreceiptid DESC";

        public static List<RedemptionByPointReceipt> getAllRedemptionByPointReceiptByUserIdClientId(Guid UserId, int ClientId)
        {
            List<RedemptionByPointReceipt> lst = new List<RedemptionByPointReceipt>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONBYPOINTSRECEIPTS_BYUSERID_BYCLIENTID, UserId, ClientId))
                {
                    var redemptionByPointReceipt = new RedemptionByPointReceipt();
                    redemptionByPointReceipt.redemptionbypointreceiptid = a.redemptionbypointreceiptid;
                    redemptionByPointReceipt.UserId = a.UserId;
                    redemptionByPointReceipt.receiptpath = a.receiptpath;
                    redemptionByPointReceipt.clientid = a.clientid;
                    redemptionByPointReceipt.status = a.status;
                    redemptionByPointReceipt.totalpoints = a.totalpoints;
                    redemptionByPointReceipt.resellerid = a.resellerid;
                    redemptionByPointReceipt.invoiceno = a.invoiceno;

                    redemptionByPointReceipt.purchasedate = a.purchasedate;
                    redemptionByPointReceipt.datemodified = a.datemodified;
                    redemptionByPointReceipt.dateentry = a.dateentry;

                    lst.Add(redemptionByPointReceipt);
                }
                return lst;
            }
        }

        public static List<RedemptionByPointReceipt3> getAllRedemptionByPointReceiptPendingProcess()
        {
            List<RedemptionByPointReceipt3> lst = new List<RedemptionByPointReceipt3>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONBYPOINTSRECEIPTS_PENDING_PROCESS))
                {
                    var redemptionByPointReceipt3 = new RedemptionByPointReceipt3();
                    redemptionByPointReceipt3.redemptionbypointreceiptid = a.redemptionbypointreceiptid;
                    redemptionByPointReceipt3.UserId = a.UserId;
                    redemptionByPointReceipt3.receiptpath = a.receiptpath;
                    redemptionByPointReceipt3.clientid = a.clientid;
                    redemptionByPointReceipt3.status = a.status;

                    redemptionByPointReceipt3.datemodified = a.datemodified;
                    redemptionByPointReceipt3.dateentry = a.dateentry;
                    redemptionByPointReceipt3.totalpoints = a.totalpoints;
                    redemptionByPointReceipt3.resellerid = a.resellerid;
                    redemptionByPointReceipt3.purchasedate = a.purchasedate;
                    redemptionByPointReceipt3.invoiceno = a.invoiceno;

                    redemptionByPointReceipt3.firstname = a.firstname;
                    redemptionByPointReceipt3.lastname = a.lastname;
                    redemptionByPointReceipt3.NRIC = a.NRIC;
                    redemptionByPointReceipt3.contactno = a.contactno;
                    redemptionByPointReceipt3.clientname = a.clientname;


                    lst.Add(redemptionByPointReceipt3);

                }
                return lst;
            }
        }



        public static bool insertRedemptionByPointReceipt(Guid UserId, string receiptpath, int clientid,
           int status, int totalpoints, int resellerid, string invoiceno, DateTime? purchasedate)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = new RedemptionByPointReceipt();
                    redemptionByPointReceipt.UserId = UserId;
                    redemptionByPointReceipt.receiptpath = receiptpath;
                    redemptionByPointReceipt.clientid = clientid;
                    redemptionByPointReceipt.status = status;
                    redemptionByPointReceipt.totalpoints = totalpoints;
                    redemptionByPointReceipt.resellerid = resellerid;
                    redemptionByPointReceipt.invoiceno = invoiceno;
                    redemptionByPointReceipt.purchasedate = purchasedate;
                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.dateentry = DateTime.Now;
                    db.Insert(redemptionByPointReceipt);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }


        public static bool updateRedemptionByPointReceiptPoint(int redemptionbypointreceiptid, int totalpoints)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);

                    redemptionByPointReceipt.totalpoints = totalpoints;

                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool approveRedemptionByPointReceipt(int redemptionbypointreceiptid,
           int resellerid, string invoiceno, DateTime purchasedate)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);

                    redemptionByPointReceipt.resellerid = resellerid;
                    redemptionByPointReceipt.invoiceno = invoiceno;
                    redemptionByPointReceipt.purchasedate = purchasedate;
                    redemptionByPointReceipt.status = (int)RedemptionByPointReceiptState.PROCESSED;
                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool rejectRedemptionByPointReceipt(int redemptionbypointreceiptid         )
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);   
                    redemptionByPointReceipt.status = (int)RedemptionByPointReceiptState.REJECTED;
                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool duplicateRedemptionByPointReceipt(int redemptionbypointreceiptid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);
                    redemptionByPointReceipt.status = (int)RedemptionByPointReceiptState.DUPLICATE;
                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool voidRedemptionByPointReceipt(int redemptionbypointreceiptid,
          int resellerid, string invoiceno, DateTime purchasedate)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);

                    redemptionByPointReceipt.resellerid = resellerid;
                    redemptionByPointReceipt.invoiceno = invoiceno;
                    redemptionByPointReceipt.purchasedate = purchasedate;
                    redemptionByPointReceipt.status = (int)RedemptionByPointReceiptState.VOID;
                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool updateRedemptionByPointReceipt(int redemptionbypointreceiptid, Guid UserId, string receiptpath, int clientid,
           int status, int totalpoints, int resellerid, string invoiceno, DateTime purchasedate)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);
                    redemptionByPointReceipt.UserId = UserId;
                    redemptionByPointReceipt.receiptpath = receiptpath;
                    redemptionByPointReceipt.clientid = clientid;
                    redemptionByPointReceipt.status = status;
                    redemptionByPointReceipt.totalpoints = totalpoints;
                    redemptionByPointReceipt.resellerid = resellerid;
                    redemptionByPointReceipt.invoiceno = invoiceno;
                    redemptionByPointReceipt.purchasedate = purchasedate;
                    redemptionByPointReceipt.datemodified = DateTime.Now;
                    redemptionByPointReceipt.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static RedemptionByPointReceipt getRedemptionByPointReceipt(int redemptionbypointreceiptid)
        {
            // bool success = false;
            var redemptionByPointReceipt = new RedemptionByPointReceipt();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionByPointReceipt = RedemptionByPointReceipt.SingleOrDefault("WHERE redemptionbypointreceiptid=@0", redemptionbypointreceiptid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionByPointReceipt;
        }

        #endregion
        #region RedemptionByPointReceiptItem

        private const string ALL_REDEMPTIONBYPOINTS_RECEIPTPOINTITEMS_BYRECEIPTID = @"SELECT     
 redemptionbypointreceiptitemid, redemptionbypointreceiptid, productid, productmodel, serialno, productpoints, dateentry, datemodified
FROM         dbo.RedemptionByPointReceiptItem
WHERE     (redemptionbypointreceiptid = @0)";
        public static List<RedemptionByPointReceiptItem> getAllRedemptionByPointReceiptReceiptId(int redemptionbypointreceiptid)
        {
            List<RedemptionByPointReceiptItem> lst = new List<RedemptionByPointReceiptItem>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONBYPOINTS_RECEIPTPOINTITEMS_BYRECEIPTID, redemptionbypointreceiptid))
                {
                    var redemptionByPointReceiptItem = new RedemptionByPointReceiptItem();
                    redemptionByPointReceiptItem.redemptionbypointreceiptitemid = a.redemptionbypointreceiptitemid;
                    redemptionByPointReceiptItem.redemptionbypointreceiptid = a.redemptionbypointreceiptid;
                    redemptionByPointReceiptItem.productid = a.productid;
                    redemptionByPointReceiptItem.productmodel = a.productmodel;
                    redemptionByPointReceiptItem.serialno = a.serialno;
                    redemptionByPointReceiptItem.productpoints = a.productpoints;

                    redemptionByPointReceiptItem.datemodified = a.datemodified;
                    redemptionByPointReceiptItem.dateentry = a.dateentry;

                    lst.Add(redemptionByPointReceiptItem);
                }
                return lst;
            }
        }


        public static bool insertRedemptionByPointReceiptItem(
            int redemptionbypointreceiptid, int productid,
           string serialno, int productpoints, string productmodel)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceiptItem = new RedemptionByPointReceiptItem();
                    redemptionByPointReceiptItem.redemptionbypointreceiptid = redemptionbypointreceiptid;
                    redemptionByPointReceiptItem.productid = productid;
                    redemptionByPointReceiptItem.serialno = serialno;
                    redemptionByPointReceiptItem.productpoints = productpoints;
                    redemptionByPointReceiptItem.productmodel = productmodel;
                    redemptionByPointReceiptItem.datemodified = DateTime.Now;
                    redemptionByPointReceiptItem.dateentry = DateTime.Now;
                    db.Insert(redemptionByPointReceiptItem);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool deleteRedemptionByPointReceiptItem(
            int redemptionbypointreceiptItemid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointReceiptItem = RedemptionByPointReceiptItem.SingleOrDefault("WHERE redemptionbypointreceiptItemid=@0", redemptionbypointreceiptItemid);
                    redemptionByPointReceiptItem.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static RedemptionByPointReceiptItem getRedemptionByPointReceiptItem(int redemptionbypointreceiptitemid)
        {
            // bool success = false;
            var redemptionByPointReceiptItem = new RedemptionByPointReceiptItem();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionByPointReceiptItem = RedemptionByPointReceiptItem.SingleOrDefault("WHERE redemptionbypointreceiptitemid=@0", redemptionbypointreceiptitemid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionByPointReceiptItem;
        }
        #endregion


        #region redemption by point tranactions


        private const string ALL_REDEMPTIONBYPOINTSTRANSACTIONS_BYUSERID = @"SELECT     
redemptionbypointtransactionid, 
UserId, clientid, type, points, balance, notes, dateentry, datemodified
FROM         dbo.RedemptionByPointTransaction
WHERE     (UserId = @0) AND (clientid = @1)  order by redemptionbypointtransactionid desc";


        public static List<RedemptionByPointTransaction> getAllRedemptionByPointTransactionByUserId(Guid UserId, int clientid)
        {
            List<RedemptionByPointTransaction> lst = new List<RedemptionByPointTransaction>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_REDEMPTIONBYPOINTSTRANSACTIONS_BYUSERID, UserId, clientid))
                {
                    var redemptionByPointTransaction = new RedemptionByPointTransaction();
                    redemptionByPointTransaction.redemptionbypointtransactionid = a.redemptionbypointtransactionid;
                    redemptionByPointTransaction.UserId = a.UserId;
                    redemptionByPointTransaction.clientid = a.clientid;
                    redemptionByPointTransaction.type = a.type;
                    redemptionByPointTransaction.points = a.points;
                    redemptionByPointTransaction.balance = a.balance;
                    redemptionByPointTransaction.notes = a.notes;
                    redemptionByPointTransaction.datemodified = a.datemodified;
                    redemptionByPointTransaction.dateentry = a.dateentry;

                    lst.Add(redemptionByPointTransaction);
                }
                return lst;
            }
        }

        public static int insertRedemptionByPointTransaction(
            Guid UserId, int clientid,
            int type, int points, int balance, string notes)
        {
            int id = -1;
            // bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var redemptionByPointTransaction = new RedemptionByPointTransaction();
                    redemptionByPointTransaction.UserId = UserId;
                    redemptionByPointTransaction.clientid = clientid;
                    redemptionByPointTransaction.type = type;
                    redemptionByPointTransaction.points = points;
                    redemptionByPointTransaction.balance = balance;
                    redemptionByPointTransaction.notes = notes;
                    redemptionByPointTransaction.datemodified = DateTime.Now;
                    redemptionByPointTransaction.dateentry = DateTime.Now;
                    db.Insert(redemptionByPointTransaction);
                    // success = true;
                    id = redemptionByPointTransaction.redemptionbypointtransactionid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            // return success;
            return id;
        }


        public static RedemptionByPointTransaction getRedemptionByPointTransaction(
            int RedemptionByPointTransactionid)
        {
            // bool success = false;
            var redemptionByPointTransaction = new RedemptionByPointTransaction();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    redemptionByPointTransaction = RedemptionByPointTransaction.SingleOrDefault("WHERE RedemptionByPointTransactionid=@0", RedemptionByPointTransactionid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return redemptionByPointTransaction;
        }
        #endregion


        private const string PROMOTIONBYPRODUCTPRODUCTREWARD_BYCPROMOTIONID_BYREWARDID = @"SELECT     promotionid, productid, rewardid
FROM         dbo.PromotionByProductProductReward
WHERE     (promotionid = @0) AND (rewardid = @1)";

        public static PromotionByProductProductReward getPromotionByProductProductRewardByPromotionIdRewardId(
              int promotionid, int rewardid)
        {
            // bool success = false;
            var promotionByProductProductReward = new PromotionByProductProductReward();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    promotionByProductProductReward = PromotionByProductProductReward.SingleOrDefault(
                        PROMOTIONBYPRODUCTPRODUCTREWARD_BYCPROMOTIONID_BYREWARDID, promotionid, rewardid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return promotionByProductProductReward;

        }
        private const string PROMOTIONBYPRODUCTPRODUCTREWARD_BYCPROMOTIONID_BYPRODUCTID = @"SELECT     promotionid, productid, rewardid
FROM         dbo.PromotionByProductProductReward
WHERE     (promotionid = @0) AND (productid = @1)";

        public static PromotionByProductProductReward getPromotionByProductProductRewardByPromotionIdProductId(
              int promotionid, int productid)
        {
            // bool success = false;
            var promotionByProductProductReward = new PromotionByProductProductReward();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    promotionByProductProductReward = PromotionByProductProductReward.SingleOrDefault(
                        PROMOTIONBYPRODUCTPRODUCTREWARD_BYCPROMOTIONID_BYPRODUCTID, promotionid, productid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return promotionByProductProductReward;

        }
        public sealed class PromotionByProductProductReward2
        {
            public int promotionid { get; set; }
            public int productid { get; set; }
            public string productname { get; set; }
            public int rewardid { get; set; }
            public string rewardname { get; set; }

        }
        private const string ALL_PROMOTIONBYPRODUCTPRODUCTREWARDS = @"SELECT     
dbo.PromotionByProductProductReward.promotionid, 
dbo.PromotionByProductProductReward.productid, 
dbo.Product.name AS productname, 
dbo.PromotionByProductProductReward.rewardid, 
dbo.Reward.name AS rewardname
FROM         dbo.PromotionByProductProductReward INNER JOIN
                      dbo.Product ON dbo.PromotionByProductProductReward.productid = dbo.Product.productid INNER JOIN
                      dbo.Reward ON dbo.PromotionByProductProductReward.rewardid = dbo.Reward.rewardid
WHERE     (dbo.PromotionByProductProductReward.promotionid = @0)";
        public static List<PromotionByProductProductReward2> getAllPromotionByProductProductRewardByPromotionId(int promotionid)
        {
            List<PromotionByProductProductReward2> lst = new List<PromotionByProductProductReward2>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_PROMOTIONBYPRODUCTPRODUCTREWARDS, promotionid))
                {
                    var promotionByProductProductReward2 = new PromotionByProductProductReward2();
                    promotionByProductProductReward2.promotionid = a.promotionid;
                    promotionByProductProductReward2.productid = a.productid;
                    promotionByProductProductReward2.productname = a.productname;
                    promotionByProductProductReward2.rewardid = a.rewardid;
                    promotionByProductProductReward2.rewardname = a.rewardname;
                    lst.Add(promotionByProductProductReward2);
                }
                return lst;
            }
        }

        public static bool insertPromotionByProductProductReward(
      int promotionid, int rewardid, int productid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var promotionByProductProductReward = new PromotionByProductProductReward();
                    promotionByProductProductReward.rewardid = rewardid;
                    promotionByProductProductReward.productid = productid;
                    promotionByProductProductReward.promotionid = promotionid;

                    promotionByProductProductReward.datemodified = DateTime.Now;
                    promotionByProductProductReward.dateentry = DateTime.Now;
                    db.Insert(promotionByProductProductReward);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        public static bool deletePromotionByProductProductReward(
              int promotionid, int rewardid, int productid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    // var   promotionByPointReward = PromotionByPointReward.SingleOrDefault("WHERE (promotionid=@0) and (rewardid=@1)", promotionid, rewardid);
                    // promotionByPointReward.Delete();
                    var sql = new Sql("Delete from PromotionByProductProductReward  ");
                    sql.Append("WHERE (promotionid=@0) and (rewardid=@1) and (productid=@2)", promotionid, rewardid, productid);
                    db.Execute(sql);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        #region Reseller

        private const string ALL_RESELLERS = @"SELECT     
resellerid, name, dateentry, datemodified
FROM         dbo.Reseller order by name";
        public static List<Reseller> getAllResellers()
        {
            List<Reseller> lst = new List<Reseller>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_RESELLERS))
                {
                    var reseller = new Reseller();
                    reseller.resellerid = a.resellerid;
                    reseller.name = a.name;
                    reseller.datemodified = a.datemodified;
                    reseller.dateentry = a.dateentry;

                    lst.Add(reseller);
                }
                return lst;
            }
        }

        public static int insertReseller(string name)
        {
            int resellerid = -1;
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var reseller = new Reseller();

                    reseller.name = name;

                    reseller.datemodified = DateTime.Now;
                    reseller.dateentry = DateTime.Now;
                    db.Insert(reseller);
                    success = true;
                    resellerid = reseller.resellerid;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return resellerid;
        }

        public static bool updateReseller(int resellerid, string name)
        {
            //http://stackoverflow.com/questions/6232304/inserting-to-petapoco-with-entity-relationships?rq=1
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var reseller = Reseller.SingleOrDefault("WHERE resellerid=@0", resellerid);

                    reseller.name = name;

                    reseller.datemodified = DateTime.Now;
                    reseller.Update();

                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deleteReseller(int resellerid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var reseller = Reseller.SingleOrDefault("WHERE resellerid=@0", resellerid);
                    reseller.Delete();
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static Reseller getReseller(int resellerid)
        {
            var reseller = new Reseller();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    reseller = Reseller.SingleOrDefault("WHERE resellerid=@0", resellerid);


                }
            }
            catch (Exception e)
            {
                //log this
            }
            return reseller;
        }

        #endregion

        #region stockreceive

        private const string ALL_STOCKRECEIVE_BYREWARDID = @"SELECT     
stockreceiveid, rewardid, 
rewardname, companyid, 
companyname, qty, 
balance, invoice, 
remarks, dateentry, datemodified
FROM         dbo.StockReceive
WHERE     (rewardid = @0)
order by stockreceiveid desc";
        public static List<StockReceive> getAllStockReceiveByRewardId(int rewardid)
        {
            List<StockReceive> lst = new List<StockReceive>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_STOCKRECEIVE_BYREWARDID, rewardid))
                {
                    var stockReceive = new StockReceive();

                    stockReceive.stockreceiveid = a.stockreceiveid;
                    stockReceive.rewardid = a.rewardid;
                    stockReceive.rewardname = a.rewardname;
                    stockReceive.companyid = a.companyid;
                    stockReceive.companyname = a.companyname;
                    stockReceive.qty = a.qty;
                    stockReceive.balance = a.balance;
                    stockReceive.invoice = a.invoice;
                    stockReceive.remarks = a.remarks;

                    stockReceive.datemodified = a.datemodified;
                    stockReceive.dateentry = a.dateentry;

                    lst.Add(stockReceive);
                }
                return lst;
            }
        }

        public static bool insertStockReceive(
            int rewardid, string rewardname,
            int companyid, string companyname,
            int qty, int balance,
            string invoice, string remarks)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var stockReceive = new StockReceive();
                    stockReceive.rewardid = rewardid;
                    stockReceive.rewardname = rewardname;
                    stockReceive.companyid = companyid;
                    stockReceive.companyname = companyname;
                    stockReceive.qty = qty;
                    stockReceive.balance = balance;
                    stockReceive.invoice = invoice;
                    stockReceive.remarks = remarks;
                    stockReceive.datemodified = DateTime.Now;
                    stockReceive.dateentry = DateTime.Now;
                    db.Insert(stockReceive);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        #endregion

        #region stockreceive

        private const string ALL_STOCKOUT_BYREWARDID = @"SELECT     
stockoutid, rewardid, 
rewardname, companyid, 
companyname, qty, 
balance, invoice, 
remarks, dateentry, datemodified
FROM         dbo.Stockout
WHERE     (rewardid = @0)
order by stockoutid desc";
        public static List<StockOut> getAllStockOutByRewardId(int rewardid)
        {
            List<StockOut> lst = new List<StockOut>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_STOCKOUT_BYREWARDID, rewardid))
                {
                    var stockReceive = new StockOut();

                    stockReceive.stockoutid = a.stockoutid;
                    stockReceive.rewardid = a.rewardid;
                    stockReceive.rewardname = a.rewardname;
                    stockReceive.companyid = a.companyid;
                    stockReceive.companyname = a.companyname;
                    stockReceive.qty = a.qty;
                    stockReceive.balance = a.balance;
                    stockReceive.invoice = a.invoice;
                    stockReceive.remarks = a.remarks;

                    stockReceive.datemodified = a.datemodified;
                    stockReceive.dateentry = a.dateentry;

                    lst.Add(stockReceive);
                }
                return lst;
            }
        }

        public static bool insertStockOut(
            int rewardid, string rewardname,
            int companyid, string companyname,
            int qty, int balance,
            string invoice, string remarks)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var stockReceive = new StockOut();
                    stockReceive.rewardid = rewardid;
                    stockReceive.rewardname = rewardname;
                    stockReceive.companyid = companyid;
                    stockReceive.companyname = companyname;
                    stockReceive.qty = qty;
                    stockReceive.balance = balance;
                    stockReceive.invoice = invoice;
                    stockReceive.remarks = remarks;
                    stockReceive.datemodified = DateTime.Now;
                    stockReceive.dateentry = DateTime.Now;
                    db.Insert(stockReceive);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        #endregion

        #region stock return

        private const string ALL_STOCKRETURN_BYREWARDID = @"SELECT     
stockreturnid, rewardid, 
rewardname, companyid, 
companyname, qty, 
balance, invoice, 
remarks, dateentry, datemodified
FROM         dbo.Stockreturn
WHERE     (rewardid = @0)
order by stockreturnid desc";
        public static List<StockReturn> getAllStockReturnByRewardId(int rewardid)
        {
            List<StockReturn> lst = new List<StockReturn>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_STOCKRETURN_BYREWARDID, rewardid))
                {
                    var stockReceive = new StockReturn();

                    stockReceive.stockreturnid = a.stockreturnid;
                    stockReceive.rewardid = a.rewardid;
                    stockReceive.rewardname = a.rewardname;
                    stockReceive.companyid = a.companyid;
                    stockReceive.companyname = a.companyname;
                    stockReceive.qty = a.qty;
                    stockReceive.balance = a.balance;
                    stockReceive.invoice = a.invoice;
                    stockReceive.remarks = a.remarks;

                    stockReceive.datemodified = a.datemodified;
                    stockReceive.dateentry = a.dateentry;

                    lst.Add(stockReceive);
                }
                return lst;
            }
        }

        public static bool insertStockReturn(
            int rewardid, string rewardname,
            int companyid, string companyname,
            int qty, int balance,
            string invoice, string remarks)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var stockReceive = new StockReturn();
                    stockReceive.rewardid = rewardid;
                    stockReceive.rewardname = rewardname;
                    stockReceive.companyid = companyid;
                    stockReceive.companyname = companyname;
                    stockReceive.qty = qty;
                    stockReceive.balance = balance;
                    stockReceive.invoice = invoice;
                    stockReceive.remarks = remarks;
                    stockReceive.datemodified = DateTime.Now;
                    stockReceive.dateentry = DateTime.Now;
                    db.Insert(stockReceive);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        #endregion
        #region PromotionByPointProduct

        public static PromotionByPointProduct getPromotionByPointProduct(int promotionid, int productid)
        {
            // bool success = false;
            var promotionByPointProduct = new PromotionByPointProduct();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    promotionByPointProduct = PromotionByPointProduct.SingleOrDefault("WHERE promotionid=@0 and productid=@1", promotionid, productid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return promotionByPointProduct;
        }

        public static bool insertPromotionByPointProduct(
        int promotionid, int productid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var promotionByPointProduct = new PromotionByPointProduct();
                    promotionByPointProduct.promotionid = promotionid;
                    promotionByPointProduct.productid = productid;

                    promotionByPointProduct.datemodified = DateTime.Now;
                    promotionByPointProduct.dateentry = DateTime.Now;
                    db.Insert(promotionByPointProduct);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deletePromotionByPointProduct(
             int promotionid, int productid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    // var   promotionByPointReward = PromotionByPointReward.SingleOrDefault("WHERE (promotionid=@0) and (rewardid=@1)", promotionid, rewardid);
                    // promotionByPointReward.Delete();
                    var sql = new Sql("Delete from PromotionByPointProduct  ");
                    sql.Append("WHERE (promotionid=@0) and (productid=@1)", promotionid, productid);
                    db.Execute(sql);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }
        #endregion
        #region PromotionByPointReward

        public static PromotionByPointReward getPromotionByPointReward(int promotionid, int rewardid)
        {
            // bool success = false;
            var promotionByPointReward = new PromotionByPointReward();
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    promotionByPointReward = PromotionByPointReward.SingleOrDefault("WHERE promotionid=@0 and rewardid=@1", promotionid, rewardid);
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return promotionByPointReward;
        }

        public static bool insertPromotionByPointReward(
         int promotionid, int rewardid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    var promotionByPointReward = new PromotionByPointReward();
                    promotionByPointReward.promotionid = promotionid;
                    promotionByPointReward.rewardid = rewardid;

                    promotionByPointReward.datemodified = DateTime.Now;
                    promotionByPointReward.dateentry = DateTime.Now;
                    db.Insert(promotionByPointReward);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        public static bool deletePromotionByPointReward(
              int promotionid, int rewardid)
        {
            bool success = false;
            try
            {
                using (var db = new ApplicationServices.ApplicationServicesDB())
                {
                    // var   promotionByPointReward = PromotionByPointReward.SingleOrDefault("WHERE (promotionid=@0) and (rewardid=@1)", promotionid, rewardid);
                    // promotionByPointReward.Delete();
                    var sql = new Sql("Delete from PromotionByPointReward  ");
                    sql.Append("WHERE (promotionid=@0) and (rewardid=@1)", promotionid, rewardid);
                    db.Execute(sql);
                    success = true;
                }
            }
            catch (Exception e)
            {
                //log this
            }
            return success;
        }

        #endregion





        private const string ALL_ADMINUSERS = @" SELECT     
dbo.aspnet_Users.UserId, dbo.aspnet_Users.UserName, 
dbo.aspnet_Users.LoweredUserName, dbo.aspnet_Membership.Email, 
dbo.aspnet_Membership.LoweredEmail, 
                      dbo.aspnet_Membership.CreateDate, dbo.aspnet_Roles.RoleName
FROM         dbo.aspnet_Users INNER JOIN
                      dbo.aspnet_Membership ON dbo.aspnet_Users.UserId = dbo.aspnet_Membership.UserId INNER JOIN
                      dbo.aspnet_UsersInRoles ON dbo.aspnet_Users.UserId = dbo.aspnet_UsersInRoles.UserId INNER JOIN
                      dbo.aspnet_Roles ON dbo.aspnet_UsersInRoles.RoleId = dbo.aspnet_Roles.RoleId
WHERE    (dbo.aspnet_Roles.RoleName = N'Admin') OR   (dbo.aspnet_Roles.RoleName = N'Staff')";
        public static List<ViewAdminUser> getAllAdminUsers()
        {
            List<ViewAdminUser> lst = new List<ViewAdminUser>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_ADMINUSERS))
                {
                    var viewAdminUser = new ViewAdminUser();

                    viewAdminUser.UserId = a.UserId;
                    viewAdminUser.UserName = a.UserName;
                    viewAdminUser.LoweredUserName = a.LoweredUserName;
                    viewAdminUser.Email = a.Email;
                    viewAdminUser.LoweredEmail = a.LoweredEmail;
                    viewAdminUser.CreateDate = a.CreateDate;
                    viewAdminUser.RoleName = a.RoleName;

                    lst.Add(viewAdminUser);
                }
                return lst;
            }
        }





        private const string ALL_AUDIT = @"SELECT top 1000 [id] ,[Date],[Message] FROM [auditlog] where level='info' order by id desc";


        public sealed class Audit
        {
            public int id { get; set; }
            public DateTime Date { get; set; }
            public string Message { get; set; }

           
        }
        public static List<Audit> getAllAudit()
        {
            List<Audit> lst = new List<Audit>();
            using (var db = new ApplicationServices.ApplicationServicesDB())
            {
                foreach (var a in db.Fetch<dynamic>(ALL_AUDIT))
                {
                    var audit = new Audit();
                    audit.id = a.id;
                    audit.Date = a.Date;
                    audit.Message = a.Message;

                    lst.Add(audit);
                }
                return lst;
            }
        }
    }
}