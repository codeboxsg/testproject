using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedemptionData
{
    public enum PromotionType
    {
        BY_POINT = 0,
        BY_PRODUCT = 1
    }
    public enum UserRole
    {
        MEMBER = 0,
        REDEMPTION_ADMIN = 1,
        REDEMPTION_SUPERADMIN = 2
    }
    public enum CollectionMode
    {
        PICK_UP = 0,
        DELIVERY = 1
    }
    public enum RedemptionRewardState
    {
        //   PENDING_PROCESS = 0,
        PENDING_DELIVERY = 1,
        PENDING_COLLECTION = 2,
        DELIVERED = 3,
        COLLECTED = 4,
        ARRANGING_DELIVERY = 5,
        VOID = 6
    }
    public enum RedemptionByProductReceiptState
    {
        PENDING_PROCESS = 0,
        PROCESSED = 1,
        DUPLICATE = 2,
        REJECTED = 3,
        VOID = 4
    }
    public enum RedemptionByPointTransactionType
    {
        REDEMPTION = 0,
        DEBIT = 1,
        VOID = 2
    }
    public enum RedemptionByPointReceiptState
    {
        PENDING_PROCESS = 0,
        PROCESSED = 1,
        DUPLICATE = 2,
        REJECTED = 3,
        VOID = 4
    }
    public static class Constants
    {
        public const string APPLICATIONSERVICES_DEFAULT_CONNECTION = "ApplicationServices";
    }
}
