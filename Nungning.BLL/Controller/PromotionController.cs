using Nungning.BLL.Info;
using Nungning.BLL.Provider;
using NungningUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nungning.BLL.Controller
{
    public class PromotionController
    {
        public static List<PromotionInfo> GetPromotion(string promotion_id)
        {
            return CBO.FillCollection<PromotionInfo>(DataProvider.Instance().GetPromotion(promotion_id));
        }
        public static List<PromotionInfo> SearchPromotion(string promotion_id,string title)
        {
            return CBO.FillCollection<PromotionInfo>(DataProvider.Instance().SearchPromotion(promotion_id,title));
        }
        public static List<PromotionInfo> AddPromotion(PromotionInfo promotion)
        {
            return CBO.FillCollection<PromotionInfo>(DataProvider.Instance().AddPromotion(promotion));
        }
        public static PromotionInfo SetPromotion(PromotionInfo promotion)
        {
            return CBO.FillObject<PromotionInfo>(DataProvider.Instance().SetPromotion(promotion));
        }
        public static PromotionInfo DelPromotion(string promotion_id, bool is_del)
        {
            var result = GetPromotion(promotion_id);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<PromotionInfo>(DataProvider.Instance().SetPromotion(result[0]));
            }
            else
                return null;
        }
    }
}
