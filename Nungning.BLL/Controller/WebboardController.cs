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
    public class WebboardController
    {
        public static List<TopicInfo> getTopic(string topic_id)
        {
            return CBO.FillCollection<TopicInfo>(DataProvider.Instance().GetTopic(topic_id));
        }

        public static TopicInfo addTopic(TopicInfo topic)
        {
            return CBO.FillObject<TopicInfo>(DataProvider.Instance().AddTopic(topic));
        }

        public static TopicInfo setToppic(TopicInfo topic)
        {
            return CBO.FillObject<TopicInfo>(DataProvider.Instance().SetTopic(topic)); ;
        }

        public static List<TopicInfo> SearchTopic(string title)
        {
            return CBO.FillCollection<TopicInfo>(DataProvider.Instance().SearchTopic(title));
        }

        //comment
        public static List<CommentInfo> getComment(string comment_id , string topic_id)
        {
            return CBO.FillCollection<CommentInfo>(DataProvider.Instance().GetComment(comment_id , topic_id));
        }

        public static CommentInfo addComment(CommentInfo comment)
        {
            return CBO.FillObject<CommentInfo>(DataProvider.Instance().AddComment(comment)); ;
        }

        public static CommentInfo setComment(CommentInfo comment)
        {
            return CBO.FillObject<CommentInfo>(DataProvider.Instance().SetComment(comment)); ; ;
        }

        public static TopicInfo DelTopic(string topic_id, bool is_del)
        {
            var result = getTopic(topic_id);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<TopicInfo>(DataProvider.Instance().SetTopic(result[0]));
            }
            else
                return null;
        }

        public static CommentInfo DelComment(string comment_id , bool is_del)
        {
            var result = getComment(comment_id,null);
            if (result.Count == 1)
            {
                result[0].is_del = is_del;
                return CBO.FillObject<CommentInfo>(DataProvider.Instance().SetComment(result[0]));
            }
            else
                return null;
        }
    }
}
